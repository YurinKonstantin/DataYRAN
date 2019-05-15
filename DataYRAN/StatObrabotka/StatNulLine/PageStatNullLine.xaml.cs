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

namespace DataYRAN.StatObrabotka.StatNulLine
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class PageStatNullLine : Page
    {
        public PageStatNullLine()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {


            if (e.Parameter is ObservableCollection<ClassSob>)
            {


                ObservableCollection<ClassSob> classRazvertka = e.Parameter as ObservableCollection<ClassSob>;

                try
                {

                    var orderedNumbers = from ClassSob in classRazvertka.AsParallel()
                                         where ClassSob.mNull[0] == 2048
                                         select ClassSob;

              
                    await NullLine(classRazvertka, 1);
                    await NullLineRas(classRazvertka);
                }
                catch(Exception ex)
                {
                    MessageDialog messageDialog = new MessageDialog(ex.ToString());
                    messageDialog.ShowAsync();
                }




            }
            else
            {

            }

            base.OnNavigatedTo(e);
        }
        public async Task NullLine(ObservableCollection<ClassSob> classRazvertka1, int cloc)
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
                    try
                    {


                        DateTime dateTimeTec = new DateTime(classSob.dateUR.GG, classSob.dateUR.MM, classSob.dateUR.DD, classSob.dateUR.HH, classSob.dateUR.Min, classSob.dateUR.CC, 0);

                        if (dateTimeTec.Subtract(dateTime).TotalHours >= 0 && dateTimeTec.Subtract(dateTime).TotalHours < cloc)
                        {
                            for (int ii = 0; ii < 12; ii++)
                            {

                                mas[ii] = mas[ii] + classSob.mNull[ii];

                            }

                            col++;
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageDialog messageDialog = new MessageDialog(ex.ToString() + dateTime1.Hour.ToString());
                        messageDialog.ShowAsync();
                    }
                }
                for(int j=0; j<12; j++)
                {
                    if (col > 0)
                        mas[j] = mas[j] / col;
                    else
                        mas[j] = 0;
                }
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
() =>
{
    DataColec.Add(new NullLine() { dateTime = dateTime, mNullLine = mas,  });
  
});

                col = 0;
                mas = new int[12];
                masN = new int[12];
                dateTime = dateTime1;
                dateTime1 = dateTime1.AddHours(cloc);

            }

          

        }
        List<ClassRasNul> classRasNuls = new List<ClassRasNul>();
        List<ClassRasNul> classRasNuls1 = new List<ClassRasNul>();
        public async Task NullLineRas(ObservableCollection<ClassSob> classRazvertka1)
        {
            
            foreach (ClassSob classSob in classRazvertka1)
            {
                for(int i=0; i<12; i++)
                {
                    var orderedNumbers1 = from ClassRasNul in classRasNuls1
                                          where ClassRasNul.znacRas == classSob.mNull[i]
                                          select ClassRasNul;
                    if (orderedNumbers1.Count() != 0)
                    {


                        foreach (ClassRasNul classRas in orderedNumbers1)
                        {
                            int[] f1 = classRas.MNullLine;
                            f1[i] = f1[i] + 1;
                        }
                    }
                    else
                    {
                        int[] f1 = new int[12];
                        f1[i] = 1;
                        classRasNuls1.Add(new ClassRasNul() { znacRas = classSob.mNull[i], MNullLine = f1 });
                    }
             



                    /*
                    if (classRasNuls.Count != 0)
                    {

                        int x = 0;
                       
                        foreach (ClassRasNul classRas in classRasNuls)
                        {
                            if(classRas.znacRas == classSob.mNull[i])
                            {
                                int[] f2 = classRas.MNullLine;
                                f2[i] = f2[i] + 1;


                                x++;

                            }
                         
                        }
                        if(x>0)
                        {
                            x = 0;
                        }
                        else
                        {
                            int[] f2 = new int[12];
                            f2[i] = 1;
                            classRasNuls.Add(new ClassRasNul() { znacRas = classSob.mNull[i], MNullLine = f2 });

                        }
                    }
                    else
                    {
                        int[] f3 = new int[12];
                        f3[0] = 1;
                        classRasNuls.Add(new ClassRasNul() { znacRas = classSob.mNull[i], MNullLine=f3  });
                    }
                    */
                }
             
              
            }
        //    var orderedNumbers = from ClassRasNul in classRasNuls
                               //  orderby ClassRasNul.znacRas
                                // select ClassRasNul;
            var orderedNumbersnew = from ClassRasNul in classRasNuls1
                                 orderby ClassRasNul.znacRas
                                 select ClassRasNul;
            DataColecN = orderedNumbersnew.ToList();
            NeutronGrid.ItemsSource = DataColecN;
       
           
            MessageDialog messageDialog = new MessageDialog("Конец");
            await messageDialog.ShowAsync();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPageObrData));
        }
        ObservableCollection<NullLine> _DataColec = new ObservableCollection<NullLine>();
        public ObservableCollection<NullLine> DataColec
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

        List<ClassRasNul> _DataColecN = new List<ClassRasNul>();
        public List<ClassRasNul> DataColecN
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
                   "NullLine" + "." + "txt", CreationCollisionOption.GenerateUniqueName)))
                    {
                        string sSob = "DateTime"  + "\t" + "D1" + "\t" + "D2" + "\t" + "D3" + "\t" + "D4" + "\t" + "D5" + "\t" + "D6" + "\t" + "D7"
                            + "\t" + "D8" + "\t" + "D9" + "\t" + "D10" + "\t" + "D11" + "\t" + "D12";


                        await writer.WriteLineAsync(sSob);
                        foreach (NullLine sob in DataColec)
                        {

                            string Sob = sob.dateTime.ToString() + "\t" + sob.mNullLine[0].ToString() + "\t" + sob.mNullLine[1].ToString() + "\t" +
                           sob.mNullLine[2].ToString() + "\t" + sob.mNullLine[3].ToString() + "\t" + sob.mNullLine[4].ToString() + "\t" + sob.mNullLine[5].ToString() + "\t" + sob.mNullLine[6].ToString() + "\t" + sob.mNullLine[7].ToString() +
                            "\t" + sob.mNullLine[8].ToString() + "\t" + sob.mNullLine[9].ToString() + "\t" + sob.mNullLine[10].ToString() + "\t" + sob.mNullLine[11].ToString();
                            await writer.WriteLineAsync(Sob);
                        }
                    }
                }
                if (DataColecN.Count != 0)
                {
                    using (StreamWriter writer =
                   new StreamWriter(await folder.OpenStreamForWriteAsync(
                   "РаспределениеNullLine" + "." + "txt", CreationCollisionOption.GenerateUniqueName)))
                    {
                        string sSob = "Код АЦП" + "\t" + "D1" + "\t" + "D2" + "\t" + "D3" + "\t" + "D4" + "\t" + "D5" + "\t" + "D6" + "\t" + "D7"
                            + "\t" + "D8" + "\t" + "D9" + "\t" + "D10" + "\t" + "D11" + "\t" + "D12";


                        await writer.WriteLineAsync(sSob);
                        foreach (ClassRasNul sob in DataColecN)
                        {

                            string Sob = sob.znacRas.ToString() + "\t" + sob.MNullLine[0].ToString() + "\t" + sob.MNullLine[1].ToString() + "\t" +
                            sob.MNullLine[2].ToString() + "\t" + sob.MNullLine[3].ToString() + "\t" + sob.MNullLine[4].ToString() + "\t" + sob.MNullLine[5].ToString() + "\t" + sob.MNullLine[6].ToString() + "\t" + sob.MNullLine[7].ToString() +
                            "\t" + sob.MNullLine[8].ToString() + "\t" + sob.MNullLine[9].ToString() + "\t" + sob.MNullLine[10].ToString() + "\t" + sob.MNullLine[11].ToString();
                            await writer.WriteLineAsync(Sob);
                        }
                    }
                }

                MessageDialog messageDialog = new MessageDialog("Статистика нулевых линий сохранена сохранен");
                await messageDialog.ShowAsync();

            }
            else
            {

            }
        }

        private async void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pivot pivot = (Pivot)sender;
            if (pivot!=null && pivot.SelectedItem != null)
            {
                if(pivot.SelectedIndex==0)
                {
                    pivot.Title = "Среднее значение за час";
                }
                if (pivot.SelectedIndex == 1)
                {
                    pivot.Title = "Распределение";
                }


            }
        }
    }
}
