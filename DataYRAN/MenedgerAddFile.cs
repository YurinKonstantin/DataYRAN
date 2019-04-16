using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.UI.Xaml;

namespace DataYRAN
{
    public partial class BlankPageObrData
    {
        private async void Button_Click_6(object sender, RoutedEventArgs e)
        {
            gridMenedgerAddFile.Visibility = Visibility.Collapsed;
            mySplitView.IsPaneOpen = true;
            if (storage != null)
            {
                String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;";
                // Application now has read/write access to all contents in the picked folder
                // (including other sub-folder contents)








                IReadOnlyList<StorageFile> fileList = await storage.GetFilesAsync();

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
                        if (!Convert.ToBoolean(ChTime.IsChecked))
                        {
                            if (Convert.ToBoolean(ChklAll.IsChecked))
                            {
                               
                                // Application now has read/write access to the picked file
                                ViewModel.AddFile(new ClassСписокList {  Status = false, file1 = file, StatusSize = 0, basicProperties = await file.GetBasicPropertiesAsync() });

                            }
                            else
                            {
                                string[] s = FileName.Split('_');
                                string sNew = String.Empty;
                                if(s.Length==2)
                                {
                                    sNew = s[0].Split("№")[1];
                                }
                                else
                                {
                                    sNew = s[0];
                                }
                                if (sNew == "1" && Chkl1.IsChecked == true)
                                {
                                    
                                    // Application now has read/write access to the picked file
                                    ViewModel.AddFile(new ClassСписокList { Status = false, file1 = file,  StatusSize = 0, basicProperties = await file.GetBasicPropertiesAsync() });

                                  
                                }
                                if (sNew == "2" && Chkl2.IsChecked == true)
                                {
                                   
                                    // Application now has read/write access to the picked file
                                    ViewModel.AddFile(new ClassСписокList {  Status = false, file1 = file, StatusSize = 0, basicProperties= await file.GetBasicPropertiesAsync() });

                                }
                                if (sNew == "3" && Chkl3.IsChecked == true)
                                {
                                 
                                    // Application now has read/write access to the picked file
                                    ViewModel.AddFile(new ClassСписокList {   Status = false, file1 = file, StatusSize = 0, basicProperties = await file.GetBasicPropertiesAsync() });

                                }
                                if (sNew == "4" && Chkl4.IsChecked == true)
                                {
                                   
                                    // Application now has read/write access to the picked file
                                    ViewModel.AddFile(new ClassСписокList {  Status = false, file1 = file, StatusSize = 0, basicProperties = await file.GetBasicPropertiesAsync() });

                                }
                                if (sNew == "5" && Chkl5.IsChecked == true)
                                {
                                  
                                    // Application now has read/write access to the picked file
                                    ViewModel.AddFile(new ClassСписокList {Status = false, file1 = file,  StatusSize = 0, basicProperties = await file.GetBasicPropertiesAsync() });

                                }
                                if (sNew == "6" && Chkl6.IsChecked == true)
                                {
                                   
                                    // Application now has read/write access to the picked file
                                    ViewModel.AddFile(new ClassСписокList { Status = false, file1 = file,  StatusSize = 0, basicProperties = await file.GetBasicPropertiesAsync() });

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

                                }
                                else
                                {
                                   
                                    string sNew = String.Empty;
                                    if (s.Length == 2)
                                    {
                                        sNew = s[0].Split("№")[1];
                                    }
                                    else
                                    {
                                        sNew = s[0];
                                    }
                                    if (sNew == "1" && Chkl1.IsChecked == true)
                                    {
                                      
                                        // Application now has read/write access to the picked file
                                        ViewModel.AddFile(new ClassСписокList {  Status = false, file1 = file, StatusSize = 0, basicProperties = await file.GetBasicPropertiesAsync() });

                                    }
                                    if (sNew == "2" && Chkl2.IsChecked == true)
                                    {
                                       
                                        // Application now has read/write access to the picked file
                                        ViewModel.AddFile(new ClassСписокList {  Status = false, file1 = file, StatusSize = 0, basicProperties = await file.GetBasicPropertiesAsync() });

                                    }
                                    if (sNew == "3" && Chkl3.IsChecked == true)
                                    {
                                        
                                        // Application now has read/write access to the picked file
                                        ViewModel.AddFile(new ClassСписокList {  Status = false, file1 = file, StatusSize = 0, basicProperties = await file.GetBasicPropertiesAsync() });

                                    }
                                    if (sNew == "4" && Chkl4.IsChecked == true)
                                    {
                                       
                                        // Application now has read/write access to the picked file
                                        ViewModel.AddFile(new ClassСписокList {  Status = false, file1 = file, StatusSize = 0, basicProperties = await file.GetBasicPropertiesAsync() });

                                       
                                    }
                                    if (sNew == "5" && Chkl5.IsChecked == true)
                                    {
                                        
                                        // Application now has read/write access to the picked file
                                        ViewModel.AddFile(new ClassСписокList {  Status = false, file1 = file, StatusSize = 0, basicProperties = await file.GetBasicPropertiesAsync() });

                                    }
                                    if (sNew == "6" && Chkl6.IsChecked == true)
                                    {
                                      
                                        // Application now has read/write access to the picked file
                                        ViewModel.AddFile(new ClassСписокList {  Status = false, file1 = file,  StatusSize = 0, basicProperties = await file.GetBasicPropertiesAsync() });

                                    }




                                }
                            }
                        }




                        // Print the name of the file.
                        // outputText.AppendLine("   " + file.Name);
                    }
                }

                gridMenedgerAddFile.Visibility = Visibility.Collapsed;

                // var messageDialog = new MessageDialog(folder.Name);
                //await messageDialog.ShowAsync();

            }
        }
    }
}
