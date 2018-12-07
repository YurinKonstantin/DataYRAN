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
        public void ShowDeteClea()
        {
            k1d1.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k1d2.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k1d3.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k1d4.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k1d5.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k1d6.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k1d7.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k1d8.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k1d9.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k1d10.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k1d11.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k1d12.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);

            k1d1.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k1d2.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k1d3.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k1d4.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k1d5.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k1d6.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k1d7.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k1d8.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k1d9.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k1d10.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k1d11.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k1d12.Fill = new SolidColorBrush(Windows.UI.Colors.White);


            k2d1.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k2d2.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k2d3.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k2d4.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k2d5.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k2d6.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k2d7.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k2d8.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k2d9.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k2d10.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k2d11.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k2d12.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);

            k2d1.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k2d2.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k2d3.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k2d4.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k2d5.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k2d6.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k2d7.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k2d8.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k2d9.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k2d10.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k2d11.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k2d12.Fill = new SolidColorBrush(Windows.UI.Colors.White);

            k3d1.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k3d2.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k3d3.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k3d4.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k3d5.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k3d6.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k3d7.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k3d8.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k3d9.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k3d10.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k3d11.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k3d12.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);

            k3d1.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k3d2.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k3d3.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k3d4.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k3d5.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k3d6.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k3d7.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k3d8.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k3d9.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k3d10.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k3d11.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k3d12.Fill = new SolidColorBrush(Windows.UI.Colors.White);

            k4d1.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k4d2.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k4d3.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k4d4.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k4d5.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k4d6.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k4d7.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k4d8.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k4d9.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k4d10.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k4d11.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k4d12.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);

            k4d1.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k4d2.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k4d3.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k4d4.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k4d5.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k4d6.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k4d7.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k4d8.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k4d9.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k4d10.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k4d11.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k4d12.Fill = new SolidColorBrush(Windows.UI.Colors.White);

            k5d1.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k5d2.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k5d3.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k5d4.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k5d5.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k5d6.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k5d7.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k5d8.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k5d9.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k5d10.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k5d11.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k5d12.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);

            k5d1.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k5d2.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k5d3.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k5d4.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k5d5.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k5d6.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k5d7.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k5d8.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k5d9.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k5d10.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k5d11.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k5d12.Fill = new SolidColorBrush(Windows.UI.Colors.White);

            k6d1.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k6d2.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k6d3.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k6d4.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k6d5.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k6d6.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k6d7.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k6d8.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k6d9.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k6d10.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k6d11.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);
            k6d12.Stroke = new SolidColorBrush(Windows.UI.Colors.Gray);

            k6d1.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k6d2.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k6d3.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k6d4.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k6d5.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k6d6.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k6d7.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k6d8.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k6d9.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k6d10.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k6d11.Fill = new SolidColorBrush(Windows.UI.Colors.White);
            k6d12.Fill = new SolidColorBrush(Windows.UI.Colors.White);
        }
        public void ShowDetec(ClassSob classSob)
        {
            ShowDeteClea();
            if (classSob.nameklaster == "1")
            {
                k1d1.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k1d2.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k1d3.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k1d4.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k1d5.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k1d6.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k1d7.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k1d8.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k1d9.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k1d10.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k1d11.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k1d12.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(255, 202, 24, 37));

                short max = classSob.AmpSum().Max();
                short min = classSob.AmpSum().Min();
                double step = max / 5;

                Text3.Text = step.ToString();
                Text2.Text = (2 * step).ToString();
                Text1.Text = (3 * step).ToString();
                Text0.Text = (4 * step).ToString();
                TextMax.Text = max.ToString();

                if (classSob.Amp0 == 0)
                {
                    k1d1.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp0 > 0 && classSob.Amp0 < step)
                {
                    k1d1.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp0 >= step && classSob.Amp0 < 2 * step)
                {
                    k1d1.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp0 >= 2 * step && classSob.Amp0 < 3 * step)
                {
                    k1d1.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp0 >= 3 * step && classSob.Amp0 < 4 * step)
                {
                    k1d1.Fill = new SolidColorBrush(Windows.UI.Colors.DarkRed);
                }
                if (classSob.Amp0 >= 4 * step)
                {
                    k1d1.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }


                if (classSob.Amp1 == 0)
                {
                    k1d2.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp1 > 0 && classSob.Amp1 < step)
                {
                    k1d2.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp1 >= step && classSob.Amp1 < 2 * step)
                {
                    k1d2.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp1 >= 2 * step && classSob.Amp1 < 3 * step)
                {
                    k1d2.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp1 >= 3 * step && classSob.Amp1 < 4 * step)
                {
                    k1d2.Fill = new SolidColorBrush(Windows.UI.Colors.OrangeRed);
                }
                if (classSob.Amp1 >= 4 * step)
                {
                    k1d2.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }


                if (classSob.Amp2 == 0)
                {
                    k1d3.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp2 > 0 && classSob.Amp2 < step)
                {
                    k1d3.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp2 >= step && classSob.Amp2 < 2 * step)
                {
                    k1d3.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp2 >= 2 * step && classSob.Amp2 < 3 * step)
                {
                    k1d3.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp2 >= 3 * step && classSob.Amp2 < 4 * step)
                {
                    k1d3.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp2 >= 4 * step)
                {
                    k1d3.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp3 == 0)
                {
                    k1d4.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp3 > 0 && classSob.Amp3 < step)
                {
                    k1d4.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp3 >= step && classSob.Amp3 < 2 * step)
                {
                    k1d4.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp3 >= 2 * step && classSob.Amp3 < 3 * step)
                {
                    k1d4.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp3 >= 3 * step && classSob.Amp3 < 4 * step)
                {
                    k1d4.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp3 >= 4 * step)
                {
                    k1d4.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp4 == 0)
                {
                    k1d5.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp4 > 0 && classSob.Amp4 < step)
                {
                    k1d5.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp4 >= step && classSob.Amp4 < 2 * step)
                {
                    k1d5.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp4 >= 2 * step && classSob.Amp4 < 3 * step)
                {
                    k1d5.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp4 >= 3 * step && classSob.Amp4 < 4 * step)
                {
                    k1d5.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp4 >= 4 * step)
                {
                    k1d5.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp5 == 0)
                {
                    k1d6.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp5 > 0 && classSob.Amp5 < step)
                {
                    k1d6.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp5 >= step && classSob.Amp5 < 2 * step)
                {
                    k1d6.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp5 >= 2 * step && classSob.Amp5 < 3 * step)
                {
                    k1d6.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp5 >= 3 * step && classSob.Amp5 < 4 * step)
                {
                    k1d6.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp5 >= 4 * step)
                {
                    k1d6.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp6 == 0)
                {
                    k1d7.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp6 > 0 && classSob.Amp6 < step)
                {
                    k1d7.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp6 >= step && classSob.Amp6 < 2 * step)
                {
                    k1d7.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp6 >= 2 * step && classSob.Amp6 < 3 * step)
                {
                    k1d7.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp6 >= 3 * step && classSob.Amp6 < 4 * step)
                {
                    k1d7.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp6 >= 4 * step)
                {
                    k1d7.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp7 == 0)
                {
                    k1d8.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp7 > 0 && classSob.Amp7 < step)
                {
                    k1d8.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp7 >= step && classSob.Amp7 < 2 * step)
                {
                    k1d8.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp7 >= 2 * step && classSob.Amp7 < 3 * step)
                {
                    k1d8.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp7 >= 3 * step && classSob.Amp7 < 4 * step)
                {
                    k1d8.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp7 >= 4 * step)
                {
                    k1d8.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp8 == 0)
                {
                    k1d9.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp8 > 0 && classSob.Amp8 < step)
                {
                    k1d9.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp8 >= step && classSob.Amp8 < 2 * step)
                {
                    k1d9.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp8 >= 2 * step && classSob.Amp8 < 3 * step)
                {
                    k1d9.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp8 >= 3 * step && classSob.Amp8 < 4 * step)
                {
                    k1d9.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp8 >= 4 * step)
                {
                    k1d9.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp9 == 0)
                {
                    k1d10.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp9 > 0 && classSob.Amp9 < step)
                {
                    k1d10.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp9 >= step && classSob.Amp9 < 2 * step)
                {
                    k1d10.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp9 >= 2 * step && classSob.Amp9 < 3 * step)
                {
                    k1d10.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp9 >= 3 * step && classSob.Amp9 < 4 * step)
                {
                    k1d10.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp9 >= 4 * step)
                {
                    k1d10.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp10 == 0)
                {
                    k1d11.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp10 > 0 && classSob.Amp10 < step)
                {
                    k1d11.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp10 >= step && classSob.Amp10 < 2 * step)
                {
                    k1d11.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp10 >= 2 * step && classSob.Amp10 < 3 * step)
                {
                    k1d11.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp10 >= 3 * step && classSob.Amp10 < 4 * step)
                {
                    k1d11.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp10 >= 4 * step)
                {
                    k1d11.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp11 == 0)
                {
                    k1d12.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp11 > 0 && classSob.Amp11 < step)
                {
                    k1d12.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp11 >= step && classSob.Amp11 < 2 * step)
                {
                    k1d12.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp11 >= 2 * step && classSob.Amp11 < 3 * step)
                {
                    k1d12.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp11 >= 3 * step && classSob.Amp11 < 4 * step)
                {
                    k1d12.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp11 >= 4 * step)
                {
                    k1d12.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }
            }
            if (classSob.nameklaster == "2")
            {
                k2d1.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k2d2.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k2d3.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k2d4.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k2d5.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k2d6.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k2d7.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k2d8.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k2d9.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k2d10.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k2d11.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k2d12.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(255, 202, 24, 37));

                short max = classSob.AmpSum().Max();
                short min = classSob.AmpSum().Min();
                int step = (max - min) / 4;

                Text1.Text = step.ToString();
                Text2.Text = (2 * step).ToString();
                Text3.Text = (3 * step).ToString();
                Text4.Text = (4 * step).ToString();

                if (classSob.Amp0 == 0)
                {
                    k2d1.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp0 > 0 && classSob.Amp0 < step)
                {
                    k2d1.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp0 >= step && classSob.Amp0 < 2 * step)
                {
                    k2d1.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp0 >= 2 * step && classSob.Amp0 < 3 * step)
                {
                    k2d1.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp0 >= 3 * step && classSob.Amp0 < 4 * step)
                {
                    k2d1.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp0 >= 4 * step)
                {
                    k2d1.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }


                if (classSob.Amp1 == 0)
                {
                    k2d2.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp1 > 0 && classSob.Amp1 < step)
                {
                    k2d2.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp1 >= step && classSob.Amp1 < 2 * step)
                {
                    k2d2.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp1 >= 2 * step && classSob.Amp1 < 3 * step)
                {
                    k2d2.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp1 >= 3 * step && classSob.Amp1 < 4 * step)
                {
                    k2d2.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp1 >= 4 * step)
                {
                    k2d2.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }


                if (classSob.Amp2 == 0)
                {
                    k2d3.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp2 > 0 && classSob.Amp2 < step)
                {
                    k2d3.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp2 >= step && classSob.Amp2 < 2 * step)
                {
                    k2d3.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp2 >= 2 * step && classSob.Amp2 < 3 * step)
                {
                    k2d3.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp2 >= 3 * step && classSob.Amp2 < 4 * step)
                {
                    k2d3.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp2 >= 4 * step)
                {
                    k2d3.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp3 == 0)
                {
                    k2d4.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp3 > 0 && classSob.Amp3 < step)
                {
                    k2d4.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp3 >= step && classSob.Amp3 < 2 * step)
                {
                    k2d4.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp3 >= 2 * step && classSob.Amp3 < 3 * step)
                {
                    k2d4.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp3 >= 3 * step && classSob.Amp3 < 4 * step)
                {
                    k2d4.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp3 >= 4 * step)
                {
                    k2d4.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp4 == 0)
                {
                    k2d5.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp4 > 0 && classSob.Amp4 < step)
                {
                    k2d5.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp4 >= step && classSob.Amp4 < 2 * step)
                {
                    k2d5.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp4 >= 2 * step && classSob.Amp4 < 3 * step)
                {
                    k2d5.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp4 >= 3 * step && classSob.Amp4 < 4 * step)
                {
                    k2d5.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp4 >= 4 * step)
                {
                    k2d5.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp5 == 0)
                {
                    k2d6.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp5 > 0 && classSob.Amp5 < step)
                {
                    k2d6.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp5 >= step && classSob.Amp5 < 2 * step)
                {
                    k2d6.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp5 >= 2 * step && classSob.Amp5 < 3 * step)
                {
                    k2d6.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp5 >= 3 * step && classSob.Amp5 < 4 * step)
                {
                    k2d6.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp5 >= 4 * step)
                {
                    k2d6.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp6 == 0)
                {
                    k2d7.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp6 > 0 && classSob.Amp6 < step)
                {
                    k2d7.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp6 >= step && classSob.Amp6 < 2 * step)
                {
                    k2d7.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp6 >= 2 * step && classSob.Amp6 < 3 * step)
                {
                    k2d7.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp6 >= 3 * step && classSob.Amp6 < 4 * step)
                {
                    k2d7.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp6 >= 4 * step)
                {
                    k2d7.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp7 == 0)
                {
                    k2d8.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp7 > 0 && classSob.Amp7 < step)
                {
                    k2d8.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp7 >= step && classSob.Amp7 < 2 * step)
                {
                    k2d8.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp7 >= 2 * step && classSob.Amp7 < 3 * step)
                {
                    k2d8.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp7 >= 3 * step && classSob.Amp7 < 4 * step)
                {
                    k2d8.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp7 >= 4 * step)
                {
                    k2d8.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp8 == 0)
                {
                    k2d9.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp8 > 0 && classSob.Amp8 < step)
                {
                    k2d9.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp8 >= step && classSob.Amp8 < 2 * step)
                {
                    k2d9.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp8 >= 2 * step && classSob.Amp8 < 3 * step)
                {
                    k2d9.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp8 >= 3 * step && classSob.Amp8 < 4 * step)
                {
                    k2d9.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp8 >= 4 * step)
                {
                    k2d9.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp9 == 0)
                {
                    k2d10.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp9 > 0 && classSob.Amp9 < step)
                {
                    k2d10.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp9 >= step && classSob.Amp9 < 2 * step)
                {
                    k2d10.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp9 >= 2 * step && classSob.Amp9 < 3 * step)
                {
                    k2d10.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp9 >= 3 * step && classSob.Amp9 < 4 * step)
                {
                    k2d10.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp9 >= 4 * step)
                {
                    k2d10.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp10 == 0)
                {
                    k2d11.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp10 > 0 && classSob.Amp10 < step)
                {
                    k2d11.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp10 >= step && classSob.Amp10 < 2 * step)
                {
                    k2d11.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp10 >= 2 * step && classSob.Amp10 < 3 * step)
                {
                    k2d11.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp10 >= 3 * step && classSob.Amp10 < 4 * step)
                {
                    k2d11.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp10 >= 4 * step)
                {
                    k2d11.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp11 == 0)
                {
                    k2d12.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp11 > 0 && classSob.Amp11 < step)
                {
                    k2d12.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp11 >= step && classSob.Amp11 < 2 * step)
                {
                    k2d12.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp11 >= 2 * step && classSob.Amp11 < 3 * step)
                {
                    k2d12.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp11 >= 3 * step && classSob.Amp11 < 4 * step)
                {
                    k2d12.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp11 >= 4 * step)
                {
                    k2d12.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

            }
            if (classSob.nameklaster == "3")
            {
                k3d1.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k3d2.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k3d3.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k3d4.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k3d5.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k3d6.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k3d7.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k3d8.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k3d9.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k3d10.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k3d11.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k3d12.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(255, 202, 24, 37));

                short max = classSob.AmpSum().Max();
                short min = classSob.AmpSum().Min();
                int step = (max - min) / 4;

                Text1.Text = step.ToString();
                Text2.Text = (2 * step).ToString();
                Text3.Text = (3 * step).ToString();
                Text4.Text = (4 * step).ToString();

                if (classSob.Amp0 == 0)
                {
                    k3d1.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp0 > 0 && classSob.Amp0 < step)
                {
                    k3d1.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp0 >= step && classSob.Amp0 < 2 * step)
                {
                    k3d1.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp0 >= 2 * step && classSob.Amp0 < 3 * step)
                {
                    k3d1.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp0 >= 3 * step && classSob.Amp0 < 4 * step)
                {
                    k3d1.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp0 >= 4 * step)
                {
                    k3d1.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }


                if (classSob.Amp1 == 0)
                {
                    k3d2.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp1 > 0 && classSob.Amp1 < step)
                {
                    k3d2.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp1 >= step && classSob.Amp1 < 2 * step)
                {
                    k3d2.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp1 >= 2 * step && classSob.Amp1 < 3 * step)
                {
                    k3d2.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp1 >= 3 * step && classSob.Amp1 < 4 * step)
                {
                    k3d2.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp1 >= 4 * step)
                {
                    k3d2.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }


                if (classSob.Amp2 == 0)
                {
                    k3d3.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp2 > 0 && classSob.Amp2 < step)
                {
                    k3d3.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp2 >= step && classSob.Amp2 < 2 * step)
                {
                    k3d3.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp2 >= 2 * step && classSob.Amp2 < 3 * step)
                {
                    k3d3.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp2 >= 3 * step && classSob.Amp2 < 4 * step)
                {
                    k3d3.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp2 >= 4 * step)
                {
                    k3d3.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp3 == 0)
                {
                    k3d4.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp3 > 0 && classSob.Amp3 < step)
                {
                    k3d4.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp3 >= step && classSob.Amp3 < 2 * step)
                {
                    k3d4.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp3 >= 2 * step && classSob.Amp3 < 3 * step)
                {
                    k3d4.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp3 >= 3 * step && classSob.Amp3 < 4 * step)
                {
                    k3d4.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp3 >= 4 * step)
                {
                    k3d4.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp4 == 0)
                {
                    k3d5.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp4 > 0 && classSob.Amp4 < step)
                {
                    k3d5.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp4 >= step && classSob.Amp4 < 2 * step)
                {
                    k3d5.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp4 >= 2 * step && classSob.Amp4 < 3 * step)
                {
                    k3d5.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp4 >= 3 * step && classSob.Amp4 < 4 * step)
                {
                    k3d5.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp4 >= 4 * step)
                {
                    k3d5.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp5 == 0)
                {
                    k3d6.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp5 > 0 && classSob.Amp5 < step)
                {
                    k3d6.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp5 >= step && classSob.Amp5 < 2 * step)
                {
                    k3d6.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp5 >= 2 * step && classSob.Amp5 < 3 * step)
                {
                    k3d6.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp5 >= 3 * step && classSob.Amp5 < 4 * step)
                {
                    k3d6.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp5 >= 4 * step)
                {
                    k3d6.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp6 == 0)
                {
                    k3d7.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp6 > 0 && classSob.Amp6 < step)
                {
                    k3d7.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp6 >= step && classSob.Amp6 < 2 * step)
                {
                    k3d7.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp6 >= 2 * step && classSob.Amp6 < 3 * step)
                {
                    k3d7.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp6 >= 3 * step && classSob.Amp6 < 4 * step)
                {
                    k3d7.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp6 >= 4 * step)
                {
                    k3d7.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp7 == 0)
                {
                    k3d8.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp7 > 0 && classSob.Amp7 < step)
                {
                    k3d8.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp7 >= step && classSob.Amp7 < 2 * step)
                {
                    k3d8.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp7 >= 2 * step && classSob.Amp7 < 3 * step)
                {
                    k3d8.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp7 >= 3 * step && classSob.Amp7 < 4 * step)
                {
                    k3d8.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp7 >= 4 * step)
                {
                    k3d8.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp8 == 0)
                {
                    k3d9.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp8 > 0 && classSob.Amp8 < step)
                {
                    k3d9.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp8 >= step && classSob.Amp8 < 2 * step)
                {
                    k3d9.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp8 >= 2 * step && classSob.Amp8 < 3 * step)
                {
                    k3d9.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp8 >= 3 * step && classSob.Amp8 < 4 * step)
                {
                    k3d9.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp8 >= 4 * step)
                {
                    k3d9.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp9 == 0)
                {
                    k3d10.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp9 > 0 && classSob.Amp9 < step)
                {
                    k3d10.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp9 >= step && classSob.Amp9 < 2 * step)
                {
                    k3d10.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp9 >= 2 * step && classSob.Amp9 < 3 * step)
                {
                    k3d10.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp9 >= 3 * step && classSob.Amp9 < 4 * step)
                {
                    k3d10.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp9 >= 4 * step)
                {
                    k3d10.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp10 == 0)
                {
                    k3d11.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp10 > 0 && classSob.Amp10 < step)
                {
                    k3d11.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp10 >= step && classSob.Amp10 < 2 * step)
                {
                    k3d11.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp10 >= 2 * step && classSob.Amp10 < 3 * step)
                {
                    k3d11.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp10 >= 3 * step && classSob.Amp10 < 4 * step)
                {
                    k3d11.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp10 >= 4 * step)
                {
                    k3d11.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp11 == 0)
                {
                    k3d12.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp11 > 0 && classSob.Amp11 < step)
                {
                    k3d12.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp11 >= step && classSob.Amp11 < 2 * step)
                {
                    k3d12.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp11 >= 2 * step && classSob.Amp11 < 3 * step)
                {
                    k3d12.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp11 >= 3 * step && classSob.Amp11 < 4 * step)
                {
                    k3d12.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp11 >= 4 * step)
                {
                    k3d12.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

            }

            if (classSob.nameklaster == "4")
            {
                k4d1.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k4d2.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k4d3.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k4d4.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k4d5.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k4d6.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k4d7.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k4d8.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k4d9.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k4d10.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k4d11.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k4d12.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(255, 202, 24, 37));

                short max = classSob.AmpSum().Max();
                short min = classSob.AmpSum().Min();
                int step = (max - min) / 4;

                Text1.Text = step.ToString();
                Text2.Text = (2 * step).ToString();
                Text3.Text = (3 * step).ToString();
                Text4.Text = (4 * step).ToString();

                if (classSob.Amp0 == 0)
                {
                    k4d1.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp0 > 0 && classSob.Amp0 < step)
                {
                    k4d1.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp0 >= step && classSob.Amp0 < 2 * step)
                {
                    k4d1.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp0 >= 2 * step && classSob.Amp0 < 3 * step)
                {
                    k4d1.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp0 >= 3 * step && classSob.Amp0 < 4 * step)
                {
                    k4d1.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp0 >= 4 * step)
                {
                    k4d1.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }


                if (classSob.Amp1 == 0)
                {
                    k4d2.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp1 > 0 && classSob.Amp1 < step)
                {
                    k4d2.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp1 >= step && classSob.Amp1 < 2 * step)
                {
                    k4d2.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp1 >= 2 * step && classSob.Amp1 < 3 * step)
                {
                    k4d2.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp1 >= 3 * step && classSob.Amp1 < 4 * step)
                {
                    k4d2.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp1 >= 4 * step)
                {
                    k4d2.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }


                if (classSob.Amp2 == 0)
                {
                    k4d3.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp2 > 0 && classSob.Amp2 < step)
                {
                    k4d3.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp2 >= step && classSob.Amp2 < 2 * step)
                {
                    k4d3.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp2 >= 2 * step && classSob.Amp2 < 3 * step)
                {
                    k4d3.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp2 >= 3 * step && classSob.Amp2 < 4 * step)
                {
                    k4d3.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp2 >= 4 * step)
                {
                    k4d3.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp3 == 0)
                {
                    k4d4.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp3 > 0 && classSob.Amp3 < step)
                {
                    k4d4.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp3 >= step && classSob.Amp3 < 2 * step)
                {
                    k4d4.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp3 >= 2 * step && classSob.Amp3 < 3 * step)
                {
                    k4d4.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp3 >= 3 * step && classSob.Amp3 < 4 * step)
                {
                    k4d4.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp3 >= 4 * step)
                {
                    k4d4.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp4 == 0)
                {
                    k4d5.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp4 > 0 && classSob.Amp4 < step)
                {
                    k4d5.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp4 >= step && classSob.Amp4 < 2 * step)
                {
                    k4d5.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp4 >= 2 * step && classSob.Amp4 < 3 * step)
                {
                    k4d5.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp4 >= 3 * step && classSob.Amp4 < 4 * step)
                {
                    k4d5.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp4 >= 4 * step)
                {
                    k4d5.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp5 == 0)
                {
                    k4d6.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp5 > 0 && classSob.Amp5 < step)
                {
                    k4d6.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp5 >= step && classSob.Amp5 < 2 * step)
                {
                    k4d6.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp5 >= 2 * step && classSob.Amp5 < 3 * step)
                {
                    k4d6.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp5 >= 3 * step && classSob.Amp5 < 4 * step)
                {
                    k4d6.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp5 >= 4 * step)
                {
                    k4d6.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp6 == 0)
                {
                    k4d7.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp6 > 0 && classSob.Amp6 < step)
                {
                    k4d7.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp6 >= step && classSob.Amp6 < 2 * step)
                {
                    k4d7.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp6 >= 2 * step && classSob.Amp6 < 3 * step)
                {
                    k4d7.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp6 >= 3 * step && classSob.Amp6 < 4 * step)
                {
                    k4d7.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp6 >= 4 * step)
                {
                    k4d7.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp7 == 0)
                {
                    k4d8.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp7 > 0 && classSob.Amp7 < step)
                {
                    k4d8.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp7 >= step && classSob.Amp7 < 2 * step)
                {
                    k4d8.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp7 >= 2 * step && classSob.Amp7 < 3 * step)
                {
                    k4d8.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp7 >= 3 * step && classSob.Amp7 < 4 * step)
                {
                    k4d8.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp7 >= 4 * step)
                {
                    k4d8.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp8 == 0)
                {
                    k4d9.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp8 > 0 && classSob.Amp8 < step)
                {
                    k4d9.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp8 >= step && classSob.Amp8 < 2 * step)
                {
                    k4d9.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp8 >= 2 * step && classSob.Amp8 < 3 * step)
                {
                    k4d9.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp8 >= 3 * step && classSob.Amp8 < 4 * step)
                {
                    k4d9.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp8 >= 4 * step)
                {
                    k4d9.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp9 == 0)
                {
                    k4d10.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp9 > 0 && classSob.Amp9 < step)
                {
                    k4d10.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp9 >= step && classSob.Amp9 < 2 * step)
                {
                    k4d10.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp9 >= 2 * step && classSob.Amp9 < 3 * step)
                {
                    k4d10.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp9 >= 3 * step && classSob.Amp9 < 4 * step)
                {
                    k4d10.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp9 >= 4 * step)
                {
                    k4d10.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp10 == 0)
                {
                    k4d11.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp10 > 0 && classSob.Amp10 < step)
                {
                    k4d11.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp10 >= step && classSob.Amp10 < 2 * step)
                {
                    k4d11.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp10 >= 2 * step && classSob.Amp10 < 3 * step)
                {
                    k4d11.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp10 >= 3 * step && classSob.Amp10 < 4 * step)
                {
                    k4d11.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp10 >= 4 * step)
                {
                    k4d11.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp11 == 0)
                {
                    k4d12.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp11 > 0 && classSob.Amp11 < step)
                {
                    k4d12.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp11 >= step && classSob.Amp11 < 2 * step)
                {
                    k4d12.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp11 >= 2 * step && classSob.Amp11 < 3 * step)
                {
                    k4d12.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp11 >= 3 * step && classSob.Amp11 < 4 * step)
                {
                    k4d12.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp11 >= 4 * step)
                {
                    k4d12.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

            }
            if (classSob.nameklaster == "5")
            {
                k5d1.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k5d2.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k5d3.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k5d4.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k5d5.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k5d6.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k5d7.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k5d8.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k5d9.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k5d10.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k5d11.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k5d12.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(255, 202, 24, 37));

                short max = classSob.AmpSum().Max();
                short min = classSob.AmpSum().Min();
                int step = (max - min) / 4;

                Text1.Text = step.ToString();
                Text2.Text = (2 * step).ToString();
                Text3.Text = (3 * step).ToString();
                Text4.Text = (4 * step).ToString();

                if (classSob.Amp0 == 0)
                {
                    k5d1.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp0 > 0 && classSob.Amp0 < step)
                {
                    k5d1.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp0 >= step && classSob.Amp0 < 2 * step)
                {
                    k5d1.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp0 >= 2 * step && classSob.Amp0 < 3 * step)
                {
                    k5d1.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp0 >= 3 * step && classSob.Amp0 < 4 * step)
                {
                    k5d1.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp0 >= 4 * step)
                {
                    k5d1.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }


                if (classSob.Amp1 == 0)
                {
                    k5d2.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp1 > 0 && classSob.Amp1 < step)
                {
                    k5d2.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp1 >= step && classSob.Amp1 < 2 * step)
                {
                    k5d2.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp1 >= 2 * step && classSob.Amp1 < 3 * step)
                {
                    k5d2.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp1 >= 3 * step && classSob.Amp1 < 4 * step)
                {
                    k5d2.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp1 >= 4 * step)
                {
                    k5d2.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }


                if (classSob.Amp2 == 0)
                {
                    k5d3.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp2 > 0 && classSob.Amp2 < step)
                {
                    k5d3.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp2 >= step && classSob.Amp2 < 2 * step)
                {
                    k5d3.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp2 >= 2 * step && classSob.Amp2 < 3 * step)
                {
                    k5d3.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp2 >= 3 * step && classSob.Amp2 < 4 * step)
                {
                    k5d3.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp2 >= 4 * step)
                {
                    k5d3.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp3 == 0)
                {
                    k5d4.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp3 > 0 && classSob.Amp3 < step)
                {
                    k5d4.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp3 >= step && classSob.Amp3 < 2 * step)
                {
                    k5d4.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp3 >= 2 * step && classSob.Amp3 < 3 * step)
                {
                    k5d4.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp3 >= 3 * step && classSob.Amp3 < 4 * step)
                {
                    k5d4.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp3 >= 4 * step)
                {
                    k5d4.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp4 == 0)
                {
                    k5d5.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp4 > 0 && classSob.Amp4 < step)
                {
                    k5d5.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp4 >= step && classSob.Amp4 < 2 * step)
                {
                    k5d5.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp4 >= 2 * step && classSob.Amp4 < 3 * step)
                {
                    k5d5.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp4 >= 3 * step && classSob.Amp4 < 4 * step)
                {
                    k5d5.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp4 >= 4 * step)
                {
                    k5d5.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp5 == 0)
                {
                    k5d6.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp5 > 0 && classSob.Amp5 < step)
                {
                    k5d6.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp5 >= step && classSob.Amp5 < 2 * step)
                {
                    k5d6.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp5 >= 2 * step && classSob.Amp5 < 3 * step)
                {
                    k5d6.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp5 >= 3 * step && classSob.Amp5 < 4 * step)
                {
                    k5d6.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp5 >= 4 * step)
                {
                    k5d6.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp6 == 0)
                {
                    k5d7.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp6 > 0 && classSob.Amp6 < step)
                {
                    k5d7.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp6 >= step && classSob.Amp6 < 2 * step)
                {
                    k5d7.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp6 >= 2 * step && classSob.Amp6 < 3 * step)
                {
                    k5d7.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp6 >= 3 * step && classSob.Amp6 < 4 * step)
                {
                    k5d7.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp6 >= 4 * step)
                {
                    k5d7.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp7 == 0)
                {
                    k5d8.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp7 > 0 && classSob.Amp7 < step)
                {
                    k5d8.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp7 >= step && classSob.Amp7 < 2 * step)
                {
                    k5d8.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp7 >= 2 * step && classSob.Amp7 < 3 * step)
                {
                    k5d8.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp7 >= 3 * step && classSob.Amp7 < 4 * step)
                {
                    k5d8.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp7 >= 4 * step)
                {
                    k5d8.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp8 == 0)
                {
                    k5d9.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp8 > 0 && classSob.Amp8 < step)
                {
                    k5d9.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp8 >= step && classSob.Amp8 < 2 * step)
                {
                    k5d9.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp8 >= 2 * step && classSob.Amp8 < 3 * step)
                {
                    k5d9.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp8 >= 3 * step && classSob.Amp8 < 4 * step)
                {
                    k5d9.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp8 >= 4 * step)
                {
                    k5d9.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp9 == 0)
                {
                    k5d10.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp9 > 0 && classSob.Amp9 < step)
                {
                    k5d10.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp9 >= step && classSob.Amp9 < 2 * step)
                {
                    k5d10.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp9 >= 2 * step && classSob.Amp9 < 3 * step)
                {
                    k5d10.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp9 >= 3 * step && classSob.Amp9 < 4 * step)
                {
                    k5d10.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp9 >= 4 * step)
                {
                    k5d10.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp10 == 0)
                {
                    k5d11.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp10 > 0 && classSob.Amp10 < step)
                {
                    k5d11.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp10 >= step && classSob.Amp10 < 2 * step)
                {
                    k5d11.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp10 >= 2 * step && classSob.Amp10 < 3 * step)
                {
                    k5d11.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp10 >= 3 * step && classSob.Amp10 < 4 * step)
                {
                    k5d11.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp10 >= 4 * step)
                {
                    k5d11.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp11 == 0)
                {
                    k5d12.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp11 > 0 && classSob.Amp11 < step)
                {
                    k5d12.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp11 >= step && classSob.Amp11 < 2 * step)
                {
                    k5d12.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp11 >= 2 * step && classSob.Amp11 < 3 * step)
                {
                    k5d12.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp11 >= 3 * step && classSob.Amp11 < 4 * step)
                {
                    k5d12.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp11 >= 4 * step)
                {
                    k5d12.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

            }
            if (classSob.nameklaster == "6")
            {
                k6d1.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k6d2.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k6d3.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k6d4.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k6d5.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k6d6.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k6d7.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k6d8.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k6d9.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k6d10.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k6d11.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                k6d12.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(255, 202, 24, 37));

                short max = classSob.AmpSum().Max();
                short min = classSob.AmpSum().Min();
                int step = (max - min) / 4;

                Text1.Text = step.ToString();
                Text2.Text = (2 * step).ToString();
                Text3.Text = (3 * step).ToString();
                Text4.Text = (4 * step).ToString();

                if (classSob.Amp0 == 0)
                {
                    k6d1.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp0 > 0 && classSob.Amp0 < step)
                {
                    k6d1.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp0 >= step && classSob.Amp0 < 2 * step)
                {
                    k6d1.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp0 >= 2 * step && classSob.Amp0 < 3 * step)
                {
                    k6d1.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp0 >= 3 * step && classSob.Amp0 < 4 * step)
                {
                    k6d1.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp0 >= 4 * step)
                {
                    k6d1.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }


                if (classSob.Amp1 == 0)
                {
                    k6d2.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp1 > 0 && classSob.Amp1 < step)
                {
                    k6d2.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp1 >= step && classSob.Amp1 < 2 * step)
                {
                    k6d2.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp1 >= 2 * step && classSob.Amp1 < 3 * step)
                {
                    k6d2.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp1 >= 3 * step && classSob.Amp1 < 4 * step)
                {
                    k6d2.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp1 >= 4 * step)
                {
                    k6d2.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }


                if (classSob.Amp2 == 0)
                {
                    k6d3.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp2 > 0 && classSob.Amp2 < step)
                {
                    k6d3.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp2 >= step && classSob.Amp2 < 2 * step)
                {
                    k6d3.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp2 >= 2 * step && classSob.Amp2 < 3 * step)
                {
                    k6d3.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp2 >= 3 * step && classSob.Amp2 < 4 * step)
                {
                    k6d3.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp2 >= 4 * step)
                {
                    k6d3.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp3 == 0)
                {
                    k6d4.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp3 > 0 && classSob.Amp3 < step)
                {
                    k6d4.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp3 >= step && classSob.Amp3 < 2 * step)
                {
                    k6d4.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp3 >= 2 * step && classSob.Amp3 < 3 * step)
                {
                    k6d4.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp3 >= 3 * step && classSob.Amp3 < 4 * step)
                {
                    k6d4.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp3 >= 4 * step)
                {
                    k6d4.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp4 == 0)
                {
                    k6d5.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp4 > 0 && classSob.Amp4 < step)
                {
                    k6d5.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp4 >= step && classSob.Amp4 < 2 * step)
                {
                    k6d5.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp4 >= 2 * step && classSob.Amp4 < 3 * step)
                {
                    k6d5.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp4 >= 3 * step && classSob.Amp4 < 4 * step)
                {
                    k6d5.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp4 >= 4 * step)
                {
                    k6d5.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp5 == 0)
                {
                    k6d6.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp5 > 0 && classSob.Amp5 < step)
                {
                    k6d6.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp5 >= step && classSob.Amp5 < 2 * step)
                {
                    k6d6.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp5 >= 2 * step && classSob.Amp5 < 3 * step)
                {
                    k6d6.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp5 >= 3 * step && classSob.Amp5 < 4 * step)
                {
                    k6d6.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp5 >= 4 * step)
                {
                    k6d6.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp6 == 0)
                {
                    k6d7.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp6 > 0 && classSob.Amp6 < step)
                {
                    k6d7.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp6 >= step && classSob.Amp6 < 2 * step)
                {
                    k6d7.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp6 >= 2 * step && classSob.Amp6 < 3 * step)
                {
                    k6d7.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp6 >= 3 * step && classSob.Amp6 < 4 * step)
                {
                    k6d7.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp6 >= 4 * step)
                {
                    k6d7.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp7 == 0)
                {
                    k6d8.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp7 > 0 && classSob.Amp7 < step)
                {
                    k6d8.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp7 >= step && classSob.Amp7 < 2 * step)
                {
                    k6d8.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp7 >= 2 * step && classSob.Amp7 < 3 * step)
                {
                    k6d8.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp7 >= 3 * step && classSob.Amp7 < 4 * step)
                {
                    k6d8.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp7 >= 4 * step)
                {
                    k6d8.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp8 == 0)
                {
                    k6d9.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp8 > 0 && classSob.Amp8 < step)
                {
                    k6d9.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp8 >= step && classSob.Amp8 < 2 * step)
                {
                    k6d9.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp8 >= 2 * step && classSob.Amp8 < 3 * step)
                {
                    k6d9.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp8 >= 3 * step && classSob.Amp8 < 4 * step)
                {
                    k6d9.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp8 >= 4 * step)
                {
                    k6d9.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp9 == 0)
                {
                    k6d10.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp9 > 0 && classSob.Amp9 < step)
                {
                    k6d10.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp9 >= step && classSob.Amp9 < 2 * step)
                {
                    k6d10.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp9 >= 2 * step && classSob.Amp9 < 3 * step)
                {
                    k6d10.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp9 >= 3 * step && classSob.Amp9 < 4 * step)
                {
                    k6d10.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp9 >= 4 * step)
                {
                    k6d10.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp10 == 0)
                {
                    k6d11.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp10 > 0 && classSob.Amp10 < step)
                {
                    k6d11.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp10 >= step && classSob.Amp10 < 2 * step)
                {
                    k6d11.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp10 >= 2 * step && classSob.Amp10 < 3 * step)
                {
                    k6d11.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp10 >= 3 * step && classSob.Amp10 < 4 * step)
                {
                    k6d11.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp10 >= 4 * step)
                {
                    k6d11.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

                if (classSob.Amp11 == 0)
                {
                    k6d12.Fill = new SolidColorBrush(Windows.UI.Colors.Wheat);
                }
                if (classSob.Amp11 > 0 && classSob.Amp11 < step)
                {
                    k6d12.Fill = new SolidColorBrush(Windows.UI.Colors.LimeGreen);
                }
                if (classSob.Amp11 >= step && classSob.Amp11 < 2 * step)
                {
                    k6d12.Fill = new SolidColorBrush(Windows.UI.Colors.Blue);
                }
                if (classSob.Amp11 >= 2 * step && classSob.Amp11 < 3 * step)
                {
                    k6d12.Fill = new SolidColorBrush(Windows.UI.Colors.Yellow);
                }
                if (classSob.Amp11 >= 3 * step && classSob.Amp11 < 4 * step)
                {
                    k6d12.Fill = new SolidColorBrush(Windows.UI.Colors.IndianRed);
                }
                if (classSob.Amp11 >= 4 * step)
                {
                    k6d12.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
                }

            }
        }

        private void ListSob_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClassSob classSob = (ClassSob)ListSob.SelectedItem;
            ShowDetec(classSob);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPageObrData));
        }
    }
}
