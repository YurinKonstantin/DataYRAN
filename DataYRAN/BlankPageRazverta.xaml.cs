using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
          
        }
        ClassRazvertka ClassRazvertkaR = new ClassRazvertka();
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is ClassRazvertka )
            {
                ClassRazvertka classRazvertka = e.Parameter as ClassRazvertka;
                ClassRazvertkaR = classRazvertka;
                textZag.Text = classRazvertka.nameFile1;
                string s = "i" + "\t" + "Ch1" + "\t" + "Ch2" + "\t" + "Ch3" + "\t" + "Ch4" + "\t" + "Ch5" + "\t" + "Ch6" + "\t" + "Ch7" + "\t" + "Ch8" + "\t" + "Ch9" + "\t" + "Ch10" + "\t" + "Ch11" + "\t" + "Ch12" + "\r\n";
                for (int i = 0; i < 1024; i++)
                {
                    s = s + (i + 1).ToString() + "\t";
                    for (int j = 0; j < 12; j++)
                    {
                        s = s + classRazvertka.data[j, i] + "\t";
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
                
            }
            base.OnNavigatedTo(e);
        }

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

              
          
          
        
    }
}
