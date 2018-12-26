using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

// Документацию по шаблону элемента "Диалоговое окно содержимого" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace DataYRAN
{
    public sealed partial class ContentDialog1 : ContentDialog
    {
        public ContentDialog1()
        {
            this.InitializeComponent();
            StepText.Text = StepX.ToString();
        }
        public int StepX=100;
        public int StepY = 100;
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
           
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            
        }

        private void StepText_TextChanged(object sender, TextChangedEventArgs e)
        {
            StepX = Convert.ToInt32(StepText.Text);
        }

        private void StepTextY_TextChanged(object sender, TextChangedEventArgs e)
        {
            StepY = Convert.ToInt32(StepTextY.Text);
        }
    }
}
