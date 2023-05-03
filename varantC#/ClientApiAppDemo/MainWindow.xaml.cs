using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClientApiAppDemo.Annotations;
using ClientApiAppDemo.Models;
using Matriks.Api;
using Matriks.Api.RequestModels;
using Matriks.Api.ResposeModels;
using Matriks.API.Shared;
using Matriks.ApiClient;
using Matriks.ApiClient.TcpConnection;
using Matriks.Utility;
using Newtonsoft.Json;
using Microsoft.Office.Interop.Excel ;
using System.Globalization;
using System.Data.SQLite;
 
using System.Reflection;




using Excel = Microsoft.Office.Interop.Excel;

using Timer = System.Timers.Timer;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Net;

namespace ClientApiAppDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : System.Windows.Window, INotifyPropertyChanged
    {
        public ObservableCollection<Accounts> Accounts
        {
            get => _accounts;
            set
            {
                _accounts = value;
                OnPropertyChanged("Accounts");
            }
        }

        public Accounts SelectedAccount
        {
            get => _selectedAccount;
            set
            {
                _selectedAccount = value;
                if (SelectedAccount != null)
                {
                    FilterPositions();
                    FilterOrders();
                }

                OnPropertyChanged();
            }
        }



        public ObservableCollection<PositionResponseModel> FilteredPositions
        {
            get => _filteredPositions;
            set
            {
                _filteredPositions = value;

                OnPropertyChanged();
            }
        }

        public ObservableCollection<OrderRequest> FileteredOrders
        {
            get => _fileteredOrders;
            set
            {
                _fileteredOrders = value;
                OnPropertyChanged();
            }
        }

        public OrderRequest SelectedOrderApiModel
        {
            get => _orderApiModel;
            set
            {
                _orderApiModel = value;
                if (value != null)
                    this.Symbol = value.Symbol;
                OnPropertyChanged();
            }
        }

        private void FilterPositions()
        {
            if (SelectedAccount == null)
                return;
            FilteredPositions = new ObservableCollection<PositionResponseModel>(AllPositionResponseModels
                    .Where(x => x.AccountId == SelectedAccount.AccountId && x.BrokageId == SelectedAccount.BrokageId && x.ExchangeId == SelectedAccount.ExchangeId));

        }

        private void FilterOrders()
        {
            if (SelectedAccount == null)
                return;
            FileteredOrders = new ObservableCollection<OrderRequest>(AllOrderApiModels.Where(x => x.AccountId == SelectedAccount.AccountId));

        }
        public List<PositionResponseModel> AllPositionResponseModels;

        public List<OrderRequest> AllOrderApiModels;

        public string Symbol
        {
            get => _symbol;
            set
            {
                _symbol = value;
                OnPropertyChanged();
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }

        public decimal Volume
        {
            get => _volume;
            set
            {
                _volume = value;
                OnPropertyChanged();
            }
        }

        private ICommand OnRefreshAccountInfoCommand { get; set; }

        private TcpClientService _tcpClientService;
        private TcpCallbackService _tcpCallbackService;
        private ObservableCollection<Accounts> _accounts;
        private Accounts _selectedAccount;
        private ObservableCollection<PositionResponseModel> _filteredPositions;
        private ObservableCollection<OrderRequest> _fileteredOrders;
        private string _symbol;
        private decimal _price;
        private decimal _volume;
        private OrderRequest _orderApiModel;

        private Timer _keepAliveTimer;
        public MainWindow()
        {
            _tcpCallbackService = new TcpCallbackService();
            _tcpClientService = new TcpClientService(_tcpCallbackService, "localhost", 18890);
            InitializeComponent();
            DataContext = this;
            this.Accounts = new ObservableCollection<Accounts>();
            AllPositionResponseModels = new List<PositionResponseModel>();
            AllOrderApiModels = new List<OrderRequest>();
            FileteredOrders = new ObservableCollection<OrderRequest>();
            OnRefreshAccountInfoCommand = new RoutedCommand();
            _tcpClientService.InitializeTcpConnection();
            RegisterEvents();
            FilteredPositions = new ObservableCollection<PositionResponseModel>();
        }

        private void RegisterEvents()
        {
            _tcpCallbackService.ListAccountsResponseEvent += TcpCallbackServiceOnListAccountsResponseEvent;
            _tcpCallbackService.ListPositionsResponseEvent += TcpCallbackServiceOnListPositionsResponseEvent;
            _tcpCallbackService.ListOrdersResponseEvent += TcpCallbackServiceOnListOrdersResponseEvent;
            _tcpCallbackService.OrderChangedEvent += TcpCallbackServiceOnOrderChangedEvent;
            _tcpCallbackService.PositionChangedEvent += TcpCallbackServiceOnPositionChangedEvent;
            _tcpCallbackService.TradeUserLoginEvent += TcpCallbackServiceOnTradeUserLoginEvent;
            _tcpCallbackService.TraderUserLogoutEvent += TcpCallbackServiceOnTraderUserLogoutEvent;
            _tcpCallbackService.KeepAliveResponseEvent += TcpCallbackServiceOnKeepAliveResponseEvent;
            _keepAliveTimer = new Timer();
            _keepAliveTimer.Interval = 1000 * 30;
            _keepAliveTimer.Elapsed += KeepAliveTimerOnElapsed;
            _keepAliveTimer.Start();
        }

        private void TcpCallbackServiceOnKeepAliveResponseEvent(object sender, KeepAlive e)
        {
        }

        private void KeepAliveTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            _tcpClientService.SendKeepAlive();
        }

        private void TcpCallbackServiceOnTraderUserLogoutEvent(object sender, TradeUserLogoutModel e)
        {
            if (!Accounts.Any(x => x.AccountId == e.AccountId && x.BrokageId == e.BrokageId))
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    this.Accounts.Remove(Accounts.FirstOrDefault(x => x.AccountId == e.AccountId && x.BrokageId == e.BrokageId));
                    this.AllPositionResponseModels.RemoveAll(x =>
                        x.BrokageId == e.BrokageId && x.AccountId == e.AccountId);
                    this.AllOrderApiModels.RemoveAll(x => x.AccountId == e.AccountId && x.BrokageId == e.BrokageId);
                    if (SelectedAccount.AccountId == e.AccountId && SelectedAccount.BrokageId == e.BrokageId)
                        SelectedAccount = null;

                    FilterOrders();
                    FilterPositions();

                });
        }

        private void TcpCallbackServiceOnTradeUserLoginEvent(object sender, TradeUserLoginModel e)
        {
            _tcpClientService.RequestAccounts();
            //    var account = new Accounts();
            //    account.BrokageId = e.BrokageId;
            //    account.AccountId = e.AccountId;
            //    account.ExchangeId = e.ExchangeId;
            //    account.DisplayName = e.BrokageName + " " + e.AccountId;
            //    if(!Accounts.Any(x => x.AccountId == account.AccountId && x.BrokageId == account.BrokageId))
            //        Application.Current.Dispatcher.Invoke(() => { this.Accounts.Add(account); });
            //    _tcpClientService.RequestPositions(account.BrokageId, account.AccountId, account.ExchangeId);
            //_tcpClientService.RequestWaitingOrders(account.AccountId, account.BrokageId,account.ExchangeId);

        }

        private void TcpCallbackServiceOnPositionChangedEvent(object sender, PositionResponseModel e)
        {
            if (!AllPositionResponseModels.Any(x =>
                x.Symbol == e.Symbol && x.AccountId == e.AccountId && x.BrokageId == e.BrokageId && e.ExchangeId == x.ExchangeId))
            {
                AllPositionResponseModels.Add(e);
            }
            else
            {
                AllPositionResponseModels.Remove(AllPositionResponseModels.FirstOrDefault(x =>
                    x.Symbol == e.Symbol && x.AccountId == e.AccountId && x.BrokageId == e.BrokageId && x.ExchangeId == e.ExchangeId));
                AllPositionResponseModels.Add(e);
            }
           
      
            

            FilterPositions();
        }

        private void TcpCallbackServiceOnOrderChangedEvent(object sender, OrderRequest e)
        {
            if (!AllOrderApiModels.Any(x => x.OrderId == e.OrderId))
            {
                AllOrderApiModels.Add(e);
            }
            else
            {
                AllOrderApiModels.Remove(AllOrderApiModels.FirstOrDefault(x => x.OrderId == e.OrderId));
                AllOrderApiModels.Add(e);
            }
         
         
            FilterOrders();
         
        }

        private void TcpCallbackServiceOnListOrdersResponseEvent(object sender, ListOrdersApiResponseModel e)
        {
            foreach (var eOrderApiModel in e.OrderApiModels)
            {
                AllOrderApiModels.Add(eOrderApiModel);
            }

        }
        string SymbolSatis;
        decimal PriceSatis;
        decimal QuantitySatis;
        decimal kalandger;
        decimal ysatis;
        int OrderSideSatis;
        decimal[] kalandeger = new decimal[99999999];
       
        public string sqllite(string orderid)
        {       //where orderid=@orderid
            SQLiteConnection con = new SQLiteConnection("Data source =.\\emirler.db");
            string deger;


            con.Open();
            string stm = "SELECT * FROM emirsatis where orderid=@orderid";
            string count = "SELECT count(*) FROM emirsatis where orderid=1234567";
        //    SQLiteCommand cmdSayi = new SQLiteCommand(count, con);
       //     cmdSayi.Parameters.AddWithValue("@orderid", orderid);

            SQLiteCommand cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@orderid", orderid);
      //      int sayi = (int)cmdSayi.ExecuteScalar();
            SQLiteDataReader dr = cmd.ExecuteReader();
            

            //dr.Read();
            if(dr.Read())
            {
                deger = dr["filledyedek"].ToString();
            }
            else
            {
                deger = null;
            }
             



       //     MessageBox.Show("hebele hübele" + sayi);
            //Console.WriteLine("hebele hübele" + sayi);


         //   if(sayi!=0)
         //   {
               // deger = dr["filledyedek"].ToString();
        //    }
            


            dr.Close();
            con.Close();
            return deger;
              
        }
     /*   public string sqllitelistcallput( string sembolad)
        { 
            string gelen;
            SQLiteConnection con = new SQLiteConnection("Data source =.\\emirler.db");
            con.Open();
            string stm = "SELECT * FROM sembol where sembol_isim=@sembolad ";
            SQLiteCommand cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@sembolad", sembolad);
            SQLiteDataReader dr = cmd.ExecuteReader();
           if (dr.Read())
            {
                gelen = dr["sembol_tur"].ToString();
            }
            else
            {
                gelen = null;
            } 
            dr.Close();
            con.Close();
            return gelen;
        } */
        public string sqllitelistorderid(string orderid)
        {       //where orderid=@orderid
            SQLiteConnection con = new SQLiteConnection("Data source =.\\emirler.db");
            string deger;


            con.Open();
            string stm = "SELECT * FROM emirsatis where orderid=@orderid";
            string count = "SELECT count(*) FROM emirsatis where orderid=1234567";
            //    SQLiteCommand cmdSayi = new SQLiteCommand(count, con);
            //     cmdSayi.Parameters.AddWithValue("@orderid", orderid);

            SQLiteCommand cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@orderid", orderid);
            //      int sayi = (int)cmdSayi.ExecuteScalar();
            SQLiteDataReader dr = cmd.ExecuteReader();


            //dr.Read();
            if (dr.Read())
            {
                deger = dr["filledyedek"].ToString();
            }
            else
            {
                deger = null;
            }




            //     MessageBox.Show("hebele hübele" + sayi);
            //Console.WriteLine("hebele hübele" + sayi);


            //   if(sayi!=0)
            //   {
            // deger = dr["filledyedek"].ToString();
            //    }



            dr.Close();
            con.Close();
            return deger;

        }
        private void sqlliteekle(string order, string fyedek)
        {
            SQLiteConnection con = new SQLiteConnection("Data source =.\\emirler.db");
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = "INSERT INTO emirsatis (orderid,filledyedek) VALUES(@order,@fyedek) ";
            
            cmd.Parameters.AddWithValue("@order", order);
            cmd.Parameters.AddWithValue("@fyedek", fyedek);
            cmd.ExecuteNonQuery();
            con.Close(); //sonradan ekledim





        }
        private void otomatiksatis()      // hatalı çalışıyor o yüzden kullanmadım
        {                                   // emirde gerçekleşen miktar kadar varantı 1kr fazlasına satışa çıkarıyor
                                            // ancak durmuyor aynı miktarı satışa çıkarmaya devam ediyor
            decimal gelenkalan;
            decimal sonsatis;

      
                
            foreach (var item in FileteredOrders.ToList())
            {
               
                  if (item.OrdStatus == '0' && item.OrderSide==0)             //4 İPTAL edilmiş  0 // bekleyen // 2 gerçekleşmiş
                {
                 //çevirmeler yanlış, dizi elemanı olarak göstertemedim 
                   
                
                    if (item.FilledQty != 0)
                    {   
                        OrderRequest orderApiModel = new OrderRequest();
                        orderApiModel.Symbol = item.Symbol;
                        orderApiModel.AccountId = SelectedAccount.AccountId;
                        orderApiModel.BrokageId = SelectedAccount.BrokageId;
                        orderApiModel.Price = item.Price + decimal.Parse("0.01", CultureInfo.InvariantCulture);
                    
                        if ( (sqllite(item.OrderId) ) == null)
                        {
                            gelenkalan = 0;
                            Console.Write("gelen kalan 0 a eşitlendi" + gelenkalan);
                        }
                        else
                        {
                            gelenkalan = decimal.Parse(sqllite(item.OrderId), CultureInfo.InvariantCulture);
                            Console.Write("gelen kalan veritabanından alındı" + gelenkalan);
                        }
                        
                        
                        orderApiModel.Quantity = item.FilledQty - gelenkalan;
                           
                       sqlliteekle(item.OrderId, item.FilledQty.ToString());
                        Console.Write("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" + item.FilledQty.ToString());
                    //    orderApiModel.LeavesQty = item.OrderQty - item.LeavesQty;
                        orderApiModel.OrderId2 = null;
                   //     orderApiModel.OrderQty = item.OrderQty - item.LeavesQty;

                        orderApiModel.OrderSide = 1;   //  0 alış , 1 satış

                       
                        orderApiModel.OrderType = '2';
                        orderApiModel.TimeInForce = '0';

                        orderApiModel.TransactionType = '1';
                        orderApiModel.OrderId = null;

                        orderApiModel.ClientOrderId = GetTimeStamp();
                        orderApiModel.OrdStatus = '0';
                        if (item.FilledQty - gelenkalan != 0 && item.FilledQty - gelenkalan >= 0  )  
                        {
                            
                           _tcpClientService.SendNewOrder(orderApiModel);
                              Console.WriteLine("@@@@@@@@@@@aaaaaaa@@@@@@@@@@@@@@@" + item.FilledQty.ToString());
                              Console.Read();
                            System.Threading.Thread.Sleep(1000);
                        }
                    }                 
                } 

                 if(item.OrdStatus=='2' && item.OrderSide == 0 && item.OrderId.Substring(0, 2) != "MC")
                {  //MC OLAN HİÇBİŞEY İLE İŞLEM YAPMIYORUM
                   
                    if ((sqllite(item.OrderId)) == null)
                    {
                        sonsatis = 0;
                    }
                    else
                    {
                        sonsatis =  decimal.Parse(sqllite(item.OrderId));
                        Console.WriteLine(" sonsatis " + sonsatis);
                    }
                        OrderRequest orderApiModel = new OrderRequest();
                    orderApiModel.Symbol = item.Symbol;
                    orderApiModel.AccountId = SelectedAccount.AccountId;
                    orderApiModel.BrokageId = SelectedAccount.BrokageId;
                    orderApiModel.Price = item.Price + decimal.Parse("0.01", CultureInfo.InvariantCulture);
                    orderApiModel.Quantity = item.OrderQty - sonsatis;
                    orderApiModel.OrderId2 = null;
                    orderApiModel.OrderSide = 1;   //  0 alış , 1 satış


                    orderApiModel.OrderType = '2';
                    orderApiModel.TimeInForce = '0';

                    orderApiModel.TransactionType = '1';
                    orderApiModel.OrderId = null;

                    orderApiModel.ClientOrderId = GetTimeStamp();
                    orderApiModel.OrdStatus = '0';
                 
                    if (item.OrderQty - sonsatis != 0 && item.OrderQty - sonsatis >= 0  )  //&& sonsatis !=13013333333333  son ekledim
                    {
                                  
                      // geri sil      _tcpClientService.SendNewOrder(orderApiModel);
                              Console.WriteLine("@@@@@@@@@@LLLLLLLLLLLL@@@@@@@@@@@@@@@" + item.FilledQty.ToString());
                               
                        System.Threading.Thread.Sleep(1000);
                        
                            sqlliteekle(item.OrderId, item.OrderQty.ToString());
                       //  sqlliteekle(item.OrderId, "13013333333333");
                     // İŞLEM GERÇEKLEŞTİKTEN SONRA SON SATIŞI YAPMAYA DEVAM EDİYOR
                    
                        
                    }
                }  
            }

               
        }

        private void TcpCallbackServiceOnListPositionsResponseEvent(object sender, ListPositionResponseModel e)
        {
            AllPositionResponseModels.AddRange(e.PositionResponseList);

        }

        private void TcpCallbackServiceOnListAccountsResponseEvent(object sender, List<BrokageAccounts> e)
        {
            foreach (var brokerAccountse in e)
            {
                foreach (var accountId in brokerAccountse.AccountIdList)
                {
                    var account = new Accounts();
                    account.BrokageId = brokerAccountse.BrokageId;
                    account.AccountId = accountId.AccountId;
                    account.ExchangeId = accountId.ExchangeId;
                    account.DisplayName = brokerAccountse.BrokageName + " " + accountId.AccountId + " " + account.ExchangeId;
                    System.Windows.Application.Current.Dispatcher.Invoke(() =>
                    {
                        if (!Accounts.Any(x => x.AccountId == account.AccountId && x.BrokageId == account.BrokageId && x.ExchangeId == account.ExchangeId))
                            this.Accounts.Add(account);
                    });
                    if (Accounts.Any(x =>
                        x.AccountId == account.AccountId && x.BrokageId == account.BrokageId &&
                        x.ExchangeId == account.ExchangeId))
                    {
                        _tcpClientService.RequestPositions(account.BrokageId, account.AccountId, account.ExchangeId);
                        _tcpClientService.RequestWaitingOrders(account.AccountId, account.BrokageId, account.ExchangeId);
                      
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            OrderRequest orderApiModel = new OrderRequest();
            orderApiModel.Symbol = Symbol;
            orderApiModel.AccountId = SelectedAccount.AccountId;
            orderApiModel.BrokageId = SelectedAccount.BrokageId;
            orderApiModel.Price = Price;
            orderApiModel.Quantity = Volume;
            orderApiModel.OrderSide = 0;
            orderApiModel.OrderType = '2';
            orderApiModel.TransactionType = '1';
            orderApiModel.ApiCommands = (int)ApiCommands.NewOrder;
            _tcpClientService.SendNewOrder(orderApiModel);



        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderView orderView = new OrderView();
                orderView.Symbol = SelectedOrderApiModel.Symbol;
                orderView.SelectedAccount = SelectedOrderApiModel.AccountId;
                orderView.SelectedBrokage = SelectedOrderApiModel.BrokageId;
                orderView.IsEdit = true;
                orderView.Price = SelectedOrderApiModel.Price;
                orderView.Volume = SelectedOrderApiModel.LeavesQty;
                orderView.TcpClientService = _tcpClientService;
                if (SelectedOrderApiModel.OrderSide == 0)
                    orderView.IsBuy = true;
                else
                    orderView.IsBuy = false;

                orderView.OrderId = SelectedOrderApiModel.OrderId;
                orderView.OrderId2 = SelectedOrderApiModel.OrderId2;
                orderView.ClientOrderId = SelectedOrderApiModel.ClientOrderId;
                orderView.Show();
            }
            catch (Exception)
            {

            }

        }

        private void MenuItem_OnClickCancel(object sender, RoutedEventArgs e)
        {
            OrderRequest orderApiModel = new OrderRequest();
            orderApiModel.Symbol = Symbol;
            orderApiModel.AccountId = SelectedOrderApiModel.AccountId;
            Console.Write(orderApiModel.AccountId);
            orderApiModel.BrokageId = SelectedOrderApiModel.BrokageId;
            orderApiModel.Price = SelectedOrderApiModel.Price;
            orderApiModel.Quantity = SelectedOrderApiModel.OrderQty;
            orderApiModel.LeavesQty = SelectedOrderApiModel.LeavesQty;
            orderApiModel.OrderId2 = SelectedOrderApiModel.OrderId2;
            orderApiModel.OrderSide = SelectedOrderApiModel.OrderSide;
            orderApiModel.OrderId = SelectedOrderApiModel.OrderId;
            orderApiModel.OrderId2 = SelectedOrderApiModel.OrderId2;


            orderApiModel.OrderType = '2';
            orderApiModel.TimeInForce = SelectedOrderApiModel.TimeInForce;



            orderApiModel.TransactionType = '1';

            _tcpClientService.SendCancelOrder(orderApiModel);
        }

        private void MenuItem_OnClickAddOrder(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderView orderView = new OrderView();

                orderView.SelectedAccount = SelectedAccount.AccountId;
                orderView.SelectedBrokage = SelectedAccount.BrokageId;
                orderView.IsEdit = false;
                if (SelectedOrderApiModel != null)
                {
                    orderView.Symbol = SelectedOrderApiModel.Symbol;
                    orderView.Price = SelectedOrderApiModel.Price;
                    orderView.Volume = SelectedOrderApiModel.LeavesQty;
                    orderView.OrderId = SelectedOrderApiModel.OrderId;
                    orderView.OrderId2 = SelectedOrderApiModel.OrderId2;
                    if (SelectedOrderApiModel.OrderSide == 0)
                        orderView.IsBuy = true;
                    else
                        orderView.IsBuy = false;

                }
                orderView.TcpClientService = _tcpClientService;


                orderView.Show();
            }
            catch (Exception)
            {

            }
        }

        private void DuzenleClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderView orderView = new OrderView();
                orderView.Symbol = SelectedOrderApiModel.Symbol;
                orderView.SelectedAccount = SelectedOrderApiModel.AccountId;
                orderView.SelectedBrokage = SelectedOrderApiModel.BrokageId;
                orderView.IsEdit = true;
                orderView.Price = SelectedOrderApiModel.Price;
                orderView.Volume = SelectedOrderApiModel.LeavesQty;
                orderView.TcpClientService = _tcpClientService;
                if (SelectedOrderApiModel.OrderSide == 0)
                    orderView.IsBuy = true;
                else
                    orderView.IsBuy = false;

                orderView.OrderId = SelectedOrderApiModel.OrderId;
                orderView.OrderId2 = SelectedOrderApiModel.OrderId2;
                orderView.ClientOrderId = SelectedOrderApiModel.ClientOrderId;
                orderView.Show();
            }
            catch (Exception)
            {

            }
        }

        private void SilClicked(object sender, RoutedEventArgs e)
        {
            OrderRequest orderApiModel = new OrderRequest();
            orderApiModel.Symbol = Symbol;
            orderApiModel.AccountId = SelectedOrderApiModel.AccountId;
            orderApiModel.BrokageId = SelectedOrderApiModel.BrokageId;
            orderApiModel.Price = SelectedOrderApiModel.Price;
            orderApiModel.Quantity = SelectedOrderApiModel.OrderQty;
            orderApiModel.LeavesQty = SelectedOrderApiModel.LeavesQty;
            orderApiModel.OrderId2 = SelectedOrderApiModel.OrderId2;
            orderApiModel.OrderSide = SelectedOrderApiModel.OrderSide;
            orderApiModel.OrderId = SelectedOrderApiModel.OrderId;
            //            orderApiModel.OrderId2 = SelectedOrderApiModel.OrderId2;


            orderApiModel.OrderType = '2';
            orderApiModel.TimeInForce = SelectedOrderApiModel.TimeInForce;



            orderApiModel.TransactionType = '1';
            Console.WriteLine(Symbol + " " + SelectedOrderApiModel.AccountId + " " + SelectedOrderApiModel.BrokageId + " " + SelectedOrderApiModel.Price + " " + SelectedOrderApiModel.OrderQty + " " + SelectedOrderApiModel.LeavesQty + " " + SelectedOrderApiModel.OrderId2 + " " + SelectedOrderApiModel.OrderSide + " " + SelectedOrderApiModel.OrderId);
            _tcpClientService.SendCancelOrder(orderApiModel);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private static Random _rng = new Random();


        private void topluEmirGonder(string Symbol, decimal Price, decimal Quantity, int OrderSide)
        {
            OrderRequest orderApiModel = new OrderRequest();
            orderApiModel.Symbol = Symbol;
            orderApiModel.AccountId = SelectedAccount.AccountId;
            orderApiModel.BrokageId = SelectedAccount.BrokageId;
            orderApiModel.Price = Price;
            orderApiModel.Quantity = Quantity;
            orderApiModel.LeavesQty = Quantity;
            orderApiModel.OrderId2 = null;
            orderApiModel.OrderQty = Quantity;

            orderApiModel.OrderSide = OrderSide;   //  0 alış , 1 satış



            Console.WriteLine(orderApiModel.OrderSide);
            orderApiModel.OrderType = '2';
            orderApiModel.TimeInForce = '0';




            orderApiModel.TransactionType = '1';
            orderApiModel.OrderId = null;





            orderApiModel.ClientOrderId = GetTimeStamp();
            orderApiModel.OrdStatus = '0';
            _tcpClientService.SendNewOrder(orderApiModel);
        }
        private void Button_Click(object sender, RoutedEventArgs e)   //Toplu Emir Gönder
        {
            string filepath = "c:\\emir\\emirler.xlsx";
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb;
            Worksheet ws;
            wb = excel.Workbooks.Open(filepath);
            ws = wb.Worksheets[1];

            int i = 2;
            //     var allLength = ws.Cells.Rows.Count;
            //       var all = ws.Cells.Columns.Count;
            //   MessageBox.Show(allLength.ToString()+ "  "+ all.ToString());
            while (true)
            {
                string s_Price = ws.Cells[i, 2].Value.ToString();
                s_Price = s_Price.Replace(',', '.');
                decimal Price = decimal.Parse(s_Price, CultureInfo.InvariantCulture);
                string s_Quantity = ws.Cells[i, 3].Value.ToString();

                decimal Quantity = decimal.Parse(s_Quantity, CultureInfo.InvariantCulture);

                topluEmirGonder(ws.Cells[i, 1].Value, Price, Quantity, 0);
                i++;


                if (null == ws.Cells[i, 1].Value)
                {
                    wb.Close();
                    break;
                }

            }



        }
        public static string GetTimeStamp()
        {
            var randomNumber = _rng.Next(1000000);
            return (DateTime.Now.Ticks + randomNumber).ToString("00000000000000000000");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // bekleyen emirler
        {
            //    FilteredPositions.ToList().ForEach(x=>Console.WriteLine(x.Symbol)); // mal varlıklarım
            //   FileteredOrders.ToList().ForEach(x=>Console.WriteLine(x.Symbol));
            string[] bekleyenemirler = new string[1000];

            int bek = 0;

            int a = 0;
            foreach (var item in FileteredOrders.ToList())
            {
                /*  if(item.OrdStatus=='0')             //4 İPTAL edilmiş  0 // bekleyen // 2 gerçekleşmiş
                  {   if(item.OrderQty - item.LeavesQty != 0)
                      Console.WriteLine("GERÇEKLEŞMİŞ: "+ item.Symbol +" " +  (item.OrderQty-item.LeavesQty));
                  } 
                  /*  if(item.OrdStatus=='4')             //4 İPTAL edilmiş  0 // bekleyen // 2 gerçekleşmiş
                  {
                      Console.WriteLine("İPTAL: "+item.Symbol);
                  }   

                  if (item.OrdStatus == '2')             //4 İPTAL edilmiş  0 // bekleyen // 2 gerçekleşmiş
                  {
                      Console.WriteLine("kısmen GERÇEKLEŞMİŞ: " + item.Symbol +" " + item.FilledQty   );
                  } */

                if (item.OrdStatus == '0')
                {
                    bekleyenemirler[bek] = item.Symbol;
                    bek++;


                }
            }
            string[] kalanemirler = new string[bek];

            Console.WriteLine(bek);

            for (int i = 0; i < bek; i++)
            {
                if (bekleyenemirler[i] != bekleyenemirler[i + 1] && bekleyenemirler[i] != null)
                {
                    kalanemirler[a] = bekleyenemirler[i];
                    a++;
                }

            }
            Console.WriteLine("a" + a);
            for (int o = 0; o < a; o++)
            {
                Console.WriteLine(kalanemirler[o]);
                Console.WriteLine("3" + o);
            }




            // mal varlıklarım
            //////////////////////////////////////////////////////////////////////////////////////////
            ///



            //ecxel oluştur

            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;

            try
            {
                //Start Excel and get Application object.
                oXL = new Excel.Application();
                oXL.Visible = true;

                //Get a new workbook.
                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));

                Excel.Sheets worksheets = oWB.Worksheets;



                Excel.Worksheet[] xlNewSheett = new Excel.Worksheet[a];
                //string[] sheetName = new string[4] { "sheet1", "sheet2", "sheet3", "sheet4" };
                // string[] symbols = new string[4] { "AGIMI.V", "ALIJK.V", "PTIAS.V", "ABIOF.V" };
                for (int i = 0; i < a; i++)
                {

                    //MessageBox.Show(table[1][0]);
                    xlNewSheett[i] = worksheets.Add(worksheets[1], Type.Missing, Type.Missing, Type.Missing);
                    xlNewSheett[i].Name = kalanemirler[i];

                    //xlNewSheett[i].Cells[1, 2] = sheetName[i];


                    xlNewSheett[i] = (Excel.Worksheet)oWB.Worksheets.get_Item(1);
                    xlNewSheett[i].Select();


                }

                try
                {
                    oWB.Sheets["Sayfa1"].Delete();
                    oWB.Sheets["Sheet1"].Delete();
                }
                catch (Exception theException1)
                {
                    String errorMessage;
                    errorMessage = "Error: ";
                    errorMessage = String.Concat(errorMessage, theException1.Message);
                    errorMessage = String.Concat(errorMessage, " Line: ");
                    errorMessage = String.Concat(errorMessage, theException1.Source);

                    //MessageBox.Show(errorMessage, "Error");
                }

                for (int i = 0; i < a; i++)
                {
                    string vsiz = kalanemirler[i].Substring(0, kalanemirler[i].Length - 1);
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
                    xlNewSheett[i].Cells[1, 1] = "Dayanak Varlık Satış Fiyatı";
                    xlNewSheett[i].Cells[1, 2] = "Piyasa Yapıcısı Alış Fiyatı";
                    for (int j = 0; j < table.Count; j++)
                    {
                        xlNewSheett[i].Cells[j + 2, 1] = table[j][0];
                        xlNewSheett[i].Cells[j + 2, 2] = table[j][1];
                        Console.WriteLine(table[j][0] + " " + table[j][1]);
                    }
                }




                var emirler = (Excel.Worksheet)worksheets.Add(worksheets[1], Type.Missing, Type.Missing, Type.Missing);
                emirler.Name = "Tümemirler";
                emirler.Cells[1, 1] = "SembolAdi";
                emirler.Cells[1, 2] = "Fiyat";
                emirler.Cells[1, 3] = "Adet";
                emirler.Cells[1, 4] = "Durum";
                emirler.Cells[1, 5] = "Orderid";
                emirler.Cells[1, 6] = "Alis/Satis";
                int semb = 2;
                foreach (var item in FileteredOrders.ToList())
                {
                    emirler.Cells[semb, 1] = item.Symbol;
                    emirler.Cells[semb, 2] = item.Price;
                    emirler.Cells[semb, 3] = item.OrderQty;
                    emirler.Cells[semb, 4] = item.OrdStatus.ToString();
                    emirler.Cells[semb, 5] = item.OrderId;
                    if(item.OrderSide==0)
                         emirler.Cells[semb, 6] = "Alış";
                    if (item.OrderSide == 1)
                        emirler.Cells[semb, 6] = "Satış";
                    
                    semb++;
                }
                emirler = (Excel.Worksheet)oWB.Worksheets.get_Item(1);
                emirler.Select();



                var emirlerbek = (Excel.Worksheet)worksheets.Add(worksheets[1], Type.Missing, Type.Missing, Type.Missing);
                emirlerbek.Name = "BekleyenEmirler";
                emirlerbek.Cells[1, 1] = "SembolAdi";
                emirlerbek.Cells[1, 2] = "Fiyat";
                emirlerbek.Cells[1, 3] = "Adet";
                emirlerbek.Cells[1, 4] = "Durum";
                emirlerbek.Cells[1, 5] = "Orderid";
                emirlerbek.Cells[1, 6] = "Alis/Satis";
                emirlerbek.Cells[1, 7] = "Anlık Değer";
                int sembo = 2;
                foreach (var item in FileteredOrders.ToList())
                {   if (item.OrdStatus.ToString() == "0")
                    {
                        emirlerbek.Cells[sembo, 1] = item.Symbol;
                        emirlerbek.Cells[sembo, 2] = item.Price;
                        emirlerbek.Cells[sembo, 3] = item.OrderQty;
                        emirlerbek.Cells[sembo, 4] = item.OrdStatus.ToString();
                        emirlerbek.Cells[sembo, 5] = item.OrderId;
                        if (item.OrderSide == 0)
                            emirlerbek.Cells[sembo, 6] = "Alış";
                        if (item.OrderSide == 1)
                            emirlerbek.Cells[sembo, 6] = "Satış";
                          emirlerbek.Cells[sembo, 7] = "=MTXIQ|DATA!"+ item.Symbol +".SON";
                        sembo++;

                    }              
                  }
                emirlerbek = (Excel.Worksheet)oWB.Worksheets.get_Item(1);
                emirlerbek.Select();






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


            ////////////////////////////////////////////////////////////////////////////////////////////////////////

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

        private void Button_Click_2(object sender, RoutedEventArgs e)    //emiriptal
        {
            string filepath = "c:\\emir\\emiriptal.xlsx";
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb;
            Worksheet ws;
            wb = excel.Workbooks.Open(filepath);
            ws = wb.Worksheets[1];

            int i = 2;
            //     var allLength = ws.Cells.Rows.Count;
            //       var all = ws.Cells.Columns.Count;
            //   MessageBox.Show(allLength.ToString()+ "  "+ all.ToString());
            while (true)
            {
                OrderRequest orderApiModel = new OrderRequest();
                orderApiModel.Symbol = ws.Cells[i, 1].Value.ToString();
                orderApiModel.AccountId = SelectedAccount.AccountId; ;
                //   Console.WriteLine("++++++++++++++++++++++++" + SelectedAccount.AccountId);
                orderApiModel.BrokageId = SelectedAccount.BrokageId;
                //    orderApiModel.Price = decimal.Parse("25,00", CultureInfo.InvariantCulture); ;
                //   orderApiModel.Quantity = decimal.Parse("100", CultureInfo.InvariantCulture); ;
                //    orderApiModel.LeavesQty = decimal.Parse("100", CultureInfo.InvariantCulture); ;
                orderApiModel.OrderId2 = ws.Cells[i, 5].Value.ToString() + "*" + ws.Cells[i, 2].Value.ToString();
                 
                orderApiModel.OrderId = ws.Cells[i, 5].Value.ToString();




                orderApiModel.OrderType = '2';
                //       orderApiModel.TimeInForce = SelectedOrderApiModel.TimeInForce;



                orderApiModel.TransactionType = '1';
                if (ws.Cells[i, 4].Value.ToString()=="4")
                {
                    _tcpClientService.SendCancelOrder(orderApiModel);
                }
                i++;

                

                if (null == ws.Cells[i, 1].Value)
                {
                    wb.Close();
                    break;
                    //       }

                }


            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)  //filtrele
        { /*
            string filepath = "c:\\emir\\emirler.xlsx";
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb;
            Worksheet ws;
            wb = excel.Workbooks.Open(filepath);
            ws = wb.Worksheets[1];
            //    if (null == ws.Cells[1, 1].Value) {
            string a = ws.Cells[2, 3].Value.ToString();
            string b = ws.Cells[3, 3].Value.ToString();
            Console.WriteLine(a);
          
            int isimler = 2;
            int uzunluk = 0;
            while (true)
            {
                if(ws.Cells[isimler, 1].Value ==null)
                { 
                    break;
                }
                isimler++;
                uzunluk++;
            }
            Console.WriteLine(uzunluk);
      
            string[] emirisimler = new string[3000];
            string[] kalanemirisimler = new string[uzunluk];
          for(int i = 0; i < uzunluk; i++)

            {
                emirisimler[i]=ws.Cells[i+2, 1].Value.ToString();
                
            }
            int ab = 0;
          for(int i=0;i<uzunluk; i++)
            {
                if (emirisimler[i] != emirisimler[i+1] && emirisimler[i]!=null)
                {
                    kalanemirisimler[ab] = emirisimler[i];
                    ab++;
                }
            }
            Console.WriteLine(kalanemirisimler[0]);
            Console.WriteLine(kalanemirisimler[1]);
            Console.WriteLine(kalanemirisimler[2]);
            Console.WriteLine(ab);
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
                int CALLK = Convert.ToInt32 (CALLtxt.Text);
                int PUTK = Convert.ToInt32(PUTtxt.Text);
                string calputkontrol;
                int kontrolA = 0;
              
              //for döngüsünü aç gelen değerleri kontrol et
             for(int abc=0; abc<table.Count-1; abc++)
                { 
             /*   yorum    SQLiteConnection conn = new SQLiteConnection("Data source =.\\emirler.db");
                    conn.Open();
                    string stmm = "SELECT * FROM sembol";
                    SQLiteCommand cmdd = new SQLiteCommand(stmm, conn);
                    cmdd.Parameters.AddWithValue("@sembolad", kalanemirisimler[i].ToString());
                    
                    SQLiteDataReader drr = cmdd.ExecuteReader();
                    int aa = 0;
                    while (drr.Read())
                    {
                         /*
                        string stmmm = "update sembol set sembol_isim=@semboladyeni where sembol_isim=@sembolad";
                        SQLiteCommand cmddd = new SQLiteCommand(stmmm, conn);
                        cmddd.Parameters.AddWithValue("@sembolad", drr["sembol_isim"].ToString());
                       cmddd.Parameters.AddWithValue("@semboladyeni", drr["sembol_isim"].ToString().Trim());
                        cmddd.ExecuteNonQuery();
                   //      

                        Console.WriteLine( "+"+drr["sembol_isim"].ToString().Trim()+"+");
                        Console.WriteLine("+" + drr["sembol_isim"].ToString() + "+");


                    }
                    drr.Close();
                    conn.Close(); 
      yorum      *//////////////////
            /*                     
                     //    Console.WriteLine("abc " + abc);
                     //    Console.WriteLine("tabeleeeee " + table[1][1]);
                     if (table[abc][1] == table[abc + 1][1] && table[abc + 1][1] != null)
                     {
                         Console.WriteLine("tabeleeeee " + table[2][1]);

                         kontrolA++;
                         Console.WriteLine("kontrolA " + kontrolA);
                     }
                     else
                     {
                         string gelen;
                         SQLiteConnection con = new SQLiteConnection("Data source =.\\emirler.db");
                         con.Open();
                         string stm = "SELECT * FROM sembol where sembol_isim=@sembolad";
                         SQLiteCommand cmd = new SQLiteCommand(stm, con);
                         cmd.Parameters.AddWithValue("@sembolad", kalanemirisimler[i].ToString());
                         Console.WriteLine("iiiiiiiiiiiiiiii " + i);
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
                         //    calputkontrol = sqllitelistcallput(kalanemirisimler[i]);
                         Console.WriteLine("calllllllllkontrolA :" + kalanemirisimler[i]+"@");
                         Console.WriteLine("calllllllllkontrolA :" + gelen+"@");
                         if (gelen =="CALL" && CALLK > kontrolA)
                         {

                             int x=Array.IndexOf(filtreliemirler, kalanemirisimler[i]);
                             filtreliemirler = filtreliemirler.Where((source, index) => index != x).ToArray();
                             for(int y=0; y<filtreliemirler.Length; y++)
                                 Console.WriteLine("ddddd " + filtreliemirler[y]);
                         }

                         if (gelen == "PUT" && PUTK > kontrolA)
                         {

                             int x = Array.IndexOf(filtreliemirler, kalanemirisimler[i]);
                             filtreliemirler = filtreliemirler.Where((source, index) => index != x).ToArray();
                             for (int y = 0; y < filtreliemirler.Length; y++)
                                 Console.WriteLine("ddddd " + filtreliemirler[y]);
                         }
                         kontrolA = 1;
                     }
                 }                      
             }
             Console.WriteLine("ddddd "+ filtreliemirler[0]);
         //   Console.WriteLine("ddddd " + filtreliemirler[1]);
          //   Console.WriteLine("ddddd " + filtreliemirler[2]);
             wb.Close();               */

            filtrele ftrl = new filtrele();
            ftrl.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)   //sembol ekle
        {
            sembolekle se = new sembolekle();
            se.Show();
        }
    }
}









