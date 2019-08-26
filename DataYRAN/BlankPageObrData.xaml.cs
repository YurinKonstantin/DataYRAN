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

using Windows.UI.Xaml.Input;

using Windows.UI.Xaml.Navigation;
using Microsoft.QueryStringDotNET;
using Windows.ApplicationModel.Activation;

using Windows.ApplicationModel.DataTransfer;
using Windows.Storage.FileProperties;

using Windows.ApplicationModel.ExtendedExecution;
using DataYRAN.StatObrabotka.StatNulLine;
using DataYRAN.StatObrabotka.StatSig;

using DataYRAN.StatObrabotka.statObcTemp;
using DataYRAN.StatObrabotka.TimeDistribuchen;
using DataYRAN.Script;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;
using Windows.Devices.Usb;
using Telerik.Core.Data;


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

        //   ViewModel.ClassSobsT


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
           
             
                ToggleSwitchSaveRaz.IsOn = ClassUserSetUp.SaveRaz;
                ToggleSwitchObrSig.IsOn = ClassUserSetUp.ObrSig;
                TextBloxPorogN.Text = ClassUserSetUp.PorogN.ToString();
                TextBloxDlitN.Text = ClassUserSetUp.DlitN3.ToString();
                ToggleSwitchObrNoise.IsOn = ClassUserSetUp.ObrNoise;
                TextBloxKoefNoise.Text = ClassUserSetUp.KoefNoise.ToString();
               TextBloxAmpNoise.Text = ClassUserSetUp.AmpNoise.ToString();
                
                first = false;
             
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
   



        CancellationTokenSource cancellationTokenSource;
        public void ffg(string text)
        {
            Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                       () => {
                           ExampleInAppNotification.Show(text, 3000);
                       });
        }
        private void AppBarButton_Click_Cansel(object sender, RoutedEventArgs e)
        {
            cancellationTokenSource.Cancel();
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
                 
             
            Task task = Task.Run(() => 
            Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => { ExampleInAppNotification.Show("Обработка запушена в фоновом режиме" + "\n" + "Можно свернуть экран", 3000);})
                    );
            cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;
          
          
         
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
                            Task.Run(() => ZapicOcheredNaObrabotkyAsync("У1", 1, "1", l, cancellationToken));
                 //   MessageDialog messageDialog = new MessageDialog("dd");
                   // messageDialog.ShowAsync();

                    await Task.Run(()=> WriteInFileIzOcherediAsync(cancellationToken, ViewModel.cclassUserSetUp, ViewModel.script));

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
                    var messq = new MessageDialog("Обработка данных завершена успешно." +"\n"+"Длительность обработки: "+ (watch.ElapsedMilliseconds / 1000).ToString()+"c.", "Завершение обработки");
                    await messq.ShowAsync();
                    
                    

                }
                catch (Exception ex)
                {
                    var mes = new MessageDialog("Ошибка"+ex.ToString());
                    await mes.ShowAsync();
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
        public delegate Task ObrSig(string nameFile, string nemeBAAK, int[,] data1, int[,] dataTail1, string time1, string tipName, ClassUserSetUp classUserSetUp, DataTimeUR dataTimeUR, string script);//

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

        private async void OpenDevice()
        {
            UInt32 vid = 0x045E;
            UInt32 pid = 0x0611;
           
            string aqs = UsbDevice.GetDeviceSelector(vid, pid);

            var myDevices = await Windows.Devices.Enumeration.DeviceInformation.FindAllAsync(aqs);

            try
            {
             var   usbDevice = await UsbDevice.FromIdAsync(myDevices[0].Id);
            }
            catch (Exception exception)
            {
 
            }
            finally
            {

            }

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

        private async  void AppBarButton_Click_8(object sender, RoutedEventArgs e)
        {


          


        }
        private async void ButtonScript_Click(object sender, RoutedEventArgs e)
        {
            Pyt();
        }
        private async void ButtonScriptSaveRazvertca_Click(object sender, RoutedEventArgs e)
        {
           ContentDialogScriptSaveRAzvertki deleteFileDialog = new ContentDialogScriptSaveRAzvertki()
            {
               

            };
          
            ContentDialogResult result = await deleteFileDialog.ShowAsync();
            if (deleteFileDialog.Script != String.Empty)
            {
                ViewModel.script = deleteFileDialog.Script;
            }
            else
            {
                ViewModel.script = String.Empty;
            }
            
        }
        private async void ButtonScriptFilterDataGrid_Click(object sender, RoutedEventArgs e)
        {
            ContentDialogScriptSaveRAzvertki deleteFileDialog = new ContentDialogScriptSaveRAzvertki()
            {
                Title="Срипт для фильтра данных"

            };
     
            ContentDialogResult result = await deleteFileDialog.ShowAsync();
            if (deleteFileDialog.Script != String.Empty)
            {
                IDataView currentView = this.DataGrid.GetDataView();
                if (currentView.Items.Count > 0)
                {


                    ObservableCollection<ClassSob> classSobs = new ObservableCollection<ClassSob>();
                    foreach (ClassSob classSob in currentView)
                    {
                        string yNumber = "false";
                       
                   
                    
                        ScriptEngine engine = Python.CreateEngine();
                        ScriptScope scope = engine.CreateScope();
                        scope.SetVariable("Rez", yNumber);

                        scope.SetVariable("ClassSob", classSob);
                        engine.Execute(deleteFileDialog.Script, scope);
                        dynamic zNumber = scope.GetVariable("Rez");
                   
                        // dynamic xNumber = scope.GetVariable("x");
                        //   dynamic zNumber = scope.GetVariable("z");
                        if (zNumber.ToString() == "true")
                        {
                            classSobs.Add(classSob);
                        }
                    
                    }

                    DataGrid.ItemsSource = classSobs;
                }
            }
            else
            {
               DataGrid.ItemsSource= ViewModel.ClassSobsT; 
            }

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
  
        private async void AppBarToggleButton_Click_4(object sender, RoutedEventArgs e)
        {
            gridMenedger.Visibility = Visibility.Visible;
            SaveAllMenedger();
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


         


            }

            else
            {
               
            }
        }
        private async void DataGrid1_SelectionChanged(object sender, DataGridSelectionChangedEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {


                Split22.IsPaneOpen = !Split22.IsPaneOpen;


                object ind = DataGrid1.SelectedItem;


                ClassSobColl classSob = (ClassSobColl)DataGrid1.SelectedItem;

                await MyUserO.ShowDetecAsync(classSob.col);
                await MyUsernO.ShowDetecТAsync(classSob.col);

            }
            else
            {
                Split22.IsPaneOpen = false;
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
                IDataView currentView = this.DataGrid1.GetDataView();
                if (currentView.Items.Count > 0)
                {


                   // ObservableCollection<ClassSobColl> classSobs = new ObservableCollection<ClassSobColl>();
                    using (StreamWriter writer =
              new StreamWriter(await folder.OpenStreamForWriteAsync(
              "ОбщиеСоб.txt", CreationCollisionOption.OpenIfExists)))
                    {
                        string sSob = "n" + "\t" + "time" + "\t" + "sumAmpl" + "\t" + "sumNeut" + "\t" + "sumClust" + "\t" + "sumDecUp" + "\t" + "NDn";


                    await writer.WriteLineAsync(sSob);
                    foreach (ClassSobColl classSob in currentView)
                    {
                        i++;
                        string Sob = i + "\t" + classSob.StartTime + "\t" + classSob.SummAmpl + "\t" + classSob.SummNeu + "\t" + classSob.SumClast + "\t" + classSob.SumClastUp+"\t"+classSob.NDn;
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
  
        private Double Sum(List<int> n, double x)
        {
            Double res = 0;
            foreach (int i in n)
            {
                res = res + Math.Pow((i - x), 2);
            }
            return res;
        }
   
        private void AppBarButton_Clear(object sender, RoutedEventArgs e)
        {
            ViewModel._DataColecSobCopy.Clear();
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

       
      
        public async Task obrRazv(string nameFile, string time, string tip)
        {
            var df = from ClassСписокList in ViewModel.DataColec.ToList().AsParallel()
                     where ClassСписокList.file1.DisplayName == nameFile
                     select ClassСписокList;
           foreach (var v in df)
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
                                                        string ss = String.Empty;
                                                        if (ClassUserSetUp.TipTail)
                                                        {
                                                        ss=  ParserBAAK12.ParseBinFileBAAK12.ParseBinFileBAAK200H(dataOnePac, out data1, out time1, out dataTail1);
                                                        }
                                                        else
                                                        {

                                                          ParserBAAK12.ParseBinFileBAAK12.ParseBinFileBAAK200(dataOnePac, 1, out data1, out time1);
                                                        }


                                                      
                                                           
                                                            string[] strTime = time1.Split('.');
                                 
                                                            //  Debug.WriteLine(time1);
                                                            DataTimeUR dataTimeUR = new DataTimeUR(0, 0, Convert.ToInt16(strTime[0]), Convert.ToInt16(strTime[1]), Convert.ToInt16(strTime[2]) , Convert.ToInt16(strTime[3]),
                                                                         Convert.ToInt16(strTime[4]), Convert.ToInt16(strTime[5]), Convert.ToInt16(strTime[6]));
                                                       
                                                                dataTimeUR.corectTime(nameFile);




                                                        // time1 = strTime[0] + "." + strTime[1] + "." + (Convert.ToInt32(strTime[2]) + t).ToString("00") + "." + strTime[3] + "." + strTime[4] + "." + strTime[5] + "." + strTime[6];

                                                        time1 = strTime[0] + "." + strTime[1] + "." + (Convert.ToInt32(strTime[2])).ToString("00") + "." + strTime[3] + "." + strTime[4] + "." + strTime[5] + "." + strTime[6];

                                                        Debug.WriteLine(dataTimeUR.DateTimeString()+"\t"+ time);

                                                        if (time == dataTimeUR.TimeString())
                                                        {
                                                            Debug.WriteLine("EEE");
                                                            ClassRazvertka classRazvertka = new ClassRazvertka() { nameFile1=nameFile, data=data1, dataTail=dataTail1, Time=time1 };
                                                            if (tip == "Viz")
                                                            {


                                                                this.Frame.Navigate(typeof(BlankPageRazverta), classRazvertka);
                                                            }
                                                            else
                                                            {

                                                                await saveAsyncFolder(data1, dataTail1, time1, nameFile);



                                                            }
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
            HyperlinkButton hyperlinkButton = (HyperlinkButton)sender;
          await  obrRazv(classSob.nameFile, classSob.time, hyperlinkButton.Tag.ToString());
           // this.Frame.Navigate(typeof(BlankPageRazverta), classSob.nameFile);
        }
        private async void AppBarButtonMap(object sender, RoutedEventArgs e)
        {
           
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
        private async void MenuFlyoutItemPnew_Click(object sender, RoutedEventArgs e)
        {
            ClassProject.SaveProgect(ViewModel.ClassSobsT);
           
        }
        private async void MenuFlyoutItemPOpen_Click(object sender, RoutedEventArgs e)
        {
            // ObservableCollection<ClassSob> classSobsC = new ObservableCollection<ClassSob>();
            ViewModel.ClassSobsT=await ClassProject.OpenP();
            DataGrid.ItemsSource = ViewModel.ClassSobsT;
            //  classSobsC
            //  foreach (ClassSob classSob in classSobsC)
            //  {
            //     ViewModel.ClassSobsT.Add(classSob);
            //  }

            MessageDialog messageDialog = new MessageDialog("Открыт");
           await messageDialog.ShowAsync();


        }
        private async void MenuFlyoutItemTabOpenSob_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".doc");
            picker.FileTypeFilter.Add(".data");
            picker.FileTypeFilter.Add(".txt");
            try
            {


                Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
                if (file != null)

                {
                    ContentDialog contentDialog = new ContentDialog
                    {
                        Title = "Загрузка данных из текстовой таблице",
                        Content = "Дождитесь закрытия этого окна." + "\n" + "Идет процесс ...",

                    };
                    contentDialog.ShowAsync();
                    IList<string> g = await Windows.Storage.FileIO.ReadLinesAsync(file);
                    int h = g.Count;
                    int x = 0;
                    try
                    {
                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
() =>
{

    contentDialog.Content = "Дождитесь закрытия этого окна." + "\n" + "Идет процесс ..." + "\n" + "Осталось: " + h.ToString();
});
                
                        foreach (string f in g)
                        {
                            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
() =>
{

contentDialog.Content = "Дождитесь закрытия этого окна." + "\n" + "Идет процесс ..." + "\n" + "Осталось: " + h.ToString();
});
                            h--;
                            string[] rows = f.Split("\t");
                            if (rows.Length != 0 && !rows[0].Contains("n"))
                            {
                                //count = Convert.ToInt32(rows[0]);
                                if (rows[1].Contains("T"))
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
                                                ll.Add(new ClassSobNeutron() { D = ic, Amp = 0, TimeAmp = 0, TimeEnd = 0, TimeEnd3 = 0, TimeFirst = 0, TimeFirst3 = 0 });


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


                      classSobNeutronsList = ll,
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
                    catch (Exception)
                    {
                        MessageDialog g1 = new MessageDialog("Ошибка в строке " + x.ToString());
                        await g1.ShowAsync();
                    }
                    //  MessageDialog g = new MessageDialog(text);
                    // await g.ShowAsync();
                    contentDialog.Hide();

                }
                else
                {

                }
            }
            catch (Exception)
            {
                var mess = new MessageDialog("Ошибка");
                await mess.ShowAsync();
            }
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
        private async void AppBarButton_Play(object sender, RoutedEventArgs e)
        {
            try
            {



                int MaxDur = Convert.ToInt16(TimeGate.Text);
                int MaxAmpl = Convert.ToInt16(MinAmplDetect.Text);
                int MinClust = Convert.ToInt16(MinClustDec.Text);
                double minAmpN = Convert.ToDouble(AmpNeBol.Text);
                ContentDialog contentDialog = new ContentDialog
                {
                    Title = "Поиск общих событий",
                    Content = "Дождитесь закрытия этого окна." + "\n" + "Идет процесс ...",

                };
                contentDialog.ShowAsync();
                await Task.Run(() => ObchSobURAN(MaxDur, MaxAmpl, MinClust, minAmpN, contentDialog));
                contentDialog.Hide();




            }
            catch (Exception ex)
            {
                MessageDialog messageDialog = new MessageDialog(ex.ToString());
                await messageDialog.ShowAsync();
            }

        }
        public async void ObchSobURAN(int MaxDur, int MaxAmpl, int MinClust, double AmpN, ContentDialog contentDialog)
        {
            try
            {

              //  contentDialog.ShowAsync();


                foreach (ClassSob classSob in ViewModel.ClassSobsT)
                {
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
() =>
{
    ViewModel._DataColecSobCopy.Add(classSob);
 

});
                }


              var  listC =  (from ClassSob in ViewModel._DataColecSobCopy
                         orderby ClassSob.time
                         select ClassSob).ToList();
              //  (Enumerable.Range(0, (data1.Length / 12)).Select(x => data1[i, x]).Max()) - nul;
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
() =>
{
textOb.Text = listC.Count().ToString();
    contentDialog.Content = "Дождитесь закрытия этого окна." + "\n" + "Идет процесс ..." + "\n" + "Осталось: " + listC.Count().ToString();
});

                while (listC.Count!=0)
                {
                    ClassSobColl classSobColl = new ClassSobColl();
               
                    
                  if (listC.Count != 0)
                  {

                        ParallelQuery<ClassSob> orderedNumbers;
                           // Debug.WriteLine("Выборка");
                           if (listC.Count()>=8)
                        {
                             orderedNumbers = from ClassSob in (Enumerable.Range(0, 8).Select(x => listC.ElementAt(x))).AsParallel()
                                                 where DateNanos.isEventSimul(listC.ElementAt(0).time, ClassSob.time, MaxDur)
                                              select ClassSob;
                        }
                           else
                        {
                           orderedNumbers = from ClassSob in (Enumerable.Range(0, listC.Count()).Select(x => listC.ElementAt(x))).AsParallel()
                                            where DateNanos.isEventSimul(listC.ElementAt(0).time, ClassSob.time, MaxDur)
                                                 select ClassSob;
                        }
                        
                           if ((orderedNumbers.Count()>= MinClust))
                        {

                            classSobColl.col.AddRange(orderedNumbers);
                            classSobColl.StartTime = orderedNumbers.ElementAt(0).time;
                            classSobColl.dateUR = orderedNumbers.ElementAt(0).dateUR;
                            classSobColl.SumAmpAndNeutronAndClaster();
                           
                           
                                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => { ViewModel._DataSobColli.Add(classSobColl); });
                                
                       
                        }
                          
                           // Debug.WriteLine("удаление");
                            var dd = orderedNumbers.Distinct();
                              foreach (ClassSob classSob in dd)
                              {
                          
                                  try
                                  {


                                      listC.Remove(classSob);
                                  }
                                  catch(Exception ex)
                                  {

                                  }
                         
                              }

                    }
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
() =>
{
    textOb.Text = listC.Count().ToString();
    contentDialog.Content = "Дождитесь закрытия этого окна." + "\n" + "Идет процесс ..." + "\n" + "Осталось: " + listC.Count().ToString();
});             
                   
                   // Debug.WriteLine("добавление в общию");
                   // Debug.WriteLine(classSobColl.StartTime.ToString());

                   
                }

             
            }


            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
               // new MessageDialog(ex.ToString()).ShowAsync();

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
       

        

        private async void Button_Click_7(object sender, RoutedEventArgs e)
        {
            DataPackage dataPackage = new DataPackage();
         

        
              await OutputClipboardText();
            colstroc.Text = ViewModel.ClassSobsT.Count().ToString();
            MessageDialog messageDialog = new MessageDialog("Данные вставлены!!!");
           await messageDialog.ShowAsync();
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
        private async void OnCheckBoxClick1(object sender, RoutedEventArgs e)
        {
            var cb = (CheckBox)sender;
            var newCheckedItem = (ClassSobV)cb.DataContext;
         
            if (cb.IsChecked.HasValue && cb.IsChecked.Value)
            {
                this.DataGridV.ShowRowDetailsForItem(newCheckedItem);
            }
            else
            {
                this.DataGridV.HideRowDetailsForItem(newCheckedItem);
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
        
            this.Frame.Navigate(typeof(BlankPageTemp), classSobs);

        }
        private async void StatNullLine_Clic(object sender, RoutedEventArgs e)
        {
            IDataView currentView = this.DataGrid.GetDataView();
            if (currentView.Items.Count > 0)
            {


                ObservableCollection<ClassSob> classSobs = new ObservableCollection<ClassSob>();
                foreach (ClassSob classSob in currentView)
                {
                    classSobs.Add(classSob);
                }

                this.Frame.Navigate(typeof(PageStatNullLine), classSobs);
            }

        }
        private async void StatSigLine_Clic(object sender, RoutedEventArgs e)
        {
            IDataView currentView = this.DataGrid.GetDataView();
            if (currentView.Items.Count > 0)
            {


                ObservableCollection<ClassSob> classSobs = new ObservableCollection<ClassSob>();
                foreach (ClassSob classSob in currentView)
                {
                    classSobs.Add(classSob);
                }

                this.Frame.Navigate(typeof(PageStatSig), classSobs);
            }

        }

        private void Sobitie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pivot tabView = (Pivot)sender;
            int x = tabView.SelectedIndex;
            if(x==2)
            {
                ed.IsEnabled = true;
                edAmp.IsEnabled = true;
                edN.IsEnabled = true;
            }
            else
            {
                ed.IsEnabled = false;
                edAmp.IsEnabled = false;
                edN.IsEnabled = false;
            }
        }

        private void Ed_Click(object sender, RoutedEventArgs e)
        {
            IDataView currentView = this.DataGrid1.GetDataView();
            if (currentView.Items.Count > 0)
            {
              

                ObservableCollection<ClassSobColl> classSobs = new ObservableCollection<ClassSobColl>();
                foreach (ClassSobColl classSob in currentView)
                {
                    classSobs.Add(classSob);
                }

                this.Frame.Navigate(typeof(PageStatSobTemp), classSobs);
            }
        }
        private void TimeN_Click(object sender, RoutedEventArgs e)
        {
            IDataView currentView = this.DataGrid.GetDataView();
            if (currentView.Items.Count > 0)
            {


                ObservableCollection<ClassSob> classSobs = new ObservableCollection<ClassSob>();
                foreach (ClassSob classSob in currentView)
                {
                    classSobs.Add(classSob);
                }

                this.Frame.Navigate(typeof(PageTimeDistrib), classSobs);
            }
        }
      
       
        private async void ListViewRight_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            MenuFlyout flyout = new MenuFlyout();
            ClassСписокList data = (ClassСписокList)args.Item;
            //  MessageDialog messageDialog = new MessageDialog(data.NameFile);
            // await messageDialog.ShowAsync();
            var deleteCommand = new StandardUICommand(StandardUICommandKind.Delete);

            deleteCommand.ExecuteRequested += DeleteCommand_ExecuteRequested;

        



            MenuFlyoutItem item = new MenuFlyoutItem() { Command = deleteCommand };
            flyout.Items.Add(item);
            args.ItemContainer.ContextFlyout = flyout;
        }

        private void DeleteCommand_ExecuteRequested(XamlUICommand sender, ExecuteRequestedEventArgs args)
        {
            if (args.Parameter != null)
            {
                foreach (var i in ViewModel.DataColec)
                {
                    if (i.Text == (args.Parameter as string))
                    {
                        ViewModel.DataColec.Remove(i);
                        return;
                    }
                }
            }
            if (listView1.SelectedIndex != -1)
            {
                ViewModel.DataColec.RemoveAt(listView1.SelectedIndex);
            }
        }
    }
}
