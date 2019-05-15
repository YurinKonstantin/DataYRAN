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
            int[] mas = new int[12];
            int[] masN = new int[12];
            for (int i = 0; i <= dateTimeEnd.Subtract(dateTimeFirst).TotalHours; i++)
            {


                foreach (ClassSob classSob in orderedNumbers)
                {
                    DateTime dateTimeTec = new DateTime(classSob.dateUR.GG, classSob.dateUR.MM, classSob.dateUR.DD, classSob.dateUR.HH, classSob.dateUR.Min, classSob.dateUR.CC, 0);

                    if (dateTimeTec.Subtract(dateTime).TotalHours >= 0 && dateTimeTec.Subtract(dateTime).TotalHours < cloc)
                    {
                        for (int ii = 0; ii < 12; ii++)
                        {
                            if (classSob.mAmp[ii] >= 10)
                            {
                                mas[ii] = mas[ii] + 1;
                            }

                        }
                        masN[0] = masN[0] + classSob.Nnut0;
                        masN[1] = masN[1] + classSob.Nnut1;
                        masN[2] = masN[2] + classSob.Nnut2;
                        masN[3] = masN[3] + classSob.Nnut3;
                        masN[4] = masN[4] + classSob.Nnut4;
                        masN[5] = masN[5] + classSob.Nnut5;
                        masN[6] = masN[6] + classSob.Nnut6;
                        masN[7] = masN[7] + classSob.Nnut7;
                        masN[8] = masN[8] + classSob.Nnut8;
                        masN[9] = masN[9] + classSob.Nnut9;
                        masN[10] = masN[10] + classSob.Nnut10;
                        masN[11] = masN[11] + classSob.Nnut11;
                        col++;
                    }
                }
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
() =>
{
    DataColec.Add(new ClassTemp() { dateTime = dateTime, mTemp = mas, colSob = col });
    DataColecN.Add(new ClassTemp() { dateTime = dateTime, mTemp = masN });
});

                col = 0;
                mas = new int[12];
                masN = new int[12];
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
        ObservableCollection<ClassTemp> _DataColec = new ObservableCollection<ClassTemp>();
        public ObservableCollection<ClassTemp> DataColec
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

        ObservableCollection<ClassTemp> _DataColecN = new ObservableCollection<ClassTemp>();
        public ObservableCollection<ClassTemp> DataColecN
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
                        string sSob = "DateTime" + "\t" + "SobTemp" + "\t" + "SumDTemp" + "\t" + "TempD1" + "\t" + "TempD2" + "\t" + "TempD3" + "\t" + "TempD4" + "\t" + "TempD5" + "\t" + "TempD6" + "\t" + "TempD7"
                            + "\t" + "TempD8" + "\t" + "TempD9" + "\t" + "TempD10" + "\t" + "TempD11" + "\t" + "TempD12";


                        await writer.WriteLineAsync(sSob);
                        foreach (ClassTemp sob in DataColec)
                        {

                            string Sob = sob.dateTime.ToString() + "\t" + sob.colSob.ToString() + "\t" + sob.Temp.ToString() + "\t" + sob.mTemp[0].ToString() + "\t" + sob.mTemp[1].ToString() + "\t" +
                            sob.mTemp[2].ToString() + "\t" + sob.mTemp[3].ToString() + "\t" + sob.mTemp[4].ToString() + "\t" + sob.mTemp[5].ToString() + "\t" + sob.mTemp[6].ToString() + "\t" + sob.mTemp[7].ToString() +
                            "\t" + sob.mTemp[8].ToString() + "\t" + sob.mTemp[9].ToString() + "\t" + sob.mTemp[10].ToString() + "\t" + sob.mTemp[11].ToString();
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
                        string sSob = "DateTime" + "\t" + "STemp" + "\t" + "TempD1" + "\t" + "TempD2" + "\t" + "TempD3" + "\t" + "TempD4" + "\t" + "TempD5" + "\t" + "TempD6" + "\t" + "TempD7"
                            + "\t" + "TempD8" + "\t" + "TempD9" + "\t" + "TempD10" + "\t" + "TempD11" + "\t" + "TempD12";


                        await writer.WriteLineAsync(sSob);
                        foreach (ClassTemp sob in DataColecN)
                        {

                            string Sob = sob.dateTime.ToString() + "\t" + sob.Temp.ToString() + "\t" + sob.mTemp[0].ToString() + "\t" + sob.mTemp[1].ToString() + "\t" +
                            sob.mTemp[2].ToString() + "\t" + sob.mTemp[3].ToString() + "\t" + sob.mTemp[4].ToString() + "\t" + sob.mTemp[5].ToString() + "\t" + sob.mTemp[6].ToString() + "\t" + sob.mTemp[7].ToString() +
                            "\t" + sob.mTemp[8].ToString() + "\t" + sob.mTemp[9].ToString() + "\t" + sob.mTemp[10].ToString() + "\t" + sob.mTemp[11].ToString();
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
