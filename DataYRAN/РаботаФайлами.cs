using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.UI.Xaml.Controls.Grid;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DataYRAN
{
    public sealed partial class BlankPageObrData
    {
        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mySplitView.IsPaneOpen = true;
                await OpenFileAsync();
            }
            catch 
            {
                var g = new MessageDialog("Ошибка открытия файла");
                await g.ShowAsync();
            }
        }
        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            ObRing.IsActive = true;
            ViewModel.DataColec.Clear();
            ObRing.IsActive = false;
        }
        private async void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = true;
            await OpenFolderAsync();

        }
        private void AppBarButton_Click_3(object sender, RoutedEventArgs e)
        {
            if (listView1.SelectedIndex < listView1.Items.Count - 1)
            {
                listView1.SelectedIndex++;
            }

        }

        private void AppBarButton_Click_4(object sender, RoutedEventArgs e)
        {
            if (listView1.SelectedIndex > 0)
            {
                listView1.SelectedIndex--;
            }
        }
        private void ListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (listView1.SelectedItem != null)
            {


            }
            else
            {

            }
            // selectedIndex.Text =
            //    "Selected index: " + listView1.SelectedIndex.ToString();
            // selectedItemCount.Text =
            //    "Items selected: " + listView1.SelectedItems.Count.ToString();
            // addedItems.Text =
            //    "Added: " + e.AddedItems.Count.ToString();
            //  removedItems.Text =
            //     "Removed: " + e.RemovedItems.Count.ToString();
        }
        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            listView1.SelectionMode = ListViewSelectionMode.Multiple;
        }

        private void MenuFlyoutItem_Click_1(object sender, RoutedEventArgs e)
        {
            listView1.SelectionMode = ListViewSelectionMode.Extended;
        }


        public delegate Task SaveFile(int[,] data, int[,] Tail, string time, string nameFile);//
        public async Task SaveAsync(int[,] data, int[,] Tail, string time, string nameFile)
        {
            await saveAsync(data, Tail, time, nameFile);
        }
        private async void AppBarButton_Click_6(object sender, RoutedEventArgs e)
        {
           
            ObRing.IsActive = true;
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

                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

                StorageFolder storageFolderRazvertka = await storageFolder.CreateFolderAsync("Развертка", CreationCollisionOption.OpenIfExists);

                IReadOnlyList<StorageFile> fileList =
                    await storageFolderRazvertka.GetFilesAsync();
                if (fileList.Count != 0)
                {
                    StorageFolder storageFolderSave = await folder.CreateFolderAsync("Развертка", CreationCollisionOption.GenerateUniqueName);
                    foreach (StorageFile file in fileList)
                    {
                        await file.CopyAsync(storageFolderSave);
                    }
                }

                await SaveSob(folder, "СобытияФайлаT", "txt", cul);
               await SaveSobTimeСмешения_детектора(folder, "ВременаСрабатДетек", "txt", cul);
                await SaveSobPlox(folder, "СобытияФайлаBadT", "txt", cul);

                await SaveSobNeutron(folder, "НейтроныФайлаT", "txt", cul);
                await SaveSobN(folder, "СобытияФайлаN", "txt", cul);
                await SaveSobPloxN(folder, "СобытияФайлаBadN", "txt", cul);
                await SaveSobV(folder, "СобытияФайлаV", "txt", cul);
                await SaveSobPloxV(folder, "СобытияФайлаBadV", "txt", cul);
               await SaveSobTimeСмешения_детектораNew(folder, "ВременаСрабатДетекNew", "txt", cul);



            }
            else
            {

            }

            ObRing.IsActive = false;
            var mess = new MessageDialog("Сохранение завершено");
            await mess.ShowAsync();

        }
        private async void AppBarButton_Click_Filter(object sender, RoutedEventArgs e)
        {

            ObRing.IsActive = true;
            string cul = "en-US";
            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add("*");

            Windows.Storage.StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
     
                await SaveSobFilter(folder, "СобытияФайлаTFilter", "txt", cul);
         



            }
            else
            {

            }

            ObRing.IsActive = false;
            var mess = new MessageDialog("Сохранение завершено");
            await mess.ShowAsync();

        }
        private async void AppBarButton_Click_TimeNew(object sender, RoutedEventArgs e)
        {

            ObRing.IsActive = true;
            string cul = "en-US";
            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add("*");

            Windows.Storage.StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {

                await SaveSobTimeСмешения_детектораNew(folder, "ВременаСрабатДетекNew", "txt", cul);




            }
            else
            {

            }

            ObRing.IsActive = false;
            var mess = new MessageDialog("Сохранение завершено");
            await mess.ShowAsync();

        }
        private async void SaveQ_Click_6(object sender, RoutedEventArgs e)
        {

            ObRing.IsActive = true;
            if (ClassUserSetUp.TipTail)
            {
             
            }
            if (!ClassUserSetUp.TipTail)
            {
                await SaveAllNoTailQ();
            }

            ObRing.IsActive = false;
            var mess = new MessageDialog("Сохранение завершено");
            await mess.ShowAsync();

        }
        public async Task SaveAllNoTail()
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

                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

                StorageFolder storageFolderRazvertka = await storageFolder.CreateFolderAsync("Развертка", CreationCollisionOption.OpenIfExists);

                IReadOnlyList<StorageFile> fileList =
                    await storageFolderRazvertka.GetFilesAsync();
                if (fileList.Count != 0)
                {
                    StorageFolder storageFolderSave =await folder.CreateFolderAsync("Развертка", CreationCollisionOption.GenerateUniqueName);
                    foreach (StorageFile file in fileList)
                    {
                        await file.CopyAsync(storageFolderSave);
                    }
                }
                int i = 0;
                if (ViewModel.ClassSobsT.Count != 0)
                {
                    using (StreamWriter writer =
                   new StreamWriter(await folder.OpenStreamForWriteAsync(
                   "СобытияФайла.txt", CreationCollisionOption.GenerateUniqueName)))
                    {
                        string sSob = "n" + "\t" + "file" + "\t" + "kl" + "\t" + "PSB" + "\t" + "Time" + "\t" + "SA" + "\t" +  "\t" + "AD1" + "\t" + "AD2" + "\t" + "AD3" + "\t" + "AD4" + "\t" + "AD5" + "\t" + "AD6" + "\t" + "AD7" + "\t" + "AD8" + "\t" + "AD9" + "\t" + "AD10" + "\t" + "AD11" + "\t" + "AD12" +
                                   "\t" + "SigD1" + "\t" + "SigD2" + "\t" + "SigD3" + "\t" + "SigD4" + "\t" + "SigD5" + "\t" + "SigD6" + "\t" + "SigD7" + "\t" + "SigD8" + "\t" + "SigD9" + "\t" + "SigD10" + "\t" + "SigD11" + "\t" + "SigD12" + "\t" + "NullD1" + "\t" + "NullD2"
                                   + "\t" + "NullD3" + "\t" + "NullD4" + "\t" + "NullD5" + "\t" + "NullD6" + "\t" + "NullD7" + "\t" + "NullD8" + "\t" + "NullD9" + "\t" + "NullD10" + "\t" + "NullD11" + "\t" + "NullD12";


                        await writer.WriteLineAsync(sSob);
                        foreach (ClassSob sob in ViewModel.ClassSobsT)
                        {
                            i++;
                            string Sob = i.ToString() + "\t" + sob.nameFile + "\t" + sob.nameklaster + "\t" + sob.nameBAAK.ToString() + "\t" + sob.time + "\t" + sob.SumAmp + "\t" + sob.SumNeu + "\t" + sob.mAmp[0].ToString() + "\t" + sob.mAmp[1].ToString() + "\t" + sob.mAmp[2].ToString() + "\t" + sob.mAmp[3].ToString() + "\t" + sob.mAmp[4].ToString() + "\t" + sob.mAmp[5].ToString() + "\t" + sob.mAmp[6].ToString() + "\t" + sob.mAmp[7].ToString() + "\t" + sob.mAmp[8].ToString() + "\t" + sob.mAmp[9].ToString() + "\t" + sob.mAmp[10].ToString() + "\t" + sob.mAmp[11].ToString() +
                               "\t" + sob.sig0.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig1.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig2.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig3.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig4.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig5.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig6.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig7.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig8.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig9.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig10.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig11.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.Nnull0
                                 + "\t" + sob.Nnull1 + "\t" + sob.Nnull2 + "\t" + sob.Nnull3 + "\t" + sob.Nnull4 + "\t" + sob.Nnull5 + "\t" + sob.Nnull6 + "\t" + sob.Nnull7 + "\t" + sob.Nnull8 + "\t" + sob.Nnull9 + "\t" + sob.Nnull10 + "\t" + sob.Nnull11;
                            await writer.WriteLineAsync(Sob);
                        }
                    }
                }
                i = 0;
                if (_DataColecSobPlox.Count != 0)
                {
                    using (StreamWriter writer =
                   new StreamWriter(await folder.OpenStreamForWriteAsync(
                   "СобытияФайлаBad.txt", CreationCollisionOption.GenerateUniqueName)))
                    {
                        string sSob = "n" + "\t" + "file" + "\t" + "kl" + "\t" + "PSB" + "\t" + "Time" + "\t" + "SA" + "\t" + "SN" + "\t" + "AD1" + "\t" + "AD2" + "\t" + "AD3" + "\t" + "AD4" + "\t" + "AD5" + "\t" + "AD6" + "\t" + "AD7" + "\t" + "AD8" + "\t" + "AD9" + "\t" + "AD10" + "\t" + "AD11" + "\t" + "AD12" +
                                   "\t" +"SigD1" + "\t" + "SigD2" + "\t" + "SigD3" + "\t" + "SigD4" + "\t" + "SigD5" + "\t" + "SigD6" + "\t" + "SigD7" + "\t" + "SigD8" + "\t" + "SigD9" + "\t" + "SigD10" + "\t" + "SigD11" + "\t" + "SigD12" + "\t" + "NullD1" + "\t" + "NullD2"
                                   + "\t" + "NullD3" + "\t" + "NullD4" + "\t" + "NullD5" + "\t" + "NullD6" + "\t" + "NullD7" + "\t" + "NullD8" + "\t" + "NullD9" + "\t" + "NullD10" + "\t" + "NullD11" + "\t" + "NullD12";


                        await writer.WriteLineAsync(sSob);
                        foreach (ClassSob sob in _DataColecSobPlox)
                        {
                            i++;
                            string Sob = i.ToString() + "\t" + sob.nameFile + "\t" + sob.nameklaster + "\t" + sob.nameBAAK.ToString() + "\t" + sob.time + "\t" + sob.SumAmp + "\t" + sob.SumNeu + "\t" + sob.mAmp[0].ToString() + "\t" + sob.mAmp[1].ToString() + "\t" + sob.mAmp[2].ToString() + "\t" + sob.mAmp[3].ToString() + "\t" + sob.mAmp[4].ToString() + "\t" + sob.mAmp[5].ToString() + "\t" + sob.mAmp[6].ToString() + "\t" + sob.mAmp[7].ToString() + "\t" + sob.mAmp[8].ToString() + "\t" + sob.mAmp[9].ToString() + "\t" + sob.mAmp[10].ToString() + "\t" + sob.mAmp[11].ToString() +
                               "\t" +sob.sig0.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig1.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig2.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig3.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig4.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig5.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig6.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig7.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig8.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig9.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig10.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig11.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.Nnull0
                                 + "\t" + sob.Nnull1 + "\t" + sob.Nnull2 + "\t" + sob.Nnull3 + "\t" + sob.Nnull4 + "\t" + sob.Nnull5 + "\t" + sob.Nnull6 + "\t" + sob.Nnull7 + "\t" + sob.Nnull8 + "\t" + sob.Nnull9 + "\t" + sob.Nnull10 + "\t" + sob.Nnull11;
                            await writer.WriteLineAsync(Sob);
                        }
                    }
                }
               
            }
            else
            {

            }
        }
        public async Task SaveSob(StorageFolder folder, String name, string tip, string cul)
        {
            


                int i = 0;
                if (ViewModel.ClassSobsT.Count != 0)
                {
                    using (StreamWriter writer =
                   new StreamWriter(await folder.OpenStreamForWriteAsync(
                   name + "." + tip, CreationCollisionOption.GenerateUniqueName)))
                    {
                        string sSob = "n" + "\t" + "file" + "\t" + "kl" + "\t" + "PSB" + "\t" + "Time" + "\t" + "SA" + "\t" + "SN" + "\t" + "AD1" + "\t" + "AD2" + "\t" + "AD3" + "\t" + "AD4" + "\t" + "AD5" + "\t" + "AD6" + "\t" + "AD7" + "\t" + "AD8" + "\t" + "AD9" + "\t" + "AD10" + "\t" + "AD11" + "\t" + "AD12" +
                                   "\t" + "ND1" + "\t" + "ND2" + "\t" + "ND3" + "\t" + "ND4" + "\t" + "ND5" + "\t" + "ND6" + "\t" + "ND7" + "\t" + "ND8" + "\t" + "ND9" + "\t" + "ND10" + "\t" + "ND11" + "\t" + "ND12" + "\t" +
                                   "SigD1" + "\t" + "SigD2" + "\t" + "SigD3" + "\t" + "SigD4" + "\t" + "SigD5" + "\t" + "SigD6" + "\t" + "SigD7" + "\t" + "SigD8" + "\t" + "SigD9" + "\t" + "SigD10" + "\t" + "SigD11" + "\t" + "SigD12" + "\t" + "NullD1" + "\t" + "NullD2"
                                   + "\t" + "NullD3" + "\t" + "NullD4" + "\t" + "NullD5" + "\t" + "NullD6" + "\t" + "NullD7" + "\t" + "NullD8" + "\t" + "NullD9" + "\t" + "NullD10" + "\t" + "NullD11" + "\t" + "NullD12";


                        await writer.WriteLineAsync(sSob);
                        foreach (ClassSob sob in ViewModel.ClassSobsT)
                        {
                            i++;
                            string Sob = i.ToString() + "\t" + sob.nameFile + "\t" + sob.nameklaster + "\t" + sob.nameBAAK.ToString() + "\t" + sob.time + "\t" + sob.SumAmp + "\t" + sob.SumNeu + "\t" + sob.mAmp[0].ToString() + "\t" + sob.mAmp[1].ToString() + "\t" + 
                            sob.mAmp[2].ToString() + "\t" + sob.mAmp[3].ToString() + "\t" + sob.mAmp[4].ToString() + "\t" + sob.mAmp[5].ToString() + "\t" + sob.mAmp[6].ToString() + "\t" + sob.mAmp[7].ToString() + 
                            "\t" + sob.mAmp[8].ToString() + "\t" + sob.mAmp[9].ToString() + "\t" + sob.mAmp[10].ToString() + "\t" + sob.mAmp[11].ToString() +
                               "\t" + sob.Nnut0.ToString() + "\t" + sob.Nnut1.ToString() + "\t" + sob.Nnut2.ToString() + "\t" + sob.Nnut3.ToString() + "\t" + sob.Nnut4.ToString() + "\t" + sob.Nnut5.ToString() + "\t" + sob.Nnut6.ToString() + "\t" + sob.Nnut7.ToString() + "\t" + sob.Nnut8.ToString() + "\t" + sob.Nnut9.ToString() + "\t" + sob.Nnut10.ToString() + "\t" + sob.Nnut11.ToString() + "\t" +
                                sob.sig0.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig1.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig2.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig3.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig4.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig5.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig6.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig7.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig8.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig9.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig10.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig11.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.Nnull0
                                 + "\t" + sob.Nnull1 + "\t" + sob.Nnull2 + "\t" + sob.Nnull3 + "\t" + sob.Nnull4 + "\t" + sob.Nnull5 + "\t" + sob.Nnull6 + "\t" + sob.Nnull7 + "\t" + sob.Nnull8 + "\t" + sob.Nnull9 + "\t" + sob.Nnull10 + "\t" + sob.Nnull11;
                            await writer.WriteLineAsync(Sob);
                        }
                    }
                }

        


        }
        public async Task SaveSobFilter(StorageFolder folder, String name, string tip, string cul)
        {

            IDataView currentView = this.DataGrid.GetDataView();
           

            int i = 0;
            if (currentView.Items.Count != 0)
            {
                using (StreamWriter writer =
               new StreamWriter(await folder.OpenStreamForWriteAsync(
               name + "." + tip, CreationCollisionOption.GenerateUniqueName)))
                {
                    string sSob = "n" + "\t" + "file" + "\t" + "kl" + "\t" + "PSB" + "\t" + "Time" + "\t" + "SA" + "\t" + "SN" + "\t" + "AD1" + "\t" + "AD2" + "\t" + "AD3" + "\t" + "AD4" + "\t" + "AD5" + "\t" + "AD6" + "\t" + "AD7" + "\t" + "AD8" + "\t" + "AD9" + "\t" + "AD10" + "\t" + "AD11" + "\t" + "AD12" +
                               "\t" + "ND1" + "\t" + "ND2" + "\t" + "ND3" + "\t" + "ND4" + "\t" + "ND5" + "\t" + "ND6" + "\t" + "ND7" + "\t" + "ND8" + "\t" + "ND9" + "\t" + "ND10" + "\t" + "ND11" + "\t" + "ND12" + "\t" +
                               "SigD1" + "\t" + "SigD2" + "\t" + "SigD3" + "\t" + "SigD4" + "\t" + "SigD5" + "\t" + "SigD6" + "\t" + "SigD7" + "\t" + "SigD8" + "\t" + "SigD9" + "\t" + "SigD10" + "\t" + "SigD11" + "\t" + "SigD12" + "\t" + "NullD1" + "\t" + "NullD2"
                               + "\t" + "NullD3" + "\t" + "NullD4" + "\t" + "NullD5" + "\t" + "NullD6" + "\t" + "NullD7" + "\t" + "NullD8" + "\t" + "NullD9" + "\t" + "NullD10" + "\t" + "NullD11" + "\t" + "NullD12";


                    await writer.WriteLineAsync(sSob);
                    foreach (ClassSob sob in currentView)
                    {
                        i++;
                        string Sob = i.ToString() + "\t" + sob.nameFile + "\t" + sob.nameklaster + "\t" + sob.nameBAAK.ToString() + "\t" + sob.time + "\t" + sob.SumAmp + "\t" + sob.SumNeu 
                            + "\t" + sob.mAmp[0].ToString() + "\t" + sob.mAmp[1].ToString() + "\t" + sob.mAmp[2].ToString() + "\t" + sob.mAmp[3].ToString() + "\t" + sob.mAmp[4].ToString()
                            + "\t" + sob.mAmp[5].ToString() + "\t" + sob.mAmp[6].ToString() + "\t" + sob.mAmp[7].ToString() + "\t" + sob.mAmp[8].ToString() + "\t" + sob.mAmp[9].ToString()
                            + "\t" + sob.mAmp[10].ToString() + "\t" + sob.mAmp[11].ToString() +
                           "\t" + sob.Nnut0.ToString() + "\t" + sob.Nnut1.ToString() + "\t" + sob.Nnut2.ToString() + "\t" + sob.Nnut3.ToString() + "\t" + sob.Nnut4.ToString() + "\t" + sob.Nnut5.ToString() + "\t" + sob.Nnut6.ToString() + "\t" + sob.Nnut7.ToString() + "\t" + sob.Nnut8.ToString() + "\t" + sob.Nnut9.ToString() + "\t" + sob.Nnut10.ToString() + "\t" + sob.Nnut11.ToString() + "\t" +
                            sob.sig0.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig1.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig2.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig3.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig4.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig5.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig6.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig7.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig8.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig9.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig10.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig11.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.Nnull0
                             + "\t" + sob.Nnull1 + "\t" + sob.Nnull2 + "\t" + sob.Nnull3 + "\t" + sob.Nnull4 + "\t" + sob.Nnull5 + "\t" + sob.Nnull6 + "\t" + sob.Nnull7 + "\t" + sob.Nnull8 + "\t" + sob.Nnull9 + "\t" + sob.Nnull10 + "\t" + sob.Nnull11;
                        await writer.WriteLineAsync(Sob);
                    }
                }
            }




        }
        public async Task SaveSobTimeСмешения_детектора(StorageFolder folder, String name, string tip, string cul)
        {



            int i = 0;
            if (ViewModel.ClassSobsT.Count != 0)
            {
                using (StreamWriter writer =
               new StreamWriter(await folder.OpenStreamForWriteAsync(
               name + "." + tip, CreationCollisionOption.GenerateUniqueName)))
                {
                    string sSob = "n" + "\t" + "file" + "\t" + "kl" + "\t" + "Time" + "\t" + "TD1" + "\t" + "TD2" + "\t" + "TD3" + "\t" + "TD4" + "\t" + "TD5" + "\t" + "TD6" + "\t" + "TD7" + "\t" + "TD8" + "\t" + "TD9" + "\t" + "TD10" + "\t" + "TD11" + "\t" + "TD12";


                    await writer.WriteLineAsync(sSob);
                    foreach (ClassSob sob in ViewModel.ClassSobsT)
                    {
                        i++;
                        int[] Poradoc = new int[12];
                        int perPoz = 0;
                        int perZ = 1025;
                        bool sobPor = false;
                        Poradoc = sob.masTime();
                       for(int f=0; f<12; f++)
                        {
                            if (Poradoc[f] > 0 && perZ > Poradoc[f] && Poradoc[f] != null)
                            {
                                perZ = Poradoc[f];
                                perPoz = f;
                                sobPor = true;
                            }
                        }
                       // MessageDialog messageDialog = new MessageDialog(perPoz+"\t"+perZ);
                       //await messageDialog.ShowAsync();
                        for (int f = 0; f < 12; f++)
                        {
                            if (Poradoc[f] > -1 )
                            {
                                Poradoc[f] = (Poradoc[f] - perZ)*5;
                              //  MessageDialog messageDialog1 = new MessageDialog( "gg"+"\n"+Poradoc[f] + "\t" + perZ);
                               // await messageDialog1.ShowAsync();

                            }
                        }
                        string Sob = i.ToString() + "\t" + sob.nameFile + "\t" + sob.nameklaster +"\t"+sob.time+ "\t" + Poradoc[0].ToString() + "\t" + Poradoc[1].ToString() + "\t"
                            + Poradoc[2].ToString() + "\t" + Poradoc[3].ToString() + "\t" + Poradoc[4].ToString() + "\t" + Poradoc[5].ToString() + "\t" + Poradoc[6].ToString() + 
                            "\t" + Poradoc[7].ToString() + "\t" + Poradoc[8].ToString() + "\t" + Poradoc[9].ToString() + "\t" + Poradoc[10].ToString() + "\t" + Poradoc[11].ToString();
                        await writer.WriteLineAsync(Sob);
                    }
                }
            }




        }
        public async Task SaveSobTimeСмешения_детектораNew(StorageFolder folder, string name, string tip, string cul)
        {


            try
            {


                int i = 0;
                if (ViewModel.ClassSobsT.Count != 0)
                {
                    using (StreamWriter writer =
                   new StreamWriter(await folder.OpenStreamForWriteAsync(
                   name + "." + tip, CreationCollisionOption.GenerateUniqueName)))
                    {
                        string sSob = "n" + "\t" + "file" + "\t" + "kl" + "\t" + "Time" + "\t" + "AD1" + "\t" + "AD2" + "\t" + "AD3" + "\t" + "AD4" + "\t"
                            + "AD5" + "\t" + "AD6" + "\t" + "AD7" + "\t" + "AD8" + "\t" + "AD9" + "\t" + "AD10" + "\t" + "AD11" + "\t" + "AD12"
                            + "\t" + "TD1" + "\t" + "TD2" + "\t" + "TD3" + "\t" + "TD4" + "\t" + "TD5" + "\t" + "TD6" + "\t" + "TD7" + "\t" + "TD8" + "\t"
                            + "TD9" + "\t" + "TD10" + "\t" + "TD11" + "\t" + "TD12";


                        await writer.WriteLineAsync(sSob);
                        string Sob = String.Empty;
                        foreach (ClassSob sob in ViewModel.ClassSobsT)
                        {
                            try
                            {

                                i++;

                                 Sob = i.ToString() + "\t" + sob.nameFile + "\t" + sob.nameklaster + "\t" + sob.time + "\t" + sob.mAmp[0].ToString() + "\t" + sob.mAmp[1].ToString() + "\t"
                                    + sob.mAmp[2].ToString() + "\t" + sob.mAmp[3].ToString() + "\t" + sob.mAmp[4].ToString() + "\t" + sob.mAmp[5].ToString() + "\t" + sob.mAmp[6].ToString() +
                                    "\t" + sob.mAmp[7].ToString() + "\t" + sob.mAmp[8].ToString() + "\t" + sob.mAmp[9].ToString() + "\t" + sob.mAmp[10].ToString() + "\t" + sob.mAmp[11].ToString()
                                    + "\t" + sob.mTimeD[0].ToString() + "\t" + sob.mTimeD[1].ToString() + "\t"
                                    + sob.mTimeD[2].ToString() + "\t" + sob.mTimeD[3].ToString() + "\t" + sob.mTimeD[4].ToString() + "\t" + sob.mTimeD[5].ToString() + "\t" + sob.mTimeD[6].ToString() +
                                    "\t" + sob.mTimeD[7].ToString() + "\t" + sob.mTimeD[8].ToString() + "\t" + sob.mTimeD[9].ToString() + "\t" + sob.mTimeD[10].ToString() + "\t" + sob.mTimeD[11].ToString();
                                await writer.WriteLineAsync(Sob);
                            }
                            catch(Exception ex)
                            {
                                MessageDialog messageDialog = new MessageDialog(ex.ToString()+"\n"+Sob);
                                await messageDialog.ShowAsync();
                            }
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                MessageDialog messageDialog = new MessageDialog(ex.ToString());
                await messageDialog.ShowAsync();
            }


        }
        public async Task SaveSobBigData(ClassSob sob)
        {
            string cul = "en-US";
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder; ;
    
           
                using (StreamWriter writer = new StreamWriter(await storageFolder.OpenStreamForWriteAsync("SobT.txt", CreationCollisionOption.OpenIfExists)))
                {
                  
 
                        string Sob = "0" + "\t" + sob.nameFile + "\t" + sob.nameklaster + "\t" + sob.nameBAAK.ToString() + "\t" + sob.time + "\t" + sob.SumAmp + "\t" + sob.SumNeu 
                    + "\t" + sob.mAmp[0].ToString() + "\t" + sob.mAmp[1].ToString() + "\t" + sob.mAmp[2].ToString() + "\t" + sob.mAmp[3].ToString() + "\t" + sob.mAmp[4].ToString()
                    + "\t" + sob.mAmp[5].ToString() + "\t" + sob.mAmp[6].ToString() + "\t" + sob.mAmp[7].ToString() + "\t" + sob.mAmp[8].ToString() + "\t" + sob.mAmp[9].ToString() + "\t" + sob.mAmp[10].ToString()
                    + "\t" + sob.mAmp[11].ToString() +
                           "\t" + sob.Nnut0.ToString() + "\t" + sob.Nnut1.ToString() + "\t" + sob.Nnut2.ToString() + "\t" + sob.Nnut3.ToString() + "\t" + sob.Nnut4.ToString() + "\t" + sob.Nnut5.ToString() + "\t" + sob.Nnut6.ToString() + "\t" + sob.Nnut7.ToString() + "\t" + sob.Nnut8.ToString() + "\t" + sob.Nnut9.ToString() + "\t" + sob.Nnut10.ToString() + "\t" + sob.Nnut11.ToString() + "\t" +
                            sob.sig0.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig1.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig2.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig3.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig4.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig5.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig6.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig7.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig8.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig9.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig10.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig11.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.Nnull0
                             + "\t" + sob.Nnull1 + "\t" + sob.Nnull2 + "\t" + sob.Nnull3 + "\t" + sob.Nnull4 + "\t" + sob.Nnull5 + "\t" + sob.Nnull6 + "\t" + sob.Nnull7 + "\t" + sob.Nnull8 + "\t" + sob.Nnull9 + "\t" + sob.Nnull10 + "\t" + sob.Nnull11;
                        await writer.WriteLineAsync(Sob);

            }
           


        }
        public async Task SaveSobN(StorageFolder folder, String name, string tip, string cul)
        {
            int i = 0;
            if (ViewModel.ClassSobsN.Count != 0)
            {
                using (StreamWriter writer =
               new StreamWriter(await folder.OpenStreamForWriteAsync(
               name+tip, CreationCollisionOption.GenerateUniqueName)))
                {
                    string sSob = "n" + "\t" + "file" + "\t" + "kl" + "\t" + "PSB" + "\t" + "Time" + "\t" + "SA" + "\t" + "SQ" + "\t" + "\t" + "AD1" + "\t" + "AD2" + "\t" + "AD3" + "\t" + "AD4" + "\t" + "AD5" + "\t" + "AD6" + "\t" + "AD7" + "\t" + "AD8" + "\t" + "AD9" + "\t" + "aD10" + "\t" + "AD11" + "\t" + "AD12" +
                               "\t" + "QD1" + "\t" + "QD2" + "\t" + "QD3" + "\t" + "QD4" + "\t" + "QD5" + "\t" + "QD6" + "\t" + "QD7" + "\t" + "QD8" + "\t" + "QD9" + "\t" + "QD10" + "\t" + "QD11" + "\t" + "QD12";


                    await writer.WriteLineAsync(sSob);
                    foreach (ClassSobN sob in ViewModel.ClassSobsN)
                    {
                        i++;
                        string Sob = i.ToString() + "\t" + sob.nameFile + "\t" + sob.nameklaster + "\t" + sob.nameBAAK.ToString() + "\t" + sob.time + "\t" +
                       sob.SumAmp + "\t" + sob.Qsum.Sum().ToString() + "\t" + sob.Amp0.ToString() + "\t" + sob.Amp1.ToString() + "\t" + sob.Amp2.ToString() + "\t" + sob.Amp3.ToString() + "\t"
                       + sob.Amp4.ToString() + "\t" + sob.Amp5.ToString() + "\t" + sob.Amp6.ToString() + "\t" + sob.Amp7.ToString() + "\t" + sob.Amp8.ToString() + "\t" +
                       sob.Amp9.ToString() + "\t" + sob.Amp10.ToString() + "\t" + sob.Amp11.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t"
                       + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" +
                       sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t";
                        await writer.WriteLineAsync(Sob);
                    }
                }
            }

        }
        public async Task SaveSobV(StorageFolder folder, String name, string tip, string cul)
        {
            int i = 0;
            if (ViewModel.ClassSobsV.Count != 0)
            {
                using (StreamWriter writer =
               new StreamWriter(await folder.OpenStreamForWriteAsync(
               name +"."+ tip, CreationCollisionOption.GenerateUniqueName)))
                {
                    string sSob = "n" + "\t" + "file" + "\t" + "kl" + "\t" + "PSB" + "\t" + "Time" + "\t" + "SA" + "\t" + "D" + "\t" + "AmpNV" + "\t" + "FirstTimeV" + "\t" + "MaxTime" + "\t"
                        + "AD1" + "\t" + "AD2" + "\t" + "AD3" + "\t" + "AD4" + "\t" + "AD5" + "\t" + "AD6" + "\t" + "AD7" + "\t" + "AD8" + "\t" + "AD9" + "\t" + "aD10" + "\t" + "AD11" + "\t" + "AD12" + "\t"
                        + "TD1" + "\t" + "TD2" + "\t" + "TD3" + "\t" + "TD4" + "\t" + "TD5" + "\t" + "TD6" + "\t" + "TD7" + "\t" + "TD8" + "\t" + "TD9" + "\t" + "TD10" + "\t" + "TD11" + "\t" + "TD12"
                        + "\t" + "TMD1" + "\t" + "TMD2" + "\t" + "TMD3" + "\t" + "TMD4" + "\t" + "TMD5" + "\t" + "TMD6" + "\t" + "TMD7" + "\t" + "TMD8" + "\t" + "TMD9" + "\t" + "TMD10" + "\t" + "TMD11" + "\t" + "TMD12"; ; 


                    await writer.WriteLineAsync(sSob);
                    foreach (ClassSobV sob in ViewModel.ClassSobsV)
                    {
                        i++;
                        string Sob = i.ToString() + "\t" + sob.nameFile + "\t" + sob.nameklaster + "\t" + sob.nameBAAK.ToString() + "\t" + sob.time + "\t" +
                       sob.SumAmp.ToString() + "\t" + sob.nV.ToString("00") + "\t" + sob.AmpNV.ToString() + "\t" + sob.FirstTimeV[sob.nV].ToString() + "\t" + sob.MaxTime.ToString("00") + "\t" + sob.Amp0.ToString() + "\t" + sob.Amp1.ToString() + "\t" + sob.Amp2.ToString() + "\t" + sob.Amp3.ToString() + "\t"
                       + sob.Amp4.ToString() + "\t" + sob.Amp5.ToString() + "\t" + sob.Amp6.ToString() + "\t" + sob.Amp7.ToString() + "\t" + sob.Amp8.ToString() + "\t" +
                       sob.Amp9.ToString() + "\t" + sob.Amp10.ToString() + "\t" + sob.Amp11.ToString() + "\t" + sob.maxTimeV[0].ToString() + "\t" + sob.maxTimeV[1].ToString() + "\t" + sob.maxTimeV[2].ToString() + "\t" + sob.maxTimeV[3].ToString() + "\t"
                       + sob.maxTimeV[4].ToString() + "\t" + sob.maxTimeV[5].ToString() + "\t" + sob.maxTimeV[6].ToString() + "\t" + sob.maxTimeV[7].ToString() + "\t" + sob.maxTimeV[8].ToString() + "\t" +
                       sob.maxTimeV[9].ToString() + "\t" + sob.maxTimeV[10].ToString() + "\t" + sob.maxTimeV[11].ToString() + "\t" + sob.FirstTimeV[0].ToString() + "\t" + sob.FirstTimeV[1].ToString() + "\t" + sob.FirstTimeV[2].ToString() + "\t" + sob.FirstTimeV[3].ToString() + "\t"
                       + sob.FirstTimeV[4].ToString() + "\t" + sob.FirstTimeV[5].ToString() + "\t" + sob.FirstTimeV[6].ToString() + "\t" + sob.FirstTimeV[7].ToString() + "\t" + sob.FirstTimeV[8].ToString() + "\t" +
                       sob.FirstTimeV[9].ToString() + "\t" + sob.FirstTimeV[10].ToString() + "\t" + sob.FirstTimeV[11].ToString() + "\t" + sob.PolmaxTimeV[0].ToString(); 
                        await writer.WriteLineAsync(Sob);
                    }
                }
            }

        }
        public async Task SaveSobPlox(StorageFolder folder, String name, string tip, string cul)
        {
            int i = 0;
            if (_DataColecSobPlox.Count != 0)
            {
                using (StreamWriter writer =
               new StreamWriter(await folder.OpenStreamForWriteAsync(
               name + "." + tip, CreationCollisionOption.GenerateUniqueName)))
                {
                    string sSob = "n" + "\t" + "file" + "\t" + "kl" + "\t" + "PSB" + "\t" + "Time" + "\t" + "SA" + "\t" + "SN" + "\t" + "AD1" + "\t" + "AD2" + "\t" + "AD3" + "\t" + "AD4" + "\t" + "AD5" + "\t" + "AD6" + "\t" + "AD7" + "\t" + "AD8" + "\t" + "AD9" + "\t" + "AD10" + "\t" + "AD11" + "\t" + "AD12" +
                               "\t" + "ND1" + "\t" + "ND2" + "\t" + "ND3" + "\t" + "ND4" + "\t" + "ND5" + "\t" + "ND6" + "\t" + "ND7" + "\t" + "ND8" + "\t" + "ND9" + "\t" + "ND10" + "\t" + "ND11" + "\t" + "ND12" + "\t" +
                               "SigD1" + "\t" + "SigD2" + "\t" + "SigD3" + "\t" + "SigD4" + "\t" + "SigD5" + "\t" + "SigD6" + "\t" + "SigD7" + "\t" + "SigD8" + "\t" + "SigD9" + "\t" + "SigD10" + "\t" + "SigD11" + "\t" + "SigD12" + "\t" + "NullD1" + "\t" + "NullD2"
                               + "\t" + "NullD3" + "\t" + "NullD4" + "\t" + "NullD5" + "\t" + "NullD6" + "\t" + "NullD7" + "\t" + "NullD8" + "\t" + "NullD9" + "\t" + "NullD10" + "\t" + "NullD11" + "\t" + "NullD12";


                    await writer.WriteLineAsync(sSob);
                    foreach (ClassSob sob in _DataColecSobPlox)
                    {
                        i++;
                        string Sob = i.ToString() + "\t" + sob.nameFile + "\t" + sob.nameklaster + "\t" + sob.nameBAAK.ToString() + "\t" + sob.time + "\t" + sob.SumAmp + "\t" + sob.SumNeu
                            + "\t" + sob.mAmp[0].ToString() + "\t" + sob.mAmp[1].ToString() + "\t" + sob.mAmp[2].ToString() + "\t" + sob.mAmp[3].ToString() + "\t" + sob.mAmp[4].ToString() + "\t" + sob.mAmp[5].ToString() 
                            + "\t" + sob.mAmp[6].ToString() + "\t" + sob.mAmp[7].ToString() + "\t" + sob.mAmp[8].ToString() + "\t" + sob.mAmp[9].ToString() + "\t" + sob.mAmp[10].ToString() + "\t" + sob.mAmp[11].ToString() +
                           "\t" + sob.Nnut0.ToString() + "\t" + sob.Nnut1.ToString() + "\t" + sob.Nnut2.ToString() + "\t" + sob.Nnut3.ToString() + "\t" + sob.Nnut4.ToString() + "\t" + sob.Nnut5.ToString() + "\t" + sob.Nnut6.ToString() + "\t" + sob.Nnut7.ToString() + "\t" + sob.Nnut8.ToString() + "\t" + sob.Nnut9.ToString() + "\t" + sob.Nnut10.ToString() + "\t" + sob.Nnut11.ToString() + "\t" +
                            sob.sig0.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig1.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig2.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig3.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig4.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig5.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig6.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig7.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig8.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig9.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig10.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig11.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.Nnull0
                             + "\t" + sob.Nnull1 + "\t" + sob.Nnull2 + "\t" + sob.Nnull3 + "\t" + sob.Nnull4 + "\t" + sob.Nnull5 + "\t" + sob.Nnull6 + "\t" + sob.Nnull7 + "\t" + sob.Nnull8 + "\t" + sob.Nnull9 + "\t" + sob.Nnull10 + "\t" + sob.Nnull11;
                        await writer.WriteLineAsync(Sob);
                    }
                }
            }

        }
        public async Task SaveSobPloxN(StorageFolder folder, String name, string tip, string cul)
        {
            int i = 0;
            if (ViewModel.ClassSobsN.Count != 0)
            {
                using (StreamWriter writer =
               new StreamWriter(await folder.OpenStreamForWriteAsync(
               name + tip, CreationCollisionOption.GenerateUniqueName)))
                {
                    string sSob = "n" + "\t" + "file" + "\t" + "kl" + "\t" + "PSB" + "\t" + "Time" + "\t" + "SA" + "\t" + "SQ" + "\t" + "\t" + "AD1" + "\t" + "AD2" + "\t" + "AD3" + "\t" + "AD4" + "\t" + "AD5" + "\t" + "AD6" + "\t" + "AD7" + "\t" + "AD8" + "\t" + "AD9" + "\t" + "aD10" + "\t" + "AD11" + "\t" + "AD12" +
                               "\t" + "QD1" + "\t" + "QD2" + "\t" + "QD3" + "\t" + "QD4" + "\t" + "QD5" + "\t" + "QD6" + "\t" + "QD7" + "\t" + "QD8" + "\t" + "QD9" + "\t" + "QD10" + "\t" + "QD11" + "\t" + "QD12";


                    await writer.WriteLineAsync(sSob);
                    foreach (ClassSobN sob in ViewModel.ClassSobsN)
                    {
                        i++;
                        string Sob = i.ToString() + "\t" + sob.nameFile + "\t" + sob.nameklaster + "\t" + sob.nameBAAK.ToString() + "\t" + sob.time + "\t" +
                       sob.SumAmp + "\t" + sob.Qsum.Sum().ToString() + "\t" + sob.Amp0.ToString() + "\t" + sob.Amp1.ToString() + "\t" + sob.Amp2.ToString() + "\t" + sob.Amp3.ToString() + "\t"
                       + sob.Amp4.ToString() + "\t" + sob.Amp5.ToString() + "\t" + sob.Amp6.ToString() + "\t" + sob.Amp7.ToString() + "\t" + sob.Amp8.ToString() + "\t" +
                       sob.Amp9.ToString() + "\t" + sob.Amp10.ToString() + "\t" + sob.Amp11.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t"
                       + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" +
                       sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t";
                        await writer.WriteLineAsync(Sob);
                    }
                }
            }

        }
        public async Task SaveSobPloxV(StorageFolder folder, String name, string tip, string cul)
        {
            int i = 0;
            if (ViewModel.ClassSobsV.Count != 0)
            {
                using (StreamWriter writer =
               new StreamWriter(await folder.OpenStreamForWriteAsync(
               name +"."+ tip, CreationCollisionOption.GenerateUniqueName)))
                {
                    string sSob = "n" + "\t" + "file" + "\t" + "kl" + "\t" + "PSB" + "\t" + "Time" + "\t" + "SA" + "\t" + "SQ" + "\t" + "\t" + "AD1" + "\t" + "AD2" + "\t" + "AD3" + "\t" + "AD4" + "\t" + "AD5" + "\t" + "AD6" + "\t" + "AD7" + "\t" + "AD8" + "\t" + "AD9" + "\t" + "aD10" + "\t" + "AD11" + "\t" + "AD12" +
                               "\t" + "QD1" + "\t" + "QD2" + "\t" + "QD3" + "\t" + "QD4" + "\t" + "QD5" + "\t" + "QD6" + "\t" + "QD7" + "\t" + "QD8" + "\t" + "QD9" + "\t" + "QD10" + "\t" + "QD11" + "\t" + "QD12";


                    await writer.WriteLineAsync(sSob);
                    foreach (ClassSobV sob in ViewModel.ClassSobsV)
                    {
                        i++;
                        string Sob = i.ToString() + "\t" + sob.nameFile + "\t" + sob.nameklaster + "\t" + sob.nameBAAK.ToString() + "\t" + sob.time + "\t" +
                       sob.SumAmp + "\t" + sob.Qsum.Sum().ToString() + "\t" + sob.Amp0.ToString() + "\t" + sob.Amp1.ToString() + "\t" + sob.Amp2.ToString() + "\t" + sob.Amp3.ToString() + "\t"
                       + sob.Amp4.ToString() + "\t" + sob.Amp5.ToString() + "\t" + sob.Amp6.ToString() + "\t" + sob.Amp7.ToString() + "\t" + sob.Amp8.ToString() + "\t" +
                       sob.Amp9.ToString() + "\t" + sob.Amp10.ToString() + "\t" + sob.Amp11.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t"
                       + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" +
                       sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t";
                        await writer.WriteLineAsync(Sob);
                    }
                }
            }

        }
        public async Task SaveSobNeutron(StorageFolder folder, String name, string tip, string cul)
        {
            int ii = 0;
            if (ViewModel.ClassSobNeutrons.Count != 0)
            {
                using (StreamWriter writer =
               new StreamWriter(await folder.OpenStreamForWriteAsync(
               name+"."+tip, CreationCollisionOption.GenerateUniqueName)))
                {
                    string sNeu = "n" + "\t" + "file" + "\t" + "D" + "\t" + "A" + "\t" + "Time" + "\t" + "tf" + "\t" + "tf3" + "\t" + "tmax" + "\t" + "tend3" + "\t" + "tend";
                    await writer.WriteLineAsync(sNeu);
                    foreach (ClassSobNeutron sob in ViewModel.ClassSobNeutrons)
                    {
                        ii++;
                        string Sob = ii.ToString() + "\t" + sob.nameFile + "\t" + sob.D.ToString("00") + "\t" + sob.Amp.ToString() + "\t" + sob.time + "\t" + sob.TimeFirst.ToString() + "\t" + sob.TimeFirst3.ToString() + "\t" + sob.TimeAmp.ToString() + "\t" + sob.TimeEnd3.ToString() + "\t" + sob.TimeEnd3.ToString();
                        await writer.WriteLineAsync(Sob);
                    }
                }
            }

        }
        public async Task SaveAll()
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

                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

                StorageFolder storageFolderRazvertka = await storageFolder.CreateFolderAsync("Развертка", CreationCollisionOption.OpenIfExists);

                IReadOnlyList<StorageFile> fileList =
                    await storageFolderRazvertka.GetFilesAsync();
                if (fileList.Count != 0)
                {
                    StorageFolder storageFolderSave = await folder.CreateFolderAsync("Развертка", CreationCollisionOption.GenerateUniqueName);
                    foreach (StorageFile file in fileList)
                    {
                        await file.CopyAsync(storageFolderSave);
                    }
                }

              await  SaveSob(folder, "СобытияФайлаT", "txt", cul);
                await SaveSobPlox(folder, "СобытияФайлаBadT", "txt", cul);

                await SaveSobNeutron(folder, "НейтроныФайлаT", "txt", cul);
                await SaveSobN(folder, "СобытияФайла", "txt", cul);
                await SaveSobPloxN(folder, "СобытияФайлаBad", "txt", cul);
                await SaveSobV(folder, "СобытияФайла", "txt", cul);
                await SaveSobPloxV(folder, "СобытияФайлаBad", "txt", cul);



            }
            else
            {

            }
        }
        public async Task SaveAllNoTailQ()
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

                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

                StorageFolder storageFolderRazvertka = await storageFolder.CreateFolderAsync("Развертка", CreationCollisionOption.OpenIfExists);

                IReadOnlyList<StorageFile> fileList =
                    await storageFolderRazvertka.GetFilesAsync();
                if (fileList.Count != 0)
                {
                    
                }
                int i = 0;
                if (ViewModel.ClassSobsT.Count != 0)
                {
                    using (StreamWriter writer =
                   new StreamWriter(await folder.OpenStreamForWriteAsync(
                   "QСобытияФайла.txt", CreationCollisionOption.GenerateUniqueName)))
                    {
                        string sSob = "n" + "\t" + "file" + "\t" + "kl" + "\t" + "PSB" + "\t" + "Time" + "\t" + "SA" +"\t"+"SQ"+ "\t" + "\t" + "AD1" + "\t" + "AD2" + "\t" + "AD3" + "\t" + "AD4" + "\t" + "AD5" + "\t" + "AD6" + "\t" + "AD7" + "\t" + "AD8" + "\t" + "AD9" + "\t" + "aD10" + "\t" + "AD11" + "\t" + "AD12" +
                                   "\t" + "QD1" + "\t" + "QD2" + "\t" + "QD3" + "\t" + "QD4" + "\t" + "QD5" + "\t" + "QD6" + "\t" + "QD7" + "\t" + "QD8" + "\t" + "QD9" + "\t" + "QD10" + "\t" + "QD11" + "\t" + "QD12";


                        await writer.WriteLineAsync(sSob);
                        foreach (ClassSobN sob in ViewModel.ClassSobsN)
                        {
                            i++;
                            string Sob = i.ToString() + "\t" + sob.nameFile + "\t" + sob.nameklaster + "\t" + sob.nameBAAK.ToString() + "\t" + sob.time + "\t" +
                           sob.SumAmp + "\t" + sob.Qsum.Sum().ToString() + "\t" + sob.Amp0.ToString() + "\t" + sob.Amp1.ToString() + "\t" + sob.Amp2.ToString() + "\t" + sob.Amp3.ToString() + "\t" 
                           + sob.Amp4.ToString() + "\t" + sob.Amp5.ToString() + "\t" + sob.Amp6.ToString() + "\t" + sob.Amp7.ToString() + "\t" + sob.Amp8.ToString() + "\t" +
                           sob.Amp9.ToString() + "\t" + sob.Amp10.ToString() + "\t" + sob.Amp11.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t"
                           + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" +
                           sob.QS0.ToString() + "\t" + sob.QS0.ToString() + "\t" + sob.QS0.ToString()+"\t";
                            await writer.WriteLineAsync(Sob);
                        }
                    }
                }
                
              

            }
            else
            {

            }
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


            // StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder; ;
            StorageFolder storageFolderRazvertka = await storageFolder.CreateFolderAsync("Развертка", CreationCollisionOption.OpenIfExists);
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
                storageFolderRazvertka = await storageFolder.CreateFolderAsync("Развертка", CreationCollisionOption.OpenIfExists);
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
        public async Task SaveFilter()
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

                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

                StorageFolder storageFolderRazvertka = await storageFolder.CreateFolderAsync("Развертка", CreationCollisionOption.OpenIfExists);

                IReadOnlyList<StorageFile> fileList =
                    await storageFolderRazvertka.GetFilesAsync();
                if (fileList.Count != 0)
                {
                    StorageFolder storageFolderSave = await folder.CreateFolderAsync("Развертка", CreationCollisionOption.GenerateUniqueName);
                    foreach (StorageFile file in fileList)
                    {
                        await file.CopyAsync(storageFolderSave);
                    }
                }
                int i = 0;
                if (ViewModel.ClassSobsT.Count != 0)
                {
                    using (StreamWriter writer =
                   new StreamWriter(await folder.OpenStreamForWriteAsync(
                   "СобытияФайла.txt", CreationCollisionOption.GenerateUniqueName)))
                    {
                        string sSob = "n" + "\t" + "file" + "\t" + "kl" + "\t" + "PSB" + "\t" + "Time" + "\t" + "SA" + "\t" + "SN" + "\t" + "AD1" + "\t" + "AD2" + "\t" + "AD3" + "\t" + "AD4" + "\t" + "AD5" + "\t" + "AD6" + "\t" + "AD7" + "\t" + "AD8" + "\t" + "AD9" + "\t" + "AD10" + "\t" + "AD11" + "\t" + "AD12" +
                                   "\t" + "ND1" + "\t" + "ND2" + "\t" + "ND3" + "\t" + "ND4" + "\t" + "ND5" + "\t" + "ND6" + "\t" + "ND7" + "\t" + "ND8" + "\t" + "ND9" + "\t" + "ND10" + "\t" + "ND11" + "\t" + "ND12" + "\t" +
                                   "SigD1" + "\t" + "SigD2" + "\t" + "SigD3" + "\t" + "SigD4" + "\t" + "SigD5" + "\t" + "SigD6" + "\t" + "SigD7" + "\t" + "SigD8" + "\t" + "SigD9" + "\t" + "SigD10" + "\t" + "SigD11" + "\t" + "SigD12" + "\t" + "NullD1" + "\t" + "NullD2"
                                   + "\t" + "NullD3" + "\t" + "NullD4" + "\t" + "NullD5" + "\t" + "NullD6" + "\t" + "NullD7" + "\t" + "NullD8" + "\t" + "NullD9" + "\t" + "NullD10" + "\t" + "NullD11" + "\t" + "NullD12";


                        await writer.WriteLineAsync(sSob);
                        foreach (ClassSob sob in ViewModel.ClassSobsT)
                        {
                            i++;
                            string Sob = i.ToString() + "\t" + sob.nameFile + "\t" + sob.nameklaster + "\t" + sob.nameBAAK.ToString() + "\t" + sob.time + "\t" + sob.SumAmp + "\t" + sob.SumNeu
                                + "\t" + sob.mAmp[0].ToString() + "\t" + sob.mAmp[1].ToString() + "\t" + sob.mAmp[2].ToString() + "\t" + sob.mAmp[3].ToString() + "\t" + sob.mAmp[4].ToString() + "\t" 
                                + sob.mAmp[5].ToString() + "\t" + sob.mAmp[6].ToString() + "\t" + sob.mAmp[7].ToString() + "\t" + sob.mAmp[8].ToString() + "\t" + sob.mAmp[9].ToString() + "\t" + sob.mAmp[10].ToString() + 
                                "\t" + sob.mAmp[11].ToString() +
                               "\t" + sob.Nnut0.ToString() + "\t" + sob.Nnut1.ToString() + "\t" + sob.Nnut2.ToString() + "\t" + sob.Nnut3.ToString() + "\t" + sob.Nnut4.ToString() + "\t" + sob.Nnut5.ToString() + "\t" + sob.Nnut6.ToString() + "\t" + sob.Nnut7.ToString() + "\t" + sob.Nnut8.ToString() + "\t" + sob.Nnut9.ToString() + "\t" + sob.Nnut10.ToString() + "\t" + sob.Nnut11.ToString() + "\t" +
                                sob.sig0.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig1.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig2.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig3.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig4.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig5.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig6.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig7.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig8.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig9.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig10.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig11.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.Nnull0
                                 + "\t" + sob.Nnull1 + "\t" + sob.Nnull2 + "\t" + sob.Nnull3 + "\t" + sob.Nnull4 + "\t" + sob.Nnull5 + "\t" + sob.Nnull6 + "\t" + sob.Nnull7 + "\t" + sob.Nnull8 + "\t" + sob.Nnull9 + "\t" + sob.Nnull10 + "\t" + sob.Nnull11;
                            await writer.WriteLineAsync(Sob);
                        }
                    }
                }
                i = 0;
                if (_DataColecSobPlox.Count != 0)
                {
                    using (StreamWriter writer =
                   new StreamWriter(await folder.OpenStreamForWriteAsync(
                   "СобытияФайлаBad.txt", CreationCollisionOption.GenerateUniqueName)))
                    {
                        string sSob = "n" + "\t" + "file" + "\t" + "kl" + "\t" + "PSB" + "\t" + "Time" + "\t" + "SA" + "\t" + "SN" + "\t" + "AD1" + "\t" + "AD2" + "\t" + "AD3" + "\t" + "AD4" + "\t" + "AD5" + "\t" + "AD6" + "\t" + "AD7" + "\t" + "AD8" + "\t" + "AD9" + "\t" + "AD10" + "\t" + "AD11" + "\t" + "AD12" +
                                   "\t" + "ND1" + "\t" + "ND2" + "\t" + "ND3" + "\t" + "ND4" + "\t" + "ND5" + "\t" + "ND6" + "\t" + "ND7" + "\t" + "ND8" + "\t" + "ND9" + "\t" + "ND10" + "\t" + "ND11" + "\t" + "ND12" + "\t" +
                                   "SigD1" + "\t" + "SigD2" + "\t" + "SigD3" + "\t" + "SigD4" + "\t" + "SigD5" + "\t" + "SigD6" + "\t" + "SigD7" + "\t" + "SigD8" + "\t" + "SigD9" + "\t" + "SigD10" + "\t" + "SigD11" + "\t" + "SigD12" + "\t" + "NullD1" + "\t" + "NullD2"
                                   + "\t" + "NullD3" + "\t" + "NullD4" + "\t" + "NullD5" + "\t" + "NullD6" + "\t" + "NullD7" + "\t" + "NullD8" + "\t" + "NullD9" + "\t" + "NullD10" + "\t" + "NullD11" + "\t" + "NullD12";


                        await writer.WriteLineAsync(sSob);
                        foreach (ClassSob sob in _DataColecSobPlox)
                        {
                            i++;
                            string Sob = i.ToString() + "\t" + sob.nameFile + "\t" + sob.nameklaster + "\t" + sob.nameBAAK.ToString() + "\t" + sob.time + "\t" + sob.SumAmp + "\t" + sob.SumNeu + "\t" +
                                sob.mAmp[0].ToString() + "\t" + sob.mAmp[1].ToString() + "\t" + sob.mAmp[2].ToString() + "\t" + sob.mAmp[3].ToString() + "\t" + sob.mAmp[4].ToString() + "\t" + sob.mAmp[5].ToString()
                                + "\t" + sob.mAmp[6].ToString() + "\t" + sob.mAmp[7].ToString() + "\t" + sob.mAmp[8].ToString() + "\t" + sob.mAmp[9].ToString() + "\t" + sob.mAmp[10].ToString() + "\t" + sob.mAmp[11].ToString() +
                               "\t" + sob.Nnut0.ToString() + "\t" + sob.Nnut1.ToString() + "\t" + sob.Nnut2.ToString() + "\t" + sob.Nnut3.ToString() + "\t" + sob.Nnut4.ToString() + "\t" + sob.Nnut5.ToString() + "\t" + sob.Nnut6.ToString() + "\t" + sob.Nnut7.ToString() + "\t" + sob.Nnut8.ToString() + "\t" + sob.Nnut9.ToString() + "\t" + sob.Nnut10.ToString() + "\t" + sob.Nnut11.ToString() + "\t" +
                                sob.sig0.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig1.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig2.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig3.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig4.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig5.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig6.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig7.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig8.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig9.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig10.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.sig11.ToString("0.00", CultureInfo.GetCultureInfo(cul)) + "\t" + sob.Nnull0
                                 + "\t" + sob.Nnull1 + "\t" + sob.Nnull2 + "\t" + sob.Nnull3 + "\t" + sob.Nnull4 + "\t" + sob.Nnull5 + "\t" + sob.Nnull6 + "\t" + sob.Nnull7 + "\t" + sob.Nnull8 + "\t" + sob.Nnull9 + "\t" + sob.Nnull10 + "\t" + sob.Nnull11;
                            await writer.WriteLineAsync(Sob);
                        }
                    }
                }
                int ii = 0;
                if (ViewModel.ClassSobNeutrons.Count != 0)
                {
                    using (StreamWriter writer =
                   new StreamWriter(await folder.OpenStreamForWriteAsync(
                   "НейтроныФайла.txt", CreationCollisionOption.GenerateUniqueName)))
                    {
                        string sNeu = "n" + "\t" + "file" + "\t" + "D" + "\t" + "A" + "\t" + "Time" + "\t" + "tf" + "\t" + "tf3" + "\t" + "tmax" + "\t" + "tend3" + "\t" + "tend";
                        await writer.WriteLineAsync(sNeu);
                        foreach (ClassSobNeutron sob in ViewModel.ClassSobNeutrons)
                        {
                            ii++;
                            string Sob = ii.ToString() + "\t" + sob.nameFile + "\t" + sob.D.ToString("00") + "\t" + sob.Amp.ToString() + "\t" + sob.time + "\t" + sob.TimeFirst.ToString() + "\t" + sob.TimeFirst3.ToString() + "\t" + sob.TimeAmp.ToString() + "\t" + sob.TimeEnd3.ToString() + "\t" + sob.TimeEnd3.ToString();
                            await writer.WriteLineAsync(Sob);
                        }
                    }
                }
            }
            else
            {

            }
        }


        public async Task SaveAllMenedger()
        {
            string cul = "en-US";

            // Application now has read/write access to all contents in the picked folder
            // (including other sub-folder contents)
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            ViewModel._DataColecViewSaveMenedger.Add(new ClassSaveSetUp() { Folder = folder, NameFile = "СобытияФайлаT", tip = ".txt", save = true });
            ViewModel._DataColecViewSaveMenedger.Add(new ClassSaveSetUp() { Folder = folder, NameFile = "СобытияФайлаBadT", tip = ".txt", save = true });
            ViewModel._DataColecViewSaveMenedger.Add(new ClassSaveSetUp() { Folder = folder, NameFile = "НейтроныФайлаT", tip = ".txt", save = true });

            ViewModel._DataColecViewSaveMenedger.Add(new ClassSaveSetUp() { Folder = folder, NameFile = "СобытияФайлаN", tip = ".txt", save = true });
            ViewModel._DataColecViewSaveMenedger.Add(new ClassSaveSetUp() { Folder = folder, NameFile = "СобытияФайлаBadN", tip = ".txt", save = true });
            ViewModel._DataColecViewSaveMenedger.Add(new ClassSaveSetUp() { Folder = folder, NameFile = "СобытияФайлаV", tip = ".txt", save = true });
            ViewModel._DataColecViewSaveMenedger.Add(new ClassSaveSetUp() { Folder = folder, NameFile = "СобытияФайлаBadV", tip = ".txt", save = true });





        }
    }
}
