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
            
            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)

            {
                
                IList<string> g = await Windows.Storage.FileIO.ReadLinesAsync(file);
                int h=0;
                foreach(string f in g)
                {if(h>0)
                    {
                        string[] stroc = f.Split("\t");
                        _DataColecSob.Add(new ClassSob()
                        {
                            nameFile = stroc[1],
                            nameklaster = stroc[2],
                            nameBAAK = stroc[3],
                            time = stroc[4],
                            Amp0 = Convert.ToInt16(stroc[7]),
                            Amp1 = Convert.ToInt16(stroc[8]),
                            Amp2 = Convert.ToInt16(stroc[9]),
                            Amp3 = Convert.ToInt16(stroc[10]),
                            Amp4 = Convert.ToInt16(stroc[11]),
                            Amp5 = Convert.ToInt16(stroc[12]),
                            Amp6 = Convert.ToInt16(stroc[13]),
                            Amp7 = Convert.ToInt16(stroc[14]),
                            Amp8 = Convert.ToInt16(stroc[15]),
                            Amp9 = Convert.ToInt16(stroc[16]),
                            Amp10 = Convert.ToInt16(stroc[17]),
                            Amp11 = Convert.ToInt16(stroc[18]),
                            Nnut0 = Convert.ToInt16(stroc[19]),
                            Nnut1 = Convert.ToInt16(stroc[20]),
                            Nnut2 = Convert.ToInt16(stroc[21]),
                            Nnut3 = Convert.ToInt16(stroc[22]),
                            Nnut4 = Convert.ToInt16(stroc[23]),
                            Nnut5 = Convert.ToInt16(stroc[24]),
                            Nnut6 = Convert.ToInt16(stroc[25]),
                            Nnut7 = Convert.ToInt16(stroc[26]),
                            Nnut8 = Convert.ToInt16(stroc[27]),
                            Nnut9 = Convert.ToInt16(stroc[28]),
                            Nnut10 = Convert.ToInt16(stroc[29]),
                            Nnut11 = Convert.ToInt16(stroc[30]),
                            SumAmp = Convert.ToInt32(stroc[5]),
                            SumNeu= Convert.ToInt32(stroc[6])
                           
                           
                        });

    
                    }
                   else
                    {
                        h++;
                    }
                   

                    
                }
                //  MessageDialog g = new MessageDialog(text);
                // await g.ShowAsync();

            }
            else
            {
               
            }
          
        }

        private async void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            int porog = 10;
            int trig = 4;
            int step = 200;
            int g = 0;
            List<int> listsob = new List<int>();
            double sredN = 0;
            for (int i= 1; i<2048*12; i++)
            {
                g++;
                foreach (ClassSob sob in _DataColecSob)
                {
                    int c =0;

                    if(sob.SumAmp==i&&sob.SumNeu<15)
                    {
                        if(Convert.ToInt32(sob.Amp0)>=porog)
                        {
                            c++;
                        }
                        if (Convert.ToInt32(sob.Amp1) >= porog)
                        {
                            c++;
                        }
                        if (Convert.ToInt32(sob.Amp2) >= porog)
                        {
                            c++;
                        }
                        if (Convert.ToInt32(sob.Amp3) >= porog)
                        {
                            c++;
                        }
                        if (Convert.ToInt32(sob.Amp4) >= porog)
                        {
                            c++;
                        }
                        if (Convert.ToInt32(sob.Amp5) >= porog)
                        {
                            c++;
                        }
                        if (Convert.ToInt32(sob.Amp6) >= porog)
                        {
                            c++;
                        }
                        if (Convert.ToInt32(sob.Amp7) >= porog)
                        {
                            c++;
                        }
                        if (Convert.ToInt32(sob.Amp8) >= porog)
                        {
                            c++;
                        }
                        if (Convert.ToInt32(sob.Amp9) >= porog)
                        {
                            c++;
                        }
                        if (Convert.ToInt32(sob.Amp10) >= porog)
                        {
                            c++;
                        }
                        if (Convert.ToInt32(sob.Amp11) >= porog)
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
    }
}
