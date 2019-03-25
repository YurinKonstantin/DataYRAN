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
        ObservableCollection<ClassСписокList> _DataColec = new ObservableCollection<ClassСписокList>();

        ObservableCollection<ClassSob> _DataColecSobPlox = new ObservableCollection<ClassSob>();
   
      
       // ObservableCollection<ClassSobNeutron> _DataColecNeu = new ObservableCollection<ClassSobNeutron>();
    
        ClassСписокList _СписокФайловОбработки = new ClassСписокList();

        ObservableCollection<ClassSobObrZav> _DataColecSob2 = new ObservableCollection<ClassSobObrZav>();

        public class Book
        {
            public String title;
            public List<string> gg { get; set; }
        }
        public async void saveSer()
        {
            try
            {
                if (_DataColec.Count>0)
                {
                  

                }
                else
                {
                    MessageDialog messageDialog = new MessageDialog("Данных нет");
                    await messageDialog.ShowAsync();
                }
            }
           
            catch (Exception ex)
            {
                MessageDialog messageDialog = new MessageDialog(ex.ToString());
                await messageDialog.ShowAsync();
            }
        }
        public async void openDeser()
        {
            MessageDialog messageDialog = new MessageDialog("Открытие");
            await messageDialog.ShowAsync();
            XmlSerializer formatter = new XmlSerializer(typeof(ClassProject));
         //   using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
          //  {
          //      ClassProject classProject = (ClassProject)formatter.Deserialize(fs);

            //    foreach(var g in classProject.КолекцияФайловРазверткиP)
            //    {
             //       MessageDialog messageDialog1 = new MessageDialog(g.ToString());
             //       await messageDialog1.ShowAsync();
              //  }
           // }
        }



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
                listView1.ItemsSource = _DataColec;
               
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
                ComboFile.ItemsSource = КолекцияФайловРазвертки;
                first = false;
                Avto_Toggled(null, null);
                flagFileSetup = true;
                FileOb_Toggled(null, null);
                if (MainPage.FileEvent != null)
                {for(int i=0; i< MainPage.FileEvent.Length; i++)
                    {
                        string FileName = MainPage.FileEvent[i].DisplayName;
                        string FilePath = MainPage.FileEvent[i].Path;
                        // Application now has read/write access to the picked file
                        _DataColec.Add(new ClassСписокList { NameFile = FileName, NemePapka = FilePath, Status = false, file1 = MainPage.FileEvent[i] });
                    }
                    
                    listView1.SelectedIndex = 0;
                    MainPage.FileEvent = null;
                    mySplitView.IsPaneOpen = true;


                }

            }

        }
     
        public void AddDataColec(String nameFile, string namePapka, string stat)
        {
            _DataColec.Add(new ClassСписокList() { NameFile = nameFile, NemePapka = namePapka, Status = false });

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


        List<Byte> listDataAll;
        /// <summary>
        /// Окрывает файл, разбивает на пакеты и помещает на обработку с информацией о файле
        /// </summary>
        /// <param name="nBaaK"></param>
        /// <param name="leng"></param>
        /// <param name="nameRan"></param>
        /// 
        bool flagFileSetup = false;
        private async Task ZapicOcheredNaObrabotkyAsync(string nBaaK, int leng, string nameRan, List<ClassСписокList> listt)
        {
            

            int[] masNul = new int[12];
            for (int i = 0; i < 12; i++)
            {
                masNul[i] = 2058;
            }

            foreach (ClassСписокList d in listt)
            {
                
                listDataAll = new List<byte>();
                bool flagUserSetup = true;
                string tipN = "T";
                tipN = d.file1.DisplayName.Split('_')[2];
                
                // foreach(ClassСписокList d1 in _DataColec)
                //   {
                //     if(d1==d)
                //    {
                d.Status = true;
                    //    break;
                 //   }
               // }
                if (flagUserSetup)
                {
                    try
                    {
                            var stream = await d.file1.OpenAsync(Windows.Storage.FileAccessMode.Read);
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
                                             
                                                    OcherediNaObrab.Enqueue(new MyclasDataizFile { NameFile = d.NameFile, Buf00 = dataOnePac, LenghtChenel = leng, НулеваяЛиния = masNul, NameBaaR12 = nBaaK.ToString(), Ran = nameRan, tipName=tipN });
                                                    pac++;
                                                    dataOnePac = new Byte[504648];
                                                    d.StatusSize+= 504648;
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
                    string b2 = d.NameFile;

                    String[] substrings = b2.Split('.');
                    string result = null;
                    for (int i = 0; i < substrings.Length - 2; i++)
                    {
                        result = result + substrings[i] + ".";
                    }
                    result = result + substrings[substrings.Length - 2];

                }
                foreach (ClassСписокList d1 in _DataColec)
                {
                    if (d1 == d)
                    {
                        d1.Status = false;
                        break;
                    }
                }
            }
           
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();


            }
            

        }



        CancellationTokenSource cancellationTokenSource;
        public void ffg()
        {
            Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                       () => {
                           ExampleInAppNotification.Show("Обработка запушена", 2000);
                       });
        }
        private async void AppBarButton_Click_5(object sender, RoutedEventArgs e)
        {
            Task task = Task.Run(() => ffg());
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
                    List<ClassСписокList> l = new List<ClassСписокList>();
                    foreach(ClassСписокList g in listView1.SelectedItems)
                    {
                        l.Add(g);
                    }
                    ZapicOcheredNaObrabotkyAsync(Y, 1, "1", l);
                    await Task.Run(()=> WriteInFileIzOcherediAsync(cancellationToken));

                    // await WriteInFileIzOcherediAsync(cancellationToken);
                    watch.Stop();
                    colstroc.Text = ViewModel.ClassSobsT.Count.ToString();
                    duration.Text = $"Duration (ms): {watch.ElapsedMilliseconds}";
                    if(watch.Elapsed.Seconds!=0)
                    sobInSec.Text = (ViewModel.ClassSobsT.Count / watch.Elapsed.Seconds).ToString();
                    else
                    {
                        sobInSec.Text = "Очень бычстро";
                    }
                   // watch.Reset();
                    var messq = new MessageDialog("Конец");
                    await messq.ShowAsync();
                    ObRing.IsActive = false;
                    

                }
                catch (Exception ex)
                {
                    var mes = new MessageDialog("Ошибка"+ex.ToString());
                    await mes.ShowAsync();
                }


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
        public delegate Task ObrSig(int[] nul, string nameFile, string nemeBAAK, int[,] data1, int[,] dataTail1, string time1, string tipName);//

        /// <summary>
        /// охраняем пакет в файл
        /// </summary>
        public ObrSig ObrSigDelegate;




       

      

        private  void sigSave1_Toggled(object sender, RoutedEventArgs e)
        {
            if (ToggleSwitchSaveRaz.IsOn == true)
            {
                razTab.Visibility = Visibility.Visible;
                SaveFileDelegate += SaveAsync;
                ClassUserSetUp.SaveRaz = true;

            }
            else
            {
                razTab.Visibility = Visibility.Collapsed;
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

        private async void ComboFile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProgR.IsActive = true;
            if (ComboFile.SelectedItem != null)
            {

                ClassСписокList clac = new ClassСписокList();

                int c = ComboFile.SelectedIndex;
                clac = КолекцияФайловРазвертки[c];

                StorageFile sampleFile = clac.file1;
                textT.Text = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
            }
            else
            {

            }
            ProgR.IsActive = false;
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
                    ViewModel.ClassSobsT.Clear();
                    _DataColecSobPlox.Clear();
                    ViewModel.ClassSobNeutrons.Clear();
                   
                
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

                ViewModel.ClassSobNeutrons.Clear();

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

            
            
           
            MessageDialog messageDialog = new MessageDialog(ViewModel.ClassSobsT.Count.ToString()+"\n"+ViewModel.ClassSobsN.Count.ToString());
           await messageDialog.ShowAsync();

        }

        private async void AppBarToggleButton_Click_3(object sender, RoutedEventArgs e)
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

        private async void AppBarToggleButton_Click_4(object sender, RoutedEventArgs e)
        {
            gridMenedger.Visibility = Visibility.Visible;
            SaveAllMenedger();
        }

        private async void AppBarToggleButton_Click_5(object sender, RoutedEventArgs e)
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
      
        public void ShowDeteClea()
        {
            k1d1.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k1d2.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k1d3.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k1d4.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k1d5.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k1d6.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k1d7.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k1d8.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k1d9.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k1d10.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k1d11.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k1d12.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);

            k1d1.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k1d2.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k1d3.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k1d4.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k1d5.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k1d6.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k1d7.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k1d8.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k1d9.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k1d10.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k1d11.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k1d12.Fill = new SolidColorBrush(Windows.UI.Colors.White);


            k2d1.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k2d2.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k2d3.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k2d4.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k2d5.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k2d6.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k2d7.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k2d8.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k2d9.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k2d10.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k2d11.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k2d12.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);

            k2d1.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k2d2.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k2d3.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k2d4.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k2d5.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k2d6.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k2d7.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k2d8.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k2d9.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k2d10.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k2d11.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k2d12.Fill = new SolidColorBrush(Windows.UI.Colors.White);

            k3d1.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k3d2.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k3d3.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k3d4.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k3d5.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k3d6.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k3d7.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k3d8.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k3d9.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k3d10.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k3d11.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k3d12.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);

            k3d1.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k3d2.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k3d3.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k3d4.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k3d5.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k3d6.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k3d7.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k3d8.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k3d9.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k3d10.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k3d11.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k3d12.Fill = new SolidColorBrush(Windows.UI.Colors.White);

            k4d1.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k4d2.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k4d3.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k4d4.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k4d5.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k4d6.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k4d7.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k4d8.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k4d9.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k4d10.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k4d11.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k4d12.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);

            k4d1.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k4d2.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k4d3.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k4d4.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k4d5.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k4d6.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k4d7.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k4d8.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k4d9.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k4d10.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k4d11.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k4d12.Fill = new SolidColorBrush(Windows.UI.Colors.White);

            k5d1.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k5d2.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k5d3.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k5d4.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k5d5.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k5d6.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k5d7.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k5d8.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k5d9.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k5d10.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k5d11.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k5d12.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);

            k5d1.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k5d2.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k5d3.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k5d4.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k5d5.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k5d6.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k5d7.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k5d8.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k5d9.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k5d10.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k5d11.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k5d12.Fill = new SolidColorBrush(Windows.UI.Colors.White);

            k6d1.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k6d2.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k6d3.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k6d4.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k6d5.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k6d6.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k6d7.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k6d8.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k6d9.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k6d10.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k6d11.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k6d12.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);

            k6d1.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k6d2.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k6d3.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k6d4.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k6d5.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k6d6.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k6d7.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k6d8.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k6d9.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k6d10.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k6d11.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k6d12.Fill = new SolidColorBrush(Windows.UI.Colors.White);
        }
        public void ShowDetec(ClassSob classSob)
        {
            ShowDeteClea();
            if (classSob.nameklaster == "1")
            {
                k1d1.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k1d2.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k1d3.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k1d4.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k1d5.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k1d6.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k1d7.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k1d8.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k1d9.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k1d10.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k1d11.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k1d12.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(255, 202, 24, 37));

                short max = classSob.AmpSum().Max();
                short min = classSob.AmpSum().Min();
                double step = max / 5;

                Text3.Text = step.ToString();
                Text2.Text = (2 * step).ToString();
                Text1.Text = (3 * step).ToString();
                Text0.Text = (4 * step).ToString();
                TextMax.Text = max.ToString();

                if (classSob.Amp0 == 0)
                {
                    k1d1.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp0 > 0 && classSob.Amp0 < step)
                {
                    k1d1.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp0 >= step && classSob.Amp0 < 2*step)
                {
                    k1d1.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp0 >=  2*step && classSob.Amp0 < 3*step)
                {
                    k1d1.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp0 >= 3*step && classSob.Amp0 < 4*step)
                {
                    k1d1.Fill = new SolidColorBrush(Windows.UI.Colors.DarkRed);
                }
                if (classSob.Amp0 >= 4*step)
                {
                    k1d1.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }


                if (classSob.Amp1 == 0)
                {
                    k1d2.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp1 > 0 && classSob.Amp1 < step)
                {
                    k1d2.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp1 >= step && classSob.Amp1 < 2 * step)
                {
                    k1d2.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp1 >= 2 * step && classSob.Amp1 < 3 * step)
                {
                    k1d2.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp1 >= 3 * step && classSob.Amp1 < 4 * step)
                {
                    k1d2.Fill = new SolidColorBrush(Windows.UI.Colors.OrangeRed);
                }
                if (classSob.Amp1 >= 4 * step)
                {
                    k1d2.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }


                if (classSob.Amp2 == 0)
                {
                    k1d3.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp2 > 0 && classSob.Amp2 < step)
                {
                    k1d3.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp2 >= step && classSob.Amp2 < 2 * step)
                {
                    k1d3.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp2 >= 2 * step && classSob.Amp2 < 3 * step)
                {
                    k1d3.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp2 >= 3 * step && classSob.Amp2 < 4 * step)
                {
                    k1d3.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp2 >= 4 * step)
                {
                    k1d3.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp3 == 0)
                {
                    k1d4.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp3 > 0 && classSob.Amp3 < step)
                {
                    k1d4.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp3 >= step && classSob.Amp3 < 2 * step)
                {
                    k1d4.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp3 >= 2 * step && classSob.Amp3 < 3 * step)
                {
                    k1d4.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp3 >= 3 * step && classSob.Amp3 < 4 * step)
                {
                    k1d4.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp3 >= 4 * step)
                {
                    k1d4.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp4 == 0)
                {
                    k1d5.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp4 > 0 && classSob.Amp4 < step)
                {
                    k1d5.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp4 >= step && classSob.Amp4 < 2 * step)
                {
                    k1d5.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp4 >= 2 * step && classSob.Amp4 < 3 * step)
                {
                    k1d5.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp4 >= 3 * step && classSob.Amp4 < 4 * step)
                {
                    k1d5.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp4 >= 4 * step)
                {
                    k1d5.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp5 == 0)
                {
                    k1d6.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp5 > 0 && classSob.Amp5 < step)
                {
                    k1d6.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp5 >= step && classSob.Amp5 < 2 * step)
                {
                    k1d6.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp5 >= 2 * step && classSob.Amp5 < 3 * step)
                {
                    k1d6.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp5 >= 3 * step && classSob.Amp5 < 4 * step)
                {
                    k1d6.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp5 >= 4 * step)
                {
                    k1d6.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp6 == 0)
                {
                    k1d7.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp6 > 0 && classSob.Amp6 < step)
                {
                    k1d7.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp6 >= step && classSob.Amp6 < 2 * step)
                {
                    k1d7.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp6 >= 2 * step && classSob.Amp6 < 3 * step)
                {
                    k1d7.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp6 >= 3 * step && classSob.Amp6 < 4 * step)
                {
                    k1d7.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp6 >= 4 * step)
                {
                    k1d7.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp7 == 0)
                {
                    k1d8.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp7 > 0 && classSob.Amp7 < step)
                {
                    k1d8.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp7 >= step && classSob.Amp7 < 2 * step)
                {
                    k1d8.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp7 >= 2 * step && classSob.Amp7 < 3 * step)
                {
                    k1d8.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp7 >= 3 * step && classSob.Amp7 < 4 * step)
                {
                    k1d8.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp7 >= 4 * step)
                {
                    k1d8.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp8 == 0)
                {
                    k1d9.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp8 > 0 && classSob.Amp8 < step)
                {
                    k1d9.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp8 >= step && classSob.Amp8 < 2 * step)
                {
                    k1d9.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp8 >= 2 * step && classSob.Amp8 < 3 * step)
                {
                    k1d9.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp8 >= 3 * step && classSob.Amp8 < 4 * step)
                {
                    k1d9.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp8 >= 4 * step)
                {
                    k1d9.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp9 == 0)
                {
                    k1d10.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp9 > 0 && classSob.Amp9 < step)
                {
                    k1d10.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp9 >= step && classSob.Amp9 < 2 * step)
                {
                    k1d10.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp9 >= 2 * step && classSob.Amp9 < 3 * step)
                {
                    k1d10.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp9 >= 3 * step && classSob.Amp9 < 4 * step)
                {
                    k1d10.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp9 >= 4 * step)
                {
                    k1d10.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp10 == 0)
                {
                    k1d11.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp10 > 0 && classSob.Amp10 < step)
                {
                    k1d11.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp10 >= step && classSob.Amp10 < 2 * step)
                {
                    k1d11.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp10 >= 2 * step && classSob.Amp10 < 3 * step)
                {
                    k1d11.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp10 >= 3 * step && classSob.Amp10 < 4 * step)
                {
                    k1d11.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp10 >= 4 * step)
                {
                    k1d11.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp11 == 0)
                {
                    k1d12.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp11 > 0 && classSob.Amp11 < step)
                {
                    k1d12.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp11 >= step && classSob.Amp11 < 2 * step)
                {
                    k1d12.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp11 >= 2 * step && classSob.Amp11 < 3 * step)
                {
                    k1d12.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp11 >= 3 * step && classSob.Amp11 < 4 * step)
                {
                    k1d12.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp11 >= 4 * step)
                {
                    k1d12.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }
            }
            if (classSob.nameklaster == "2")
            {
                k2d1.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k2d2.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k2d3.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k2d4.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k2d5.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k2d6.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k2d7.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k2d8.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k2d9.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k2d10.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k2d11.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k2d12.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(255, 202, 24, 37));

                short max = classSob.AmpSum().Max();
                short min = classSob.AmpSum().Min();
                int step = (max - min) / 4;

                Text1.Text = step.ToString();
                Text2.Text = (2 * step).ToString();
                Text3.Text = (3 * step).ToString();
                Text4.Text = (4 * step).ToString();

                if (classSob.Amp0 == 0)
                {
                    k2d1.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp0 > 0 && classSob.Amp0 < step)
                {
                    k2d1.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp0 >= step && classSob.Amp0 < 2 * step)
                {
                    k2d1.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp0 >= 2 * step && classSob.Amp0 < 3 * step)
                {
                    k2d1.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp0 >= 3 * step && classSob.Amp0 < 4 * step)
                {
                    k2d1.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp0 >= 4 * step)
                {
                    k2d1.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }


                if (classSob.Amp1 == 0)
                {
                    k2d2.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp1 > 0 && classSob.Amp1 < step)
                {
                    k2d2.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp1 >= step && classSob.Amp1 < 2 * step)
                {
                    k2d2.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp1 >= 2 * step && classSob.Amp1 < 3 * step)
                {
                    k2d2.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp1 >= 3 * step && classSob.Amp1 < 4 * step)
                {
                    k2d2.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp1 >= 4 * step)
                {
                    k2d2.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }


                if (classSob.Amp2 == 0)
                {
                    k2d3.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp2 > 0 && classSob.Amp2 < step)
                {
                    k2d3.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp2 >= step && classSob.Amp2 < 2 * step)
                {
                    k2d3.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp2 >= 2 * step && classSob.Amp2 < 3 * step)
                {
                    k2d3.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp2 >= 3 * step && classSob.Amp2 < 4 * step)
                {
                    k2d3.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp2 >= 4 * step)
                {
                    k2d3.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp3 == 0)
                {
                    k2d4.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp3 > 0 && classSob.Amp3 < step)
                {
                    k2d4.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp3 >= step && classSob.Amp3 < 2 * step)
                {
                    k2d4.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp3 >= 2 * step && classSob.Amp3 < 3 * step)
                {
                    k2d4.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp3 >= 3 * step && classSob.Amp3 < 4 * step)
                {
                    k2d4.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp3 >= 4 * step)
                {
                    k2d4.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp4 == 0)
                {
                    k2d5.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp4 > 0 && classSob.Amp4 < step)
                {
                    k2d5.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp4 >= step && classSob.Amp4 < 2 * step)
                {
                    k2d5.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp4 >= 2 * step && classSob.Amp4 < 3 * step)
                {
                    k2d5.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp4 >= 3 * step && classSob.Amp4 < 4 * step)
                {
                    k2d5.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp4 >= 4 * step)
                {
                    k2d5.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp5 == 0)
                {
                    k2d6.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp5 > 0 && classSob.Amp5 < step)
                {
                    k2d6.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp5 >= step && classSob.Amp5 < 2 * step)
                {
                    k2d6.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp5 >= 2 * step && classSob.Amp5 < 3 * step)
                {
                    k2d6.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp5 >= 3 * step && classSob.Amp5 < 4 * step)
                {
                    k2d6.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp5 >= 4 * step)
                {
                    k2d6.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp6 == 0)
                {
                    k2d7.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp6 > 0 && classSob.Amp6 < step)
                {
                    k2d7.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp6 >= step && classSob.Amp6 < 2 * step)
                {
                    k2d7.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp6 >= 2 * step && classSob.Amp6 < 3 * step)
                {
                    k2d7.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp6 >= 3 * step && classSob.Amp6 < 4 * step)
                {
                    k2d7.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp6 >= 4 * step)
                {
                    k2d7.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp7 == 0)
                {
                    k2d8.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp7 > 0 && classSob.Amp7 < step)
                {
                    k2d8.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp7 >= step && classSob.Amp7 < 2 * step)
                {
                    k2d8.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp7 >= 2 * step && classSob.Amp7 < 3 * step)
                {
                    k2d8.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp7 >= 3 * step && classSob.Amp7 < 4 * step)
                {
                    k2d8.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp7 >= 4 * step)
                {
                    k2d8.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp8 == 0)
                {
                    k2d9.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp8 > 0 && classSob.Amp8 < step)
                {
                    k2d9.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp8 >= step && classSob.Amp8 < 2 * step)
                {
                    k2d9.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp8 >= 2 * step && classSob.Amp8 < 3 * step)
                {
                    k2d9.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp8 >= 3 * step && classSob.Amp8 < 4 * step)
                {
                    k2d9.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp8 >= 4 * step)
                {
                    k2d9.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp9 == 0)
                {
                    k2d10.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp9 > 0 && classSob.Amp9 < step)
                {
                    k2d10.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp9 >= step && classSob.Amp9 < 2 * step)
                {
                    k2d10.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp9 >= 2 * step && classSob.Amp9 < 3 * step)
                {
                    k2d10.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp9 >= 3 * step && classSob.Amp9 < 4 * step)
                {
                    k2d10.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp9 >= 4 * step)
                {
                    k2d10.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp10 == 0)
                {
                    k2d11.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp10 > 0 && classSob.Amp10 < step)
                {
                    k2d11.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp10 >= step && classSob.Amp10 < 2 * step)
                {
                    k2d11.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp10 >= 2 * step && classSob.Amp10 < 3 * step)
                {
                    k2d11.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp10 >= 3 * step && classSob.Amp10 < 4 * step)
                {
                    k2d11.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp10 >= 4 * step)
                {
                    k2d11.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp11 == 0)
                {
                    k2d12.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp11 > 0 && classSob.Amp11 < step)
                {
                    k2d12.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp11 >= step && classSob.Amp11 < 2 * step)
                {
                    k2d12.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp11 >= 2 * step && classSob.Amp11 < 3 * step)
                {
                    k2d12.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp11 >= 3 * step && classSob.Amp11 < 4 * step)
                {
                    k2d12.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp11 >= 4 * step)
                {
                    k2d12.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

            }
            if (classSob.nameklaster == "3")
            {
                k3d1.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k3d2.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k3d3.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k3d4.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k3d5.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k3d6.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k3d7.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k3d8.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k3d9.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k3d10.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k3d11.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k3d12.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(255, 202, 24, 37));

                short max = classSob.AmpSum().Max();
                short min = classSob.AmpSum().Min();
                int step = (max - min) / 4;

                Text1.Text = step.ToString();
                Text2.Text = (2 * step).ToString();
                Text3.Text = (3 * step).ToString();
                Text4.Text = (4 * step).ToString();

                if (classSob.Amp0 == 0)
                {
                    k3d1.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp0 > 0 && classSob.Amp0 < step)
                {
                    k3d1.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp0 >= step && classSob.Amp0 < 2 * step)
                {
                    k3d1.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp0 >= 2 * step && classSob.Amp0 < 3 * step)
                {
                    k3d1.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp0 >= 3 * step && classSob.Amp0 < 4 * step)
                {
                    k3d1.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp0 >= 4 * step)
                {
                    k3d1.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }


                if (classSob.Amp1 == 0)
                {
                    k3d2.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp1 > 0 && classSob.Amp1 < step)
                {
                    k3d2.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp1 >= step && classSob.Amp1 < 2 * step)
                {
                    k3d2.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp1 >= 2 * step && classSob.Amp1 < 3 * step)
                {
                    k3d2.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp1 >= 3 * step && classSob.Amp1 < 4 * step)
                {
                    k3d2.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp1 >= 4 * step)
                {
                    k3d2.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }


                if (classSob.Amp2 == 0)
                {
                    k3d3.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp2 > 0 && classSob.Amp2 < step)
                {
                    k3d3.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp2 >= step && classSob.Amp2 < 2 * step)
                {
                    k3d3.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp2 >= 2 * step && classSob.Amp2 < 3 * step)
                {
                    k3d3.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp2 >= 3 * step && classSob.Amp2 < 4 * step)
                {
                    k3d3.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp2 >= 4 * step)
                {
                    k3d3.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp3 == 0)
                {
                    k3d4.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp3 > 0 && classSob.Amp3 < step)
                {
                    k3d4.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp3 >= step && classSob.Amp3 < 2 * step)
                {
                    k3d4.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp3 >= 2 * step && classSob.Amp3 < 3 * step)
                {
                    k3d4.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp3 >= 3 * step && classSob.Amp3 < 4 * step)
                {
                    k3d4.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp3 >= 4 * step)
                {
                    k3d4.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp4 == 0)
                {
                    k3d5.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp4 > 0 && classSob.Amp4 < step)
                {
                    k3d5.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp4 >= step && classSob.Amp4 < 2 * step)
                {
                    k3d5.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp4 >= 2 * step && classSob.Amp4 < 3 * step)
                {
                    k3d5.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp4 >= 3 * step && classSob.Amp4 < 4 * step)
                {
                    k3d5.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp4 >= 4 * step)
                {
                    k3d5.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp5 == 0)
                {
                    k3d6.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp5 > 0 && classSob.Amp5 < step)
                {
                    k3d6.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp5 >= step && classSob.Amp5 < 2 * step)
                {
                    k3d6.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp5 >= 2 * step && classSob.Amp5 < 3 * step)
                {
                    k3d6.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp5 >= 3 * step && classSob.Amp5 < 4 * step)
                {
                    k3d6.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp5 >= 4 * step)
                {
                    k3d6.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp6 == 0)
                {
                    k3d7.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp6 > 0 && classSob.Amp6 < step)
                {
                    k3d7.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp6 >= step && classSob.Amp6 < 2 * step)
                {
                    k3d7.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp6 >= 2 * step && classSob.Amp6 < 3 * step)
                {
                    k3d7.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp6 >= 3 * step && classSob.Amp6 < 4 * step)
                {
                    k3d7.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp6 >= 4 * step)
                {
                    k3d7.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp7 == 0)
                {
                    k3d8.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp7 > 0 && classSob.Amp7 < step)
                {
                    k3d8.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp7 >= step && classSob.Amp7 < 2 * step)
                {
                    k3d8.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp7 >= 2 * step && classSob.Amp7 < 3 * step)
                {
                    k3d8.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp7 >= 3 * step && classSob.Amp7 < 4 * step)
                {
                    k3d8.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp7 >= 4 * step)
                {
                    k3d8.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp8 == 0)
                {
                    k3d9.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp8 > 0 && classSob.Amp8 < step)
                {
                    k3d9.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp8 >= step && classSob.Amp8 < 2 * step)
                {
                    k3d9.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp8 >= 2 * step && classSob.Amp8 < 3 * step)
                {
                    k3d9.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp8 >= 3 * step && classSob.Amp8 < 4 * step)
                {
                    k3d9.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp8 >= 4 * step)
                {
                    k3d9.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp9 == 0)
                {
                    k3d10.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp9 > 0 && classSob.Amp9 < step)
                {
                    k3d10.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp9 >= step && classSob.Amp9 < 2 * step)
                {
                    k3d10.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp9 >= 2 * step && classSob.Amp9 < 3 * step)
                {
                    k3d10.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp9 >= 3 * step && classSob.Amp9 < 4 * step)
                {
                    k3d10.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp9 >= 4 * step)
                {
                    k3d10.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp10 == 0)
                {
                    k3d11.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp10 > 0 && classSob.Amp10 < step)
                {
                    k3d11.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp10 >= step && classSob.Amp10 < 2 * step)
                {
                    k3d11.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp10 >= 2 * step && classSob.Amp10 < 3 * step)
                {
                    k3d11.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp10 >= 3 * step && classSob.Amp10 < 4 * step)
                {
                    k3d11.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp10 >= 4 * step)
                {
                    k3d11.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp11 == 0)
                {
                    k3d12.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp11 > 0 && classSob.Amp11 < step)
                {
                    k3d12.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp11 >= step && classSob.Amp11 < 2 * step)
                {
                    k3d12.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp11 >= 2 * step && classSob.Amp11 < 3 * step)
                {
                    k3d12.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp11 >= 3 * step && classSob.Amp11 < 4 * step)
                {
                    k3d12.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp11 >= 4 * step)
                {
                    k3d12.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

            }

            if (classSob.nameklaster == "4")
            {
                k4d1.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k4d2.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k4d3.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k4d4.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k4d5.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k4d6.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k4d7.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k4d8.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k4d9.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k4d10.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k4d11.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k4d12.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(255, 202, 24, 37));

                short max = classSob.AmpSum().Max();
                short min = classSob.AmpSum().Min();
                int step = (max - min) / 4;

                Text1.Text = step.ToString();
                Text2.Text = (2 * step).ToString();
                Text3.Text = (3 * step).ToString();
                Text4.Text = (4 * step).ToString();

                if (classSob.Amp0 == 0)
                {
                    k4d1.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp0 > 0 && classSob.Amp0 < step)
                {
                    k4d1.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp0 >= step && classSob.Amp0 < 2 * step)
                {
                    k4d1.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp0 >= 2 * step && classSob.Amp0 < 3 * step)
                {
                    k4d1.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp0 >= 3 * step && classSob.Amp0 < 4 * step)
                {
                    k4d1.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp0 >= 4 * step)
                {
                    k4d1.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }


                if (classSob.Amp1 == 0)
                {
                    k4d2.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp1 > 0 && classSob.Amp1 < step)
                {
                    k4d2.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp1 >= step && classSob.Amp1 < 2 * step)
                {
                    k4d2.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp1 >= 2 * step && classSob.Amp1 < 3 * step)
                {
                    k4d2.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp1 >= 3 * step && classSob.Amp1 < 4 * step)
                {
                    k4d2.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp1 >= 4 * step)
                {
                    k4d2.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }


                if (classSob.Amp2 == 0)
                {
                    k4d3.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp2 > 0 && classSob.Amp2 < step)
                {
                    k4d3.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp2 >= step && classSob.Amp2 < 2 * step)
                {
                    k4d3.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp2 >= 2 * step && classSob.Amp2 < 3 * step)
                {
                    k4d3.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp2 >= 3 * step && classSob.Amp2 < 4 * step)
                {
                    k4d3.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp2 >= 4 * step)
                {
                    k4d3.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp3 == 0)
                {
                    k4d4.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp3 > 0 && classSob.Amp3 < step)
                {
                    k4d4.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp3 >= step && classSob.Amp3 < 2 * step)
                {
                    k4d4.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp3 >= 2 * step && classSob.Amp3 < 3 * step)
                {
                    k4d4.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp3 >= 3 * step && classSob.Amp3 < 4 * step)
                {
                    k4d4.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp3 >= 4 * step)
                {
                    k4d4.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp4 == 0)
                {
                    k4d5.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp4 > 0 && classSob.Amp4 < step)
                {
                    k4d5.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp4 >= step && classSob.Amp4 < 2 * step)
                {
                    k4d5.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp4 >= 2 * step && classSob.Amp4 < 3 * step)
                {
                    k4d5.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp4 >= 3 * step && classSob.Amp4 < 4 * step)
                {
                    k4d5.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp4 >= 4 * step)
                {
                    k4d5.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp5 == 0)
                {
                    k4d6.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp5 > 0 && classSob.Amp5 < step)
                {
                    k4d6.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp5 >= step && classSob.Amp5 < 2 * step)
                {
                    k4d6.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp5 >= 2 * step && classSob.Amp5 < 3 * step)
                {
                    k4d6.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp5 >= 3 * step && classSob.Amp5 < 4 * step)
                {
                    k4d6.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp5 >= 4 * step)
                {
                    k4d6.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp6 == 0)
                {
                    k4d7.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp6 > 0 && classSob.Amp6 < step)
                {
                    k4d7.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp6 >= step && classSob.Amp6 < 2 * step)
                {
                    k4d7.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp6 >= 2 * step && classSob.Amp6 < 3 * step)
                {
                    k4d7.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp6 >= 3 * step && classSob.Amp6 < 4 * step)
                {
                    k4d7.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp6 >= 4 * step)
                {
                    k4d7.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp7 == 0)
                {
                    k4d8.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp7 > 0 && classSob.Amp7 < step)
                {
                    k4d8.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp7 >= step && classSob.Amp7 < 2 * step)
                {
                    k4d8.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp7 >= 2 * step && classSob.Amp7 < 3 * step)
                {
                    k4d8.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp7 >= 3 * step && classSob.Amp7 < 4 * step)
                {
                    k4d8.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp7 >= 4 * step)
                {
                    k4d8.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp8 == 0)
                {
                    k4d9.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp8 > 0 && classSob.Amp8 < step)
                {
                    k4d9.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp8 >= step && classSob.Amp8 < 2 * step)
                {
                    k4d9.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp8 >= 2 * step && classSob.Amp8 < 3 * step)
                {
                    k4d9.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp8 >= 3 * step && classSob.Amp8 < 4 * step)
                {
                    k4d9.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp8 >= 4 * step)
                {
                    k4d9.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp9 == 0)
                {
                    k4d10.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp9 > 0 && classSob.Amp9 < step)
                {
                    k4d10.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp9 >= step && classSob.Amp9 < 2 * step)
                {
                    k4d10.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp9 >= 2 * step && classSob.Amp9 < 3 * step)
                {
                    k4d10.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp9 >= 3 * step && classSob.Amp9 < 4 * step)
                {
                    k4d10.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp9 >= 4 * step)
                {
                    k4d10.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp10 == 0)
                {
                    k4d11.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp10 > 0 && classSob.Amp10 < step)
                {
                    k4d11.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp10 >= step && classSob.Amp10 < 2 * step)
                {
                    k4d11.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp10 >= 2 * step && classSob.Amp10 < 3 * step)
                {
                    k4d11.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp10 >= 3 * step && classSob.Amp10 < 4 * step)
                {
                    k4d11.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp10 >= 4 * step)
                {
                    k4d11.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp11 == 0)
                {
                    k4d12.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp11 > 0 && classSob.Amp11 < step)
                {
                    k4d12.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp11 >= step && classSob.Amp11 < 2 * step)
                {
                    k4d12.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp11 >= 2 * step && classSob.Amp11 < 3 * step)
                {
                    k4d12.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp11 >= 3 * step && classSob.Amp11 < 4 * step)
                {
                    k4d12.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp11 >= 4 * step)
                {
                    k4d12.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

            }
            if (classSob.nameklaster == "5")
            {
                k5d1.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k5d2.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k5d3.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k5d4.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k5d5.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k5d6.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k5d7.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k5d8.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k5d9.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k5d10.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k5d11.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k5d12.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(255, 202, 24, 37));

                short max = classSob.AmpSum().Max();
                short min = classSob.AmpSum().Min();
                int step = (max - min) / 4;

                Text1.Text = step.ToString();
                Text2.Text = (2 * step).ToString();
                Text3.Text = (3 * step).ToString();
                Text4.Text = (4 * step).ToString();

                if (classSob.Amp0 == 0)
                {
                    k5d1.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp0 > 0 && classSob.Amp0 < step)
                {
                    k5d1.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp0 >= step && classSob.Amp0 < 2 * step)
                {
                    k5d1.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp0 >= 2 * step && classSob.Amp0 < 3 * step)
                {
                    k5d1.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp0 >= 3 * step && classSob.Amp0 < 4 * step)
                {
                    k5d1.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp0 >= 4 * step)
                {
                    k5d1.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }


                if (classSob.Amp1 == 0)
                {
                    k5d2.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp1 > 0 && classSob.Amp1 < step)
                {
                    k5d2.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp1 >= step && classSob.Amp1 < 2 * step)
                {
                    k5d2.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp1 >= 2 * step && classSob.Amp1 < 3 * step)
                {
                    k5d2.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp1 >= 3 * step && classSob.Amp1 < 4 * step)
                {
                    k5d2.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp1 >= 4 * step)
                {
                    k5d2.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }


                if (classSob.Amp2 == 0)
                {
                    k5d3.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp2 > 0 && classSob.Amp2 < step)
                {
                    k5d3.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp2 >= step && classSob.Amp2 < 2 * step)
                {
                    k5d3.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp2 >= 2 * step && classSob.Amp2 < 3 * step)
                {
                    k5d3.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp2 >= 3 * step && classSob.Amp2 < 4 * step)
                {
                    k5d3.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp2 >= 4 * step)
                {
                    k5d3.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp3 == 0)
                {
                    k5d4.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp3 > 0 && classSob.Amp3 < step)
                {
                    k5d4.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp3 >= step && classSob.Amp3 < 2 * step)
                {
                    k5d4.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp3 >= 2 * step && classSob.Amp3 < 3 * step)
                {
                    k5d4.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp3 >= 3 * step && classSob.Amp3 < 4 * step)
                {
                    k5d4.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp3 >= 4 * step)
                {
                    k5d4.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp4 == 0)
                {
                    k5d5.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp4 > 0 && classSob.Amp4 < step)
                {
                    k5d5.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp4 >= step && classSob.Amp4 < 2 * step)
                {
                    k5d5.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp4 >= 2 * step && classSob.Amp4 < 3 * step)
                {
                    k5d5.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp4 >= 3 * step && classSob.Amp4 < 4 * step)
                {
                    k5d5.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp4 >= 4 * step)
                {
                    k5d5.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp5 == 0)
                {
                    k5d6.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp5 > 0 && classSob.Amp5 < step)
                {
                    k5d6.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp5 >= step && classSob.Amp5 < 2 * step)
                {
                    k5d6.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp5 >= 2 * step && classSob.Amp5 < 3 * step)
                {
                    k5d6.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp5 >= 3 * step && classSob.Amp5 < 4 * step)
                {
                    k5d6.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp5 >= 4 * step)
                {
                    k5d6.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp6 == 0)
                {
                    k5d7.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp6 > 0 && classSob.Amp6 < step)
                {
                    k5d7.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp6 >= step && classSob.Amp6 < 2 * step)
                {
                    k5d7.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp6 >= 2 * step && classSob.Amp6 < 3 * step)
                {
                    k5d7.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp6 >= 3 * step && classSob.Amp6 < 4 * step)
                {
                    k5d7.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp6 >= 4 * step)
                {
                    k5d7.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp7 == 0)
                {
                    k5d8.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp7 > 0 && classSob.Amp7 < step)
                {
                    k5d8.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp7 >= step && classSob.Amp7 < 2 * step)
                {
                    k5d8.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp7 >= 2 * step && classSob.Amp7 < 3 * step)
                {
                    k5d8.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp7 >= 3 * step && classSob.Amp7 < 4 * step)
                {
                    k5d8.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp7 >= 4 * step)
                {
                    k5d8.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp8 == 0)
                {
                    k5d9.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp8 > 0 && classSob.Amp8 < step)
                {
                    k5d9.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp8 >= step && classSob.Amp8 < 2 * step)
                {
                    k5d9.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp8 >= 2 * step && classSob.Amp8 < 3 * step)
                {
                    k5d9.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp8 >= 3 * step && classSob.Amp8 < 4 * step)
                {
                    k5d9.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp8 >= 4 * step)
                {
                    k5d9.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp9 == 0)
                {
                    k5d10.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp9 > 0 && classSob.Amp9 < step)
                {
                    k5d10.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp9 >= step && classSob.Amp9 < 2 * step)
                {
                    k5d10.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp9 >= 2 * step && classSob.Amp9 < 3 * step)
                {
                    k5d10.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp9 >= 3 * step && classSob.Amp9 < 4 * step)
                {
                    k5d10.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp9 >= 4 * step)
                {
                    k5d10.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp10 == 0)
                {
                    k5d11.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp10 > 0 && classSob.Amp10 < step)
                {
                    k5d11.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp10 >= step && classSob.Amp10 < 2 * step)
                {
                    k5d11.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp10 >= 2 * step && classSob.Amp10 < 3 * step)
                {
                    k5d11.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp10 >= 3 * step && classSob.Amp10 < 4 * step)
                {
                    k5d11.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp10 >= 4 * step)
                {
                    k5d11.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp11 == 0)
                {
                    k5d12.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp11 > 0 && classSob.Amp11 < step)
                {
                    k5d12.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp11 >= step && classSob.Amp11 < 2 * step)
                {
                    k5d12.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp11 >= 2 * step && classSob.Amp11 < 3 * step)
                {
                    k5d12.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp11 >= 3 * step && classSob.Amp11 < 4 * step)
                {
                    k5d12.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp11 >= 4 * step)
                {
                    k5d12.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

            }
            if (classSob.nameklaster == "6")
            {
                k6d1.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k6d2.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k6d3.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k6d4.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k6d5.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k6d6.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k6d7.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k6d8.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k6d9.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k6d10.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k6d11.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k6d12.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(255, 202, 24, 37));

                short max = classSob.AmpSum().Max();
                short min = classSob.AmpSum().Min();
                int step = (max - min) / 4;

                Text1.Text = step.ToString();
                Text2.Text = (2 * step).ToString();
                Text3.Text = (3 * step).ToString();
                Text4.Text = (4 * step).ToString();

                if (classSob.Amp0 == 0)
                {
                    k6d1.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp0 > 0 && classSob.Amp0 < step)
                {
                    k6d1.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp0 >= step && classSob.Amp0 < 2 * step)
                {
                    k6d1.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp0 >= 2 * step && classSob.Amp0 < 3 * step)
                {
                    k6d1.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp0 >= 3 * step && classSob.Amp0 < 4 * step)
                {
                    k6d1.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp0 >= 4 * step)
                {
                    k6d1.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }


                if (classSob.Amp1 == 0)
                {
                    k6d2.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp1 > 0 && classSob.Amp1 < step)
                {
                    k6d2.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp1 >= step && classSob.Amp1 < 2 * step)
                {
                    k6d2.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp1 >= 2 * step && classSob.Amp1 < 3 * step)
                {
                    k6d2.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp1 >= 3 * step && classSob.Amp1 < 4 * step)
                {
                    k6d2.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp1 >= 4 * step)
                {
                    k6d2.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }


                if (classSob.Amp2 == 0)
                {
                    k6d3.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp2 > 0 && classSob.Amp2 < step)
                {
                    k6d3.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp2 >= step && classSob.Amp2 < 2 * step)
                {
                    k6d3.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp2 >= 2 * step && classSob.Amp2 < 3 * step)
                {
                    k6d3.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp2 >= 3 * step && classSob.Amp2 < 4 * step)
                {
                    k6d3.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp2 >= 4 * step)
                {
                    k6d3.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp3 == 0)
                {
                    k6d4.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp3 > 0 && classSob.Amp3 < step)
                {
                    k6d4.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp3 >= step && classSob.Amp3 < 2 * step)
                {
                    k6d4.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp3 >= 2 * step && classSob.Amp3 < 3 * step)
                {
                    k6d4.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp3 >= 3 * step && classSob.Amp3 < 4 * step)
                {
                    k6d4.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp3 >= 4 * step)
                {
                    k6d4.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp4 == 0)
                {
                    k6d5.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp4 > 0 && classSob.Amp4 < step)
                {
                    k6d5.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp4 >= step && classSob.Amp4 < 2 * step)
                {
                    k6d5.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp4 >= 2 * step && classSob.Amp4 < 3 * step)
                {
                    k6d5.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp4 >= 3 * step && classSob.Amp4 < 4 * step)
                {
                    k6d5.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp4 >= 4 * step)
                {
                    k6d5.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp5 == 0)
                {
                    k6d6.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp5 > 0 && classSob.Amp5 < step)
                {
                    k6d6.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp5 >= step && classSob.Amp5 < 2 * step)
                {
                    k6d6.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp5 >= 2 * step && classSob.Amp5 < 3 * step)
                {
                    k6d6.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp5 >= 3 * step && classSob.Amp5 < 4 * step)
                {
                    k6d6.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp5 >= 4 * step)
                {
                    k6d6.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp6 == 0)
                {
                    k6d7.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp6 > 0 && classSob.Amp6 < step)
                {
                    k6d7.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp6 >= step && classSob.Amp6 < 2 * step)
                {
                    k6d7.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp6 >= 2 * step && classSob.Amp6 < 3 * step)
                {
                    k6d7.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp6 >= 3 * step && classSob.Amp6 < 4 * step)
                {
                    k6d7.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp6 >= 4 * step)
                {
                    k6d7.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp7 == 0)
                {
                    k6d8.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp7 > 0 && classSob.Amp7 < step)
                {
                    k6d8.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp7 >= step && classSob.Amp7 < 2 * step)
                {
                    k6d8.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp7 >= 2 * step && classSob.Amp7 < 3 * step)
                {
                    k6d8.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp7 >= 3 * step && classSob.Amp7 < 4 * step)
                {
                    k6d8.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp7 >= 4 * step)
                {
                    k6d8.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp8 == 0)
                {
                    k6d9.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp8 > 0 && classSob.Amp8 < step)
                {
                    k6d9.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp8 >= step && classSob.Amp8 < 2 * step)
                {
                    k6d9.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp8 >= 2 * step && classSob.Amp8 < 3 * step)
                {
                    k6d9.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp8 >= 3 * step && classSob.Amp8 < 4 * step)
                {
                    k6d9.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp8 >= 4 * step)
                {
                    k6d9.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp9 == 0)
                {
                    k6d10.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp9 > 0 && classSob.Amp9 < step)
                {
                    k6d10.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp9 >= step && classSob.Amp9 < 2 * step)
                {
                    k6d10.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp9 >= 2 * step && classSob.Amp9 < 3 * step)
                {
                    k6d10.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp9 >= 3 * step && classSob.Amp9 < 4 * step)
                {
                    k6d10.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp9 >= 4 * step)
                {
                    k6d10.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp10 == 0)
                {
                    k6d11.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp10 > 0 && classSob.Amp10 < step)
                {
                    k6d11.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp10 >= step && classSob.Amp10 < 2 * step)
                {
                    k6d11.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp10 >= 2 * step && classSob.Amp10 < 3 * step)
                {
                    k6d11.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp10 >= 3 * step && classSob.Amp10 < 4 * step)
                {
                    k6d11.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp10 >= 4 * step)
                {
                    k6d11.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp11 == 0)
                {
                    k6d12.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp11 > 0 && classSob.Amp11 < step)
                {
                    k6d12.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp11 >= step && classSob.Amp11 < 2 * step)
                {
                    k6d12.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp11 >= 2 * step && classSob.Amp11 < 3 * step)
                {
                    k6d12.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp11 >= 3 * step && classSob.Amp11 < 4 * step)
                {
                    k6d12.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp11 >= 4 * step)
                {
                    k6d12.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

            }
        }
        private void DataGrid_SelectionChanged(object sender, Telerik.UI.Xaml.Controls.Grid.DataGridSelectionChangedEventArgs e)
        {
            if (DataGrid.SelectedItem != null)
            {if (ind == DataGrid.SelectedItem)
                {
                    ind = null;
                   
                    Split1.IsPaneOpen = !Split1.IsPaneOpen;
                }
                else
                {
                    ind = DataGrid.SelectedItem;
                    ClassSob classSob = (ClassSob)DataGrid.SelectedItem;
                 
                    Split1.IsPaneOpen = true;
                    ShowDetec(classSob);
              
                }

            }
            else
            {
                Split1.IsPaneOpen = false;
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
        /*
        ObservableCollection<ClassSob> _DataColecSob = new ObservableCollection<ClassSob>();
        ObservableCollection<ClassSob> _DataColecSobCopy { get; set; }
        _DataSobColli
        */
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

            if (Convert.ToInt32(sob.Amp0) >= porog)
            {
                c++;
            }
            if (Convert.ToInt32(sob.Amp1) >= porog)
            {
                c++;
            }
            if (Convert.ToInt32(sob.Amp2) >= porog)
            {
                c++;
            }
            if (Convert.ToInt32(sob.Amp3) >= porog)
            {
                c++;
            }
            if (Convert.ToInt32(sob.Amp4) >= porog)
            {
                c++;
            }
            if (Convert.ToInt32(sob.Amp5) >= porog)
            {
                c++;
            }
            if (Convert.ToInt32(sob.Amp6) >= porog)
            {
                c++;
            }
            if (Convert.ToInt32(sob.Amp7) >= porog)
            {
                c++;
            }
            if (Convert.ToInt32(sob.Amp8) >= porog)
            {
                c++;
            }
            if (Convert.ToInt32(sob.Amp9) >= porog)
            {
                c++;
            }
            if (Convert.ToInt32(sob.Amp10) >= porog)
            {
                c++;
            }
            if (Convert.ToInt32(sob.Amp11) >= porog)
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
            RadioButton rb = sender as RadioButton;

            if (rb != null && TextBloxPorogN != null && TextBloxDlitN!=null && dataN != null && List54!= null && List55 != null)
            {
                string colorName = rb.Tag.ToString();
                switch (colorName)
                {
                    case "Tail":
                        TextBloxPorogN.IsEnabled = true;
                        TextBloxDlitN.IsEnabled = true;
                        ClassUserSetUp.TipTail = true;
                        dataN.IsVisible = true;
                        List55.Visibility = Visibility.Collapsed;
                        List54.Visibility = Visibility.Visible;
                        break;
                    case "NoTail":
                        TextBloxPorogN.IsEnabled = false;
                        TextBloxDlitN.IsEnabled = false;
                        ClassUserSetUp.TipTail = false;
                        dataN.IsVisible = false;
                        List55.Visibility = Visibility.Visible;
                        List54.Visibility = Visibility.Collapsed;
                        break;
                   
                }
            }
        }

        private void AppBarToggleButton_Click_6(object sender, RoutedEventArgs e)
        {
            if(DataGrid.Visibility==Visibility.Visible && ViewModel.ClassSobsT.Count!=0 || GridGistogram.Visibility == Visibility.Visible)
            {
                DataGrid.Visibility = Visibility.Collapsed;
                GridGistogram.Visibility = Visibility.Collapsed;
                GridStatictik.Visibility = Visibility.Visible;
                List<ClassSob> classSobs = ViewModel.ClassSobsT.ToList<ClassSob>();
                string stat = "Статистика общая"+"\n";

                stat += "Средняя нулевая линия" + "\n";
                double SrNull1 = 0;
                double SrNull2 = 0;
                double SrNull3 = 0;
                double SrNull4 = 0;
                double SrNull5 = 0;
                double SrNull6 = 0;
                double SrNull7 = 0;
                double SrNull8 = 0;
                double SrNull9 = 0;
                double SrNull10 = 0;
                double SrNull11 = 0;
                double SrNull12 = 0;

                double Srsig1 = 0;
                double Srsig2 = 0;
                double Srsig3 = 0;
                double Srsig4 = 0;
                double Srsig5 = 0;
                double Srsig6 = 0;
                double Srsig7 = 0;
                double Srsig8 = 0;
                double Srsig9 = 0;
                double Srsig10 = 0;
                double Srsig11 = 0;
                double Srsig12 = 0;
                foreach (var c in classSobs)
                {
                    SrNull1 += c.Nnull0;
                    SrNull2 += c.Nnull1;
                    SrNull3 += c.Nnull2;
                    SrNull4 += c.Nnull3;
                    SrNull5 += c.Nnull4;
                    SrNull6 += c.Nnull5;
                    SrNull7 += c.Nnull6;
                    SrNull8 += c.Nnull7;
                    SrNull9 += c.Nnull8;
                    SrNull10 += c.Nnull9;
                    SrNull11 += c.Nnull10;
                    SrNull12 += c.Nnull11;
                    Srsig1 += c.sig0;
                    Srsig2 += c.sig1;
                    Srsig3 += c.sig2;
                    Srsig4 += c.sig3;
                    Srsig5 += c.sig4;
                    Srsig6 += c.sig5;
                    Srsig7 += c.sig6;
                    Srsig8 += c.sig7;
                    Srsig9 += c.sig8;
                    Srsig10 += c.sig9;
                    Srsig11 += c.sig10;
                    Srsig12 += c.sig11;
                }
                stat += "Кн1" + "\t"+ "Кн2" + "\t" + "Кн3" + "\t" + "Кн4" + "\t" + "Кн5" + "\t" + "Кн6" + "\t" + "Кн7" + "\t" + "Кн8" + "\t" + "Кн9" + "\t" + "Кн10" + "\t" + "Кн11" + "\t" + "Кн12"+"\n";
                stat += (SrNull1/ classSobs.Count).ToString("0.0") + "\t" + (SrNull2 / classSobs.Count).ToString("0.0") + "\t" + (SrNull3 / classSobs.Count).ToString("0.0") + "\t" +
                    (SrNull4 / classSobs.Count).ToString("0.0") + "\t" + (SrNull5 / classSobs.Count).ToString("0.0") + "\t" + (SrNull6 / classSobs.Count).ToString("0.0") + "\t" 
                    + (SrNull7 / classSobs.Count).ToString("0.0") + "\t" + (SrNull8 / classSobs.Count).ToString("0.0") + "\t" + (SrNull9 / classSobs.Count).ToString("0.0") + "\t" + (SrNull10 / classSobs.Count).ToString("0.0") + "\t" + (SrNull11 / classSobs.Count).ToString("0.0") + "\t" + (SrNull12 / classSobs.Count).ToString("0.0") + "\n";
                stat += "Средняя сигма" + "\n";
                stat += "Кн1" + "\t" + "Кн2" + "\t" + "Кн3" + "\t" + "Кн4" + "\t" + "Кн5" + "\t" + "Кн6" + "\t" + "Кн7" + "\t" + "Кн8" + "\t" + "Кн9" + "\t" + "Кн10" + "\t" + "Кн11" + "\t" + "Кн12" + "\n";
                stat += (Srsig1 / classSobs.Count).ToString("0.0000") + "\t" + (Srsig2 / classSobs.Count).ToString("0.0000") + "\t" + (Srsig3 / classSobs.Count).ToString("0.0000") + "\t" +
                    (Srsig4 / classSobs.Count).ToString("0.0000") + "\t" + (Srsig5 / classSobs.Count).ToString("0.0000") + "\t" + (Srsig6 / classSobs.Count).ToString("0.0000") + "\t"
                    + (Srsig7 / classSobs.Count).ToString("0.0000") + "\t" + (Srsig8 / classSobs.Count).ToString("0.0000") + "\t" + (Srsig9 / classSobs.Count).ToString("0.0000") + "\t" + (Srsig10 / classSobs.Count).ToString("0.0000") + "\t" + (Srsig11 / classSobs.Count).ToString("0.0000") + "\t" + (Srsig12 / classSobs.Count).ToString("0.0000") + "\n";
                Editor.Document.SetText(Windows.UI.Text.TextSetOptions.ApplyRtfDocumentDefaults, stat);
            }
            else
            {
                DataGrid.Visibility = Visibility.Visible;
                GridStatictik.Visibility = Visibility.Collapsed;
            }

        }
        private async void AppBarButtonSaveStat_Click(object sender, RoutedEventArgs e)
        {
          
            Windows.Storage.Pickers.FileSavePicker savePicker = new Windows.Storage.Pickers.FileSavePicker();
            savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;

            // Dropdown of file types the user can save the file as
            savePicker.FileTypeChoices.Add("Rich Text", new List<string>() { ".rtf" });

            // Default file name if the user does not type one in or select a file to replace
            savePicker.SuggestedFileName = "New Document";

            Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();
            if (file != null)
            {
                // Prevent updates to the remote version of the file until we
                // finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(file);
                // write to file
                Windows.Storage.Streams.IRandomAccessStream randAccStream =
                    await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);

                Editor.Document.SaveToStream(Windows.UI.Text.TextGetOptions.FormatRtf, randAccStream);

                // Let Windows know that we're finished changing the file so the
                // other app can update the remote version of the file.
                Windows.Storage.Provider.FileUpdateStatus status = await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);
                if (status != Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    Windows.UI.Popups.MessageDialog errorBox =
                        new Windows.UI.Popups.MessageDialog("File " + file.Name + " couldn't be saved.");
                    await errorBox.ShowAsync();
                }
            }
         
            var mess = new MessageDialog("Сохранение завершено");
            await mess.ShowAsync();

        }
        public async Task obrRazv(string nameFile, string time)
        {
           foreach(var v in _DataColec)
            {
                if(nameFile==v.NameFile)
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
                                                        if(time== time1)
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
                            string b2 = v.NameFile;

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
                                if (str[2] == "N")
                                {
                                    NoTailCh.IsChecked = true;
                                }
                                if (str[2] == "T")
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
                            BasicProperties basicProperties =
           await storageFile.GetBasicPropertiesAsync();

                            // Application now has read/write access to the picked file
                            _DataColec.Add(new ClassСписокList { NameFile = FileName, NemePapka = FilePath, Status = false, file1 = storageFile, size = basicProperties.Size, StatusSize = 0 });

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
                DataGrid.Visibility= Visibility.Visible;
                DataGrid1.Visibility = Visibility.Collapsed;
                TextBloxPorogN.IsEnabled = true;
                TextBloxDlitN.IsEnabled = true;
                dataNV.IsVisible = false;
              //  ClassUserSetUp.TipTail = true;
                dataN.IsVisible = true;
                dataAmp.IsVisible = true;
                ampNV.IsVisible = false;
                mtNV.IsVisible = false;
                ftNV.IsVisible = false;
                List55.Visibility = Visibility.Collapsed;
                List54.Visibility = Visibility.Visible;
                DataGrid.ItemsSource = ViewModel.ClassSobsT;
                colstroc.Text = ViewModel.ClassSobsT.Count.ToString();

            }
            if (d == 1)
            {
                DataGrid.Visibility = Visibility.Visible;
                DataGrid1.Visibility = Visibility.Collapsed;
                // ClassUserSetUp.TipTail = false;
                dataN.IsVisible = false;
                dataAmp.IsVisible = true;
                dataNV.IsVisible = false;
                ampNV.IsVisible = false;
                ftNV.IsVisible = false;
                mtNV.IsVisible = false;
                List55.Visibility = Visibility.Visible;
                List54.Visibility = Visibility.Collapsed;
                DataGrid.ItemsSource = ViewModel.ClassSobsN;
                colstroc.Text = ViewModel.ClassSobsN.Count.ToString();
            }
            if (d == 2)
            {
                DataGrid.Visibility = Visibility.Visible;
                DataGrid1.Visibility = Visibility.Collapsed;
                TextBloxPorogN.IsEnabled = false;
                TextBloxDlitN.IsEnabled = false;
              //  ClassUserSetUp.TipTail = false;
                dataN.IsVisible = false;
                dataNV.IsVisible = true;
                dataAmp.IsVisible = false;
                ampNV.IsVisible = true;
                mtNV.IsVisible = true;
                ftNV.IsVisible = true;
                List55.Visibility = Visibility.Visible;
                List54.Visibility = Visibility.Collapsed;
                DataGrid.ItemsSource = ViewModel.ClassSobsV;
                colstroc.Text = ViewModel.ClassSobsV.Count.ToString();
            }
            if (d == 3)
            {
                DataGrid.Visibility = Visibility.Visible;
                DataGrid1.Visibility = Visibility.Collapsed;
                dataN.IsVisible = false;
                dataAmp.IsVisible = true;
                ampNV.IsVisible = false;
                mtNV.IsVisible = false;
                ftNV.IsVisible = false;
                dataN.IsVisible = false;
                dataNV.IsVisible = false;
                dataAmp.IsVisible = false;
                List55.Visibility = Visibility.Visible;
                List54.Visibility = Visibility.Collapsed;
                List<ClassSob> sobs = new List<ClassSob>();
                foreach(ClassSob classSob in ViewModel.ClassSobsN)
                {
                    sobs.Add(classSob);
                }
                foreach (ClassSob classSob in ViewModel.ClassSobsT)
                {
                    sobs.Add(classSob);
                }
                DataGrid.ItemsSource = sobs;
                colstroc.Text = (ViewModel.ClassSobsN.Count+ViewModel.ClassSobsT.Count).ToString();
            }
            if(d==4)
            {
                try
                {
                    DataGrid.Visibility = Visibility.Collapsed;
                    DataGrid1.Visibility = Visibility.Visible;
                  

               


                  

ftNV.IsVisible = true;



                    int MaxDur = Convert.ToInt16(TimeGate.Text);
                    int MaxAmpl = Convert.ToInt16(MinAmplDetect.Text);
                    int MinClust = Convert.ToInt16(MinClustDec.Text);
                  ObchSobURAN(MaxDur, MaxAmpl, MinClust);
               
            
                }
                catch(Exception ex)
                {
                    MessageDialog messageDialog = new MessageDialog(ex.ToString());
                   await messageDialog.ShowAsync();
                }


            }





        }
        public async void ObchSobURAN(int MaxDur, int MaxAmpl, int MinClust)
        {
            try
            {
              


             
                int Clust = 0;
              // ViewModel._DataColecSobCopy = new ObservableCollection<ClassSob>();
              foreach(ClassSob classSob in ViewModel.ClassSobsT)
                {
                    ViewModel._DataColecSobCopy.Add(classSob);
                }
                
            
               while(ViewModel._DataColecSobCopy.Count!=0)
                {
                    ClassSobColl classSobColl = new ClassSobColl();
                    ClassSob clF = ViewModel._DataColecSobCopy.ElementAt(0);
                 classSobColl.col.Add(clF);
                    ViewModel._DataColecSobCopy.RemoveAt(0);
                    
                  if (ViewModel._DataColecSobCopy.Count != 0)
                  {
                        int xr = 0;
                      foreach (ClassSob classSob in ViewModel._DataColecSobCopy)
                      {
                          if (DateNanos.isEventSimul(clF.time, classSob.time, MaxDur))
                          {
                              classSobColl.col.Add(classSob);
                                ViewModel._DataColecSobCopy.RemoveAt(xr);
                               
                          }
                           
                      }
                  }
                 
                   
                    int x = 0;
                    foreach(ClassSob classSob in classSobColl.col)
                    {
                        if(x!=0)
                        {
                            ViewModel._DataColecSobCopy.Remove(classSob);
                            x--;
                        }
                        x++;
                    }
                   
                   classSobColl.SumAmpAndNeutronAndClaster();
                   classSobColl.StartTime = clF.time;
                   ViewModel._DataSobColli.Add(classSobColl);
                   

                }

            }


            catch (Exception ex)
            {

    await new MessageDialog(ex.ToString()).ShowAsync();

            }
         
        }
    }
}
