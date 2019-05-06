using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Telerik.UI.Xaml.Controls.Grid;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Cryptography;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.QueryStringDotNET;
using Windows.ApplicationModel.Activation;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI;
using System.Net;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage.FileProperties;
using System.Data;
using System.Runtime.InteropServices.ComTypes;
using Windows.ApplicationModel.ExtendedExecution;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace DataYRAN
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class BlankPageObrData : Page
    {
        private StorageFile f = null;
        public StorageFile FileEvent1
        {
            get { return f; }
            set { f = value; }
        }
        private ProtocolActivatedEventArgs _protocolEventArgs = null;
        public ProtocolActivatedEventArgs ProtocolEvent1
        {
            get { return _protocolEventArgs; }
            set { _protocolEventArgs = value; }
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is ClassBDMan2)
            {
                ClassBDMan2 classBD = (ClassBDMan2)e.Parameter;
                if (!classBD.flagP)
                {
                    ObRing.IsActive = true;
                   
                   await StartClientBD(classBD.listsql.ElementAt(0), classBD.ip);
                    ObRing.IsActive = false;

                }
            }
            else
            {

            }

            // Specify a known location.
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 55.6512013566365, Longitude = 37.6681702130651 };
            Geopoint cityCenter = new Geopoint(cityPosition);

            // Set the map location.
            MapControl1.Center = cityCenter;
            MapControl1.ZoomLevel = 20;
            MapControl1.LandmarksVisible = true;
            base.OnNavigatedTo(e);
        }
        public async void NavigateToFilePage1()
        {
            MessageDialog messageDialog = new MessageDialog("gfhf");
            await messageDialog.ShowAsync();
        }
        ToastNotification toast;
        ConcurrentQueue<MyclasDataizFile> OcherediNaObrab = new ConcurrentQueue<MyclasDataizFile>();
        /// <summary>
        /// Коллекция файлов развертки из локкального хранилища
        /// </summary>
        ObservableCollection<ClassСписокList> КолекцияФайловРазвертки = new ObservableCollection<ClassСписокList>();
        ObservableCollection<Data> data = new ObservableCollection<Data>();
        ObservableCollection<ObservableCollection<Data>> collection = new ObservableCollection<ObservableCollection<Data>>();
      

        ObservableCollection<ClassSob> _DataColecSobPlox = new ObservableCollection<ClassSob>();
   
      
       // ObservableCollection<ClassSobNeutron> _DataColecNeu = new ObservableCollection<ClassSobNeutron>();
    
        ClassСписокList _СписокФайловОбработки = new ClassСписокList();

        ObservableCollection<ClassSobObrZav> _DataColecSob2 = new ObservableCollection<ClassSobObrZav>();

  
       



        public BlankPageObrData()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            GridLocalizationManager.Instance.StringLoader = new TelerikStringLoader();

            Window.Current.Activated += Current_Activated;
            this.ViewModel = new RecordingViewModel();


        }
        public RecordingViewModel ViewModel { get; set; }
        public bool first = true;

        private async  void Current_Activated(object sender, WindowActivatedEventArgs e)
        {
            if (first)
            {
                try
                {
                    ClassUserSetUp.SetPush();

                }
                catch
                {

                }
                listView1.ItemsSource = ViewModel.DataColec;
               
              //  DataGrid.ItemsSource = _DataColecSob;
                DataGridPlox.ItemsSource = _DataColecSobPlox;
               // DataGridnNeutron.ItemsSource = _DataColecNeu;
           
                ToggleSwitchAuto.IsOn = ClassUserSetUp.AutoSeting;
                ToggleSwitchSaveRaz.IsOn = ClassUserSetUp.SaveRaz;
                ToggleSwitchObrSig.IsOn = ClassUserSetUp.ObrSig;
                TextBloxPorogN.Text = ClassUserSetUp.PorogN.ToString();
                TextBloxDlitN.Text = ClassUserSetUp.DlitN3.ToString();
                ToggleSwitchObrNoise.IsOn = ClassUserSetUp.ObrNoise;
                TextBloxKoefNoise.Text = ClassUserSetUp.KoefNoise.ToString();
               TextBloxAmpNoise.Text = ClassUserSetUp.AmpNoise.ToString();
                
                first = false;
                Avto_Toggled(null, null);
                flagFileSetup = true;
                FileOb_Toggled(null, null);
                if (MainPage.FileEvent != null)
                {for(int i=0; i< MainPage.FileEvent.Length; i++)
                    {
                        StorageFile storageFile = MainPage.FileEvent[i];
                        BasicProperties bb = await storageFile.GetBasicPropertiesAsync();

                        // Application now has read/write access to the picked file
                        ViewModel.AddFile(new ClassСписокList { Status = false, file1 = storageFile, StatusSize = 0, basicProperties = await storageFile.GetBasicPropertiesAsync() });
                       
                    }
                    
                    listView1.SelectedIndex = 0;
                    MainPage.FileEvent = null;
                    mySplitView.IsPaneOpen = true;


                }

            }

        }
     
    

        private void AppBarButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }
        TextBlock gg;
        TextBox gq;

        private void Avto_Toggled(object sender, RoutedEventArgs e)
        {
            if (ToggleSwitchAuto.IsOn == true)
            {
                //   var lastControl = stacPanNast.Children.LastOrDefault();
                // stacPanNast.Children.Remove(gg);
                //  stacPanNast.Children.Remove(gq);
            }
            else
            {
                gg = new TextBlock();
                gq = new TextBox();
                gq.IsEnabled = true;
                gg.Text = "Плата";
                gq.Text = "У1";
                gq.IsReadOnly = false;
                //  stacPanNast.Children.Add(gg);
                //  stacPanNast.Children.Add(gq);
            }


        }
    


        List<Byte> listDataAll;
        /// <summary>
        /// Окрывает файл, разбивает на пакеты и помещает на обработку с информацией о файле
        /// </summary>
        /// <param name="nBaaK"></param>
        /// <param name="leng"></param>
        /// <param name="nameRan"></param>
        /// 
        bool flagFileSetup = false;
        object myLockObject = new object();
        public int Count()
        {
            int v = 100;
            lock (myLockObject)
            {
                v = OcherediNaObrab.Count;
            }
            return v;
        }
        private async void ZapicOcheredNaObrabotkyAsync(string nBaaK, int leng, string nameRan, List<ClassСписокList> listt)
        {

            int ccc = 0;
            int[] masNul = new int[12];
            for (int i = 0; i < 12; i++)
            {
                masNul[i] = 2058;
            }
            uint numBytesLoaded = 1024;
            uint numBytesLoaded1 = 504648;
            foreach (ClassСписокList d in listt)
            {
                
                //listDataAll = new List<byte>();
                bool flagUserSetup = true;
                //BasicProperties basicProperties;
             
                          /* try
                           {


                               basicProperties = await d.file1.GetBasicPropertiesAsync();
                               if (basicProperties.Size > 136000000)
                               {
                                   flagUserSetup = true;
                               }
                               else
                               {
                                   flagUserSetup = false;
                               }
                           }
                           catch(Exception ex)
                           {
                               flagUserSetup = true;
                      
                           }
                
                      */
                string tipN = "T";
               // tipN = d.file1.DisplayName.Split('_')[2];
                string[] tipParser = d.file1.DisplayName.Split('_');
                if(tipParser.Length>2)
                {
                    tipN = tipParser[2];
                }
                else
                {

                }

           
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
() =>
{
    d.Status = true;
});
                    //    break;
                 //   }
               // }
                if (flagUserSetup)
                {
                    try
                    {
                            var stream = await d.file1.OpenAsync(Windows.Storage.FileAccessMode.Read);
                          //  ulong size = stream.Size;
                          
                            bool end = false;
                            uint kol = 0;
                       List<byte> dataOnePac = new List<byte>();

                        int tecpos = 0;
                            int countFlagEnt = 0;
                            int pac = 0;
                            while (!end)
                            {
                                using (var inputStream = stream.GetInputStreamAt(kol * numBytesLoaded1))
                                {

                                    using (var dataReader = new Windows.Storage.Streams.DataReader(inputStream))
                                    {
                                        numBytesLoaded = await dataReader.LoadAsync(numBytesLoaded1);
                                    if (numBytesLoaded < numBytesLoaded1 || numBytesLoaded == 0)
                                    {

                                        end = true;
                                    }
                                    else
                                    {
                                        byte[] dd = new byte[numBytesLoaded];
                                        dataReader.ReadBytes(dd);
                                        if (dd[numBytesLoaded - 1] == 0xFF && dd[numBytesLoaded - 2] == 0xFF && dd[numBytesLoaded - 3] == 0xFF && dd[numBytesLoaded - 4] == 0xFF)
                                        {

                                            int cc1 = Count();
                                            if (cc1 > 1800)
                                            {
                                                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
() =>
{
    d.StatusP = true;
});
                                                Thread.Sleep(10000);
                                                long totalMemory = GC.GetTotalMemory(false);
                                                GC.Collect();
                                                GC.WaitForPendingFinalizers();
                                                // for(int f=0; f<10000; f++)
                                                //  {
                                                //      int xx = 0;
                                                //  }
                                                //Thread.Sleep(20000);
                                                while (Count() > 500)
                                                {
                                                    Thread.Sleep(5000);
                                                }
                                                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
() =>
{
    d.StatusP = true;
});
                                            }
                                            OcherediNaObrab.Enqueue(new MyclasDataizFile { NameFile = d.file1.DisplayName, Buf00 = dd, LenghtChenel = leng, НулеваяЛиния = masNul, NameBaaR12 = nBaaK.ToString(), Ran = nameRan, tipName = tipN });
                                            pac++;
                                       
                                            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => { d.StatusSize += (ulong)dd.Length; ViewModel.CountNaObrabZ++; });


                                        }
                                       
                                        else
                                        {


                                            if ((dd[numBytesLoaded - 1] == 0xFE && dd[numBytesLoaded - 2] == 0xFE && dd[numBytesLoaded - 3] == 0xFE && dd[numBytesLoaded - 4] == 0xFE) || (numBytesLoaded > 502640 && numBytesLoaded < 504648))
                                            {

                                            }

                                            else
                                        {

                                               
                                                for (int i = 0; i < numBytesLoaded; i++)
                                            {

                                                int cc1 = Count();
                                                if (cc1 > 1800)
                                                {
                                                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
    () =>
    {
        d.StatusP = true;
    });
                                                    Thread.Sleep(10000);
                                                    long totalMemory = GC.GetTotalMemory(false);
                                                    GC.Collect();
                                                    GC.WaitForPendingFinalizers();
                                                    // for(int f=0; f<10000; f++)
                                                    //  {
                                                    //      int xx = 0;
                                                    //  }
                                                    //Thread.Sleep(20000);
                                                    while (Count() > 500)
                                                    {
                                                        Thread.Sleep(5000);
                                                    }
                                                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
() =>
{
    d.StatusP = true;
});
                                                }



                                                var b = dd[i];

                                                dataOnePac.Add(b);
                                                tecpos++;
                                                if (b == 0xFF)
                                                {
                                                    countFlagEnt++;
                                                    if (countFlagEnt == 4)
                                                        {
                                                            Debug.WriteLine(numBytesLoaded.ToString() + "\t" + tecpos);
                                                            if (tecpos > 502640 && tecpos < 504648)
                                                            {
                                                                //Debug.WriteLine(numBytesLoaded.ToString() + "\t" + "ggg");
                                                                dataOnePac = null;
                                                            }
                                                            else
                                                            {

                                                                //Debug.WriteLine(numBytesLoaded.ToString() + "\t" + "g11gg");
                                                                OcherediNaObrab.Enqueue(new MyclasDataizFile { NameFile = d.file1.DisplayName, Buf00 = dataOnePac.ToArray(), LenghtChenel = leng, НулеваяЛиния = masNul, NameBaaR12 = nBaaK.ToString(), Ran = nameRan, tipName = tipN });
                                                            }
                                                                pac++;

                                                                dataOnePac = new List<byte>();
                                                                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
            () =>
            {
                d.StatusSize += 504648;
                ViewModel.CountNaObrabZ++;
            });
                                                                //Thread.Sleep(1000);
                                                                countFlagEnt = 0;
                                                                tecpos = 0;
                                                            
                                                    }
                                                }
                                                else
                                                {
                                                    countFlagEnt = 0;
                                                }

                                            }

                                        }



                                    }
                                        }

                                    }
                                }
                                kol++;
                            }
                        stream.Dispose();
                    }
                    catch 
                    {
                       // var  messageDialog = new MessageDialog("ошибка открытия файла" + d.file1.Path +"   ");
                        // await messageDialog.ShowAsync();
                    }


                }
                else
                {
                    try
                    {
                        
                            if(Count() > 1800)
                            {
                                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
() =>
{
d.StatusP = true;
});
                            Thread.Sleep(10000);
                                long totalMemory = GC.GetTotalMemory(false);
                                GC.Collect();
                                GC.WaitForPendingFinalizers();
                                // for(int f=0; f<10000; f++)
                                //  {
                                //      int xx = 0;
                                //  }
                                //Thread.Sleep(20000);
                                while (Count() > 500)
                                {
                                Thread.Sleep(10000);
                                }
                                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
() =>
{
d.StatusP = true;
});
                            }
                         
                        
                     
                        byte[] bb = (await Windows.Storage.FileIO.ReadBufferAsync(d.file1)).ToArray();
                 
                        
                     
                     
                        byte[] dataOnePac = new byte[504648];

                        int tecpos = 0;
                        int countFlagEnt = 0;
                        int pac = 0;
                        for(int i=0; i< bb.Length; i++)
                        {
                            byte b = bb[i];
                      
                            dataOnePac[tecpos] = b;
                            tecpos++;
                            if (b == 0xFF)
                            {
                                countFlagEnt++;
                                if (countFlagEnt == 4)
                                {

                                    OcherediNaObrab.Enqueue(new MyclasDataizFile { NameFile = d.file1.DisplayName, Buf00 = dataOnePac, LenghtChenel = leng, НулеваяЛиния = masNul, NameBaaR12 = nBaaK.ToString(), Ran = nameRan, tipName = tipN });
                                    pac++;

                                    dataOnePac = new Byte[504648];
                                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
() =>
{
d.StatusSize += 504648;
ViewModel.CountNaObrabZ++;
});
                                    //Thread.Sleep(1000);
                                    countFlagEnt = 0;
                                    tecpos = 0;
                                }
                            }
                            else
                            {
                                countFlagEnt = 0;
                            }

                        }
                        
                      
                      
                    }
                    catch
                    {
                        // var  messageDialog = new MessageDialog("ошибка открытия файла" + d.file1.Path +"   ");
                        // await messageDialog.ShowAsync();
                    }

                }
                
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
() =>
{
d.Status = false;
});
            }
           
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();


            }
            

        }



        CancellationTokenSource cancellationTokenSource;
        public void ffg(string text)
        {
            Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                       () => {
                           ExampleInAppNotification.Show(text, 3000);
                       });
        }
        private async void AppBarButton_Click_5(object sender, RoutedEventArgs e)
        {

            var newSession = new ExtendedExecutionSession();
            newSession.Reason = ExtendedExecutionReason.Unspecified;
            newSession.Description = "Raising periodic toasts";
           // newSession.Revoked += SessionRevoked;
            ExtendedExecutionResult result = await newSession.RequestExtensionAsync();

            switch (result)
            {

                case ExtendedExecutionResult.Allowed:
                 
             
            Task task = Task.Run(() => ffg("Обработка запушена в фоновом режиме" + "\n" + "Можно свернуть экран"));
            cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;
            if (ToggleSwitchAuto.IsOn)
            {
                var ness = new MessageDialog("Авто режим не доступен. Выберите ручной режим");
                await ness.ShowAsync();
            }
            else
            {
                string Y = gq.Text;
                ObRing.IsActive = true;



                try
                {

                    Stopwatch watch = Stopwatch.StartNew();
                    watch.Reset();
                    watch.Start();
                    //  var messageDialog = new MessageDialog("Запустили поток");
                    // await messageDialog.ShowAsync();
                    ViewModel.CountObrabSob = 0;
                    List<ClassСписокList> l = new List<ClassСписокList>();
                    foreach(ClassСписокList g in listView1.SelectedItems)
                    {
                        l.Add(g);
                              
                    }
                   
                    FirstDiagnosticFile(l);
                            ViewModel.CountNaObrabZ = 0;
                            Task.Run(() => ZapicOcheredNaObrabotkyAsync(Y, 1, "1", l));
                 //   MessageDialog messageDialog = new MessageDialog("dd");
                   // messageDialog.ShowAsync();

                    await Task.Run(()=> WriteInFileIzOcherediAsync(cancellationToken, ViewModel.cclassUserSetUp));

                    // await WriteInFileIzOcherediAsync(cancellationToken);
                    watch.Stop();
                            ObRing.IsActive = false;
                            colstroc.Text = ViewModel.ClassSobsT.Count.ToString();
                    duration.Text = (watch.ElapsedMilliseconds / 1000).ToString();
                            if ((watch.ElapsedMilliseconds / 1000) != 0)
                            {


                                sobInSec.Text = (ViewModel.ClassSobsT.Count / (watch.ElapsedMilliseconds / 1000)).ToString();
                            }

                            else
                            {
                                sobInSec.Text = "Очень бычстро";
                            }
                   // watch.Reset();
                    var messq = new MessageDialog("Конец");
                    await messq.ShowAsync();
                    
                    

                }
                catch (Exception ex)
                {
                    var mes = new MessageDialog("Ошибка"+ex.ToString());
                    await mes.ShowAsync();
                }



            }
                    break;

                default:
                case ExtendedExecutionResult.Denied:
                    //   rootPage.NotifyUser("Extended execution denied.", NotifyType.ErrorMessage);


                  //  ToastNotificationManager.CreateToastNotifier().Show(toast);
                    newSession.Dispose();
                    break;
            }

        }
       

        /// <summary>
        /// охраняем пакет в файл
        /// </summary>
        public SaveFile SaveFileDelegate;
        public delegate Task SaveFileSob(string nameFile, string nameBAAK, string time, string nameRan, int[] Amp, string nameklaster, int[] Nnut, int[] Nl, Double[] sig);//


        /// <summary>
        /// охраняем данные о событии
        /// </summary>
        public SaveFileSob SaveFileSobDelegate;
        public delegate Task ObrSig(string nameFile, string nemeBAAK, int[,] data1, int[,] dataTail1, string time1, string tipName, ClassUserSetUp classUserSetUp, DataTimeUR dataTimeUR);//

        /// <summary>
        /// охраняем пакет в файл
        /// </summary>
        public ObrSig ObrSigDelegate;




       

      

        private  void sigSave1_Toggled(object sender, RoutedEventArgs e)
        {
            if (ToggleSwitchSaveRaz.IsOn == true)
            {
               
                SaveFileDelegate += SaveAsync;
                ClassUserSetUp.SaveRaz = true;

            }
            else
            {
                
                SaveFileDelegate -= SaveAsync;
                ClassUserSetUp.SaveRaz = false;

            }
        }
        private  void obrSig_Toggled(object sender, RoutedEventArgs e)
        {
            if (ToggleSwitchObrSig.IsOn == true)
            {
                ObrSigDelegate += ObrSigData;
                ClassUserSetUp.ObrSig = true;


            }
            else
            {
                ObrSigDelegate -= ObrSigData;
                ClassUserSetUp.ObrSig = false;


            }
        }
        private void TextBloxDlitN_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(TextBloxDlitN.Text!=null)
            ClassUserSetUp.DlitN3 = Convert.ToInt32(TextBloxDlitN.Text);
        }

     
        private async void AppBarToggleButton_Click(object sender, RoutedEventArgs e)
        {
            ObRing.IsActive = true;
            КолекцияФайловРазвертки.Clear();
            await OpenFolderLocalAsync();
            ObRing.IsActive = false;
        }

    

        /// <summary>
        /// Очищаем таблицы и хранилище с разверткой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AppBarButton_Click_7(object sender, RoutedEventArgs e)
        {
            var g = new ProgressRing();
            g.Width = 60;
            g.Height = 60;
            try
            {
               
                g.IsActive = true;
                gridpan.Children.Add(g);
               
                ContentDialog deleteFileDialog = new ContentDialog
                {
                    Title = "Удалить результаты обработки?",
                    Content = "Будет удалены все результаты обработки файла. Желаете удалить результаты обработки?",
                    PrimaryButtonText = "Удалить",
                    CloseButtonText = "Отмена"
                };

                ContentDialogResult result = await deleteFileDialog.ShowAsync();

                // Delete the file if the user clicked the primary button.
                /// Otherwise, do nothing.
                if (result == ContentDialogResult.Primary)
                {
                    
                    await Delite();
                    ViewModel.ClearData();
                 
                   
                
                    Split1.IsPaneOpen = false;
                }
                else
                {
                    // The user clicked the CLoseButton, pressed ESC, Gamepad B, or the system back button.
                    // Do nothing.
                }


                
            }
            catch (Exception ex)
            {
                var mess = new MessageDialog("ошибка2" + ex);
                await mess.ShowAsync();
            }
            finally
            {
                
               // await ggg();
                gridpan.Children.Remove(g);
            }

        }
        
        private async void AppBarToggleButton_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {


                ObRing.IsActive = true;
                ViewModel.ClassSobsT.Clear();

             

                ObRing.IsActive = false;
            }
            catch (Exception ex)
            {
                var mess = new MessageDialog("ошибка2" + ex);
                await mess.ShowAsync();// КолПакетовОчер++;
            }
        }

        public void Gg()
        {
            Thread.Sleep(5000);
        }
       public async Task ggg( )
        {
            Task myReadDataTask = Task.Run(() => Gg());
            await myReadDataTask;
        }
        private async  void AppBarButton_Click_8(object sender, RoutedEventArgs e)
        {
          IDataView currentView = this.DataGrid.GetDataView();
         foreach(object d in currentView)
            {
                MessageDialog messageDialog = new MessageDialog(d.ToString());
                await messageDialog.ShowAsync();
            }
            
               
            
          
       

        }
        async Task OutputClipboardText()
        {
            int count = 0;
            try
            {


                DataPackageView dataPackageView = Clipboard.GetContent();
                if (dataPackageView.Contains(StandardDataFormats.Text))
                {
                    string text = await dataPackageView.GetTextAsync();
                    // To output the text from this example, you need a TextBlock control
                    char[] rowSplitter = { '\r', '\n' };
                    string[] rowsInClipboard = text.Split(rowSplitter, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 1; i < rowsInClipboard.Length; i++)
                    {
                        string[] rows = rowsInClipboard[i].Split('\t');
                        count = Convert.ToInt32(rows[0]);
                        if (rows[1].Contains("T") || rows[1].Contains("N") || rows[1].Contains("V"))
                        {
                            int[] ii = new int[12];
                            ii[0] = Convert.ToInt16(rows[7]);
                            ii[1] = Convert.ToInt16(rows[8]);
                            ii[2] = Convert.ToInt16(rows[9]);
                            ii[3] = Convert.ToInt16(rows[10]);
                            ii[4] = Convert.ToInt16(rows[11]);
                            ii[5] = Convert.ToInt16(rows[12]);
                            ii[6] = Convert.ToInt16(rows[13]);
                            ii[7] = Convert.ToInt16(rows[14]);
                            ii[8] = Convert.ToInt16(rows[15]);
                            ii[9] = Convert.ToInt16(rows[16]);
                            ii[10] = Convert.ToInt16(rows[17]);
                            ii[11] = Convert.ToInt16(rows[18]);
                            int ic = 1;
                            List<ClassSobNeutron> ll = new List<ClassSobNeutron>();
                            for (int it = 19; it < 31; it++)
                            {
                                if (Convert.ToInt16(rows[it]) > 0)
                                {
                                    for (int d = 0; d < Convert.ToInt16(rows[it]); d++)
                                    {
                                        ll.Add(new ClassSobNeutron() { D = ic, Amp = 0, TimeAmp = 0, TimeEnd = 0, TimeEnd3 =0, TimeFirst = 0, TimeFirst3 = 0 });
                                  

                                    }
                                    
                                }
                                ic++;

                            }

                            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
      () =>
      {
          ViewModel.ClassSobsT.Add(new ClassSob()
          {
              nameFile = rows[1],
              nameklaster = rows[2],
              nameBAAK = rows[3],
              time = rows[4],
             mAmp = ii,
        
               // Nnut0 = Convert.ToInt16(rows[19]),
              //  Nnut1 = Convert.ToInt16(rows[20]),
              //  Nnut2 = Convert.ToInt16(rows[21]),
               // Nnut3 = Convert.ToInt16(rows[22]),
              //  Nnut4 = Convert.ToInt16(rows[23]),
              //  Nnut5 = Convert.ToInt16(rows[24]),
               // Nnut6 = Convert.ToInt16(rows[25]),
               // Nnut7 = Convert.ToInt16(rows[26]),
              //  Nnut8 = Convert.ToInt16(rows[27]),
              //  Nnut9 = Convert.ToInt16(rows[28]),
               // Nnut10 = Convert.ToInt16(rows[29]),
               // Nnut11 = Convert.ToInt16(rows[30]),
 classSobNeutronsList=ll,
                sig0 = Convert.ToDouble(rows[31].Replace(".", ",")),
                sig1 = Convert.ToDouble(rows[32].Replace(".", ",")),
                sig2 = Convert.ToDouble(rows[33].Replace(".", ",")),
                sig3 = Convert.ToDouble(rows[34].Replace(".", ",")),
                sig4 = Convert.ToDouble(rows[35].Replace(".", ",")),
                sig5 = Convert.ToDouble(rows[36].Replace(".", ",")),
                sig6 = Convert.ToDouble(rows[37].Replace(".", ",")),
                sig7 = Convert.ToDouble(rows[38].Replace(".", ",")),
                sig8 = Convert.ToDouble(rows[39].Replace(".", ",")),
                sig9 = Convert.ToDouble(rows[40].Replace(".", ",")),
                sig10 = Convert.ToDouble(rows[41].Replace(".", ",")),

                sig11 = Convert.ToDouble(rows[42].Replace(".", ",")),
                
              SumAmp = Convert.ToInt32(rows[5]),
               // SumNeu = Convert.ToInt16(rows[6]),
                
              Nnull0 = Convert.ToInt16(rows[43]),
              Nnull1 = Convert.ToInt16(rows[44]),
              Nnull2 = Convert.ToInt16(rows[45]),
              Nnull3 = Convert.ToInt16(rows[46]),
              Nnull4 = Convert.ToInt16(rows[47]),
              Nnull5 = Convert.ToInt16(rows[48]),
              Nnull6 = Convert.ToInt16(rows[49]),
              Nnull7 = Convert.ToInt16(rows[50]),
              Nnull8 = Convert.ToInt16(rows[51]),
              Nnull9 = Convert.ToInt16(rows[52]),
              Nnull10 = Convert.ToInt16(rows[53]),
              Nnull11 = Convert.ToInt16(rows[54])
             
          });
          ViewModel.CountNaObrabZ++;
          ViewModel.CountObrabSob++;

      });
                           
                        }
                        else
                        {
                            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
      () =>
      {
          ViewModel.ClassSobsT.Add(new ClassSob()
          {
              nameFile = rows[2],
              nameklaster = rows[4],
              nameBAAK = rows[3],
              time = rows[1],
             /* Amp0 = Convert.ToInt16(rows[7]),
              Amp1 = Convert.ToInt16(rows[8]),
              Amp2 = Convert.ToInt16(rows[9]),
              Amp3 = Convert.ToInt16(rows[10]),
              Amp4 = Convert.ToInt16(rows[11]),
              Amp5 = Convert.ToInt16(rows[12]),
              Amp6 = Convert.ToInt16(rows[13]),
              Amp7 = Convert.ToInt16(rows[14]),
              Amp8 = Convert.ToInt16(rows[15]),
              Amp9 = Convert.ToInt16(rows[16]),
              Amp10 = Convert.ToInt16(rows[17]),
              Amp11 = Convert.ToInt16(rows[18]),
              */
             // Nnut0 = Convert.ToInt16(rows[19]),
             // Nnut1 = Convert.ToInt16(rows[20]),
              //Nnut2 = Convert.ToInt16(rows[21]),
             // Nnut3 = Convert.ToInt16(rows[22]),
             // Nnut4 = Convert.ToInt16(rows[23]),
             // Nnut5 = Convert.ToInt16(rows[24]),
             // Nnut6 = Convert.ToInt16(rows[25]),
            //  Nnut7 = Convert.ToInt16(rows[26]),
            //  Nnut8 = Convert.ToInt16(rows[27]),
            //  Nnut9 = Convert.ToInt16(rows[28]),
            //  Nnut10 = Convert.ToInt16(rows[29]),
            //  Nnut11 = Convert.ToInt16(rows[30]),

              sig0 = Convert.ToDouble(rows[43]),
              sig1 = Convert.ToDouble(rows[44]),
              sig2 = Convert.ToDouble(rows[45]),
              sig3 = Convert.ToDouble(rows[46]),
              sig4 = Convert.ToDouble(rows[47]),
              sig5 = Convert.ToDouble(rows[48]),
              sig6 = Convert.ToDouble(rows[49]),
              sig7 = Convert.ToDouble(rows[50]),
              sig8 = Convert.ToDouble(rows[51]),
              sig9 = Convert.ToDouble(rows[52]),
              sig10 = Convert.ToDouble(rows[53]),
              sig11 = Convert.ToDouble(rows[54]),
              SumAmp = Convert.ToInt32(rows[5]),
              SumNeu = Convert.ToInt16(rows[6]),
              Nnull0 = Convert.ToInt16(rows[31]),
              Nnull1 = Convert.ToInt16(rows[32]),
              Nnull2 = Convert.ToInt16(rows[33]),
              Nnull3 = Convert.ToInt16(rows[34]),
              Nnull4 = Convert.ToInt16(rows[35]),
              Nnull5 = Convert.ToInt16(rows[36]),
              Nnull6 = Convert.ToInt16(rows[37]),
              Nnull7 = Convert.ToInt16(rows[38]),
              Nnull8 = Convert.ToInt16(rows[39]),
              Nnull9 = Convert.ToInt16(rows[40]),
              Nnull10 = Convert.ToInt16(rows[41]),
              Nnull11 = Convert.ToInt16(rows[42])
          });

      });
                        }
                   
                    }
                   
                }
            }
            catch(Exception ex)
            {
                MessageDialog messageDialog = new MessageDialog(ex.ToString());
                await messageDialog.ShowAsync();
            }
        }
        private static void ReadXmlFile(string filename)
        {
            // Создаем экземпляр Xml документа.
            var doc = new XmlDocument();

            // Загружаем данные из файла.
            doc.Load(filename);

            // Получаем корневой элемент документа.
            var root = doc.DocumentElement;

            // Используем метод для рекурсивного обхода документа.
            PrintItem(root);
        }

        /// <summary>
        /// Метод для отображения содержимого xml элемента.
        /// </summary>
        /// <remarks>
        /// Получает элемент xml, отображает его имя, затем все атрибуты
        /// после этого переходит к зависимым элементам.
        /// Отображает зависимые элементы со смещением вправо от начала строки.
        /// </remarks>
        /// <param name="item"> Элемент Xml. </param>
        /// <param name="indent"> Количество отступов от начала строки. </param>
        private static void PrintItem(XmlElement item, int indent = 0)
        {
            // Выводим имя самого элемента.
            // new string('\t', indent) - создает строку состоящую из indent табов.
            // Это нужно для смещения вправо.
            // Пробел справа нужен чтобы атрибуты не прилипали к имени.
            Console.Write($"{new string('\t', indent)}{item.LocalName} ");

            // Если у элемента есть атрибуты, 
            // то выводим их поочередно, каждый в квадратных скобках.
            foreach (XmlAttribute attr in item.Attributes)
            {
                Console.Write($"[{attr.InnerText}]");
            }

            // Если у элемента есть зависимые элементы, то выводим.
            foreach (var child in item.ChildNodes)
            {
                if (child is XmlElement node)
                {
                    // Если зависимый элемент тоже элемент,
                    // то переходим на новую строку 
                    // и рекурсивно вызываем метод.
                    // Следующий элемент будет смещен на один отступ вправо.
                    Console.WriteLine();
                    PrintItem(node, indent + 1);
                }

                if (child is XmlText text)
                {
                    // Если зависимый элемент текст,
                    // то выводим его через тире.
                    Console.Write($"- {text.InnerText}");
                }
            }
        }
       /* private async void AppBarToggleButton_Click_3(object sender, RoutedEventArgs e)
        {
            ObRing.IsActive = true;
            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add("*");

            Windows.Storage.StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                // Application now has read/write access to all contents in the picked folder
                // (including other sub-folder contents)
                Windows.Storage.AccessCache.StorageApplicationPermissions.
                FutureAccessList.AddOrReplace("PickedFolderToken", folder);

                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

                StorageFolder storageFolderRazvertka = await storageFolder.CreateFolderAsync("Развертка", CreationCollisionOption.OpenIfExists);

                IReadOnlyList<StorageFile> fileList =
                    await storageFolderRazvertka.GetFilesAsync();
               
                foreach (StorageFile file in fileList)
                {
                   
                    await file.CopyAsync(folder);
                }

            }
            else
            {

            }
            ObRing.IsActive = false;
        }
        */
        private async void AppBarToggleButton_Click_4(object sender, RoutedEventArgs e)
        {
            gridMenedger.Visibility = Visibility.Visible;
            SaveAllMenedger();
        }

      /*  private async void AppBarToggleButton_Click_5(object sender, RoutedEventArgs e)
        {
            ObRing.IsActive = true;
            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add("*");

            Windows.Storage.StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                // Application now has read/write access to all contents in the picked folder
                // (including other sub-folder contents)
                Windows.Storage.AccessCache.StorageApplicationPermissions.
                FutureAccessList.AddOrReplace("PickedFolderToken", folder);


                var storageFolder = ApplicationData.Current.LocalFolder; ;
                StorageFolder storageFolderN = await storageFolder.CreateFolderAsync("Нейтроны", CreationCollisionOption.OpenIfExists);
                IReadOnlyList<StorageFile> fileList2 =
                await storageFolderN.GetFilesAsync();

                foreach (StorageFile file in fileList2)
                {
                    await file.CopyAsync(folder);
                }

            }
            else
            {

            }
            ObRing.IsActive = false;
        }
        */
        private void FileOb_Toggled(object sender, RoutedEventArgs e)
        {
            //  if (FileOb.IsOn == true)
            //  {
            //     flagFileSetup = true;
            // }
            //  else
            //  {
            //     flagFileSetup = false;
            //  }
        }

        private void AppBarButton_Click_9(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
        }

        private async void MapControl1_MapTapped(Windows.UI.Xaml.Controls.Maps.MapControl sender, Windows.UI.Xaml.Controls.Maps.MapInputEventArgs args)
        {
            Geopoint pos = args.Location;
            Point pos1 = args.Position;
            MessageDialog messageDialog = new MessageDialog(pos.Position.Longitude.ToString() + "  " + pos.Position.Latitude.ToString());
            await messageDialog.ShowAsync();


        }

        object ind;


        bool poc = true;
        private async void DataGrid_SelectionChanged(object sender, Telerik.UI.Xaml.Controls.Grid.DataGridSelectionChangedEventArgs e)
        {
            if (DataGrid.SelectedItem != null)
            {


                // this.DataGrid.ShowRowDetailsForItem(newCheckedItem);

                //  else

                //  this.DataGrid.HideRowDetailsForItem(newCheckedItem);






                ind = DataGrid.SelectedItem;

                if (ind.ToString() == "DataYRAN.ClassSob")
                {
                    try
                    {


                        ClassSob classSob = (ClassSob)DataGrid.SelectedItem;
                        MessageDialog messageDialog = new MessageDialog(classSob.dateUR.TimeString());
                        await messageDialog.ShowAsync();
                        if (poc)
                        {
                          //  this.DataGrid.ShowRowDetailsForItem(classSob);

                        }
                        else
                        {
                          //  this.DataGrid.HideRowDetailsForItem(classSob);
                         
                        }
                        
                       
                        List<ClassSob> classSobsL = new List<ClassSob>();
                        classSobsL.Add(classSob);
                        await MyUser.ShowDetecAsync(classSobsL);
                        await MyUsern.ShowDetecТAsync(classSobsL);
                    }
                    catch (Exception ex)
                    {
                        MessageDialog messageDialog = new MessageDialog(ex.ToString());
                        await messageDialog.ShowAsync();
                    }

                }


                //  Split1.IsPaneOpen = true;

                //classSobColl


            }

            else
            {
               
            }
        }
        private void DataGrid_SelectionChangedPlox(object sender, Telerik.UI.Xaml.Controls.Grid.DataGridSelectionChangedEventArgs e)
        {
            if (DataGridPlox.SelectedItem != null)
            {
                //Split1Plox.IsPaneOpen = true;
                Split1Plox.IsPaneOpen = !Split1Plox.IsPaneOpen;

            }
            else
            {
                //Split1Plox.IsPaneOpen = false;
            }
          
        }
        private  void AppBarToggleButton_Click_2(object sender, RoutedEventArgs e)
        {

        }
        private  void UserSetUp_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SetUpUser));
            /*  CoreApplicationView newView = CoreApplication.CreateNewView();
              int newViewId = 0;
              await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
              {
                  Frame frame = new Frame();
                  frame.Navigate(typeof(SetUpUser), null);
                  Window.Current.Content = frame;
                  // You have to activate the window in order to show it later.
                  Window.Current.Activate();

                  newViewId = ApplicationView.GetForCurrentView().Id;
              });
              bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
              */

        }
        private async void SaveUserSetUp_clic(object sender, RoutedEventArgs e)
        {
            try
            {

                ViewModel.SaveUserSetUp();
               // ClassUserSetUp.saveUseSet();
               // ClassUserSetUp.saveUseSet1();
                ExampleInAppNotification.Show("Настройки успешно сохранены в память", 2000);
            }
            catch(Exception)
            {
                MessageDialog messageDialog = new MessageDialog("Произошла ошибка при сохранении настроек");
              await  messageDialog.ShowAsync();
            }

        }
  
        private async void AppBarButton_Save(object sender, RoutedEventArgs e)
        {

            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add("*");

            Windows.Storage.StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                // Application now has read/write access to all contents in the picked folder
                // (including other sub-folder contents)
                Windows.Storage.AccessCache.StorageApplicationPermissions.
                FutureAccessList.AddOrReplace("PickedFolderToken", folder);

                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

                int i = 0;
                if (ViewModel._DataSobColli.Count != 0)
                {
                    using (StreamWriter writer =
                   new StreamWriter(await folder.OpenStreamForWriteAsync(
                   "ОбщиеСоб.txt", CreationCollisionOption.OpenIfExists)))
                    {
                        string sSob = "n" + "\t" + "time" + "\t" + "sumAmpl" + "\t" + "sumNeut" + "\t" + "sumClust" + "\t" + "sumDecUp";


                        await writer.WriteLineAsync(sSob);
                        foreach (ClassSobColl sob in ViewModel._DataSobColli)
                        {
                            i++;
                            string Sob = i + "\t" + sob.StartTime + "\t" + sob.SummAmpl + "\t" + sob.SummNeu + "\t" + sob.SumClast + "\t" + sob.SumClastUp;
                            await writer.WriteLineAsync(Sob);
                        }
                    }
                }


                if (_DataColecSob2.Count != 0)
                {
                    using (StreamWriter writer =
                   new StreamWriter(await folder.OpenStreamForWriteAsync(
                   "СреднЗначОбщегоСобытия.txt", CreationCollisionOption.OpenIfExists)))
                    {
                        string sSob = "Ampl" + "\t" + "Sredn" + "\t" + "3sig";


                        await writer.WriteLineAsync(sSob);
                        foreach (ClassSobObrZav sob in _DataColecSob2)
                        {
                            i++;
                            string Sob = sob.amp + "\t" + sob.sredN + "\t" + sob.sig;
                            await writer.WriteLineAsync(Sob);
                        }
                    }
                }

            }
            else
            {

            }

            var mess = new MessageDialog("Сохранение завершено");
            await mess.ShowAsync();
        }
        private async void AppBarButton_Play(object sender, RoutedEventArgs e)
        {
            try
            {
               
                
               
                int MaxDur = Convert.ToInt16(TimeGate.Text);
                int MaxAmpl = Convert.ToInt16(MinAmplDetect.Text);
                int MinClust = Convert.ToInt16(MinClustDec.Text);
            await  Task.Run(()=>  ObchSobURAN(MaxDur, MaxAmpl, MinClust));
               



            }
            catch (Exception ex)
            {
                MessageDialog messageDialog = new MessageDialog(ex.ToString());
                await messageDialog.ShowAsync();
            }

        }
        private Double Sum(List<int> n, double x)
        {
            Double res = 0;
            foreach (int i in n)
            {
                res = res + Math.Pow((i - x), 2);
            }
            return res;
        }
        public void CountPorogs(ClassSob sob, int porog, out int c)
        {
            c = 0;

            if (Convert.ToInt32(sob.mAmp[0]) >= porog)
            {
                c++;
            }
            if (Convert.ToInt32(sob.mAmp[1]) >= porog)
            {
                c++;
            }
            if (Convert.ToInt32(sob.mAmp[2]) >= porog)
            {
                c++;
            }
            if (Convert.ToInt32(sob.mAmp[3]) >= porog)
            {
                c++;
            }
            if (Convert.ToInt32(sob.mAmp[4]) >= porog)
            {
                c++;
            }
            if (Convert.ToInt32(sob.mAmp[5]) >= porog)
            {
                c++;
            }
            if (Convert.ToInt32(sob.mAmp[6]) >= porog)
            {
                c++;
            }
            if (Convert.ToInt32(sob.mAmp[7]) >= porog)
            {
                c++;
            }
            if (Convert.ToInt32(sob.mAmp[8]) >= porog)
            {
                c++;
            }
            if (Convert.ToInt32(sob.mAmp[9]) >= porog)
            {
                c++;
            }
            if (Convert.ToInt32(sob.mAmp[10]) >= porog)
            {
                c++;
            }
            if (Convert.ToInt32(sob.mAmp[11]) >= porog)
            {
                c++;
            }

        }
        private void AppBarButton_Clear(object sender, RoutedEventArgs e)
        {
            ViewModel._DataSobColli.Clear();
        }

        private void ToggleSwitchObrNoise_Toggled(object sender, RoutedEventArgs e)
        {
            if (ToggleSwitchObrNoise.IsOn == true)
            {
                
                ClassUserSetUp.ObrNoise = true;


            }
            else
            {
               
                ClassUserSetUp.ObrNoise = false;


            }
          
        }
        private async void ButtonMenu_NewProgect(object sender, RoutedEventArgs e)
        {
          
          //  MainPage mainPage = new MainPage();
            CoreApplicationView newView = CoreApplication.CreateNewView();
             int newViewId = 0;
             await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
             {
                 Frame frame = new Frame();
                 frame.Navigate(typeof(BlankPageObrData), null);
                 Window.Current.Content = frame;
                 // You have to activate the window in order to show it later.
                 Window.Current.Activate();

                 newViewId = ApplicationView.GetForCurrentView().Id;
             });
             bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
            

        }

     
        public void pod(string title)
        {
            
            // Construct the visuals of the toast
            ToastVisual visual = new ToastVisual()
            {
                BindingGeneric = new ToastBindingGeneric()
                {
                    Children =
        {
            new AdaptiveText()
            {
                Text = title
            }

         

           
        }

                    
                }
            };

            // In a real app, these would be initialized with actual data
            int conversationId = 384928;

            // Now we can construct the final toast content
            ToastContent toastContent = new ToastContent()
            {
                Visual = visual,
                // Arguments when the user taps body of toast
                Launch = new QueryString()
    {
        { "action", "viewConversation" },
        { "conversationId", conversationId.ToString() }

    }.ToString()
            };

            // And create the toast notification
            toast = new ToastNotification(toastContent.GetXml());
            toast.Tag = "18365";
            toast.Group = "wallPosts";
        }
     

        private void TextBloxPorogN_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
           
                ClassUserSetUp.PorogN = Convert.ToInt32(TextBloxPorogN.Text);
            
           

        }

        private void TextBloxDlitN_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            ClassUserSetUp.PorogN = Convert.ToInt32(TextBloxPorogN.Text);
        }

        private void TextBloxKoefNoise_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            if (TextBloxKoefNoise.Text != null)
            {
                ClassUserSetUp.KoefNoise = Convert.ToDouble(TextBloxKoefNoise.Text);
            }
        }
       public async void OnFileActivated(FileActivatedEventArgs args)
        {
            MessageDialog messageDialog=new MessageDialog("gfhf");
            messageDialog.ShowAsync();
            // TODO: Handle file activation
            // The number of files received is args.Files.Size
            // The name of the first file is args.Files[0].Name
        }
        private void TextBloxAmpNoise_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            if (TextBloxAmpNoise.Text != null)
            {
                ClassUserSetUp.AmpNoise = Convert.ToInt32(TextBloxAmpNoise.Text);
            }
            else
            {

            }

        }
        public void TipD()
        {
            switch (ClassUserSetUp.TipTail)
            {
                case true:
                    TextBloxPorogN.IsEnabled = true;
                    TextBloxDlitN.IsEnabled = true;
                    //ClassUserSetUp.TipTail = true;
                    dataN.IsVisible = true;
                    List55.Visibility = Visibility.Collapsed;
                    List54.Visibility = Visibility.Visible;
                    break;
                case false:
                    TextBloxPorogN.IsEnabled = false;
                    TextBloxDlitN.IsEnabled = false;
                   // ClassUserSetUp.TipTail = false;
                    dataN.IsVisible = false;
                    List55.Visibility = Visibility.Visible;
                    List54.Visibility = Visibility.Collapsed;
                    break;

            }
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            
        }

       
      
        public async Task obrRazv(string nameFile, string time)
        {
           foreach(var v in ViewModel.DataColec)
            {
               
                if(nameFile==v.file1.DisplayName)
                {
                    int[] masNul = new int[12];
                    for (int i = 0; i < 12; i++)
                    {
                        masNul[i] = 2058;
                    }

                   

                        listDataAll = new List<byte>();
                        bool flagUserSetup = true;

                        // foreach(ClassСписокList d1 in _DataColec)
                        //   {
                        //     if(d1==d)
                        //    {
                      
                        //    break;
                        //   }
                        // }
                        if (flagUserSetup)
                        {
                            try
                            {
                          
                                var stream = await v.file1.OpenAsync(Windows.Storage.FileAccessMode.Read);
                                //  ulong size = stream.Size;
                                uint numBytesLoaded = 1024;
                                uint numBytesLoaded1 = 504648;
                                bool end = false;
                                uint kol = 0;
                                Byte[] dataOnePac = new Byte[504648];

                                int tecpos = 0;
                                int countFlagEnt = 0;
                                int pac = 0;
                                while (!end)
                                {
                                    using (var inputStream = stream.GetInputStreamAt(kol * numBytesLoaded1))
                                    {

                                        using (var dataReader = new Windows.Storage.Streams.DataReader(inputStream))
                                        {
                                            numBytesLoaded = await dataReader.LoadAsync(numBytesLoaded1);
                                            if (numBytesLoaded < numBytesLoaded1)
                                            {
                                                end = true;
                                            }

                                            if (numBytesLoaded == 0)
                                            {

                                            }
                                            else
                                            {
                                                for (int i = 0; i < numBytesLoaded; i++)
                                                {
                                                    // while (Count() > 1800)
                                                    // {

                                                    // }
                                                    var b = dataReader.ReadByte();

                                                    dataOnePac[tecpos] = b;
                                                    tecpos++;
                                                    if (b == 0xFF)
                                                    {
                                                        countFlagEnt++;
                                                        if (countFlagEnt == 4)
                                                        {
                                                        int[,] data1 = new int[12, 1024];
                                                        int[,] dataTail1 = new int[12, 20000];
                                                        int[] coutN1 = new int[12];
                                                        string time1 = null;
                                                     
                                                        if (ClassUserSetUp.TipTail)
                                                        {
                                                          ParserBAAK12.ParseBinFileBAAK12.ParseBinFileBAAK200H(dataOnePac, out data1, out time1, out dataTail1);
                                                        }
                                                        else
                                                        {

                                                             ParserBAAK12.ParseBinFileBAAK12.ParseBinFileBAAK200(dataOnePac, 1, out data1, out time1);
                                                        }
                                                        
                                                        if (time== time1)
                                                        {
                                                            ClassRazvertka classRazvertka = new ClassRazvertka() { nameFile1=nameFile, data=data1, dataTail=dataTail1, Time=time1 };
                                                          
                                                            this.Frame.Navigate(typeof(BlankPageRazverta), classRazvertka);
                                                            break;
                                                        }
                                                       // OcherediNaObrab.Enqueue(new MyclasDataizFile { NameFile = v.NameFile, Buf00 = dataOnePac, LenghtChenel = 1, НулеваяЛиния = masNul, NameBaaR12 = "Y", Ran = "Y" });
                                                            pac++;
                                                            dataOnePac = new Byte[504648];
                                                            
                                                            //Thread.Sleep(1000);
                                                            countFlagEnt = 0;
                                                            tecpos = 0;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        countFlagEnt = 0;
                                                    }

                                                }

                                            }

                                        }
                                    }
                                    kol++;
                                }
                            }
                            catch
                            {
                                // var  messageDialog = new MessageDialog("ошибка открытия файла" + d.file1.Path +"   ");
                                // await messageDialog.ShowAsync();
                            }


                        }
                        else
                        {
                            // string nBaaK1;
                            //string Ran;
                            string b2 = v.file1.DisplayName;

                            String[] substrings = b2.Split('.');
                            string result = null;
                            for (int i = 0; i < substrings.Length - 2; i++)
                            {
                                result = result + substrings[i] + ".";
                            }
                            result = result + substrings[substrings.Length - 2];

                        }
                     
                    


                    break;
                }

            }
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            object ff = DataGrid.SelectedItem;
            ClassSob classSob = (ClassSob)ff;
      
          await  obrRazv(classSob.nameFile, classSob.time);
           // this.Frame.Navigate(typeof(BlankPageRazverta), classSob.nameFile);
        }
        private async void AppBarButtonMap(object sender, RoutedEventArgs e)
        {
            if(StacMap.Visibility==Visibility.Collapsed)
            {
                MapControl1.Visibility = Visibility.Visible;
                StacMap.Visibility = Visibility.Visible;
            }
            else
            {
                MapControl1.Visibility = Visibility.Collapsed;
                StacMap.Visibility = Visibility.Collapsed;
            }
        }
        private async void AppBarToggleButton_Click_7(object sender, RoutedEventArgs e)
        {
            if (DataGrid.Visibility == Visibility.Visible && ViewModel.ClassSobsT.Count != 0 || GridStatictik.Visibility==Visibility.Visible)
            {
                DataGrid.Visibility = Visibility.Collapsed;
                GridStatictik.Visibility= Visibility.Collapsed;
                GridGistogram.Visibility = Visibility.Visible;
                List<ClassSob> classSobs = ViewModel.ClassSobsT.ToList<ClassSob>();
                List<int> listFregAll = new List<int>();
                List<int> listFregCh1 = new List<int>();
                string stat=String.Empty;

        
              
                var SobeGroupsAll = classSobs.GroupBy(p => p.SumAmp).OrderBy(g=>g.Key)
                        .Select(g => new { SumAmp = g.Key, Count = g.Count() });
            
                stat += "Amp" + "\t" + "FAКнAll" + "\n";

                foreach (var group in SobeGroupsAll)
                {
                    stat += Convert.ToString(group.SumAmp) + "\t" + group.Count.ToString() + "\n";
                 
                }

                
                  var SobeGroupsCh1 = classSobs.GroupBy(p => p.SumAmp).OrderBy(g => g.Key)
                        .Select(g => new { SumAmp = g.Key, Count = g.Count() });

                stat += "Amp" + "\t"  + "FAКн1" + "\n";
              
                foreach (var group in SobeGroupsCh1)
                {
                    stat += Convert.ToString(group.SumAmp) + "\t" + group.Count.ToString() + "\n";

                }
                EditorG.Document.SetText(Windows.UI.Text.TextSetOptions.ApplyRtfDocumentDefaults, stat);
                this.radChart.DataContext = new double[] { 20, 30, 50, 10, 60, 40, 20, 80 };
            }
            else
            {
                DataGrid.Visibility = Visibility.Visible;
                GridGistogram.Visibility = Visibility.Collapsed;
            }
        }

        private async void AppBarButtonMap_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPageShowMap), ViewModel.ClassSobsT);
            /* CoreApplicationView newView = CoreApplication.CreateNewView();
               int newViewId = 0;
               await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
               {
                Frame frame = new Frame();


                 frame.Navigate(typeof(BlankPageShowMap), ViewModel.ClassSobs);
               Window.Current.Content = frame;
             // You have to activate the window in order to show it later.
                Window.Current.Activate();

                 newViewId = ApplicationView.GetForCurrentView().Id;
              });
              bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
            */
        }

        private void ListView1_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;
        }

        private async void ListView1_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var items = await e.DataView.GetStorageItemsAsync();
                if (items.Count > 0)
                {

                    foreach (StorageFile storageFile in items)
                    {

                        if (storageFile.FileType == ".bin")
                        {
                            try
                            {


                                string[] str = storageFile.DisplayName.Split('_');
                                if (str.Length > 2)
                                {


                                    if (str[2] == "N")
                                    {
                                        NoTailCh.IsChecked = true;
                                    }
                                    if (str[2] == "T")
                                    {
                                        TailCh.IsChecked = true;
                                    }
                                }
                                else
                                {
                                    TailCh.IsChecked = true;
                                }
                            }
                            catch
                            {
                                TailCh.IsChecked = true;
                            }
                            string FileName = storageFile.DisplayName;
                            string FilePath = storageFile.Path;
                          

                            // Application now has read/write access to the picked file
                            ViewModel.AddFile(new ClassСписокList {Status = false, file1 = storageFile, StatusSize = 0, basicProperties = await storageFile.GetBasicPropertiesAsync() });

                        }
                        else
                        {

                        }

                    }
                }

                   
            }
        }

        private void MenuFlyoutItemn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPage1));
        }

        private async void MenuFlyoutItemTabNew_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPageRazverta));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            gridMenedger.Visibility = Visibility.Collapsed;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            gridMenedger.Visibility = Visibility.Collapsed;
        }

        private async void ListViewVid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = (ListView)sender;
            int d = listView.SelectedIndex;
            if(d==0)
            {
                dataFirstTimeV.IsVisible = false;
                dataMaxTime.IsVisible = false;
                datanV.IsVisible = false;
                dataAmpNV.IsVisible = false;
                DataGrid.Visibility= Visibility.Visible;
                DataGrid1.Visibility = Visibility.Collapsed;
                TextBloxPorogN.IsEnabled = true;
                TextBloxDlitN.IsEnabled = true;
              
              //  ClassUserSetUp.TipTail = true;
                dataN.IsVisible = true;
                dataAmp.IsVisible = true;
              
                List55.Visibility = Visibility.Collapsed;
                List54.Visibility = Visibility.Visible;
                DataGrid.ItemsSource = ViewModel.ClassSobsT;
                colstroc.Text = ViewModel.ClassSobsT.Count.ToString();
                

            }
            if (d == 1)
            {
                dataFirstTimeV.IsVisible = false;
                dataMaxTime.IsVisible = false;
                dataAmpNV.IsVisible = false;
                DataGrid.Visibility = Visibility.Visible;
                DataGrid1.Visibility = Visibility.Collapsed;
                // ClassUserSetUp.TipTail = false;
                dataN.IsVisible = false;
                dataAmp.IsVisible = true;
                datanV.IsVisible = false;
                List55.Visibility = Visibility.Visible;
                List54.Visibility = Visibility.Collapsed;
                DataGrid.ItemsSource = ViewModel.ClassSobsN;
                colstroc.Text = ViewModel.ClassSobsN.Count.ToString();
             
            }
            if (d == 2)
            {
                dataFirstTimeV.IsVisible = true;
                dataMaxTime.IsVisible = true;
                dataAmpNV.IsVisible = true;
                DataGrid.Visibility = Visibility.Visible;
                datanV.IsVisible =true;
                DataGrid1.Visibility = Visibility.Collapsed;
                TextBloxPorogN.IsEnabled = false;
                TextBloxDlitN.IsEnabled = false;
              //  ClassUserSetUp.TipTail = false;
                dataN.IsVisible = false;
           
                dataAmp.IsVisible = false;
           
           
                List55.Visibility = Visibility.Visible;
                List54.Visibility = Visibility.Collapsed;
                DataGrid.ItemsSource = ViewModel.ClassSobsV;
                colstroc.Text = ViewModel.ClassSobsV.Count.ToString();
               
            }
            if (d == 3)
            {
               
            }
            if(d==4)
            {
              


            }





        }

        public async void ObchSobURAN(int MaxDur, int MaxAmpl, int MinClust)
        {
            try
            {
              


             
                int Clust = 0;
                ObservableCollection<ClassSob> cla = new ObservableCollection<ClassSob>();
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
() =>
{
    cla = ViewModel.ClassSobsT;
});
    // ViewModel._DataColecSobCopy = new ObservableCollection<ClassSob>();
    foreach (ClassSob classSob in cla)
                {
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
() =>
{
    ViewModel._DataColecSobCopy.Add(classSob);
});
                }



               

               




               
                while (ViewModel._DataColecSobCopy.Count!=0)
                {
                    ClassSobColl classSobColl = new ClassSobColl();
                    ClassSob clF = ViewModel._DataColecSobCopy.ElementAt(0);
                 classSobColl.col.Add(clF);
                    ViewModel._DataColecSobCopy.RemoveAt(0);
                    
                  if (ViewModel._DataColecSobCopy.Count != 0)
                  {
                        
                        for(int i=0; i< ViewModel._DataColecSobCopy.Count; i++)
                        {
                            ClassSob classSob = ViewModel._DataColecSobCopy.ElementAt(i);
                            if (clF.nameklaster!=classSob.nameklaster)
                            {


                                if (DateNanos.isEventSimul(clF.time, classSob.time, MaxDur))
                                {
                                    classSobColl.col.Add(classSob);
                                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
    () =>
    {
        ViewModel._DataColecSobCopy.RemoveAt(i);
    });
                                    i--;

                                }
                            }

                        }
                        
                      
                  }
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
() =>
{
    textOb.Text = ViewModel._DataColecSobCopy.Count.ToString();
});

                 



                   classSobColl.SumAmpAndNeutronAndClaster();
                   classSobColl.StartTime = clF.time;
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
() =>
{
    ViewModel._DataSobColli.Add(classSobColl);
});
                   

                }
               

            }


            catch (Exception ex)
            {

    await new MessageDialog(ex.ToString()).ShowAsync();

            }
         
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            gridMenedgerAddFile.Visibility = Visibility.Collapsed;
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            gridMenedgerAddFile.Visibility = Visibility.Visible;
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (ChklAll != null && Chkl6 != null)
            {


                if (ChklAll.IsChecked == true)
                {
                    Chkl1.IsChecked = false;
                    Chkl2.IsChecked = false;
                    Chkl3.IsChecked = false;
                    Chkl4.IsChecked = false;
                    Chkl5.IsChecked = false;
                    Chkl6.IsChecked = false;
                }
                else
                {
                    ChklAll.IsChecked = false;
                }
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }
        StorageFolder storage;
        private async void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add("*");

            StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                PathAddFile.Text = folder.Path;
                storage = folder;
                // Application now has read/write access to all contents in the picked folder
                // (including other sub-folder contents)
                /*  Windows.Storage.AccessCache.StorageApplicationPermissions.
                  FutureAccessList.AddOrReplace("PickedFolderToken", folder);




                  IReadOnlyList<StorageFolder> folderList = await folder.GetFoldersAsync();

                  foreach (StorageFolder folder1 in folderList)
                  {
                      IReadOnlyList<StorageFile> fileList = await folder1.GetFilesAsync();

                      // Print the month and number of files in this group.
                      //  //outputText.AppendLine(folder.Name + " (" + fileList.Count + ")");
                      //  var messageDialog = new MessageDialog(folder1.Name + " (" + fileList.Count + ")");
                      //  await messageDialog.ShowAsync();

                      foreach (StorageFile file in fileList)
                      {
                          if (file.FileType == ".bin")
                          {
                              string FileName = file.DisplayName;
                              string FilePath = file.Path;
                              _DataColec.Add(new ClassСписокList { NameFile = FileName, NemePapka = FilePath, Status = false, file1 = file });
                              // Print the name of the file.
                              // outputText.AppendLine("   " + file.Name);
                          }
                      }
                  }

      */
                // var messageDialog = new MessageDialog(folder.Name);
                //await messageDialog.ShowAsync();

            }
            else
            {

            }

        }

        

        private async void Button_Click_7(object sender, RoutedEventArgs e)
        {
            DataPackage dataPackage = new DataPackage();
         

        
              await OutputClipboardText();
            colstroc.Text = ViewModel.ClassSobsT.Count().ToString();
            MessageDialog messageDialog = new MessageDialog("Данные вставлены!!!");
           await messageDialog.ShowAsync();
        }

        private async void DataGrid1_SelectionChanged(object sender, DataGridSelectionChangedEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {
              

                    Split1.IsPaneOpen = !Split1.IsPaneOpen;
                
                
                  object ind = DataGrid1.SelectedItem;
                 
                   
                        ClassSobColl classSob = (ClassSobColl)DataGrid1.SelectedItem;

                        await MyUser.ShowDetecAsync(classSob.col);
                await MyUsern.ShowDetecТAsync(classSob.col);

            }
            else
            {
                Split1.IsPaneOpen = false;
            }

        }
        private ClassSob currentCheckedItem;
        private void OnCheckBoxClick(object sender, RoutedEventArgs e)
        {
            var cb = (CheckBox)sender;
            var newCheckedItem = (ClassSob)cb.DataContext;
            if (cb.IsChecked.HasValue && cb.IsChecked.Value)
            {
                this.DataGrid.ShowRowDetailsForItem(newCheckedItem);
            }
            else
            {
                this.DataGrid.HideRowDetailsForItem(newCheckedItem);
            }

            if (currentCheckedItem != null)
            {
               // currentCheckedItem.HasRowDetails = false;
            }
           // currentCheckedItem = newCheckedItem;
        }
        private async void AppButton_Click_7(object sender, RoutedEventArgs e)
        {
            Split1.IsPaneOpen = !Split1.IsPaneOpen;
        }
        private async void AppButTemp(object sender, RoutedEventArgs e)
        {
            IDataView currentView = this.DataGrid.GetDataView();
            ObservableCollection<ClassSob> classSobs = new ObservableCollection<ClassSob>();
            foreach(ClassSob classSob in currentView)
            {
                classSobs.Add(classSob);
            }
            MessageDialog messageDialog = new MessageDialog(classSobs.Count.ToString());
            await messageDialog.ShowAsync();
            this.Frame.Navigate(typeof(BlankPageTemp), classSobs);

        }

    }
}
