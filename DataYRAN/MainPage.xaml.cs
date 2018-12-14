using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace DataYRAN
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var t = ApplicationView.GetForCurrentView().TitleBar;
            t.BackgroundColor = Colors.DodgerBlue;
            t.ForegroundColor = Colors.White;
            t.ButtonBackgroundColor = Colors.DodgerBlue;
            t.ButtonForegroundColor = Colors.White;
        }
        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            // you can also add items in code behind
            NavView.MenuItems.Add(new NavigationViewItemSeparator());
            NavView.MenuItems.Add(new NavigationViewItem()
            { Content = "My content", Icon = new SymbolIcon(Symbol.Folder), Tag = "content" });

            // set the initial SelectedItem 
            foreach (NavigationViewItemBase item in NavView.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == "home")
                {
                    NavView.SelectedItem = item;
                    ContentFrame.Navigate(typeof(BlankPage1));


                    break;
                }
            }

            ContentFrame.Navigated += On_Navigated;

            // add keyboard accelerators for backwards navigation
            KeyboardAccelerator GoBack = new KeyboardAccelerator();
            GoBack.Key = VirtualKey.GoBack;
            GoBack.Invoked += BackInvoked;
            KeyboardAccelerator AltLeft = new KeyboardAccelerator();
            AltLeft.Key = VirtualKey.Left;
            AltLeft.Invoked += BackInvoked;
            this.KeyboardAccelerators.Add(GoBack);
            this.KeyboardAccelerators.Add(AltLeft);
            // ALT routes here
            AltLeft.Modifiers = VirtualKeyModifiers.Menu;
            NavView.IsPaneOpen = false;


        }
       static private StorageFile[] f = null;
       static public StorageFile[] FileEvent
        {
            get { return f; }
            set { f = value; }
        }
       static private ProtocolActivatedEventArgs _protocolEventArgs = null;
      static  public ProtocolActivatedEventArgs ProtocolEvent
        {
            get { return _protocolEventArgs; }
            set { _protocolEventArgs = value; }
        }

        public async void NavigateToFilePage()
        {
         
        }
        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                // ContentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                // find NavigationViewItem with Content that equals InvokedItem
                var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
                NavView_Navigate(item as NavigationViewItem);
            }
        }
        private void NavView_Navigate(NavigationViewItem item)
        {
            switch (item.Tag)
            {
                case "home":
                    ContentFrame.Navigate(typeof(BlankPageObrData));
                    break;

                case "Zavisimost":
                     ContentFrame.Navigate(typeof(BlankPageZavisimost));
                    break;

                case "games":
                    // ContentFrame.Navigate(typeof(GamesPage));
                    break;

                case "music":
                    //  ContentFrame.Navigate(typeof(MusicPage));
                    break;

                case "content":
                    //  ContentFrame.Navigate(typeof(MyContentPage));
                    break;
            }
        }
        private void NavView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            On_BackRequested();

        }

        private void BackInvoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
        {
            On_BackRequested();
            args.Handled = true;

        }

        private bool On_BackRequested()
        {
            bool navigated = false;

            // don't go back if the nav pane is overlayed
            if (NavView.IsPaneOpen && (NavView.DisplayMode == NavigationViewDisplayMode.Compact || NavView.DisplayMode == NavigationViewDisplayMode.Minimal))
            {
                return false;
            }
            else
            {
                if (ContentFrame.CanGoBack)
                {
                    ContentFrame.GoBack();
                    navigated = true;
                }
            }
            return navigated;
        }
        private void On_Navigated(object sender, NavigationEventArgs e)
        {
            /*  NavView.IsBackEnabled = ContentFrame.CanGoBack;

              if (ContentFrame.SourcePageType == typeof(SettingsPage))
              {
                  NavView.SelectedItem = NavView.SettingsItem as NavigationViewItem;
              }
              else
              {
                  Dictionary<Type, string> lookup = new Dictionary<Type, string>()
          {
              {typeof(HomePage), "home"},
              {typeof(AppsPage), "apps"},
              {typeof(GamesPage), "games"},
              {typeof(MusicPage), "music"},
              {typeof(MyContentPage), "content"}
          };

                  String stringTag = lookup[ContentFrame.SourcePageType];

                  // set the new SelectedItem  
                  foreach (NavigationViewItemBase item in NavView.MenuItems)
                  {
                      if (item is NavigationViewItem && item.Tag.Equals(stringTag))
                      {
                          item.IsSelected = true;
                          break;
                      }
                  }
                  */
        }
    }
}
