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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace DataYRAN
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class BlankPageTemp : Page
    {
        public BlankPageTemp()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {


            if (e.Parameter is ClassRazvertka)
            {
                ClassTabs classTabs = new ClassTabs() { name = "tab", tag = "tab" };

                ClassRazvertka classRazvertka = e.Parameter as ClassRazvertka;
                ClassRazvertkaR = classRazvertka;
                classTabs.name = classRazvertka.nameFile1;
                classTabs.tag = classRazvertka.nameFile1;
                classTabs.newTabl();
                textZag.Text = classRazvertka.nameFile1;
                // _ClassTable.newTabl(classRazvertka.nameFile1);
                for (int i = 0; i < 12; i++)
                {
                    classTabs.newColums();
                    // newColon(_ClassTable.dataGrid, _ClassTable.newColums(i.ToString()));
                }
                // string s = "i" + "\t" + "Ch1" + "\t" + "Ch2" + "\t" + "Ch3" + "\t" + "Ch4" + "\t" + "Ch5" + "\t" + "Ch6" + "\t" + "Ch7" + "\t" + "Ch8" + "\t" + "Ch9" + "\t" + "Ch10" + "\t" + "Ch11" + "\t" + "Ch12" + "\r\n";
                for (int i = 0; i < 1024; i++)
                {
                    int[] mas = new int[12];
                    // s = s + (i + 1).ToString() + "\t";
                    for (int j = 0; j < 12; j++)
                    {
                        mas[j] = classRazvertka.data[j, i];
                        //  s = s + classRazvertka.data[j, i] + "\t";

                    }
                    classTabs.newRows(mas);
                    if (i < 1023)
                    {
                        //  s = s + "\r\n";
                    }
                    else
                    {

                    }
                }
                _ClassViewModalTab._DataColecViewDoc.Add(classTabs);

                // textT.Text = s;
            }
            else
            {
                ClassTabs classTabs = new ClassTabs() { name = "tab", tag = "tab" };

                classTabs.newTabl();
                //  classTabs.page = new BlankPage2() { Name = "fgf" };
                _ClassViewModalTab._DataColecViewDoc.Add(classTabs);
            }

            base.OnNavigatedTo(e);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPageObrData));
        }
    }
}
