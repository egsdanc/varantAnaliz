using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Office.Interop.Excel;
using System.Globalization;
using System.Data.SQLite;

using System.Reflection;
using System.Net.Http;

 
using Microsoft.Office.Core;
using OfficeOpenXml;
using OfficeOpenXml.Style;


using Excel = Microsoft.Office.Interop.Excel;

using Timer = System.Timers.Timer;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClientApiAppDemo
{








    /// <summary>
    /// Interaction logic for filtrele.xaml
    /// </summary>
    public partial class filtrele : System.Windows.Window
    {

        public void combovericek(string semboltur, ComboBox combo)
        {
            SQLiteConnection con = new SQLiteConnection("Data source =.\\emirler.db");
            con.Open();
            string stm = "SELECT * FROM sembol where sembol_tur=@semboltur";
            SQLiteCommand cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@semboltur", semboltur);
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                combo.Items.Add(dr["sembol_dayanak"]);
            }

            dr.Close();
            con.Close();


        }
        public filtrele()
        {
            InitializeComponent();
            internationalcombobox.Items.Add("Yok");
            internationalcombobox_Copy1.Items.Add("Yok");
            internationalcombobox_Copy2.Items.Add("Yok");
            internationalcombobox_Copy.Items.Add("Yok");
            bisscombobox.Items.Add("Yok");
            bisscombobox_Copy.Items.Add("Yok");
            bisscombobox_Copy1.Items.Add("Yok");
            bisscombobox_Copy2.Items.Add("Yok");
            combovericek("INTERNATIONAL", internationalcombobox);
            combovericek("BIST", bisscombobox);
            combovericek("INTERNATIONAL", internationalcombobox_Copy);
            combovericek("BIST", bisscombobox_Copy);
            combovericek("INTERNATIONAL", internationalcombobox_Copy1);
            combovericek("BIST", bisscombobox_Copy1);
            combovericek("INTERNATIONAL", internationalcombobox_Copy2);
            combovericek("BIST", bisscombobox_Copy2);

        }
        static string GetHtmlPagePhantom(string strURL)
        {
            string s = "";
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            IWebDriver driver = new ChromeDriver(options);
            driver.Url = strURL;
            //s = driver.FindElement(By.TagName("table")).GetAttribute("innerHtml");
            //s = driver.FindElement(By.XPath("//div[@class='meta']//p[2]")).Text;
            String p = driver.PageSource;


            //Console.WriteLine("Page Source is : " + p);

            driver.Quit();

            return p;


        }
        private async void Button_Click(object sender, RoutedEventArgs e)        /// filtreleme işlemini girilen call put değerlerine göre yapar 
        {                                                                       ///  toplu olarak yapar üssteki iki txt boxı doldruman yeterli  , üzerine bazı sembolleri de özel olarak      
            string filepath = "c:\\emir\\ilkliste.xlsx";                         //// filtrelemesini istersen comboboxdan seçtiğin sembolleri özel olarak filtrele 
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb;
            Worksheet ws;
            wb = excel.Workbooks.Open(filepath);
            ws = wb.Worksheets[1];
            //    if (null == ws.Cells[1, 1].Value) {


            int isimler = 2;
            int uzunluk = 0;
            while (true)
            {
                if (ws.Cells[isimler, 1].Value == null)
                {
                    break;
                }
                isimler++;
                uzunluk++;
            }


            string[] emirisimler = new string[3000];

            string[] kalanemirisimler = new string[uzunluk];
            for (int i = 0; i < uzunluk; i++)

            {
                emirisimler[i] = ws.Cells[i + 2, 1].Value.ToString();

            }
            int ab = 0;
            for (int i = 0; i < uzunluk; i++)
            {
                if (emirisimler[i] != emirisimler[i + 1] && emirisimler[i] != null)
                {
                    kalanemirisimler[ab] = emirisimler[i];
                    ab++;
                }
            }


            string[] filtreliemirler = new string[ab];
            Array.Copy(kalanemirisimler, filtreliemirler, ab);
            for (int i = 0; i < ab; i++)
            {
                string vsiz = kalanemirisimler[i].Substring(0, kalanemirisimler[i].Length - 1);
                Console.WriteLine(vsiz);
                string mesaj = GetHtmlPagePhantom("https://www.isvarant.com/piyasa-analiz/varant-hedef-fiyat?v=" + vsiz + ".V");
                //Thread.Sleep(2000);

                WebClient webClient = new System.Net.WebClient();


                //MessageBox.Show("yeni"+new_page.Count().ToString()+" eski "+ page.Count().ToString());
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(mesaj);



                List<List<string>> table = doc.DocumentNode.SelectSingleNode("//table")
                            .Descendants("tr")
                            .Skip(1)
                            .Where(tr => tr.Elements("td").Count() > 1)
                            .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                            .ToList();
                //    Console.WriteLine("tabeleeeee "+ table[0][1]);
                //    Console.WriteLine("tabeleeeee " + table[1][1]);
                int international = Convert.ToInt32(internationaltxt.Text);
                int bist = Convert.ToInt32(bisttxt.Text);
                Console.WriteLine("international " + international);
                Console.WriteLine("bist " + bist);
                string calputkontrol;
                int kontrolA = 0;

                var values = new Dictionary<string, string> { { "test", "test" } };
                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync("https://www.isvarant.com/WarrantAnalysis/Data/" + vsiz, content);
                var responseString = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(responseString);
                var fdate = json["TargetPointData"][0]["IsActive"];
                string degermavi = "0";
                int ps = 0;
                for (int a = 0; a < json["TargetPointData"].Count(); a++)

                {
                    //   txtbiss.Text += json["TargetPointData"][i]["DayanakVarlikFiyati"].ToString() + "\n";

                    if ((Boolean)json["TargetPointData"][a]["IsActive"])
                    {

                        degermavi = json["TargetPointData"][a]["DayanakVarlikFiyati"].ToString();
                        txtbisscopy.Text += degermavi;
                        txtbisscopy.Text += "   ";

                        break;
                    }
                    ps++;
                }
                txtbiss.Text += table[ps][0];
                txtbiss.Text += " ";

                //for döngüsünü aç gelen değerleri kontrol et
                for (int abc = 0; abc < table.Count - 1; abc++)
                {
                    if (table[abc][1] == table[ps][1])
                    {
                        if (table[abc][1] == table[ps][1])
                        {


                            kontrolA++;
                            Console.WriteLine("kontrolA " + kontrolA);
                            Console.WriteLine("kontrol1");

                        }
                        else
                        {

                            string gelen;
                            SQLiteConnection con = new SQLiteConnection("Data source =.\\emirler.db");
                            con.Open();
                            string stm = "SELECT * FROM sembol where sembol_isim=@sembolad";
                            SQLiteCommand cmd = new SQLiteCommand(stm, con);
                            cmd.Parameters.AddWithValue("@sembolad", kalanemirisimler[i].ToString().Substring(0, 2));
                            SQLiteDataReader dr = cmd.ExecuteReader();
                            if (dr.Read())
                            {
                                gelen = dr["sembol_tur"].ToString();
                            }
                            else
                            {
                                gelen = "yanls";
                            }
                            dr.Close();
                            con.Close();

                            Console.WriteLine("ddddd " + kontrolA);
                            if (gelen == "INTERNATIONAL" && international > kontrolA)
                            {

                                int x = Array.IndexOf(filtreliemirler, kalanemirisimler[i]);
                                for (int y = 0; y < filtreliemirler.Length; y++)
                                    filtreliemirler = filtreliemirler.Where((source, index) => index != x).ToArray();
                                Console.WriteLine("kontrol1");

                            }

                            if (gelen == "BIST" && bist > kontrolA)
                            {

                                int x = Array.IndexOf(filtreliemirler, kalanemirisimler[i]);
                                filtreliemirler = filtreliemirler.Where((source, index) => index != x).ToArray();
                                //                          for (int y = 0; y < filtreliemirler.Length; y++)
                                //                               Console.WriteLine("ddddd " + filtreliemirler[y]);
                                Console.WriteLine("kontrol2");
                            }
                            kontrolA = 0;
                        }

                    }
                }
            }
            for (int j = 0; j < 2; j++)
            {
                Console.WriteLine(filtreliemirler[j]);
            }
            int q = 0;
            int kontrolB = 0;
            string[] filtreliemirlerfiltrele = new string[filtreliemirler.Length];
            Array.Copy(filtreliemirler, filtreliemirlerfiltrele, filtreliemirler.Length);


            for (q = 0; q < filtreliemirler.Length; q++)        //kontolbbbbbbbbb
            {
                string gelen;
                SQLiteConnection con = new SQLiteConnection("Data source =.\\emirler.db");
                con.Open();
                string stm = "SELECT * FROM sembol where sembol_isim=@sembolad";
                SQLiteCommand cmd = new SQLiteCommand(stm, con);
                cmd.Parameters.AddWithValue("@sembolad", filtreliemirler[q].ToString().Substring(0, 2));
                Console.WriteLine("iiiiiiiiiiiiiiii " + q);
                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    gelen = dr["sembol_dayanak"].ToString();
                }
                else
                {
                    gelen = "yanls";
                }
                dr.Close();
                con.Close();
                Console.WriteLine("gelengelengelengelengelengelengelengelen" + gelen);

                if (internationalcombobox.Text == gelen)
                {
                    string vsiz = filtreliemirler[q].Substring(0, filtreliemirler[q].Length - 1);
                    Console.WriteLine(vsiz);
                    string mesaj = GetHtmlPagePhantom("https://www.isvarant.com/piyasa-analiz/varant-hedef-fiyat?v=" + vsiz + ".V");
                    //Thread.Sleep(2000);

                    WebClient webClient = new System.Net.WebClient();


                    //MessageBox.Show("yeni"+new_page.Count().ToString()+" eski "+ page.Count().ToString());
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(mesaj);



                    List<List<string>> table = doc.DocumentNode.SelectSingleNode("//table")
                                .Descendants("tr")
                                .Skip(1)
                                .Where(tr => tr.Elements("td").Count() > 1)
                                .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                                .ToList();

                    var values = new Dictionary<string, string> { { "test", "test" } };
                    var content = new FormUrlEncodedContent(values);
                    var response = await client.PostAsync("https://www.isvarant.com/WarrantAnalysis/Data/" + vsiz, content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(responseString);
                    var fdate = json["TargetPointData"][0]["IsActive"];
                    string degermavi = "0";
                    int ps = 0;
                    for (int a = 0; a < json["TargetPointData"].Count(); a++)

                    {
                        //   txtbiss.Text += json["TargetPointData"][i]["DayanakVarlikFiyati"].ToString() + "\n";

                        if ((Boolean)json["TargetPointData"][a]["IsActive"])
                        {

                            degermavi = json["TargetPointData"][a]["DayanakVarlikFiyati"].ToString();
                            txtbisscopy.Text += degermavi;
                            txtbisscopy.Text += "   ";

                            break;
                        }
                        ps++;
                    }
                    for (int abc = 0; abc < table.Count - 1; abc++)
                    {
                        if (table[abc][1] == table[ps][1])
                        {
                            if (table[abc][1] == table[ps][1])
                            {
                                kontrolB++;
                            }
                            else
                            {
                                if (Convert.ToInt32(txtinternational.Text) > kontrolB)
                                {
                                    int x = Array.IndexOf(filtreliemirlerfiltrele, filtreliemirler[q]);
                                    filtreliemirlerfiltrele = filtreliemirlerfiltrele.Where((source, index) => index != x).ToArray();
                                }
                                kontrolB = 1;
                            }
                        }
                    }
                }
                else if (internationalcombobox_Copy.Text == gelen)
                {
                    string vsiz = filtreliemirler[q].Substring(0, filtreliemirler[q].Length - 1);
                    Console.WriteLine(vsiz);
                    string mesaj = GetHtmlPagePhantom("https://www.isvarant.com/piyasa-analiz/varant-hedef-fiyat?v=" + vsiz + ".V");
                    //Thread.Sleep(2000);

                    WebClient webClient = new System.Net.WebClient();


                    //MessageBox.Show("yeni"+new_page.Count().ToString()+" eski "+ page.Count().ToString());
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(mesaj);



                    List<List<string>> table = doc.DocumentNode.SelectSingleNode("//table")
                                .Descendants("tr")
                                .Skip(1)
                                .Where(tr => tr.Elements("td").Count() > 1)
                                .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                                .ToList();



                    var values = new Dictionary<string, string> { { "test", "test" } };
                    var content = new FormUrlEncodedContent(values);
                    var response = await client.PostAsync("https://www.isvarant.com/WarrantAnalysis/Data/" + vsiz, content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(responseString);
                    var fdate = json["TargetPointData"][0]["IsActive"];
                    string degermavi = "0";
                    int ps = 0;
                    for (int a = 0; a < json["TargetPointData"].Count(); a++)

                    {
                        //   txtbiss.Text += json["TargetPointData"][i]["DayanakVarlikFiyati"].ToString() + "\n";

                        if ((Boolean)json["TargetPointData"][a]["IsActive"])
                        {

                            degermavi = json["TargetPointData"][a]["DayanakVarlikFiyati"].ToString();
                            txtbisscopy.Text += degermavi;
                            txtbisscopy.Text += "   ";

                            break;
                        }
                        ps++;
                    }
                    for (int abc = 0; abc < table.Count - 1; abc++)
                    {
                        if (table[abc][1] == table[ps][1])
                        {
                            if (table[abc][1] == table[ps][1])
                            {
                                kontrolB++;
                            }
                            else
                            {
                                if (Convert.ToInt32(txtinternationalcopy.Text) > kontrolB)
                                {
                                    int x = Array.IndexOf(filtreliemirlerfiltrele, filtreliemirler[q]);
                                    filtreliemirlerfiltrele = filtreliemirlerfiltrele.Where((source, index) => index != x).ToArray();
                                }
                                kontrolB = 1;
                            }
                        }
                    }
                }
                else if (internationalcombobox_Copy1.Text == gelen)
                {
                    string vsiz = filtreliemirler[q].Substring(0, filtreliemirler[q].Length - 1);
                    Console.WriteLine(vsiz);
                    string mesaj = GetHtmlPagePhantom("https://www.isvarant.com/piyasa-analiz/varant-hedef-fiyat?v=" + vsiz + ".V");
                    //Thread.Sleep(2000);

                    WebClient webClient = new System.Net.WebClient();


                    //MessageBox.Show("yeni"+new_page.Count().ToString()+" eski "+ page.Count().ToString());
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(mesaj);



                    List<List<string>> table = doc.DocumentNode.SelectSingleNode("//table")
                                .Descendants("tr")
                                .Skip(1)
                                .Where(tr => tr.Elements("td").Count() > 1)
                                .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                                .ToList();

                    var values = new Dictionary<string, string> { { "test", "test" } };
                    var content = new FormUrlEncodedContent(values);
                    var response = await client.PostAsync("https://www.isvarant.com/WarrantAnalysis/Data/" + vsiz, content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(responseString);
                    var fdate = json["TargetPointData"][0]["IsActive"];
                    string degermavi = "0";
                    int ps = 0;
                    for (int a = 0; a < json["TargetPointData"].Count(); a++)

                    {
                        //   txtbiss.Text += json["TargetPointData"][i]["DayanakVarlikFiyati"].ToString() + "\n";

                        if ((Boolean)json["TargetPointData"][a]["IsActive"])
                        {

                            degermavi = json["TargetPointData"][a]["DayanakVarlikFiyati"].ToString();
                            txtbisscopy.Text += degermavi;
                            txtbisscopy.Text += "   ";

                            break;
                        }
                        ps++;
                    }
                    for (int abc = 0; abc < table.Count - 1; abc++)
                    {
                        if (table[abc][1] == table[ps][1])
                        {
                            if (table[abc][1] == table[ps][1])
                            {
                                kontrolB++;
                            }
                            else
                            {
                                if (Convert.ToInt32(txtinternationalcopy1.Text) > kontrolB)
                                {
                                    int x = Array.IndexOf(filtreliemirlerfiltrele, filtreliemirler[q]);
                                    filtreliemirlerfiltrele = filtreliemirlerfiltrele.Where((source, index) => index != x).ToArray();
                                }
                                kontrolB = 1;
                            }
                        }
                    }
                }
                else if (internationalcombobox_Copy2.Text == gelen)
                {
                    string vsiz = filtreliemirler[q].Substring(0, filtreliemirler[q].Length - 1);
                    Console.WriteLine(vsiz);
                    string mesaj = GetHtmlPagePhantom("https://www.isvarant.com/piyasa-analiz/varant-hedef-fiyat?v=" + vsiz + ".V");
                    //Thread.Sleep(2000);

                    WebClient webClient = new System.Net.WebClient();


                    //MessageBox.Show("yeni"+new_page.Count().ToString()+" eski "+ page.Count().ToString());
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(mesaj);



                    List<List<string>> table = doc.DocumentNode.SelectSingleNode("//table")
                                .Descendants("tr")
                                .Skip(1)
                                .Where(tr => tr.Elements("td").Count() > 1)
                                .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                                .ToList();

                    var values = new Dictionary<string, string> { { "test", "test" } };
                    var content = new FormUrlEncodedContent(values);
                    var response = await client.PostAsync("https://www.isvarant.com/WarrantAnalysis/Data/" + vsiz, content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(responseString);
                    var fdate = json["TargetPointData"][0]["IsActive"];
                    string degermavi = "0";
                    int ps = 0;
                    for (int a = 0; a < json["TargetPointData"].Count(); a++)

                    {
                        //   txtbiss.Text += json["TargetPointData"][i]["DayanakVarlikFiyati"].ToString() + "\n";

                        if ((Boolean)json["TargetPointData"][a]["IsActive"])
                        {

                            degermavi = json["TargetPointData"][a]["DayanakVarlikFiyati"].ToString();
                            txtbisscopy.Text += degermavi;
                            txtbisscopy.Text += "   ";

                            break;
                        }
                        ps++;
                    }
                    for (int abc = 0; abc < table.Count - 1; abc++)
                    {
                        if (table[abc][1] == table[ps][1])
                        {
                            if (table[abc][1] == table[ps][1])
                            {
                                kontrolB++;
                            }
                            else
                            {
                                if (Convert.ToInt32(txtinternationalcopy2.Text) > kontrolB)
                                {
                                    int x = Array.IndexOf(filtreliemirlerfiltrele, filtreliemirler[q]);
                                    filtreliemirlerfiltrele = filtreliemirlerfiltrele.Where((source, index) => index != x).ToArray();
                                }
                                kontrolB = 1;
                            }
                        }
                    }
                }
                else if (bisscombobox.Text == gelen)
                {
                    Console.WriteLine("bisssssssssssssssssssssssssssssssssssssssssssssssssss" + bisscombobox.Text);
                    string vsiz = filtreliemirler[q].Substring(0, filtreliemirler[q].Length - 1);
                    Console.WriteLine(vsiz);
                    string mesaj = GetHtmlPagePhantom("https://www.isvarant.com/piyasa-analiz/varant-hedef-fiyat?v=" + vsiz + ".V");
                    //Thread.Sleep(2000);

                    WebClient webClient = new System.Net.WebClient();


                    //MessageBox.Show("yeni"+new_page.Count().ToString()+" eski "+ page.Count().ToString());
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(mesaj);



                    List<List<string>> table = doc.DocumentNode.SelectSingleNode("//table")
                                .Descendants("tr")
                                .Skip(1)
                                .Where(tr => tr.Elements("td").Count() > 1)
                                .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                                .ToList();

                    var values = new Dictionary<string, string> { { "test", "test" } };
                    var content = new FormUrlEncodedContent(values);
                    var response = await client.PostAsync("https://www.isvarant.com/WarrantAnalysis/Data/" + vsiz, content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(responseString);
                    var fdate = json["TargetPointData"][0]["IsActive"];
                    string degermavi = "0";
                    int ps = 0;
                    for (int a = 0; a < json["TargetPointData"].Count(); a++)

                    {
                        //   txtbiss.Text += json["TargetPointData"][i]["DayanakVarlikFiyati"].ToString() + "\n";

                        if ((Boolean)json["TargetPointData"][a]["IsActive"])
                        {

                            degermavi = json["TargetPointData"][a]["DayanakVarlikFiyati"].ToString();
                            txtbisscopy.Text += degermavi;
                            txtbisscopy.Text += "   ";

                            break;
                        }
                        ps++;
                    }
                    for (int abc = 0; abc < table.Count - 1; abc++)
                    {
                        if (table[abc][1] == table[ps][1])
                        {
                            if (table[abc][1] == table[ps][1])
                            {
                                kontrolB++;
                            }
                            else
                            {
                                if (Convert.ToInt32(txtbiss.Text) > kontrolB)
                                {
                                    int x = Array.IndexOf(filtreliemirlerfiltrele, filtreliemirler[q]);
                                    filtreliemirlerfiltrele = filtreliemirlerfiltrele.Where((source, index) => index != x).ToArray();
                                }
                                kontrolB = 1;
                            }
                        }
                    }
                }
                else if (bisscombobox_Copy.Text == gelen)
                {
                    Console.WriteLine("bisssssssssssssssssssssssssssssssssssssssssssssssssssCCCC" + bisscombobox.Text);
                    string vsiz = filtreliemirler[q].Substring(0, filtreliemirler[q].Length - 1);
                    Console.WriteLine(vsiz);
                    string mesaj = GetHtmlPagePhantom("https://www.isvarant.com/piyasa-analiz/varant-hedef-fiyat?v=" + vsiz + ".V");
                    //Thread.Sleep(2000);

                    WebClient webClient = new System.Net.WebClient();


                    //MessageBox.Show("yeni"+new_page.Count().ToString()+" eski "+ page.Count().ToString());
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(mesaj);



                    List<List<string>> table = doc.DocumentNode.SelectSingleNode("//table")
                                .Descendants("tr")
                                .Skip(1)
                                .Where(tr => tr.Elements("td").Count() > 1)
                                .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                                .ToList();

                    var values = new Dictionary<string, string> { { "test", "test" } };
                    var content = new FormUrlEncodedContent(values);
                    var response = await client.PostAsync("https://www.isvarant.com/WarrantAnalysis/Data/" + vsiz, content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(responseString);
                    var fdate = json["TargetPointData"][0]["IsActive"];
                    string degermavi = "0";
                    int ps = 0;
                    for (int a = 0; a < json["TargetPointData"].Count(); a++)

                    {
                        //   txtbiss.Text += json["TargetPointData"][i]["DayanakVarlikFiyati"].ToString() + "\n";

                        if ((Boolean)json["TargetPointData"][a]["IsActive"])
                        {

                            degermavi = json["TargetPointData"][a]["DayanakVarlikFiyati"].ToString();
                            txtbisscopy.Text += degermavi;
                            txtbisscopy.Text += "   ";

                            break;
                        }
                        ps++;
                    }
                    for (int abc = 0; abc < table.Count - 1; abc++)
                    {
                        if (table[abc][1] == table[ps][1])
                        {
                            if (table[abc][1] == table[ps][1])
                            {
                                kontrolB++;
                            }
                            else
                            {
                                if (Convert.ToInt32(txtbisscopy.Text) > kontrolB)
                                {
                                    int x = Array.IndexOf(filtreliemirlerfiltrele, filtreliemirler[q]);
                                    filtreliemirlerfiltrele = filtreliemirlerfiltrele.Where((source, index) => index != x).ToArray();
                                }
                                kontrolB = 1;
                            }
                        }
                    }
                }
                else if (bisscombobox_Copy1.Text == gelen)
                {
                    string vsiz = filtreliemirler[q].Substring(0, filtreliemirler[q].Length - 1);
                    Console.WriteLine(vsiz);
                    string mesaj = GetHtmlPagePhantom("https://www.isvarant.com/piyasa-analiz/varant-hedef-fiyat?v=" + vsiz + ".V");
                    //Thread.Sleep(2000);

                    WebClient webClient = new System.Net.WebClient();


                    //MessageBox.Show("yeni"+new_page.Count().ToString()+" eski "+ page.Count().ToString());
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(mesaj);



                    List<List<string>> table = doc.DocumentNode.SelectSingleNode("//table")
                                .Descendants("tr")
                                .Skip(1)
                                .Where(tr => tr.Elements("td").Count() > 1)
                                .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                                .ToList();

                    var values = new Dictionary<string, string> { { "test", "test" } };
                    var content = new FormUrlEncodedContent(values);
                    var response = await client.PostAsync("https://www.isvarant.com/WarrantAnalysis/Data/" + vsiz, content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(responseString);
                    var fdate = json["TargetPointData"][0]["IsActive"];
                    string degermavi = "0";
                    int ps = 0;
                    for (int a = 0; a < json["TargetPointData"].Count(); a++)

                    {
                        //   txtbiss.Text += json["TargetPointData"][i]["DayanakVarlikFiyati"].ToString() + "\n";

                        if ((Boolean)json["TargetPointData"][a]["IsActive"])
                        {

                            degermavi = json["TargetPointData"][a]["DayanakVarlikFiyati"].ToString();
                            txtbisscopy.Text += degermavi;
                            txtbisscopy.Text += "   ";

                            break;
                        }
                        ps++;
                    }
                    for (int abc = 0; abc < table.Count - 1; abc++)
                    {
                        if (table[abc][1] == table[ps][1])
                        {
                            if (table[abc][1] == table[ps][1])
                            {
                                kontrolB++;
                            }
                            else
                            {
                                if (Convert.ToInt32(txtbisscopy1.Text) > kontrolB)
                                {
                                    int x = Array.IndexOf(filtreliemirlerfiltrele, filtreliemirler[q]);
                                    filtreliemirlerfiltrele = filtreliemirlerfiltrele.Where((source, index) => index != x).ToArray();
                                }
                                kontrolB = 1;
                            }
                        }
                    }
                }
                else if (bisscombobox_Copy2.Text == gelen)
                {
                    string vsiz = filtreliemirler[q].Substring(0, filtreliemirler[q].Length - 1);
                    Console.WriteLine(vsiz);
                    string mesaj = GetHtmlPagePhantom("https://www.isvarant.com/piyasa-analiz/varant-hedef-fiyat?v=" + vsiz + ".V");
                    //Thread.Sleep(2000);

                    WebClient webClient = new System.Net.WebClient();


                    //MessageBox.Show("yeni"+new_page.Count().ToString()+" eski "+ page.Count().ToString());
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(mesaj);



                    List<List<string>> table = doc.DocumentNode.SelectSingleNode("//table")
                                .Descendants("tr")
                                .Skip(1)
                                .Where(tr => tr.Elements("td").Count() > 1)
                                .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                                .ToList();

                    var values = new Dictionary<string, string> { { "test", "test" } };
                    var content = new FormUrlEncodedContent(values);
                    var response = await client.PostAsync("https://www.isvarant.com/WarrantAnalysis/Data/" + vsiz, content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(responseString);
                    var fdate = json["TargetPointData"][0]["IsActive"];
                    string degermavi = "0";
                    int ps = 0;
                    for (int a = 0; a < json["TargetPointData"].Count(); a++)

                    {
                        //   txtbiss.Text += json["TargetPointData"][i]["DayanakVarlikFiyati"].ToString() + "\n";

                        if ((Boolean)json["TargetPointData"][a]["IsActive"])
                        {

                            degermavi = json["TargetPointData"][a]["DayanakVarlikFiyati"].ToString();
                            txtbisscopy.Text += degermavi;
                            txtbisscopy.Text += "   ";

                            break;
                        }
                        ps++;
                    }
                    for (int abc = 0; abc < table.Count - 1; abc++)
                    {
                        if (table[abc][1] == table[ps][1])
                        {
                            if (table[abc][1] == table[ps][1])
                            {
                                kontrolB++;
                            }
                            else
                            {
                                if (Convert.ToInt32(txtbisscopy2.Text) > kontrolB)
                                {
                                    int x = Array.IndexOf(filtreliemirlerfiltrele, filtreliemirler[q]);
                                    filtreliemirlerfiltrele = filtreliemirlerfiltrele.Where((source, index) => index != x).ToArray();
                                }
                                kontrolB = 1;
                            }
                        }
                    }
                }
            }




            try
            {
                Excel.Application oXL;
                Excel._Workbook oWB;
                Excel._Worksheet oSheet;
                Excel.Range oRng;
                int kontol = 2;
                oXL = new Excel.Application();
                oXL.Visible = true;

                //Get a new workbook.
                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));

                Excel.Sheets worksheets = oWB.Worksheets;
                Excel.Worksheet[] xlNewSheett = new Excel.Worksheet[1];
                var emirler = (Excel.Worksheet)worksheets.Add(worksheets[1], Type.Missing, Type.Missing, Type.Missing);
                emirler.Name = "filtreliemirler";
                emirler.Cells[1, 1] = "SembolAdi";
                emirler.Cells[1, 2] = "Fiyat";
                emirler.Cells[1, 3] = "Adet";
                for (int c = 0; c < filtreliemirlerfiltrele.Length; c++)
                {
                    for (int u = 2; u < uzunluk + 2; u++)
                    {
                        Console.WriteLine("ws " + ws.Cells[u, 1].Value.ToString());
                        Console.WriteLine("ws " + filtreliemirlerfiltrele[c]);
                        if (ws.Cells[u, 1].Value.ToString() == filtreliemirlerfiltrele[c])
                        {
                            emirler.Cells[kontol, 1] = ws.Cells[u, 1].Value.ToString();
                            emirler.Cells[kontol, 2] = ws.Cells[u, 2].Value.ToString();
                            emirler.Cells[kontol, 3] = ws.Cells[u, 3].Value.ToString();
                            kontol++;
                        }
                    }

                }


                emirler = (Excel.Worksheet)oWB.Worksheets.get_Item(1);
                emirler.Select();

                oXL.Visible = true;
                oXL.UserControl = true;
            }

            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }







            wb.Close();
        }

        private HttpClient client = new HttpClient();

        private async void Button_Click_1(object sender, RoutedEventArgs e) //httprequests
        {

            var values = new Dictionary<string, string> { { "test", "test" } };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://www.isvarant.com/WarrantAnalysis/Data/EGIAW", content);
            var responseString = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(responseString);
            var fdate = json["TargetPointData"][0]["IsActive"];

            for (int i = 0; i < json["TargetPointData"].Count(); i++)

            {
                //   txtbiss.Text += json["TargetPointData"][i]["DayanakVarlikFiyati"].ToString() + "\n";

                if ((Boolean)json["TargetPointData"][i]["IsActive"])
                {

                    //    txtbiss.Text = json["TargetPointData"][i]["DayanakVarlikFiyati"].ToString();


                    break;
                }

            }

        }

        private async void Button_Click_2(object sender, RoutedEventArgs e) // işvarantdan getir
        {                                                                                          
            string filepath = "c:\\emir\\ilkliste.xlsx";
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb;
            Worksheet ws;
            wb = excel.Workbooks.Open(filepath);
            ws = wb.Worksheets[1];

            int excl = 2;
            int dayanakvarant = 1;
            int isimler = 2;
            int uzunluk = 0;
            while (true)
            {
                if (ws.Cells[isimler, 1].Value == null)
                {
                    break;
                }
                isimler++;
                uzunluk++;
            }
         




            string[] kalanemirisimler = new string[uzunluk];
            string[] tur = new string[uzunluk];
            string[] dayanak = new string[uzunluk];
            for (int i = 0; i < uzunluk; i++)

            {
                kalanemirisimler[i] = ws.Cells[i + 2, 2].Value.ToString();
                tur[i] = ws.Cells[i + 2, 3].Value.ToString();
                dayanak[i] = ws.Cells[i + 2, 1].Value.ToString();

            }
            wb.Close();
            try
            {
                /*         Excel.Application oXL;
                        Excel._Workbook oWB;
                        Excel._Worksheet oSheet;
                        Excel.Range oRng;
                        int kontol = 2;
                        oXL = new Excel.Application();
                      //  oXL.Visible = true;

                        //Get a new workbook.
                        oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));

                       Excel.Sheets worksheets = oWB.Worksheets;
                        Excel.Worksheet[] xlNewSheett = new Excel.Worksheet[1];
                        var emirler = (Excel.Worksheet)worksheets.Add(worksheets[1], Type.Missing, Type.Missing, Type.Missing);
                        emirler.Name = "filtreliemirler";
                */
                 
                string path = "c:\\emir\\isvaranthedef.xlsx";
                FileInfo fileInfo = new FileInfo(path);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage package = new ExcelPackage(fileInfo);
                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                for (int i = 0; i < uzunluk; i++)
                {
                    string vsiz = kalanemirisimler[i].Substring(0, kalanemirisimler[i].Length - 1);
                    string mesaj = GetHtmlPagePhantom("https://www.isvarant.com/piyasa-analiz/varant-hedef-fiyat?v=" + vsiz + ".V");

                    WebClient webClient = new System.Net.WebClient();

                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(mesaj);

                    List<List<string>> table = doc.DocumentNode.SelectSingleNode("//table")
                                .Descendants("tr")
                                .Skip(1)
                                .Where(tr => tr.Elements("td").Count() > 1)
                                .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                                .ToList();
                    var values = new Dictionary<string, string> { { "test", "test" } };
                    var content = new FormUrlEncodedContent(values);
                    var response = await client.PostAsync("https://www.isvarant.com/WarrantAnalysis/Data/" + vsiz, content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(responseString);
                    var fdate = json["TargetPointData"][0]["IsActive"];
                    string degermavi = "0";
                    int ps = 0;
                    for (int a = 0; a < json["TargetPointData"].Count(); a++)

                    {
                        //   txtbiss.Text += json["TargetPointData"][i]["DayanakVarlikFiyati"].ToString() + "\n";

                        if ((Boolean)json["TargetPointData"][a]["IsActive"])
                        {

                            degermavi = json["TargetPointData"][a]["DayanakVarlikFiyati"].ToString();
                       //     txtbisscopy.Text += degermavi;
                       //     txtbisscopy.Text += "   ";

                            break;
                        }
                        ps++;
                    }
                    int adet=1;
                    int bir = 0;
                    for (int j = 0; j < 21; j++)

                    {
                        if (j < 20 && tur[i] == "CALL")
                        {
                            if (table[j][1] == table[j + 1][1])
                            {
                                adet++;
                            }
                            else
                            {
                                
                                worksheet.Cells[dayanakvarant + 5 + bir, 7].Value = table[j][1];
                                worksheet.Cells[dayanakvarant + 5 + bir, 6].Value = adet;
                                worksheet.Cells[dayanakvarant + 5 + bir, 5].Value = table[j][0];
                                bir++;
                                adet = 1;
                            }
                        }
                        if (j < 20 && tur[i] == "PUT")
                        {
                            if (table[j][1] == table[j + 1][1])
                            {
                                adet++;
                            }
                            else
                            {

                                worksheet.Cells[dayanakvarant + 5 + bir, 7].Value = table[j][1];
                                worksheet.Cells[dayanakvarant + 5 + bir, 6].Value = adet;
                                worksheet.Cells[dayanakvarant + 5 + bir, 5].Value = table[j+1][0];
                                bir++;
                                adet = 1;
                            }
                        }
                        worksheet.Cells[dayanakvarant, 1].Value = dayanak[i];
                        worksheet.Cells[dayanakvarant, 2].Value = kalanemirisimler[i];
                        worksheet.Cells[dayanakvarant, 5].Value = "dayanak deger";
                        worksheet.Cells[dayanakvarant, 6].Value = "=MTXIQ|DATA!" + dayanak[i] + ".SON";
                        worksheet.Cells[dayanakvarant, 7].Value = table[ps][0];
                        worksheet.Cells[dayanakvarant +1, 5].Value = "mavi";
                        worksheet.Cells[dayanakvarant + 1, 6].Value= table[ps][1];
                        worksheet.Cells[dayanakvarant+2, 5].Value = "tur";
                        worksheet.Cells[dayanakvarant + 2, 6].Value = tur[i];
                        worksheet.Cells[excl, 1].Value = table[j ][0];
                        worksheet.Cells[excl, 2].Value = table[j ][1];
                        excl++;
                       
                    }
                    excl = excl + 3;
                    dayanakvarant +=24  ;


                }
                package.Save();

                /*               emirler = (Excel.Worksheet)oWB.Worksheets.get_Item(1);
                               emirler.Select();


                               //           oXL.Visible = true;
                    //           oXL.UserControl = true;
                               oWB.SaveAs("C:\\Users\\gs_er\\Desktop\\test505.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                      false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                               oWB.Close();
                               oXL.Quit();   
                  */
            }
            catch (Exception theException) {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");

            }



    } 
    
    
    
    
    
    }
}
