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
      //  ObservableCollection<ClassSob> _DataColecSob = new ObservableCollection<ClassSob>();
        ObservableCollection<ClassSob> _DataColecSobPlox = new ObservableCollection<ClassSob>();
        ObservableCollection<ClassSob> _DataColecSobCopy { get; set; }
        ObservableCollection<ClassSobColl> _DataSobColli = new ObservableCollection<ClassSobColl>();
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
                ColDataGrid.ItemsSource = _DataSobColli;
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
                                                    OcherediNaObrab.Enqueue(new MyclasDataizFile { NameFile = d.NameFile, Buf00 = dataOnePac, LenghtChenel = leng, НулеваяЛиния = masNul, NameBaaR12 = nBaaK.ToString(), Ran = nameRan });
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

                    //  var messageDialog = new MessageDialog("Запустили поток");
                    // await messageDialog.ShowAsync();
                    List<ClassСписокList> l = new List<ClassСписокList>();
                    foreach(ClassСписокList g in listView1.SelectedItems)
                    {
                        l.Add(g);
                    }
                    ZapicOcheredNaObrabotkyAsync(Y, 1, "1", l);
                    await Task.Run(() => WriteInFileIzOcherediAsync(cancellationToken));
                   
                    // await WriteInFileIzOcherediAsync(cancellationToken);
                    colstroc.Text = ViewModel.ClassSobs.Count.ToString();
                    duration.Text = $"Duration (ms): {watch.ElapsedMilliseconds}";
                    sobInSec.Text = (ViewModel.ClassSobs.Count / watch.Elapsed.Seconds).ToString();
                    var messq = new MessageDialog("Конец");
                    await messq.ShowAsync();
                    ObRing.IsActive = false;
                    

                }
                catch 
                {
                    var mes = new MessageDialog("Ошибка");
                    await mes.ShowAsync();
                }


            }

        }
        public delegate Task SaveFile(int[,] data, int[,] Tail, string time, string nameFile);//

        /// <summary>
        /// охраняем пакет в файл
        /// </summary>
        public SaveFile SaveFileDelegate;
        public delegate Task SaveFileSob(string nameFile, string nameBAAK, string time, string nameRan, int[] Amp, string nameklaster, int[] Nnut, int[] Nl, Double[] sig);//

        /// <summary>
        /// охраняем данные о событии
        /// </summary>
        public SaveFileSob SaveFileSobDelegate;
        public delegate void ObrSig(int[] nul, string nameFile, string nemeBAAK, int[,] data1, int[,] dataTail1, string time1);//

        /// <summary>
        /// охраняем пакет в файл
        /// </summary>
        public ObrSig ObrSigDelegate;




        public async Task SaveAsync(int[,] data, int[,] Tail, string time, string nameFile)
        {
            await saveAsync(data, Tail, time, nameFile);
        }

        private async void AppBarButton_Click_6(object sender, RoutedEventArgs e)
        {string cul="en-US";
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

                StorageFolder storageFolderRazvertka = await storageFolder.CreateFolderAsync("Развертка", CreationCollisionOption.GenerateUniqueName);

                IReadOnlyList<StorageFile> fileList =
                   await storageFolderRazvertka.GetFilesAsync();
                if (fileList.Count != 0)
                {
                    foreach (StorageFile file in fileList)
                    {
                        await file.CopyAsync(folder);
                    }
                }
                int i = 0;
                if (ViewModel.ClassSobs.Count != 0)
                {
                    using (StreamWriter writer =
                   new StreamWriter(await folder.OpenStreamForWriteAsync(
                   "СобытияФайла.txt", CreationCollisionOption.GenerateUniqueName)))
                    {
                        string sSob = "n" + "\t" + "file" + "\t" + "kl" + "\t" + "PSB" + "\t" + "Time" + "\t" + "SA" + "\t" + "SN" + "\t" + "AD1" + "\t" + "AD2" + "\t" + "AD3" + "\t" + "AD4" + "\t" + "AD5" + "\t" + "AD6" + "\t" + "AD7" + "\t" + "AD8" + "\t" + "AD9" + "\t" + "aD10" + "\t" + "AD11" + "\t" + "AD12" +
                                   "\t" + "ND1" + "\t" + "ND2" + "\t" + "ND3" + "\t" + "ND4" + "\t" + "ND5" + "\t" + "ND6" + "\t" + "ND7" + "\t" + "ND8" + "\t" + "ND9" + "\t" + "ND10" + "\t" + "ND11" + "\t" + "ND12" + "\t" +
                                   "SigD1" + "\t" + "SigD2" + "\t" + "SigD3" + "\t" + "SigD4" + "\t" + "SigD5" + "\t" + "SigD6" + "\t" + "SigD7" + "\t" + "SigD8" + "\t" + "SigD9" + "\t" + "SigD10" + "\t" + "SigD11" + "\t" + "SigD12" + "\t" + "NullD1" + "\t" + "NullD2"
                                   + "\t" + "NullD3" + "\t" + "NullD4" + "\t" + "NullD5" + "\t" + "NullD6" + "\t" + "NullD7" + "\t" + "NullD8" + "\t" + "NullD9" + "\t" + "NullD10" + "\t" + "NullD11" + "\t" + "NullD12";


                        await writer.WriteLineAsync(sSob);
                        foreach (ClassSob sob in ViewModel.ClassSobs)
                        {
                            i++;
                            string Sob = i.ToString() + "\t" + sob.nameFile + "\t" + sob.nameklaster + "\t" + sob.nameBAAK.ToString() + "\t" + sob.time + "\t" + sob.SumAmp + "\t" + sob.SumNeu + "\t" + sob.Amp0.ToString() + "\t" + sob.Amp1.ToString() + "\t" + sob.Amp2.ToString() + "\t" + sob.Amp3.ToString() + "\t" + sob.Amp4.ToString() + "\t" + sob.Amp5.ToString() + "\t" + sob.Amp6.ToString() + "\t" + sob.Amp7.ToString() + "\t" + sob.Amp8.ToString() + "\t" + sob.Amp9.ToString() + "\t" + sob.Amp10.ToString() + "\t" + sob.Amp11.ToString() +
                               "\t" + sob.Nnut0.ToString() + "\t" + sob.Nnut1.ToString() + "\t" + sob.Nnut2.ToString() + "\t" + sob.Nnut3.ToString() + "\t" + sob.Nnut4.ToString() + "\t" + sob.Nnut5.ToString() + "\t" + sob.Nnut6.ToString() + "\t" + sob.Nnut7.ToString() + "\t" + sob.Nnut8.ToString() + "\t" + sob.Nnut9.ToString() + "\t" + sob.Nnut10.ToString() + "\t" + sob.Nnut11.ToString() + "\t" +
                                sob.sig0.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig1.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig2.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig3.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig4.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig5.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig6.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig7.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig8.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig9.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig10.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig11.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.Nnull0
                                 + "\t" + sob.Nnull1 + "\t" + sob.Nnull2 + "\t" + sob.Nnull3 + "\t" + sob.Nnull4 + "\t" + sob.Nnull5 + "\t" + sob.Nnull6 + "\t" + sob.Nnull7 + "\t" + sob.Nnull8 + "\t" + sob.Nnull9 + "\t" + sob.Nnull10 + "\t" + sob.Nnull11;
                            await writer.WriteLineAsync(Sob);
                        }
                    }
                }
                i = 0;
                if (_DataColecSobPlox.Count != 0)
                {
                    using (StreamWriter writer =
                   new StreamWriter(await folder.OpenStreamForWriteAsync(
                   "СобытияФайлаBad.txt", CreationCollisionOption.GenerateUniqueName)))
                    {
                        string sSob = "n" + "\t" + "file" + "\t" + "kl" + "\t" + "PSB" + "\t" + "Time" + "\t" + "SA" + "\t" + "SN" + "\t" + "AD1" + "\t" + "AD2" + "\t" + "AD3" + "\t" + "AD4" + "\t" + "AD5" + "\t" + "AD6" + "\t" + "AD7" + "\t" + "AD8" + "\t" + "AD9" + "\t" + "aD10" + "\t" + "AD11" + "\t" + "AD12" +
                                   "\t" + "ND1" + "\t" + "ND2" + "\t" + "ND3" + "\t" + "ND4" + "\t" + "ND5" + "\t" + "ND6" + "\t" + "ND7" + "\t" + "ND8" + "\t" + "ND9" + "\t" + "ND10" + "\t" + "ND11" + "\t" + "ND12" + "\t" +
                                   "SigD1" + "\t" + "SigD2" + "\t" + "SigD3" + "\t" + "SigD4" + "\t" + "SigD5" + "\t" + "SigD6" + "\t" + "SigD7" + "\t" + "SigD8" + "\t" + "SigD9" + "\t" + "SigD10" + "\t" + "SigD11" + "\t" + "SigD12" + "\t" + "NullD1" + "\t" + "NullD2"
                                   + "\t" + "NullD3" + "\t" + "NullD4" + "\t" + "NullD5" + "\t" + "NullD6" + "\t" + "NullD7" + "\t" + "NullD8" + "\t" + "NullD9" + "\t" + "NullD10" + "\t" + "NullD11" + "\t" + "NullD12";


                        await writer.WriteLineAsync(sSob);
                        foreach (ClassSob sob in _DataColecSobPlox)
                        {
                            i++;
                            string Sob = i.ToString() + "\t" + sob.nameFile + "\t" + sob.nameklaster + "\t" + sob.nameBAAK.ToString() + "\t" + sob.time + "\t" + sob.SumAmp + "\t" + sob.SumNeu + "\t" + sob.Amp0.ToString() + "\t" + sob.Amp1.ToString() + "\t" + sob.Amp2.ToString() + "\t" + sob.Amp3.ToString() + "\t" + sob.Amp4.ToString() + "\t" + sob.Amp5.ToString() + "\t" + sob.Amp6.ToString() + "\t" + sob.Amp7.ToString() + "\t" + sob.Amp8.ToString() + "\t" + sob.Amp9.ToString() + "\t" + sob.Amp10.ToString() + "\t" + sob.Amp11.ToString() +
                               "\t" + sob.Nnut0.ToString() + "\t" + sob.Nnut1.ToString() + "\t" + sob.Nnut2.ToString() + "\t" + sob.Nnut3.ToString() + "\t" + sob.Nnut4.ToString() + "\t" + sob.Nnut5.ToString() + "\t" + sob.Nnut6.ToString() + "\t" + sob.Nnut7.ToString() + "\t" + sob.Nnut8.ToString() + "\t" + sob.Nnut9.ToString() + "\t" + sob.Nnut10.ToString() + "\t" + sob.Nnut11.ToString() + "\t" +
                                sob.sig0.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig1.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig2.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig3.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig4.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig5.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig6.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig7.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig8.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig9.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig10.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig11.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.Nnull0
                                 + "\t" + sob.Nnull1 + "\t" + sob.Nnull2 + "\t" + sob.Nnull3 + "\t" + sob.Nnull4 + "\t" + sob.Nnull5 + "\t" + sob.Nnull6 + "\t" + sob.Nnull7 + "\t" + sob.Nnull8 + "\t" + sob.Nnull9 + "\t" + sob.Nnull10 + "\t" + sob.Nnull11;
                            await writer.WriteLineAsync(Sob);
                        }
                    }
                }
                int ii = 0;
                if (ViewModel.ClassSobNeutrons.Count != 0)
                {
                    using (StreamWriter writer =
                   new StreamWriter(await folder.OpenStreamForWriteAsync(
                   "НейтроныФайла.txt", CreationCollisionOption.GenerateUniqueName)))
                    {
                        string sNeu = "n" + "\t" + "file" + "\t" + "D" + "\t" + "A" + "\t" + "Time" + "\t" + "tf" + "\t" + "tf3" + "\t" + "tmax" + "\t" + "tend3" + "\t" + "tend";
                        await writer.WriteLineAsync(sNeu);
                        foreach (ClassSobNeutron sob in ViewModel.ClassSobNeutrons)
                        {
                            ii++;
                            string Sob = ii.ToString() + "\t" + sob.nameFile + "\t" + sob.D.ToString("00") + "\t" + sob.Amp.ToString() + "\t" + sob.time + "\t" + sob.TimeFirst.ToString() + "\t" + sob.TimeFirst3.ToString() + "\t" + sob.TimeAmp.ToString() + "\t" + sob.TimeEnd3.ToString() + "\t" + sob.TimeEnd3.ToString();
                            await writer.WriteLineAsync(Sob);
                        }
                    }
                }
            }
            else
            {

            }
            ObRing.IsActive = false;
            var mess = new MessageDialog("Сохранение завершено");
            await mess.ShowAsync();

        }

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
                    ViewModel.ClassSobs.Clear();
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
                ViewModel.ClassSobs.Clear();

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

            // DataGrid.SelectionMode = DataGridSelectionMode.Multiple;


            //  DataGrid.SelectAll();
            MessageDialog messageDialog = new MessageDialog(ViewModel.PorogS.ToString());
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

                StorageFolder storageFolderSob = await storageFolder.CreateFolderAsync("События", CreationCollisionOption.OpenIfExists);
                IReadOnlyList<StorageFile> fileList1 =
                await storageFolderSob.GetFilesAsync();

                foreach (StorageFile file in fileList1)
                {
                    await file.CopyAsync(folder);
                }


            }
            else
            {

            }
            ObRing.IsActive = false;
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



        object ind;
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

                    Split1.IsPaneOpen = true;
 
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
                if (_DataSobColli.Count != 0)
                {
                    using (StreamWriter writer =
                   new StreamWriter(await folder.OpenStreamForWriteAsync(
                   "ОбщиеСоб.txt", CreationCollisionOption.OpenIfExists)))
                    {
                        string sSob = "n" + "\t" + "time" + "\t" + "sumAmpl" + "\t" + "sumNeut" + "\t" + "sumClust" + "\t" + "sumDecUp";


                        await writer.WriteLineAsync(sSob);
                        foreach (ClassSobColl sob in _DataSobColli)
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
                ProgressBar1.IsActive = true;


                int MaxDur = Convert.ToInt16(TimeGate.Text);
                int MaxAmpl = Convert.ToInt16(MinAmplDetect.Text);
                int MinClust = Convert.ToInt16(MinClustDec.Text);
                int Clust = 0;
                _DataColecSobCopy = new ObservableCollection<ClassSob>();
                foreach (ClassSob cl in ViewModel.ClassSobs)
                {
                    _DataColecSobCopy.Add(cl);
                }
                int max = _DataColecSobCopy.Count;
                for (int X = 0; X < max; X++)
                {
                    ClassSob clF = _DataColecSobCopy[X];
                    int SummNeutr = clF.SumNeu, SummAmpl = clF.SumAmp, SummDetect = 1, SumDecUp = 0, SumDecUptmp = 0;

                    Clust = 1;

                    CountPorogs(clF, MaxAmpl, out SumDecUptmp);
                    SumDecUp += SumDecUptmp;
                    SumDecUptmp = 0;

                    for (int Y = 0; Y < max; Y++)
                    {
                        ClassSob clS = _DataColecSobCopy[Y];
                        if (!clF.Equals(clS))
                        {
                            //  0  1  2  3  4      5          6
                            // DD.HH.MM.SS.mSmSmS.mcSmcSmcS.nSnSnS



                            if (DateNanos.isEventSimul(clF.time, clS.time, MaxDur))
                            {
                                SummNeutr += clS.SumNeu;
                                SummAmpl += clS.SumAmp;
                                SummDetect++;

                                CountPorogs(clS, MaxAmpl, out SumDecUptmp);
                                SumDecUp += SumDecUptmp;
                                SumDecUptmp = 0;
                                Clust++;
                                _DataColecSobCopy.Remove(clS);
                                max--;
                            }

                        }
                    }
                    if (Clust >= MinClust)
                    {
                        _DataSobColli.Add(new ClassSobColl() { StartTime = clF.time, SumClast = SummDetect, SummAmpl = SummAmpl, SummNeu = SummNeutr, SumClastUp = SumDecUp });
                    }
                }







                int trig = Convert.ToInt16(MinDetectUp.Text);
                int step = Convert.ToInt16(StepsAmpl.Text);
                int g = 0;
                List<int> listsob = new List<int>();
                double sredN = 0;
                for (int i = 1; i < 2048 * 60; i++)
                {
                    g++;
                    foreach (ClassSobColl sob in _DataSobColli)
                    {
                        int c = 0;

                        if (sob.SummAmpl == i && sob.SummNeu < 15)
                        {
                            c = sob.SumClastUp;
                            if (c >= trig)
                            {
                                listsob.Add(sob.SummNeu);
                            }


                        }
                    }
                    if (g == step)
                    {
                        if (listsob.Count == 0)
                        {

                            // _DataColecSob2.Add(new ClassSobObrZav()
                            //  {
                            //    amp = i,
                            //   sredN = 0,
                            //   sig = 0

                            // });
                        }
                        else
                        {
                            sredN = listsob.Average();
                            _DataColecSob2.Add(new ClassSobObrZav()
                            {
                                amp = i,
                                sredN = listsob.Average(),
                                sig = Math.Sqrt(Sum(listsob, sredN) / listsob.Count)

                            });
                        }
                        g = 0;
                        listsob = new List<int>();
                        sredN = 0;

                    }





                }

            }







            catch (Exception ex)
            {
                await new MessageDialog(ex.ToString()).ShowAsync();
            }
            finally
            {
                ProgressBar1.IsActive = false;
                await new MessageDialog("Обработка завершена").ShowAsync();
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
            _DataSobColli.Clear();
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
            MessageDialog messageDialog = new MessageDialog("Новый проект");
           await messageDialog.ShowAsync();
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
            if(DataGrid.Visibility==Visibility.Visible && ViewModel.ClassSobs.Count!=0)
            {
                DataGrid.Visibility = Visibility.Collapsed;
                GridStatictik.Visibility = Visibility.Visible;
                List<ClassSob> classSobs = ViewModel.ClassSobs.ToList<ClassSob>();
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
    }
}
