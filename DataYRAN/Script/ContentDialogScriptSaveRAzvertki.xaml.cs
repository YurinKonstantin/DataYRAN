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

namespace DataYRAN.Script
{
    public sealed partial class ContentDialogScriptSaveRAzvertki : ContentDialog
    {
        public ContentDialogScriptSaveRAzvertki()
        {
            this.InitializeComponent();
           
            this.Closing += SignInContentDialog_Closing;
        }
        public string Script = String.Empty;
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Script = TextScript.Text;




            this.Hide();
            
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
        void SignInContentDialog_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {
            // If sign in was successful, save or clear the user name based on the user choice.
         

            // If the user entered a name and checked or cleared the 'save user name' checkbox, then clicked the back arrow,
            // confirm if it was their intention to save or clear the user name without signing in.
           
        }

    }
}
