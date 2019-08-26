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

namespace DataYRAN.StatObrabotka.TimeDistribuchen
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class PageTimeDistrib : Page
    {
        public PageTimeDistrib()
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
                                         where ClassSob.SumNeu > 0
                               select ClassSob;

                   List<ClassSobNeutron> classSobNeutronsd = new List<ClassSobNeutron>();
                 foreach(ClassSob classSob in orderedNumbers)
                    {
                        classSobNeutronsd.AddRange(classSob.classSobNeutronsList);
                    }
                    await NullLineRas(classSobNeutronsd);
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

        List<ClassTD> classTDList = new List<ClassTD>();
        public async Task NullLineRas(List<ClassSobNeutron> classRazvertka1)
        {

        
                


                    for (int i = 0; i < 20000; i++)
                    {
                        var orderedNumbers1 = from ClassRasNul in classRazvertka1
                                              where ClassRasNul.TimeAmp == i
                                              select ClassRasNul;
                        if (orderedNumbers1.Count() != 0)
                        {


                    classTDList.Add(new ClassTD() { Time = i, Count1 = orderedNumbers1.Count() });


                        }
                        else
                {
                    classTDList.Add(new ClassTD() { Time = i, Count1 = 0 });
                }
                   




                    }






            NeutronGrid.ItemsSource = classTDList;


            MessageDialog messageDialog = new MessageDialog("Конец");
            await messageDialog.ShowAsync();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPageObrData));
        }
       
 

   

        private async void AppBarButton(object sender, RoutedEventArgs e)
        {

            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add("*");

            Windows.Storage.StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {



                if (classTDList.Count != 0)
                {
                    using (StreamWriter writer =
                   new StreamWriter(await folder.OpenStreamForWriteAsync(
                   "TimeDisrrib" + "." + "txt", CreationCollisionOption.GenerateUniqueName)))
                    {
                        string sSob = "Time" + "\t" + "N";


                        await writer.WriteLineAsync(sSob);
                        foreach (ClassTD sob in classTDList)
                        {

                            string Sob = sob.Time.ToString() + "\t" + sob.Count1.ToString();
                            await writer.WriteLineAsync(Sob);
                        }
                    }
                }
            

                MessageDialog messageDialog = new MessageDialog("временное распределение сохранено");
                await messageDialog.ShowAsync();

            }
            else
            {

            }
        }

    }
}
