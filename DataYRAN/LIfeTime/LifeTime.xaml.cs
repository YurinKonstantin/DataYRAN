using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Telerik.UI.Xaml.Controls.Grid;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace DataYRAN.LIfeTime
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class LifeTime : Page
    {
        public LifeTime()
        {
            this.InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPageObrData));
        }
        ObservableCollection<ClassFileLT> _DataColecF = new ObservableCollection<ClassFileLT>();
        public ObservableCollection<ClassFileLT> DataColecF
        {
            get
            {
                return _DataColecF;
            }
            set
            {
                _DataColecF = value;

            }
        }
        ObservableCollection<ClassLifeTime> _DataColec = new ObservableCollection<ClassLifeTime>();
        public ObservableCollection<ClassLifeTime> DataColec
        {
            get
            {
                return _DataColec;
            }
            set
            {
                _DataColec = value;

            }
        }
        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
           

      

            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".txt");
            picker.FileTypeFilter.Add(".dat");
            picker.FileTypeFilter.Add(".rtf");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                this.nameFile.Text = "Имя файла: " + file.Name;
                char[] rowSplitter = { '\r', '\n' };
                
                string[] text = (await Windows.Storage.FileIO.ReadTextAsync(file)).Split(rowSplitter, StringSplitOptions.RemoveEmptyEntries);
                for(int i=0; i<text.Length; i++)
                {
                    string[] text1 = text[i].Split('\t');
                    try
                    {


                        if (text1[3] == String.Empty || text1[3] == null || text1[4] == String.Empty || text1[4] == null || text1[1].Split('_')[1] == "Test")
                        {

                        }
                        else
                        {
                            DataColecF.Add(new ClassFileLT() { nomer = Convert.ToInt32(text1[0]), nameFile = text1[1], TimeOpen = text1[3], TimeClose = text1[4], nameRun = text1[5] });
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageDialog messageDialog = new MessageDialog(ex.ToString());
                       await messageDialog.ShowAsync();
                    }
                }
              

            }
            else
            {
                this.nameFile.Text = "Файл не выбран";
            }
        }

        private async void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {


                IDataView currentView = this.DataGrid.GetDataView();
                ObservableCollection<ClassFileLT> classSobs = new ObservableCollection<ClassFileLT>();
                foreach (ClassFileLT classSob in currentView)
                {
                    classSobs.Add(classSob);
                }
                // await Task.Run(() => LF(classSobs));
              await  LF(classSobs);
            }
            catch(Exception ex)
            {
                MessageDialog messageDialog = new MessageDialog("ошибка"+"\n"+ex.ToString());
                await messageDialog.ShowAsync();
            }
            finally
            {
                MessageDialog messageDialog = new MessageDialog("Конец");
                await messageDialog.ShowAsync();
            }
         

        }
        public async Task LF(ObservableCollection<ClassFileLT> classRazvertka1)
        {

            var orderedNumbers = from ClassFileLT in classRazvertka1
                                 orderby ClassFileLT.DateTimeOpen
                                 select ClassFileLT;
            DateTime dateTime = new DateTime( orderedNumbers.ElementAt(0).DateTimeOpen.Year, orderedNumbers.ElementAt(0).DateTimeOpen.Month, orderedNumbers.ElementAt(0).DateTimeOpen.Day);
            DateTime dateTimeFirst = dateTime;
            
            DateTime dateTimeEnd = orderedNumbers.ElementAt(orderedNumbers.Count() - 1).DateTimeOpen;

       
            double[] masTime = new double[7]; 
            for (int i = 0; i <= dateTimeEnd.Subtract(dateTimeFirst).TotalDays; i++)
            {

                try
                {


                    foreach (ClassFileLT classSob in orderedNumbers)
                    {
                        if (classSob.Tip == "T")
                        {
                            try
                            {



                                DateTime dateTimeTec = classSob.DateTimeOpen;

                                if (dateTime.ToShortDateString()== classSob.DateTimeOpen.ToShortDateString() || (dateTime.ToShortDateString() == classSob.DateTimeClose.ToShortDateString()))
                                {
                                    if(dateTime.ToShortDateString() == classSob.DateTimeOpen.ToShortDateString() && (dateTime.ToShortDateString() == classSob.DateTimeClose.ToShortDateString()))
                                    {
                                        masTime[classSob.Klaster - 1] = masTime[classSob.Klaster - 1] + classSob.DurTime;
                                    }
                                    if (dateTime.ToShortDateString() == classSob.DateTimeOpen.ToShortDateString() && (dateTime.ToShortDateString() != classSob.DateTimeClose.ToShortDateString()))
                                    {
                                        DateTime dateTime1 = new DateTime(classSob.DateTimeClose.Year, classSob.DateTimeClose.Month, classSob.DateTimeClose.Day);
                                        masTime[classSob.Klaster - 1] = masTime[classSob.Klaster - 1] + classSob.DurTime - (double)(classSob.DateTimeClose.Subtract(dateTime1).TotalHours);
                                    }
                                    if (dateTime.ToShortDateString() != classSob.DateTimeOpen.ToShortDateString() && (dateTime.ToShortDateString() == classSob.DateTimeClose.ToShortDateString()))
                                    {
                                        DateTime dateTime1 = new DateTime(classSob.DateTimeOpen.Year, classSob.DateTimeOpen.Month, classSob.DateTimeOpen.Day);
                                        masTime[classSob.Klaster - 1] = masTime[classSob.Klaster - 1] + classSob.DurTime -(24- (double)(classSob.DateTimeOpen.Subtract(dateTime1).TotalHours));
                                    }
                                    // MessageDialog messageDialog = new MessageDialog("Kl="+classSob.Klaster.ToString()+ "\t"+  classSob.DurTime.ToString()+"\n"+ classSob.nomer.ToString()+"\n"+ classSob.nameFile
                                    //    +"\n"+ classSob.TimeOpen);
                                    //await messageDialog.ShowAsync();
                                }
                            }
                            catch
                            {
                             //   MessageDialog messageDialog2 = new MessageDialog(classSob.nameFile);
                             //   await messageDialog2.ShowAsync();

                            }
                        }
                    }
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
    () =>
    {
        DataColec.Add(new ClassLifeTime() { _DateTime = dateTime, mLT = masTime });

    });


                    dateTime = dateTime.AddDays(1);
                    masTime = new double[7];
                }
                catch(Exception ex)
                {
                    MessageDialog messageDialog2 = new MessageDialog(ex.ToString());
                    await messageDialog2.ShowAsync();

                }

            }


           
        }

        private void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            DataColec.Clear();
        }

        private async void AppBarButton_Click_3(object sender, RoutedEventArgs e)
        {
            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add("*");

            Windows.Storage.StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {



                if (DataColec.Count != 0)
                {
                    using (StreamWriter writer =
                   new StreamWriter(await folder.OpenStreamForWriteAsync(
                   "LifeTime" + "." + "txt", CreationCollisionOption.GenerateUniqueName)))
                    {
                        string sSob = "DateTime" + "\t" + "LifeTimeKl1" + "\t" + "LifeTimeKl2" + "\t" + "LifeTimeKl3" + "\t" + "LifeTimeKl4" + "\t" + "LifeTimeKl5" + "\t" + "LifeTimeKl6"
                            + "\t" + "LifeTimeKl7" +"\t"+"LifeTimeURAN";


                        await writer.WriteLineAsync(sSob);
                        foreach (ClassLifeTime sob in DataColec)
                        {

                            string Sob = sob.Date + "\t" + sob.mLT1.ToString() + "\t" + sob.mLT2.ToString() + "\t" + sob.mLT3.ToString() + "\t" + sob.mLT4.ToString() + "\t" +
                           sob.mLT5.ToString() + "\t" + sob.mLT6.ToString() + "\t" + sob.mLT7.ToString()+"\t"+sob.mLTURAN.ToString();
                            await writer.WriteLineAsync(Sob);
                        }
                    }
                }
             

                MessageDialog messageDialog = new MessageDialog("Живое время сохранено");
                await messageDialog.ShowAsync();

            }
            else
            {

            }
        }

        private void AppBarButton_Click_4(object sender, RoutedEventArgs e)
        {
            DataColecF.Clear();
        }

        private void AppBarButton_Click_5(object sender, RoutedEventArgs e)
        {
            DataColecF.Clear();
            DataColec.Clear();

        }
    }
}
