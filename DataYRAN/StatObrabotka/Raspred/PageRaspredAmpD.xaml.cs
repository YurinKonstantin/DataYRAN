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

namespace DataYRAN.StatObrabotka.Raspred
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class PageRaspredAmpD : Page
    {
        public PageRaspredAmpD()
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

                  
                    await AmpRas(classRazvertka);
                }
                catch (Exception ex)
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
      
   
        List<ClassRasAmp> classRasNuls1 = new List<ClassRasAmp>();
        public async Task AmpRas(ObservableCollection<ClassSob> classRazvertka1)
        {

            foreach (ClassSob classSob in classRazvertka1)
            {
                for (int i = 0; i < 12; i++)
                {
                    var orderedNumbers1 = from ClassRasAmp in classRasNuls1
                                          where ClassRasAmp.znacRas == classSob.mAmp[i]
                                          select ClassRasAmp;
                    if (orderedNumbers1.Count() != 0)
                    {


                        foreach (ClassRasAmp classRas in orderedNumbers1)
                        {
                            int[] f1 = classRas.MAmp;
                            f1[i] = f1[i] + 1;
                        }
                    }
                    else
                    {
                        int[] f1 = new int[12];
                        f1[i] = 1;
                        classRasNuls1.Add(new ClassRasAmp() { znacRas = classSob.mNull[i], MAmp = f1 });
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
     

        List<ClassRasAmp> _DataColecN = new List<ClassRasAmp>();
        public List<ClassRasAmp> DataColecN
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



                
                if (DataColecN.Count != 0)
                {
                    using (StreamWriter writer =
                   new StreamWriter(await folder.OpenStreamForWriteAsync(
                   "РаспределениеAmp" + "." + "txt", CreationCollisionOption.GenerateUniqueName)))
                    {
                        string sSob = "Код АЦП" + "\t" + "D1" + "\t" + "D2" + "\t" + "D3" + "\t" + "D4" + "\t" + "D5" + "\t" + "D6" + "\t" + "D7"
                            + "\t" + "D8" + "\t" + "D9" + "\t" + "D10" + "\t" + "D11" + "\t" + "D12";


                        await writer.WriteLineAsync(sSob);
                        foreach (ClassRasAmp sob in DataColecN)
                        {

                            string Sob = sob.znacRas.ToString() + "\t" + sob.MAmp[0].ToString() + "\t" + sob.MAmp[1].ToString() + "\t" +
                            sob.MAmp[2].ToString() + "\t" + sob.MAmp[3].ToString() + "\t" + sob.MAmp[4].ToString() + "\t" + sob.MAmp[5].ToString() + "\t" + sob.MAmp[6].ToString() + "\t" + sob.MAmp[7].ToString() +
                            "\t" + sob.MAmp[8].ToString() + "\t" + sob.MAmp[9].ToString() + "\t" + sob.MAmp[10].ToString() + "\t" + sob.MAmp[11].ToString();
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
            if (pivot != null && pivot.SelectedItem != null)
            {
                if (pivot.SelectedIndex == 0)
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
