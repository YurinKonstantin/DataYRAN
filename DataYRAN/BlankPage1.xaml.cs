using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
