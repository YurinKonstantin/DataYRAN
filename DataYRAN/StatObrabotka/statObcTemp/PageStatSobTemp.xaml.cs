using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

namespace DataYRAN.StatObrabotka.statObcTemp
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class PageStatSobTemp : Page
    {
        public PageStatSobTemp()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {


            if (e.Parameter is ObservableCollection<ClassSobColl>)
            {


                ObservableCollection<ClassSobColl> classRazvertka = e.Parameter as ObservableCollection<ClassSobColl>;

                await Temp(classRazvertka, 1);





            }
            else
            {

            }

            base.OnNavigatedTo(e);
        }
        public async Task Temp(ObservableCollection<ClassSobColl> classRazvertka1, int cloc)
        {

            var orderedNumbers = from ClassSob in classRazvertka1
                                 orderby ClassSob.dateUR.DateTimeString()
                                 select ClassSob;
            DateTime dateTime = new DateTime(orderedNumbers.ElementAt(0).dateUR.GG, orderedNumbers.ElementAt(0).dateUR.MM, orderedNumbers.ElementAt(0).dateUR.DD, orderedNumbers.ElementAt(0).dateUR.HH, 0, 0, 0);
            DateTime dateTimeFirst = new DateTime(orderedNumbers.ElementAt(0).dateUR.GG, orderedNumbers.ElementAt(0).dateUR.MM, orderedNumbers.ElementAt(0).dateUR.DD, orderedNumbers.ElementAt(0).dateUR.HH, 0, 0, 0);

            DateTime dateTime1 = dateTime; //new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0, 0);
            DateTime dateTimeEnd = new DateTime(orderedNumbers.ElementAt(orderedNumbers.Count() - 1).dateUR.GG, orderedNumbers.ElementAt(orderedNumbers.Count() - 1).dateUR.MM, orderedNumbers.ElementAt(orderedNumbers.Count() - 1).dateUR.DD, orderedNumbers.ElementAt(orderedNumbers.Count() - 1).dateUR.HH, 0, 0, 0);

            dateTime1 = dateTime1.AddHours(cloc);
            int col = 0;
            int mas = 0;
            int masN = 0;
            int masK = 0;
            for (int i = 0; i <= dateTimeEnd.Subtract(dateTimeFirst).TotalHours; i++)
            {


                foreach (ClassSobColl classSob in orderedNumbers)
                {
                    DateTime dateTimeTec = new DateTime(classSob.dateUR.GG, classSob.dateUR.MM, classSob.dateUR.DD, classSob.dateUR.HH, classSob.dateUR.Min, classSob.dateUR.CC, 0);

                    if (dateTimeTec.Subtract(dateTime).TotalHours >= 0 && dateTimeTec.Subtract(dateTime).TotalHours < cloc)
                    {
                        mas++; ;
                        masN += classSob.SummNeu;
                        masK += classSob.SumClast;

                        col++;
                    }
                }
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
() =>
{
    DataColec.Add(new ClassTempObc() { dateTime = dateTime, Temp = mas, colSob = col });
    DataColecN.Add(new ClassTempObc() { dateTime = dateTime, Temp = masN });
});

                col = 0;
                mas = 0;
                masN = 0;
                masK = 0;
               dateTime = dateTime1;
                dateTime1 = dateTime1.AddHours(cloc);

            }

            MessageDialog messageDialog = new MessageDialog("Конец");
            await messageDialog.ShowAsync();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPageObrData));
        }
        ObservableCollection<ClassTempObc> _DataColec = new ObservableCollection<ClassTempObc>();
        public ObservableCollection<ClassTempObc> DataColec
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

        ObservableCollection<ClassTempObc> _DataColecN = new ObservableCollection<ClassTempObc>();
        public ObservableCollection<ClassTempObc> DataColecN
        {
            get
            {
                return _DataColecN;
            }
            set
            {
                _DataColecN = value;

            }
        }

        private async void AppBarButton(object sender, RoutedEventArgs e)
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
                   "TempSob" + "." + "txt", CreationCollisionOption.GenerateUniqueName)))
                    {
                        string sSob = "DateTime" + "\t" + "SobTemp";


                        await writer.WriteLineAsync(sSob);
                        foreach (ClassTempObc sob in DataColec)
                        {

                            string Sob = sob.dateTime.ToString() + "\t" + sob.Temp.ToString();
                            await writer.WriteLineAsync(Sob);
                        }
                    }
                }
                if (DataColecN.Count != 0)
                {
                    using (StreamWriter writer =
                   new StreamWriter(await folder.OpenStreamForWriteAsync(
                   "TempSobN" + "." + "txt", CreationCollisionOption.GenerateUniqueName)))
                    {
                        string sSob = "DateTime" + "\t" + "STemp";


                        await writer.WriteLineAsync(sSob);
                        foreach (ClassTempObc sob in DataColecN)
                        {

                            string Sob = sob.dateTime.ToString() + "\t" + sob.Temp.ToString();
                            await writer.WriteLineAsync(Sob);
                        }
                    }
                }

                MessageDialog messageDialog = new MessageDialog("Темп сохранен");
                await messageDialog.ShowAsync();

            }
            else
            {

            }
        }
        private void rankLowFilter_Click(object sender, RoutedEventArgs e)
        {
            int x = 100;
            EmployeeGrid.ItemsSource = new ObservableCollection<ClassTempObc>(from item in DataColec
                                                                              where item.Temp > x
                                                                              select item);
        }
        private void ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeGrid != null)
            {
                EmployeeGrid.ItemsSource = DataColec;
            }
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
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
                   "TempSobFil50" + "." + "txt", CreationCollisionOption.GenerateUniqueName)))
                    {
                        string sSob = "DateTime" + "\t" + "SobTemp";


                        await writer.WriteLineAsync(sSob);
                        foreach (ClassTempObc sob in EmployeeGrid.ItemsSource)
                        {

                            string Sob = sob.dateTime.ToString() + "\t" + sob.Temp.ToString();
                            await writer.WriteLineAsync(Sob);
                        }
                    }
                }
             

                MessageDialog messageDialog = new MessageDialog("Темп сохранен");
                await messageDialog.ShowAsync();

            }
            else
            {

            }
        }
    }
}
