using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.UI.Popups;

namespace DataYRAN
{
    public sealed partial class BlankPageObrData
    {
        
        private async Task OpenFileAsync()
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.ComputerFolder;
            picker.FileTypeFilter.Add(".txt");
            picker.FileTypeFilter.Add(".dat");
            picker.FileTypeFilter.Add(".bin");
            var files = await picker.PickMultipleFilesAsync();
            if (files.Count > 0)
            {
                // Application now has read/write access to the picked file(s)
                foreach (Windows.Storage.StorageFile file in files)
                {

                    if (file.FileType == ".bin")
                    {
                        string[] str = file.DisplayName.Split('_');
                        if(str[2]=="N")
                        {
                            NoTailCh.IsChecked = true;
                        }
                        if(str[2]=="T")
                        {
                            TailCh.IsChecked = true;
                        }
                        string FileName = file.DisplayName;
                        string FilePath = file.Path;
                        BasicProperties basicProperties =
       await file.GetBasicPropertiesAsync();

                        // Application now has read/write access to the picked file
                        _DataColec.Add(new ClassСписокList { NameFile = FileName, NemePapka = FilePath, Status = false, file1 = file, size = basicProperties.Size, StatusSize = 0 });
                     
                    }
                    else
                    {

                    }

                }

            }
            else
            {

            }

        }
        public async System.Threading.Tasks.Task OpenFolderAsync()
        {
            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add("*");

            StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                // Application now has read/write access to all contents in the picked folder
                // (including other sub-folder contents)
                Windows.Storage.AccessCache.StorageApplicationPermissions.
                FutureAccessList.AddOrReplace("PickedFolderToken", folder);




                IReadOnlyList<StorageFolder> folderList = await folder.GetFoldersAsync();

                foreach (StorageFolder folder1 in folderList)
                {
                    IReadOnlyList<StorageFile> fileList = await folder1.GetFilesAsync();

                    // Print the month and number of files in this group.
                    //  //outputText.AppendLine(folder.Name + " (" + fileList.Count + ")");
                    //  var messageDialog = new MessageDialog(folder1.Name + " (" + fileList.Count + ")");
                    //  await messageDialog.ShowAsync();

                    foreach (StorageFile file in fileList)
                    {
                        if (file.FileType == ".bin")
                        {
                            string FileName = file.DisplayName;
                            string FilePath = file.Path;
                            _DataColec.Add(new ClassСписокList { NameFile = FileName, NemePapka = FilePath, Status = false, file1 = file });
                            // Print the name of the file.
                            // outputText.AppendLine("   " + file.Name);
                        }
                    }
                }
               

                // var messageDialog = new MessageDialog(folder.Name);
                //await messageDialog.ShowAsync();

            }
            else
            {

            }

        }
        /// <summary>
        /// Формирует список обработанных файлов из локольных файлов развертки
        /// </summary>
        /// <returns></returns>
        public async System.Threading.Tasks.Task OpenFolderLocalAsync()
        {
            StorageFolder picturesFolder = ApplicationData.Current.LocalFolder;
            StorageFolder storageFolderRazvertka = await picturesFolder.CreateFolderAsync("Развертка", CreationCollisionOption.OpenIfExists);
            StringBuilder outputText = new StringBuilder();

            IReadOnlyList<StorageFile> fileList =
                await storageFolderRazvertka.GetFilesAsync();

            foreach (StorageFile file in fileList)
            {
                string FileName = file.DisplayName;
                string FilePath = file.Path;
                КолекцияФайловРазвертки.Add(new ClassСписокList { NameFile = FileName, NemePapka = file.Path, Status = false, file1 = file });
            }

        }


       

        /// <summary>
        /// Очищаем хранилище с разверткой
        /// </summary>
        /// <returns></returns>
        public async Task Delite()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

            StorageFolder storageFolderRazvertka = await storageFolder.CreateFolderAsync("Развертка", CreationCollisionOption.OpenIfExists);


            IReadOnlyList<StorageFile> fileList =
                await storageFolderRazvertka.GetFilesAsync();

            foreach (StorageFile file in fileList)
            {
                StorageFile sampleFile = await storageFolderRazvertka.CreateFileAsync(file.DisplayName + ".txt", CreationCollisionOption.ReplaceExisting);
                await sampleFile.DeleteAsync();
            }
            StorageFolder storageFolderSob = await storageFolder.CreateFolderAsync("События", CreationCollisionOption.OpenIfExists);


            IReadOnlyList<StorageFile> fileList1 =
                await storageFolderSob.GetFilesAsync();

            foreach (StorageFile file in fileList1)
            {
                StorageFile sampleFile = await storageFolderSob.CreateFileAsync(file.DisplayName + ".txt", CreationCollisionOption.ReplaceExisting);
                await sampleFile.DeleteAsync();
            }
        }

    }
}
