using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace DataYRAN
{
   public partial class BlankPageObrData
    {
        private async void AppBarToggleButton_Click_6(object sender, RoutedEventArgs e)
        {
            if (DataGrid.Visibility == Visibility.Visible && ViewModel.ClassSobsT.Count != 0 || GridGistogram.Visibility == Visibility.Visible)
            {
                DataGrid.Visibility = Visibility.Collapsed;
                GridGistogram.Visibility = Visibility.Collapsed;
                GridStatictik.Visibility = Visibility.Visible;
                List<ClassSob> classSobs = ViewModel.ClassSobsT.ToList<ClassSob>();
                string stat = "Статистика общая" + "\n";
                stat += "Средняя нулевая линия" + "\n";
                foreach (string s in await colPSB(ViewModel.ClassSobsT))
                {
                    stat += "Кластер "+s + "\n";
                    double SrNull1 = 0;
                    double SrNull2 = 0;
                    double SrNull3 = 0;
                    double SrNull4 = 0;
                    double SrNull5 = 0;
                    double SrNull6 = 0;
                    double SrNull7 = 0;
                    double SrNull8 = 0;
                    double SrNull9 = 0;
                    double SrNull10 = 0;
                    double SrNull11 = 0;
                    double SrNull12 = 0;
                    int count = 0;
                    foreach (var c in classSobs)
                    {
                        if (c.nameklaster == s)
                        {


                            SrNull1 += c.Nnull0;
                            SrNull2 += c.Nnull1;
                            SrNull3 += c.Nnull2;
                            SrNull4 += c.Nnull3;
                            SrNull5 += c.Nnull4;
                            SrNull6 += c.Nnull5;
                            SrNull7 += c.Nnull6;
                            SrNull8 += c.Nnull7;
                            SrNull9 += c.Nnull8;
                            SrNull10 += c.Nnull9;
                            SrNull11 += c.Nnull10;
                            SrNull12 += c.Nnull11;
                            count++;



                        }
                    }
                    stat += "Кн1" + "\t" + "Кн2" + "\t" + "Кн3" + "\t" + "Кн4" + "\t" + "Кн5" + "\t" + "Кн6" + "\t" + "Кн7" + "\t" + "Кн8" + "\t" + "Кн9" + "\t" + "Кн10" + "\t" + "Кн11" + "\t" + "Кн12" + "\n";
                    stat += (SrNull1 / count).ToString("0.0") + "\t" + (SrNull2 / count).ToString("0.0") + "\t" + (SrNull3 / count).ToString("0.0") + "\t" +
                        (SrNull4 / count).ToString("0.0") + "\t" + (SrNull5 / count).ToString("0.0") + "\t" + (SrNull6 / count).ToString("0.0") + "\t"
                        + (SrNull7 / count).ToString("0.0") + "\t" + (SrNull8 / count).ToString("0.0") + "\t" + (SrNull9 / count).ToString("0.0") + "\t" + (SrNull10 / count).ToString("0.0") + "\t" + (SrNull11 / count).ToString("0.0") + "\t" + (SrNull12 / count).ToString("0.0") + "\n";




                }







          
               
         stat += "Средняя сигма" + "\n";
                 foreach (string s in await colPSB(ViewModel.ClassSobsT))
                {
                    stat += "Кластер " + s + "\n";
                    double Srsig1 = 0;
                    double Srsig2 = 0;
                    double Srsig3 = 0;
                    double Srsig4 = 0;
                    double Srsig5 = 0;
                    double Srsig6 = 0;
                    double Srsig7 = 0;
                    double Srsig8 = 0;
                    double Srsig9 = 0;
                    double Srsig10 = 0;
                    double Srsig11 = 0;
                    double Srsig12 = 0;
                    int count = 0;
                    foreach (var c in classSobs)
                    {
                        if (c.nameklaster == s)
                        {


                            Srsig1 += c.sig0;
                            Srsig2 += c.sig1;
                            Srsig3 += c.sig2;
                            Srsig4 += c.sig3;
                            Srsig5 += c.sig4;
                            Srsig6 += c.sig5;
                            Srsig7 += c.sig6;
                            Srsig8 += c.sig7;
                            Srsig9 += c.sig8;
                            Srsig10 += c.sig9;
                            Srsig11 += c.sig10;
                            Srsig12 += c.sig11;
                            count++;



                        }
                    }
                    stat += "Кн1" + "\t" + "Кн2" + "\t" + "Кн3" + "\t" + "Кн4" + "\t" + "Кн5" + "\t" + "Кн6" + "\t" + "Кн7" + "\t" + "Кн8" + "\t" + "Кн9" + "\t" + "Кн10" + "\t" + "Кн11" + "\t" + "Кн12" + "\n";
                    stat += (Srsig1 / classSobs.Count).ToString("0.0000") + "\t" + (Srsig2 / classSobs.Count).ToString("0.0000") + "\t" + (Srsig3 / classSobs.Count).ToString("0.0000") + "\t" +
                        (Srsig4 / classSobs.Count).ToString("0.0000") + "\t" + (Srsig5 / classSobs.Count).ToString("0.0000") + "\t" + (Srsig6 / classSobs.Count).ToString("0.0000") + "\t"
                        + (Srsig7 / classSobs.Count).ToString("0.0000") + "\t" + (Srsig8 / classSobs.Count).ToString("0.0000") + "\t" + (Srsig9 / classSobs.Count).ToString("0.0000") + "\t" + (Srsig10 / classSobs.Count).ToString("0.0000") + "\t" + (Srsig11 / classSobs.Count).ToString("0.0000") + "\t" + (Srsig12 / classSobs.Count).ToString("0.0000") + "\n";



                }



                Editor.Document.SetText(Windows.UI.Text.TextSetOptions.ApplyRtfDocumentDefaults, stat);
            }
            else
            {
                DataGrid.Visibility = Visibility.Visible;
                GridStatictik.Visibility = Visibility.Collapsed;
            }

        }

        public async Task<List<string>> colPSB(ObservableCollection<ClassSob> ClassSobs)
        {
            List<string> vs = new List<string>();
            foreach(ClassSob classSob in ClassSobs)
            {
                int i = vs.IndexOf(classSob.nameklaster);
              
                if (i==(-1))
                {
                    vs.Add(classSob.nameklaster);
                }
            }

            return vs;

        }
        private async void AppBarButtonSaveStat_Click(object sender, RoutedEventArgs e)
        {

            Windows.Storage.Pickers.FileSavePicker savePicker = new Windows.Storage.Pickers.FileSavePicker();
            savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;

            // Dropdown of file types the user can save the file as
            savePicker.FileTypeChoices.Add("Rich Text", new List<string>() { ".rtf" });

            // Default file name if the user does not type one in or select a file to replace
            savePicker.SuggestedFileName = "New Document";

            Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();
            if (file != null)
            {
                // Prevent updates to the remote version of the file until we
                // finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(file);
                // write to file
                Windows.Storage.Streams.IRandomAccessStream randAccStream =
                    await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);

                Editor.Document.SaveToStream(Windows.UI.Text.TextGetOptions.FormatRtf, randAccStream);

                // Let Windows know that we're finished changing the file so the
                // other app can update the remote version of the file.
                Windows.Storage.Provider.FileUpdateStatus status = await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);
                if (status != Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    Windows.UI.Popups.MessageDialog errorBox =
                        new Windows.UI.Popups.MessageDialog("File " + file.Name + " couldn't be saved.");
                    await errorBox.ShowAsync();
                }
            }

            var mess = new MessageDialog("Сохранение завершено");
            await mess.ShowAsync();

        }
    }
}
