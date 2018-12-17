using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Telerik.UI.Xaml.Controls.Chart;
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

namespace DataYRAN
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class BlankPageRazverta : Page
    {
        public BlankPageRazverta()
        {
            this.InitializeComponent();
            _ClassViewModalTab = new ClassViewModalTab();
          
        }
       ClassViewModalTab _ClassViewModalTab { get; set; }
        ClassRazvertka ClassRazvertkaR = new ClassRazvertka();
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _ClassTable = new ClassTabs();
           
            if (e.Parameter is ClassRazvertka )
            {
                ClassRazvertka classRazvertka = e.Parameter as ClassRazvertka;
                ClassRazvertkaR = classRazvertka;
                textZag.Text = classRazvertka.nameFile1;
                _ClassTable.newTab(classRazvertka.nameFile1);
                for(int i=0; i<12; i++)
                {
                    newColon(_ClassTable.dataGrid, _ClassTable.newColums(i.ToString()));
                }
                string s = "i" + "\t" + "Ch1" + "\t" + "Ch2" + "\t" + "Ch3" + "\t" + "Ch4" + "\t" + "Ch5" + "\t" + "Ch6" + "\t" + "Ch7" + "\t" + "Ch8" + "\t" + "Ch9" + "\t" + "Ch10" + "\t" + "Ch11" + "\t" + "Ch12" + "\r\n";
                for (int i = 0; i < 1024; i++)
                {
                    int[] mas = new int[12]; 
                    s = s + (i + 1).ToString() + "\t";
                    for (int j = 0; j < 12; j++)
                    {
                        mas[j] = classRazvertka.data[j, i];
                        s = s + classRazvertka.data[j, i] + "\t";
                        _ClassTable.newRows(mas);
                    }
                    if (i < 1023)
                    {
                        s = s + "\r\n";
                    }
                    else
                    {

                    }
                }
                
                textT.Text = s;
            }
            else
            {
                _ClassTable.newTab("Новая таблица");
            }
           
            base.OnNavigatedTo(e);
        }
        public void newColon(DataGrid dataGrid, string name)
        {
            dataGrid.Columns.Add(new Microsoft.Toolkit.Uwp.UI.Controls.DataGridTextColumn()
            {
                Header = name,
                Binding = new Binding { Path = new PropertyPath("[" + name + "]") },
                IsReadOnly = false
            });


        }
        ClassTabs _ClassTable { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPageObrData));
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
          await  saveAsync(ClassRazvertkaR.data, ClassRazvertkaR.dataTail, ClassRazvertkaR.Time, ClassRazvertkaR.nameFile1);
        }
        /// <summary>
        /// Сохраняет развертку в локальную папку
        /// </summary>
        /// <param name="data"></param>
        /// <param name="Tail"></param>
        /// <param name="time"></param>
        /// <param name="nameFile"></param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task saveAsync(int[,] data, int[,] Tail, string time, string nameFile)
        {
            string cul = "en-US";
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
                StorageFolder storageFolderRazvertka = await folder.CreateFolderAsync("Развертка", CreationCollisionOption.OpenIfExists);
                StorageFile sampleFile = await storageFolderRazvertka.CreateFileAsync(nameFile + time + ".txt", CreationCollisionOption.ReplaceExisting);
                var stream = await sampleFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
                using (var outputStream = stream.GetOutputStreamAt(0))
                {
                    using (var dataWriter = new Windows.Storage.Streams.DataWriter(outputStream))
                    {
                        string s = "i" + "\t" + "Ch1" + "\t" + "Ch2" + "\t" + "Ch3" + "\t" + "Ch4" + "\t" + "Ch5" + "\t" + "Ch6" + "\t" + "Ch7" + "\t" + "Ch8" + "\t" + "Ch9" + "\t" + "Ch10" + "\t" + "Ch11" + "\t" + "Ch12" + "\r\n";
                        for (int i = 0; i < 1024; i++)
                        {
                            s = s + (i + 1).ToString() + "\t";
                            for (int j = 0; j < 12; j++)
                            {
                                s = s + data[j, i] + "\t";
                            }
                            if (i < 1023)
                            {
                                s = s + "\r\n";
                            }
                            else
                            {

                            }
                        }
                        dataWriter.WriteString(s);
                        s = null;
                        await dataWriter.StoreAsync();
                        await outputStream.FlushAsync();
                    }
                }
                stream.Dispose(); // Or use the stream variable (see previous code snippet) with a using statement as well.
                if (ClassUserSetUp.TipTail)
                {
                   // storageFolderRazvertka = await storageFolderRazvertka.CreateFolderAsync("Развертка", CreationCollisionOption.OpenIfExists);
                    sampleFile = await storageFolderRazvertka.CreateFileAsync(nameFile + time + "Хвост" + ".txt", CreationCollisionOption.ReplaceExisting);

                    stream = await sampleFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
                    using (var outputStream = stream.GetOutputStreamAt(0))
                    {
                        using (var dataWriter = new Windows.Storage.Streams.DataWriter(outputStream))
                        {
                            string s = "i" + "\t" + "Ch1" + "\t" + "Ch2" + "\t" + "Ch3" + "\t" + "Ch4" + "\t" + "Ch5" + "\t" + "Ch6" + "\t" + "Ch7" + "\t" + "Ch8" + "\t" + "Ch9" + "\t" + "Ch10" + "\t" + "Ch11" + "\t" + "Ch12" + "\r\n";
                            for (int i = 0; i < 20000; i++)
                            {
                                s = s + (i + 1).ToString() + "\t";
                                for (int j = 0; j < 12; j++)
                                {
                                    s = s + Tail[j, i] + "\t";
                                }
                                if (i < 19999)
                                {
                                    s = s + "\r\n";
                                }
                                else
                                {

                                }

                                dataWriter.WriteString(s);
                                s = null;
                            }

                            await dataWriter.StoreAsync();
                            await outputStream.FlushAsync();
                        }
                    }
                    stream.Dispose();
                }
            }

        }
        private void DataGrid1_Loading(FrameworkElement sender, object args)
        {
            
            DataGrid dataGrid = (DataGrid)sender;
            _ClassTable.dataGrid = dataGrid;
            if (_ClassTable.booksTable != null) // table is a DataTable
            {
                dataGrid.Columns.Clear();
                int i = 0;
                foreach (DataColumn col in _ClassTable.booksTable.Columns)
                {
                    // booksTable.Columns.Add(
                    //  new DataGridTextColumn
                    //  {
                    //    Header = col.ColumnName,

                    //   Binding = new Binding(string.Format("[{0}]", col.ColumnName))



                    //  });

                    dataGrid.Columns.Add(new Microsoft.Toolkit.Uwp.UI.Controls.DataGridTextColumn()
                    {
                        Header = col.ColumnName,
                        Binding = new Binding { Path = new PropertyPath("[" + col.ColumnName.ToString() + "]") },
                        IsReadOnly = false
                    });

                }

            }
        }

        private async void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            border.Visibility = Visibility.Visible;



     




            if (_ClassTable.booksTable != null) // table is a DataTable
            {
                List<string> vs = new List<string>();
                int i = 0;
                foreach (DataColumn col in _ClassTable.booksTable.Columns)
                {
                    // booksTable.Columns.Add(
                    //  new DataGridTextColumn
                    //  {
                    //    Header = col.ColumnName,

                    //   Binding = new Binding(string.Format("[{0}]", col.ColumnName))



                    //  })
                    vs.Add(col.ColumnName.ToString());
                   
                

                }
                ListKol.ItemsSource = vs;

            }

        }
       
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int x = 0;
            List<string> vs1 = new List<string>();
            foreach (string vs in ListKol.SelectedItems)
            {
               
                vs1.Add(vs);
                }
            radChart.Series.Clear();
          _ClassTable.newGrafSer(vs1);
            MessageDialog messageDialog = new MessageDialog(_ClassTable.collectionGraf.Count.ToString());
           await messageDialog.ShowAsync();
            for(int i=0; i<_ClassTable.collectionGraf.Count; i++)
            {
                
                radChart.Series.Add(new LineSeries() { });
                radChart.Series[i].Name = _ClassTable.collectionGraf.ElementAt(i).name;              
                radChart.Series[i].ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf;
            }
            //radChart.Series.Add(new LineSeries());
            //radChart.Series[0].ItemsSource = _ClassViewModalTab._DataColecGraf1;
            // TabHeadRazGraf1.IsSelected = true;
            MessageDialog messageDialog1 = new MessageDialog(radChart.Series.Count.ToString(), "лини1");
           await messageDialog.ShowAsync();
            border.Visibility = Visibility.Collapsed;
        }
    }
}
