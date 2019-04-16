using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class BlankPageShowMap : Page
    {
        public BlankPageShowMap()
        {
            this.InitializeComponent();
            this.ViewModelMaps = new ViewShovMaps();
        }
        public ViewShovMaps ViewModelMaps { get; set; }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is ObservableCollection<ClassSob>)
            {
                ViewModelMaps.ClassSobs = (ObservableCollection<ClassSob>)e.Parameter;
            }
            else
          {
               
            }
            base.OnNavigatedTo(e);
        }
     
       

        private async void ListSob_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClassSob classSob = (ClassSob)ListSob.SelectedItem;
            List<ClassSob> classSobsL = new List<ClassSob>();
            classSobsL.Add(classSob);
           await Show1.ShowDetecAsync(classSobsL);
          await  Show2.ShowDetecТAsync(classSobsL);


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPageObrData));
        }
    }
}
