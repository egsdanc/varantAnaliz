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
using System.Data.SQLite;

namespace ClientApiAppDemo
{
    /// <summary>
    /// Interaction logic for sembolekle.xaml
    /// </summary>
    public partial class sembolekle : Window
    {
        public sembolekle()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string sii=Sisimtxt.Text;
            string sdd=Sdayanaktxt.Text;
            string stt = STurtxt.Text;

            SQLiteConnection con = new SQLiteConnection("Data source =.\\emirler.db");
            con.Open();
            SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO sembol (sembol_isim,sembol_dayanak,sembol_tur ) VALUES (@si,@sd,@st)",con);
          
            insertSQL.Parameters.AddWithValue("@si",sii.Trim() );
            insertSQL.Parameters.AddWithValue("@sd",sdd.Trim()  );
            insertSQL.Parameters.AddWithValue("@st",stt.Trim()  );
           
            insertSQL.ExecuteNonQuery();
            try
            {
                insertSQL.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            con.Close();
        }
    }
}
