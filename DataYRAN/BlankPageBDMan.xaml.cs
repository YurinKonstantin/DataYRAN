using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class BlankPageBDMan : Page
    {
        public BlankPageBDMan()
        {
            this.InitializeComponent();
            vs = new List<string>();
        }
        List<string> vs;
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView gridView = (ListView)sender;
           ListViewItem gridViewItem = (ListViewItem)gridView.SelectedItem;
            var tag = gridViewItem.Tag;
            if (tag.ToString() == "MyS")
            {
                vs.Add("select top 3000 * from [Событие] order by Код desc");
                vs.Add("select * from [Нейтроны] order by Код desc");
                this.Frame.Navigate(typeof(BlankPageBDMan2), new ClassBDMan2() {flagP=false, ip="192.168.1.155", listsql=vs });


            }
            if (tag.ToString() == "MySlocalhost")
            {
                this.Frame.Navigate(typeof(BlankPageBDMan2));
                vs.Add("select top 100 * from [Событие] where Плата = 'У1' order by Код desc");
                vs.Add("select * from [Нейтроны] order by Код desc");
                IPHostEntry iPHost = Dns.GetHostEntry("localhost");
                IPAddress iPAddress = iPHost.AddressList[1];
                this.Frame.Navigate(typeof(BlankPageBDMan2), new ClassBDMan2() { flagP = false, ip = iPAddress.ToString(), listsql = vs });
            }

        }
    }
}
