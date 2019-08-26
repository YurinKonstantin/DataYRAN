using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using Microsoft.Toolkit.Uwp;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace DataYRAN
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class BlankPageZavisimost : Page
    {
        

        ObservableCollection<ClassSob> _DataColecSob = new ObservableCollection<ClassSob>();
        ObservableCollection<ClassSobColl> _DataColecSobCol = new ObservableCollection<ClassSobColl>();
        ObservableCollection<ClassSobObrZav> _DataColecSob2 = new ObservableCollection<ClassSobObrZav>();
        public BlankPageZavisimost()
        {
            this.InitializeComponent();
        
            DataGrid1.ItemsSource = _DataColecSob2;
           dataGrid3.ItemsSource = _DataColecSob;
        }
        List<string> f = new List<string>();
        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
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

                    IList<string> g = await Windows.Storage.FileIO.ReadLinesAsync(file);
                    int h = 0;
                    int x = 0;
                    try
                    {

                        foreach (string f in g)
                        {
                            string[] rows = f.Split("\t");
                            if (rows.Length!=0 && !rows[0].Contains("n"))
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
                  _DataColecSob.Add(new ClassSob()
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
                  _DataColecSob.Add(new ClassSob()
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

                }
                else
                {

                }
            }
            catch(Exception)
            {
                var mess = new MessageDialog("Ошибка");
                await mess.ShowAsync();
            }
          
        }

        private async void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            int porog = 10;
            int trig = 4;
            int step = 40;
            int g = 0;
            List<int> listsob = new List<int>();
            double sredN = 0;
            for (int i= 1; i<2048*12; i++)
            {
                g++;
                foreach(ClassSob sob in _DataColecSob)
                {
                    int c =0;

                    if(sob.SumAmp==i&&sob.SumNeu<50)
                    {
                        if(Convert.ToInt32(sob.mAmp[0])>=porog)
                        {
                            c++;
                        }
                        if (Convert.ToInt32(sob.mAmp[1]) >= porog)
                        {
                            c++;
                        }
                        if (Convert.ToInt32(sob.mAmp[2]) >= porog)
                        {
                            c++;
                        }
                        if (Convert.ToInt32(sob.mAmp[3]) >= porog)
                        {
                            c++;
                        }
                        if (Convert.ToInt32(sob.mAmp[4]) >= porog)
                        {
                            c++;
                        }
                        if (Convert.ToInt32(sob.mAmp[5]) >= porog)
                        {
                            c++;
                        }
                        if (Convert.ToInt32(sob.mAmp[6]) >= porog)
                        {
                            c++;
                        }
                        if (Convert.ToInt32(sob.mAmp[7]) >= porog)
                        {
                            c++;
                        }
                        if (Convert.ToInt32(sob.mAmp[8]) >= porog)
                        {
                            c++;
                        }
                        if (Convert.ToInt32(sob.mAmp[9]) >= porog)
                        {
                            c++;
                        }
                        if (Convert.ToInt32(sob.mAmp[10]) >= porog)
                        {
                            c++;
                        }
                        if (Convert.ToInt32(sob.mAmp[11]) >= porog)
                        {
                            c++;
                        }
                        if(c>=trig)
                        {
                            listsob.Add(sob.SumNeu);
                        }
                       
                        
                    }
                }
                if(g== step)
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
            MessageDialog gh = new MessageDialog("Конец");
            await gh.ShowAsync();
        
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
        private async void AppBarButton_Click_2(object sender, RoutedEventArgs e)
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
                if (_DataColecSob2.Count != 0)
                {
                    using (StreamWriter writer =
                   new StreamWriter(await folder.OpenStreamForWriteAsync(
                   "СреднЗнач.txt", CreationCollisionOption.OpenIfExists)))
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

        private void AppBarButton_Click_3(object sender, RoutedEventArgs e)
        {
            _DataColecSob2.Clear();
            _DataColecSob.Clear();
        }
        private void AppBarButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }
        private async void AppBarButton_Click_1Ob(object sender, RoutedEventArgs e)
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

                    IList<string> g11 = await Windows.Storage.FileIO.ReadLinesAsync(file);
                    int h = 0;
                    int x = 0;
                    try
                    {

                        foreach (string f in g11)
                        {
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
                  _DataColecSob.Add(new ClassSob()
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
                  _DataColecSobCol.Add(new ClassSobColl()
                  {
                     SummAmpl=Convert.ToInt32(rows[2]),
                     SummNeu=Convert.ToInt32(rows[3])
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



            int porog = 10;
            int trig = 4;
            int step = Convert.ToInt32(StepsAmpl.Text);
            int g = 0;
            List<int> listsob = new List<int>();
            double sredN = 0;
            for (int i = 1; i < 2048 * 72; i++)
            {
                g++;
                foreach (ClassSobColl sob in _DataColecSobCol)
                {
                    int c = 0;

                    if (sob.SummAmpl == i && sob.SummNeu < 100)
                    {
                        
                       
                            listsob.Add(sob.SummNeu);

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
            MessageDialog gh = new MessageDialog("Конец");
            await gh.ShowAsync();

        }
    }
}
