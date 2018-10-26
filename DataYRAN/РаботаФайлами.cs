using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _DataColec.Clear();
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
    }
}
