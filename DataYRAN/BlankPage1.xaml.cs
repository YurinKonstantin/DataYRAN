using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();
          
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
           await  addP();
        }
        public async Task<List<ClassPList>> addP()
        {
            List<ClassPList> classList = new List<ClassPList>();
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            try
            {
                StorageFile storageFileP = await storageFolder.GetFileAsync("storageFileP");
                if (storageFileP != null)
                {
                    string text =await FileIO.ReadTextAsync(storageFileP);
                    string[] mText = text.Split("\n");
                    for(int i=0; i<mText.Length; i++)
                    {
                        string[] str = mText[i].Split("\t");
                        StorageFolder storageFolder1 =await StorageFolder.GetFolderFromPathAsync(str[1]);
                        classList.Add(new ClassPList() { storageFolder= storageFolder1 });
                    }
                    ListP.ItemsSource = classList;


                }
                else
                {
                  
                }

            }
            catch(Exception)
            {
                
            }
           
            return classList;
        }
       public List<ClassPList> classСписокPs { get; set; }
       
        private async void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GridView gridView = (GridView)sender;
            GridViewItem gridViewItem = (GridViewItem)gridView.SelectedItem;
            var tag = gridViewItem.Tag;
            if(tag.ToString()=="Bin")
            {
                this.Frame.Navigate(typeof(BlankPageObrData));

             
            }
            if(tag.ToString() == "BD")
            {
                this.Frame.Navigate(typeof(BlankPageBDMan));
            }
            
            
        }
    }

}
