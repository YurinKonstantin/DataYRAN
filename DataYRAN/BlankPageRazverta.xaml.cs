using LiveCharts;
using LiveCharts.Uwp;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Effects;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using Telerik.UI.Xaml.Controls.Chart;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Graphics.Imaging;
using Windows.Media.Effects;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Binding = Windows.UI.Xaml.Data.Binding;
using LineSeries = Telerik.UI.Xaml.Controls.Chart.LineSeries;
using StepLineSeries = Telerik.UI.Xaml.Controls.Chart.StepLineSeries;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace DataYRAN
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class BlankPageRazverta : Page
    {
        public class CustomPalettes
        {
            static CustomPalettes()
            {
                CreateCustomDarkPalette();
            }

            private static void CreateCustomDarkPalette()
            {
                ChartPalette palette = new ChartPalette() { Name = "CustomDark" };

                // fill
                palette.FillEntries.Brushes.Add(new SolidColorBrush(Color.FromArgb(255, 40, 152, 228)));
                palette.FillEntries.Brushes.Add(new SolidColorBrush(Color.FromArgb(255, 255, 205, 0)));
                palette.FillEntries.Brushes.Add(new SolidColorBrush(Color.FromArgb(255, 255, 60, 0)));
                palette.FillEntries.Brushes.Add(new SolidColorBrush(Color.FromArgb(255, 210, 202, 202)));
                palette.FillEntries.Brushes.Add(new SolidColorBrush(Color.FromArgb(255, 67, 67, 67)));
                palette.FillEntries.Brushes.Add(new SolidColorBrush(Color.FromArgb(255, 0, 255, 156)));
                palette.FillEntries.Brushes.Add(new SolidColorBrush(Color.FromArgb(255, 109, 49, 255)));
                palette.FillEntries.Brushes.Add(new SolidColorBrush(Color.FromArgb(255, 0, 178, 161)));
                palette.FillEntries.Brushes.Add(new SolidColorBrush(Color.FromArgb(255, 109, 255, 0)));
                palette.FillEntries.Brushes.Add(new SolidColorBrush(Color.FromArgb(255, 255, 128, 0)));

                // stroke
                palette.StrokeEntries.Brushes.Add(new SolidColorBrush(Color.FromArgb(255, 96, 194, 255)));
                palette.StrokeEntries.Brushes.Add(new SolidColorBrush(Color.FromArgb(255, 255, 225, 122)));
                palette.StrokeEntries.Brushes.Add(new SolidColorBrush(Color.FromArgb(255, 255, 108, 79)));
                palette.StrokeEntries.Brushes.Add(new SolidColorBrush(Color.FromArgb(255, 229, 229, 229)));
                palette.StrokeEntries.Brushes.Add(new SolidColorBrush(Color.FromArgb(255, 84, 84, 84)));
                palette.StrokeEntries.Brushes.Add(new SolidColorBrush(Color.FromArgb(255, 0, 255, 156)));
                palette.StrokeEntries.Brushes.Add(new SolidColorBrush(Color.FromArgb(255, 130, 79, 255)));
                palette.StrokeEntries.Brushes.Add(new SolidColorBrush(Color.FromArgb(255, 69, 204, 191)));
                palette.StrokeEntries.Brushes.Add(new SolidColorBrush(Color.FromArgb(255, 185, 255, 133)));
                palette.StrokeEntries.Brushes.Add(new SolidColorBrush(Color.FromArgb(255, 255, 175, 94)));

                CustomDark = palette;
            }

            public static ChartPalette CustomDark { get; private set; }

        }

        public BlankPageRazverta()
        {
            this.InitializeComponent();
            _ClassViewModalTab = new ClassViewModalTab();
           // ClassTabs classTabs = new ClassTabs() { name = "tab", tag = "tab" };
            
           
           // classTabs.newTabl();
          //  classTabs.page = new BlankPage2() { Name = "fgf" };
          //  _ClassViewModalTab._DataColecViewDoc.Add(classTabs);
            //radChart.Palette = CustomPalettes.CustomDark;

        }
       ClassViewModalTab _ClassViewModalTab { get; set; }
        ClassRazvertka ClassRazvertkaR = new ClassRazvertka();
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           
           
            if (e.Parameter is ClassRazvertka )
            {
                ClassTabs classTabs = new ClassTabs() { name = "tab", tag = "tab" };
             
                ClassRazvertka classRazvertka = e.Parameter as ClassRazvertka;
                ClassRazvertkaR = classRazvertka;
                classTabs.name = classRazvertka.nameFile1;
                classTabs.tag = classRazvertka.nameFile1;
                classTabs.newTabl();
                textZag.Text = classRazvertka.nameFile1;
               // _ClassTable.newTabl(classRazvertka.nameFile1);
                for(int i=0; i<12; i++)
                {
                    classTabs.newColums();
                   // newColon(_ClassTable.dataGrid, _ClassTable.newColums(i.ToString()));
                }
               // string s = "i" + "\t" + "Ch1" + "\t" + "Ch2" + "\t" + "Ch3" + "\t" + "Ch4" + "\t" + "Ch5" + "\t" + "Ch6" + "\t" + "Ch7" + "\t" + "Ch8" + "\t" + "Ch9" + "\t" + "Ch10" + "\t" + "Ch11" + "\t" + "Ch12" + "\r\n";
                for (int i = 0; i < 1024; i++)
                {
                    int[] mas = new int[12]; 
                   // s = s + (i + 1).ToString() + "\t";
                    for (int j = 0; j < 12; j++)
                    {
                        mas[j] = classRazvertka.data[j, i];
                      //  s = s + classRazvertka.data[j, i] + "\t";
                        
                    }
                    classTabs.newRows(mas);
                    if (i < 1023)
                    {
                      //  s = s + "\r\n";
                    }
                    else
                    {

                    }
                }
                _ClassViewModalTab._DataColecViewDoc.Add(classTabs);

                // textT.Text = s;
            }
            else
            {
                ClassTabs classTabs = new ClassTabs() { name = "tab", tag = "tab" };

                 classTabs.newTabl();
                //  classTabs.page = new BlankPage2() { Name = "fgf" };
                  _ClassViewModalTab._DataColecViewDoc.Add(classTabs);
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
            border.Tag = "1";
            if (_ClassTable.booksTable != null) // table is a DataTable
            {
                List<string> vs = new List<string>();
          
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
        private async void AppBarButtonBar_Click_1(object sender, RoutedEventArgs e)
        {
            border.Visibility = Visibility.Visible;
            border.Tag = "2";
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
        private async void AppBarButtonStep_Click_1(object sender, RoutedEventArgs e)
        {
            border.Visibility = Visibility.Visible;
            border.Tag = "3";
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
            if (border.Tag.ToString() == "2")
            {
                GravBar();
            }
            if(border.Tag.ToString()=="1")
            {


                List<int> vs1 = new List<int>();
                var x = ListKol.SelectedRanges;
                List<string> vs = new List<string>();
                foreach (string dd in ListKol.SelectedItems)
                {
                    vs.Add(dd);
                }
                for (int i = 0; i < ListKol.SelectedItems.Count; i++)
                {
                    int x1 = 0;

                    foreach (DataColumn col in _ClassTable.booksTable.Columns)
                    {

                        if (vs.ElementAt(i).ToString() == col.ColumnName)
                        {
                            vs1.Add(x1);
                        }
                        x1++;
                    }



                }

                _ClassTable.collectionGraf.Clear();
             //   radChart.Series.Clear();
                try
                {
                   // _ClassTable.ss.Clear();
                }
                catch(Exception)
                {

                }
               // _ClassTable.NewAddSeriaCol();
               // _ClassTable.NewAddLine();
                _ClassTable.newGrafSer(vs1);
                border.Visibility = Visibility.Collapsed;
            //    TabHeadRazGraf1.IsSelected = true;
                for (int i = 0; i < _ClassTable.collectionGraf.Count; i++)
                {
                    if (i == 0)
                    {
                       
                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
          () =>
          {
            //  radChart.Series.Add(new LineSeries() { Stroke = new SolidColorBrush(Color.FromArgb(255, 255, 128, 0)), ItemsSource =  _ClassTable.collectionGraf.ElementAt(i).collectionGraf});
          });
                        _ClassTable.NewAddLine();
                        foreach (int p in _ClassTable.collectionGraf.ElementAt(i).collectionGraf)
                        {
                            _ClassTable.NewAddPpoin(i, p);
                        }
                    }
                    if (i == 1)
                    {
                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
          () =>
          {
             // radChart.Series.Add(new LineSeries() { Stroke = new SolidColorBrush(Color.FromArgb(255, 96, 194, 25)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
          });
                       _ClassTable.NewAddLine();
                        foreach (int p in _ClassTable.collectionGraf.ElementAt(i).collectionGraf)
                        {
                            _ClassTable.NewAddPpoin(i, p);
                        }
                    }
                    if (i == 2)
                    {
                  //      radChart.Series.Add(new LineSeries() { Stroke = new SolidColorBrush(Color.FromArgb(255, 16, 194, 235)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                        _ClassTable.NewAddLine();
                        foreach (int p in _ClassTable.collectionGraf.ElementAt(i).collectionGraf)
                        {
                            _ClassTable.NewAddPpoin(i, p);
                        }
                    }
                    if (i == 3)
                    {
                    //    radChart.Series.Add(new LineSeries() { Stroke = new SolidColorBrush(Color.FromArgb(255, 92, 194, 255)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                        _ClassTable.NewAddLine();
                        foreach (int p in _ClassTable.collectionGraf.ElementAt(i).collectionGraf)
                        {
                            _ClassTable.NewAddPpoin(i, p);
                        }
                    }
                    if (i == 4)
                    {
                       // radChart.Series.Add(new LineSeries() { Stroke = new SolidColorBrush(Color.FromArgb(255, 40, 152, 228)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                        _ClassTable.NewAddLine();
                        foreach (int p in _ClassTable.collectionGraf.ElementAt(i).collectionGraf)
                        {
                            _ClassTable.NewAddPpoin(i, p);
                        }
                    }
                    if (i == 5)
                    {
                      //  radChart.Series.Add(new LineSeries() { Stroke = new SolidColorBrush(Color.FromArgb(255, 255, 60, 0)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                        _ClassTable.NewAddLine();
                        foreach (int p in _ClassTable.collectionGraf.ElementAt(i).collectionGraf)
                        {
                            _ClassTable.NewAddPpoin(i, p);
                        }
                    }
                    if (i == 6)
                    {
                      //  radChart.Series.Add(new LineSeries() { Stroke = new SolidColorBrush(Color.FromArgb(255, 210, 202, 202)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                        _ClassTable.NewAddLine();
                        foreach (int p in _ClassTable.collectionGraf.ElementAt(i).collectionGraf)
                        {
                            _ClassTable.NewAddPpoin(i, p);
                        }
                    }
                    if (i == 7)
                    {
                   //     radChart.Series.Add(new LineSeries() { Stroke = new SolidColorBrush(Color.FromArgb(255, 67, 67, 67)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                        _ClassTable.NewAddLine();
                        foreach (int p in _ClassTable.collectionGraf.ElementAt(i).collectionGraf)
                        {
                            _ClassTable.NewAddPpoin(i, p);
                        }
                    }
                    if (i == 8)
                    {
                  //      radChart.Series.Add(new LineSeries() { Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 255, 156)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                        _ClassTable.NewAddLine();
                        foreach (int p in _ClassTable.collectionGraf.ElementAt(i).collectionGraf)
                        {
                            _ClassTable.NewAddPpoin(i, p);
                        }
                    }
                    if (i == 9)
                    {
                       // radChart.Series.Add(new LineSeries() { Stroke = new SolidColorBrush(Color.FromArgb(255, 109, 49, 255)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                        _ClassTable.NewAddLine();
                        foreach (int p in _ClassTable.collectionGraf.ElementAt(i).collectionGraf)
                        {
                            _ClassTable.NewAddPpoin(i, p);
                        }
                    }
                    if (i == 10)
                    {
                     //   radChart.Series.Add(new LineSeries() { Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 178, 161)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                        _ClassTable.NewAddLine();
                        foreach (int p in _ClassTable.collectionGraf.ElementAt(i).collectionGraf)
                        {
                            _ClassTable.NewAddPpoin(i, p);
                        }
                    }
                    if (i == 11)
                    {
                    //    radChart.Series.Add(new LineSeries() { Stroke = new SolidColorBrush(Color.FromArgb(255, 109, 255, 0)) });
                        _ClassTable.NewAddLine();
                        foreach (int p in _ClassTable.collectionGraf.ElementAt(i).collectionGraf)
                        {
                            _ClassTable.NewAddPpoin(i, p);
                        }
                    }
                    // await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    // {
                  //  radChart.Series[i].Name = _ClassTable.collectionGraf.ElementAt(i).name;
                   // radChart.Series[i].LegendTitle = _ClassTable.collectionGraf.ElementAt(i).name;
                    //  radChart.Series[i].ShowLabels = true;
                   // radChart.Series[i].DisplayName = _ClassTable.collectionGraf.ElementAt(i).name;
                    //  radChart.Series[i].ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf;
                    // });

                }
                //  Bindings.Update();

                //radChart.Series.Add(new LineSeries());
                //radChart.Series[0].ItemsSource = _ClassViewModalTab._DataColecGraf1;
                // TabHeadRazGraf1.IsSelected = true;
            }
            if(border.Tag.ToString()=="3")
            {
                GravStep();
            }
            border.Visibility = Visibility.Collapsed;
        }

  
        private async void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
           


        }

private async void saveButton_Click(object sender, RoutedEventArgs e)
        {
            RenderTargetBitmap rtb = new RenderTargetBitmap();
           // await rtb.RenderAsync(_grid);

            var pixelBuffer = await rtb.GetPixelsAsync();
            var pixels = pixelBuffer.ToArray();
            var displayInformation = DisplayInformation.GetForCurrentView();
            // var file = await Loc.CreateFileAsync("testImage" + ".png", CreationCollisionOption.ReplaceExisting);
            FileSavePicker fileSavePicker = new FileSavePicker();
            fileSavePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            fileSavePicker.FileTypeChoices.Add("JPEG files", new List<string>() { ".jpg" });
            fileSavePicker.SuggestedFileName = "image";

            var outputFile = await fileSavePicker.PickSaveFileAsync();

            if (outputFile == null)
            {
                // The user cancelled the picking operation
                return;
            }
            else
            {
                using (var stream = await outputFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);
                    encoder.SetPixelData(BitmapPixelFormat.Bgra8,
                                         BitmapAlphaMode.Premultiplied,
                                         (uint)rtb.PixelWidth,
                                         (uint)rtb.PixelHeight,
                                         displayInformation.RawDpiX,
                                         displayInformation.RawDpiY,
                                         pixels);
                    await encoder.FlushAsync();
                }

            }
        
        }


        private async void LinearAxis_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            ContentDialog1 noWifiDialog = new ContentDialog1
            {
               
            };
            ContentDialogResult result = await noWifiDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
              //  radChart.HorizontalAxis.LabelInterval = noWifiDialog.StepX;
              //  radChart.VerticalAxis.LabelInterval = noWifiDialog.StepY;
                



            }
            else
            {
                // User pressed Cancel, ESC, or the back arrow.
                // Terms of use were not accepted.
            }
        }
        public async void GravStep()
        {
            List<int> vs1 = new List<int>();
            var x = ListKol.SelectedRanges;
            List<string> vs = new List<string>();
            foreach (string dd in ListKol.SelectedItems)
            {
                vs.Add(dd);
            }
            for (int i = 0; i < ListKol.SelectedItems.Count; i++)
            {
                int x1 = 0;

                foreach (DataColumn col in _ClassTable.booksTable.Columns)
                {

                    if (vs.ElementAt(i).ToString() == col.ColumnName)
                    {
                        vs1.Add(x1);
                    }
                    x1++;
                }



            }

            _ClassTable.collectionGraf.Clear();
          //  radChart.Series.Clear();
            _ClassTable.newGrafSer(vs1);
            border.Visibility = Visibility.Collapsed;
          //  TabHeadRazGraf1.IsSelected = true;
            for (int i = 0; i < _ClassTable.collectionGraf.Count; i++)
            {
                if (i == 0)
                {
                      await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                    () =>
                     {
                     //    radChart.Series.Add(new LineSeries() { Stroke = new SolidColorBrush(Color.FromArgb(255, 255, 128, 0)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                      });
                    //_ClassTable.NewAddLine();
                    try
                    {



                        foreach (int p in _ClassTable.collectionGraf.ElementAt(i).collectionGraf)
                        {
                            _ClassTable.NewAddPpoin(0, p);
                        }
                    }
                    catch(Exception ex)
                    {

                    }
                    
                }
                if (i == 1)
                {
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
      () =>
      {
         // radChart.Series.Add(new StepLineSeries() { Stroke = new SolidColorBrush(Color.FromArgb(255, 96, 194, 25)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
      });
                }
                if (i == 2)
                {
                 //   radChart.Series.Add(new StepLineSeries() { Stroke = new SolidColorBrush(Color.FromArgb(255, 16, 194, 235)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                }
                if (i == 3)
                {
                   // radChart.Series.Add(new StepLineSeries() { Stroke = new SolidColorBrush(Color.FromArgb(255, 92, 194, 255)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                }
                if (i == 4)
                {
                 //   radChart.Series.Add(new StepLineSeries() { Stroke = new SolidColorBrush(Color.FromArgb(255, 40, 152, 228)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                }
                if (i == 5)
                {
                   // radChart.Series.Add(new StepLineSeries() { Stroke = new SolidColorBrush(Color.FromArgb(255, 255, 60, 0)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                }
                if (i == 6)
                {
                   // radChart.Series.Add(new StepLineSeries() { Stroke = new SolidColorBrush(Color.FromArgb(255, 210, 202, 202)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                }
                if (i == 7)
                {
                  //  radChart.Series.Add(new StepLineSeries() { Stroke = new SolidColorBrush(Color.FromArgb(255, 67, 67, 67)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                }
                if (i == 8)
                {
                   // radChart.Series.Add(new StepLineSeries() { Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 255, 156)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                }
                if (i == 9)
                {
                 //   radChart.Series.Add(new StepLineSeries() { Stroke = new SolidColorBrush(Color.FromArgb(255, 109, 49, 255)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                }
                if (i == 10)
                {
                 //   radChart.Series.Add(new StepLineSeries() { Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 178, 161)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                }
                if (i == 11)
                {
                 //   radChart.Series.Add(new StepLineSeries() { Stroke = new SolidColorBrush(Color.FromArgb(255, 109, 255, 0)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                }
                // await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                // {
              //  radChart.Series[i].Name = _ClassTable.collectionGraf.ElementAt(i).name;
             //   radChart.Series[i].LegendTitle = _ClassTable.collectionGraf.ElementAt(i).name;
                //  radChart.Series[i].ShowLabels = true;
               // radChart.Series[i].DisplayName = _ClassTable.collectionGraf.ElementAt(i).name;
                //  radChart.Series[i].ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf;
                // });

            }
            //  Bindings.Update();

            //radChart.Series.Add(new LineSeries());
            //radChart.Series[0].ItemsSource = _ClassViewModalTab._DataColecGraf1;
            // TabHeadRazGraf1.IsSelected = true;

            border.Visibility = Visibility.Collapsed;
        }
        public async void GravBar()
        {
            List<int> vs1 = new List<int>();
            var x = ListKol.SelectedRanges;
            List<string> vs = new List<string>();
            foreach (string dd in ListKol.SelectedItems)
            {
                vs.Add(dd);
            }
            for (int i = 0; i < ListKol.SelectedItems.Count; i++)
            {
                int x1 = 0;

                foreach (DataColumn col in _ClassTable.booksTable.Columns)
                {

                    if (vs.ElementAt(i).ToString() == col.ColumnName)
                    {
                        vs1.Add(x1);
                    }
                    x1++;
                }



            }

            _ClassTable.collectionGraf.Clear();
        //    radChart.Series.Clear();
            _ClassTable.newGrafSer(vs1);
            border.Visibility = Visibility.Collapsed;
         //   TabHeadRazGraf1.IsSelected = true;
            for (int i = 0; i < _ClassTable.collectionGraf.Count; i++)
            {
                if (i == 0)
                {
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
      () =>
      {
         // radChart.Series.Add(new BarSeries() { Background = new SolidColorBrush(Color.FromArgb(255, 255, 128, 0)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
      });
                }
                if (i == 1)
                {
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
      () =>
      {
       //   radChart.Series.Add(new BarSeries() { Background = new SolidColorBrush(Color.FromArgb(255, 96, 194, 25)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
      });
                }
                if (i == 2)
                {
               //     radChart.Series.Add(new BarSeries() { Background = new SolidColorBrush(Color.FromArgb(255, 16, 194, 235)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                }
                if (i == 3)
                {
               //     radChart.Series.Add(new BarSeries() { Background = new SolidColorBrush(Color.FromArgb(255, 92, 194, 255)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                }
                if (i == 4)
                {
               //     radChart.Series.Add(new BarSeries() { Background = new SolidColorBrush(Color.FromArgb(255, 40, 152, 228)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                }
                if (i == 5)
                {
               //     radChart.Series.Add(new BarSeries() { Background = new SolidColorBrush(Color.FromArgb(255, 255, 60, 0)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                }
                if (i == 6)
                {
                //    radChart.Series.Add(new BarSeries() { Background = new SolidColorBrush(Color.FromArgb(255, 210, 202, 202)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                }
                if (i == 7)
                {
                 //   radChart.Series.Add(new BarSeries() { Background = new SolidColorBrush(Color.FromArgb(255, 67, 67, 67)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                }
                if (i == 8)
                {
                 //   radChart.Series.Add(new BarSeries() { Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 156)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                }
                if (i == 9)
                {
                 //   radChart.Series.Add(new BarSeries() { Background = new SolidColorBrush(Color.FromArgb(255, 109, 49, 255)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                }
                if (i == 10)
                {
                 //   radChart.Series.Add(new BarSeries() { Background = new SolidColorBrush(Color.FromArgb(255, 0, 178, 161)), ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf });
                }
                if (i == 11)
                {
                   // radChart.Series.Add(new BarSeries() { Background = new SolidColorBrush(Color.FromArgb(255, 109, 255, 0)) });
                }
                // await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                // {
              //  radChart.Series[i].Name = _ClassTable.collectionGraf.ElementAt(i).name;
               // radChart.Series[i].LegendTitle = _ClassTable.collectionGraf.ElementAt(i).name;
                //  radChart.Series[i].ShowLabels = true;
             //   radChart.Series[i].DisplayName = _ClassTable.collectionGraf.ElementAt(i).name;
                //  radChart.Series[i].ItemsSource = _ClassTable.collectionGraf.ElementAt(i).collectionGraf;
                // });

            }
            //  Bindings.Update();

            //radChart.Series.Add(new LineSeries());
            //radChart.Series[0].ItemsSource = _ClassViewModalTab._DataColecGraf1;
            // TabHeadRazGraf1.IsSelected = true;

            border.Visibility = Visibility.Collapsed;


        }
    }
}
