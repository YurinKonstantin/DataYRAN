using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DataYRAN
{
    public partial class BlankPageObrData
    {
      
        List<ClassСписокList> classСписокLists1 = new List<ClassСписокList>();
        private async void Button_Click_6(object sender, RoutedEventArgs e)
        {
            gridMenedgerAddFile.Visibility = Visibility.Collapsed;
            mySplitView.IsPaneOpen = true;
            if (storage != null)
            {
                ContentDialog deleteFileDialog = new ContentDialog()
                {
                    Title = "Добавление файлов для обработки",
                    Content = "Дождитесь закрытия этого окна."+"\n"+ "Идет процесс добавления файлов для обработки",
                  
                };
                deleteFileDialog.ShowAsync();
               // ContentDialogResult result = await deleteFileDialog.ShowAsync();

                IReadOnlyList<StorageFile> fileList = await storage.GetFilesAsync();

             

                foreach (StorageFile file in fileList)
                {
                    if (file.FileType == ".bin")
                    {
                        string FileName = file.DisplayName;
                        string FilePath = file.Path;
                        if (!Convert.ToBoolean(ChTime.IsChecked))
                        {
                            if (Convert.ToBoolean(ChklAll.IsChecked))
                            {
                               
                                // Application now has read/write access to the picked file
                                ViewModel.AddFile(new ClassСписокList {  Status = false, file1 = file, StatusSize = 0, basicProperties = await file.GetBasicPropertiesAsync() });
                                deleteFileDialog.Content = "Дождитесь закрытия этого окна." + "\n" + "Идет процесс добавления файлов для обработки" + "\n" +"Файл "+ file.DisplayName + " добавлен";

                            }
                            else
                            {
                                string[] s = FileName.Split('_');
                                string sNew = String.Empty;
                                if(s.Length==2)
                                {
                                    if(s[0].Contains("№"))
                                    {
                                        sNew = s[0].Split("№")[1];
                                    }
                                    else
                                    {
                                        sNew = s[0];
                                    }
                                    
                                }
                                else
                                {
                                    sNew = s[0];
                                }
                                if (sNew == "1" && Chkl1.IsChecked == true)
                                {
                                    
                                    // Application now has read/write access to the picked file
                                    ViewModel.AddFile(new ClassСписокList { Status = false, file1 = file,  StatusSize = 0, basicProperties = await file.GetBasicPropertiesAsync() });
                                    deleteFileDialog.Content = "Дождитесь закрытия этого окна." + "\n" + "Идет процесс добавления файлов для обработки" + "\n" + "Файл " + file.DisplayName + " добавлен";

                                }
                                if (sNew == "2" && Chkl2.IsChecked == true)
                                {
                                   
                                    // Application now has read/write access to the picked file
                                    ViewModel.AddFile(new ClassСписокList {  Status = false, file1 = file, StatusSize = 0, basicProperties= await file.GetBasicPropertiesAsync() });
                                    deleteFileDialog.Content = "Дождитесь закрытия этого окна." + "\n" + "Идет процесс добавления файлов для обработки" + "\n" + "Файл " + file.DisplayName + " добавлен";
                                }
                                if (sNew == "3" && Chkl3.IsChecked == true)
                                {
                                 
                                    // Application now has read/write access to the picked file
                                    ViewModel.AddFile(new ClassСписокList {   Status = false, file1 = file, StatusSize = 0, basicProperties = await file.GetBasicPropertiesAsync() });
                                    deleteFileDialog.Content = "Дождитесь закрытия этого окна." + "\n" + "Идет процесс добавления файлов для обработки" + "\n" + "Файл " + file.DisplayName + " добавлен";
                                }
                                if (sNew == "4" && Chkl4.IsChecked == true)
                                {
                                   
                                    // Application now has read/write access to the picked file
                                    ViewModel.AddFile(new ClassСписокList {  Status = false, file1 = file, StatusSize = 0, basicProperties = await file.GetBasicPropertiesAsync() });
                                    deleteFileDialog.Content = "Дождитесь закрытия этого окна." + "\n" + "Идет процесс добавления файлов для обработки" + "\n" + "Файл " + file.DisplayName + " добавлен";
                                }
                                if (sNew == "5" && Chkl5.IsChecked == true)
                                {
                                  
                                    // Application now has read/write access to the picked file
                                    ViewModel.AddFile(new ClassСписокList {Status = false, file1 = file,  StatusSize = 0, basicProperties = await file.GetBasicPropertiesAsync() });
                                    deleteFileDialog.Content = "Дождитесь закрытия этого окна." + "\n" + "Идет процесс добавления файлов для обработки" + "\n" + "Файл " + file.DisplayName + " добавлен";
                                }
                                if (sNew == "6" && Chkl6.IsChecked == true)
                                {
                                   
                                    // Application now has read/write access to the picked file
                                    ViewModel.AddFile(new ClassСписокList { Status = false, file1 = file,  StatusSize = 0, basicProperties = await file.GetBasicPropertiesAsync() });
                                    deleteFileDialog.Content = "Дождитесь закрытия этого окна." + "\n" + "Идет процесс добавления файлов для обработки" + "\n" + "Файл " + file.DisplayName + " добавлен";
                                }




                            }
                        }
                        else
                        {
                            string[] s = FileName.Split('_');
                            string[] ss = s[1].Split(' ');
                            DateTime dateTime = new DateTime(2018, 12, 12);
                            DateTime dateTime2 = new DateTime(2018, 12, 12);
                            dateTime = MyDate1.Date.Value.DateTime;
                            dateTime2 = MyDate2.Date.Value.DateTime;
                            string t = dateTime.Day.ToString() + "." + dateTime.Month.ToString() + "." + dateTime.Year.ToString();
                            string[] dd = ss[0].Split('.');
                            DateTime dateTime1 = new DateTime(Convert.ToInt32(dd[2]), Convert.ToInt32(dd[1]), Convert.ToInt32(dd[0]));

                            if (dateTime1.Date >= dateTime.Date && dateTime2.Date >= dateTime1.Date)
                            {

                                if (Convert.ToBoolean(ChklAll.IsChecked))
                                {
                                  
                                    // Application now has read/write access to the picked file
                                    ViewModel.AddFile(new ClassСписокList {  Status = false, file1 = file, StatusSize = 0, basicProperties = await file.GetBasicPropertiesAsync() });
                                    deleteFileDialog.Content = "Дождитесь закрытия этого окна." + "\n" + "Идет процесс добавления файлов для обработки" + "\n" + "Файл " + file.DisplayName + " добавлен";
                                }
                                else
                                {
                                   
                                    string sNew = String.Empty;
                                    if (s.Length == 2)
                                    {
                                       
                                        if (s[0].Contains("№"))
                                        {
                                            sNew = s[0].Split("№")[1];
                                        }
                                        else
                                        {
                                            sNew = s[0];
                                        }
                                    }
                                    else
                                    {
                                        sNew = s[0];
                                    }
                                    if (sNew == "1" && Chkl1.IsChecked == true)
                                    {
                                      
                                        // Application now has read/write access to the picked file
                                        ViewModel.AddFile(new ClassСписокList {  Status = false, file1 = file, StatusSize = 0, basicProperties = await file.GetBasicPropertiesAsync() });
                                        deleteFileDialog.Content = "Дождитесь закрытия этого окна." + "\n" + "Идет процесс добавления файлов для обработки" + "\n" + "Файл " + file.DisplayName + " добавлен";
                                    }
                                    if (sNew == "2" && Chkl2.IsChecked == true)
                                    {
                                       
                                        // Application now has read/write access to the picked file
                                        ViewModel.AddFile(new ClassСписокList {  Status = false, file1 = file, StatusSize = 0, basicProperties = await file.GetBasicPropertiesAsync() });
                                        deleteFileDialog.Content = "Дождитесь закрытия этого окна." + "\n" + "Идет процесс добавления файлов для обработки" + "\n" + "Файл " + file.DisplayName + " добавлен";
                                    }
                                    if (sNew == "3" && Chkl3.IsChecked == true)
                                    {
                                        
                                        // Application now has read/write access to the picked file
                                        ViewModel.AddFile(new ClassСписокList {  Status = false, file1 = file, StatusSize = 0, basicProperties = await file.GetBasicPropertiesAsync() });
                                        deleteFileDialog.Content = "Дождитесь закрытия этого окна." + "\n" + "Идет процесс добавления файлов для обработки" + "\n" + "Файл " + file.DisplayName + " добавлен";
                                    }
                                    if (sNew == "4" && Chkl4.IsChecked == true)
                                    {
                                       
                                        // Application now has read/write access to the picked file
                                        ViewModel.AddFile(new ClassСписокList {  Status = false, file1 = file, StatusSize = 0, basicProperties = await file.GetBasicPropertiesAsync() });
                                        deleteFileDialog.Content = "Дождитесь закрытия этого окна." + "\n" + "Идет процесс добавления файлов для обработки" + "\n" + "Файл " + file.DisplayName + " добавлен";

                                    }
                                    if (sNew == "5" && Chkl5.IsChecked == true)
                                    {
                                        
                                        // Application now has read/write access to the picked file
                                        ViewModel.AddFile(new ClassСписокList {  Status = false, file1 = file, StatusSize = 0, basicProperties = await file.GetBasicPropertiesAsync() });
                                        deleteFileDialog.Content = "Дождитесь закрытия этого окна." + "\n" + "Идет процесс добавления файлов для обработки" + "\n" + "Файл " + file.DisplayName + " добавлен";
                                    }
                                    if (sNew == "6" && Chkl6.IsChecked == true)
                                    {
                                      
                                        // Application now has read/write access to the picked file
                                        ViewModel.AddFile(new ClassСписокList {  Status = false, file1 = file,  StatusSize = 0, basicProperties = await file.GetBasicPropertiesAsync() });
                                        deleteFileDialog.Content = "Дождитесь закрытия этого окна." + "\n" + "Идет процесс добавления файлов для обработки" + "\n" + "Файл " + file.DisplayName + " добавлен";
                                    }




                                }
                            }
                        }




                        // Print the name of the file.
                        // outputText.AppendLine("   " + file.Name);
                    }
                }
                deleteFileDialog.Content = "Добавление файлов завершено";
                System.Threading.Thread.Sleep(2000);
                deleteFileDialog.Hide();
                gridMenedgerAddFile.Visibility = Visibility.Collapsed;

                // var messageDialog = new MessageDialog(folder.Name);
                //await messageDialog.ShowAsync();

            }
        }
        private async void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add("*");

            StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
               // ContentDialog deleteFileDialog = new ContentDialog()
               // {
                   // Title = "Анализ выбранной папки",
                    //Content = "Дождитесь закрытия этого окна." + "\n" + "Идет процесс анализа файлов",

              //  };
              //  deleteFileDialog.ShowAsync();
                PathAddFile.Text = folder.Path;
                storage = folder;
                IReadOnlyList<StorageFile> fileList = await folder.GetFilesAsync();
                foreach(StorageFile storageFile in fileList)
                {
                    classСписокLists1.Add(new ClassСписокList { Status = false, file1 = storageFile, StatusSize = 0, basicProperties = await storageFile.GetBasicPropertiesAsync() });
                }

             //   deleteFileDialog.Hide();
                listaddF.ItemsSource = classСписокLists1;
             
                // Application now has read/write access to all contents in the picked folder
                // (including other sub-folder contents)
                /*  Windows.Storage.AccessCache.StorageApplicationPermissions.
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

      */
                // var messageDialog = new MessageDialog(folder.Name);
                //await messageDialog.ShowAsync();

            }
            else
            {

            }

        }
    }
}
