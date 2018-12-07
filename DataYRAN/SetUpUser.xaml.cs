using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace DataYRAN
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class SetUpUser : Page
    {
        Windows.Storage.ApplicationDataContainer localSettings =
       Windows.Storage.ApplicationData.Current.LocalSettings;
        Windows.Storage.StorageFolder localFolder =
            Windows.Storage.ApplicationData.Current.LocalFolder;
        public SetUpUser()
        {
            this.InitializeComponent();
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 55.6509863734914, Longitude = 37.6680877307923, Altitude = 10 };
            SeattleLocation1 = new Geopoint(cityPosition);
            SeattleLocation2 = new Geopoint(cityPosition);


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPageObrData));
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb != null)
            {
                string cult = rb.Tag.ToString();
                switch (cult)
                {
                    case "Rus":
                        ClassUserSetUp.Cult = "ru-RUS";
                        break;
                    case "USA":
                        ClassUserSetUp.Cult = "en-US";
                        break;
                   
                    
                }
                ClassUserSetUp.saveUseSet();
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Specify a known location.
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 55.6512013566365, Longitude = 37.6681702130651 };
            Geopoint cityCenter = new Geopoint(cityPosition);

            // Set the map location.
            MapControl1.Center = cityCenter;
            MapControl1.ZoomLevel = 20;
            MapControl1.LandmarksVisible = true;
           
        }
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            add3D();

        }
        public async void HighlightArea()
        {
            // Create MapPolygon.

            double centerLatitude = MapControl1.Center.Position.Latitude;
            double centerLongitude = MapControl1.Center.Position.Longitude;
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 55.6509863734914, Longitude = 37.6680877307923, Altitude = 10 };
        
            Geopoint cityCenter = new Geopoint(cityPosition);
            var mapPolygon = new MapPolygon
            {
                Path = new Geopath(new List<BasicGeoposition> {
                    new BasicGeoposition() {Latitude=cityCenter.Position.Latitude+0.0005, Longitude=cityCenter.Position.Longitude-0.001 },
                    new BasicGeoposition() {Latitude=cityCenter.Position.Latitude-0.0005, Longitude=cityCenter.Position.Longitude-0.001 },
                    new BasicGeoposition() {Latitude=cityCenter.Position.Latitude-0.0005, Longitude=cityCenter.Position.Longitude+0.001 },
                    new BasicGeoposition() {Latitude=cityCenter.Position.Latitude+0.0005, Longitude=cityCenter.Position.Longitude+0.001 },
                }),
                ZIndex = 100,
                FillColor = Colors.Red,
                StrokeColor = Colors.Blue,
                StrokeThickness = 3,
                StrokeDashed = false,
               
            };

            // Add MapPolygon to a layer on the map control.
            var MyHighlights = new List<MapElement>();

            MyHighlights.Add(mapPolygon);

            var HighlightsLayer = new MapElementsLayer
            {
                ZIndex = 100,
                MapElements = MyHighlights,
                Visible=true
            };

            MapControl1.Layers.Add(HighlightsLayer);
        
            foreach(var d in MapControl1.Layers)
            {
                
                MessageDialog messageDialog = new MessageDialog(d.ZIndex.ToString());
                await messageDialog.ShowAsync();
            }
           
        }
        public async void add3D()
        {
          var  map3dSphereStreamReference = RandomAccessStreamReference.CreateFromUri
   (new Uri("ms-appx:///Assets/mug.3mf"));

            var myModel = await MapModel3D.CreateFrom3MFAsync(map3dSphereStreamReference,
                MapModel3DShadingOption.Smooth);

            var my3DElement = new MapElement3D();
            double centerLatitude = MapControl1.Center.Position.Latitude;
            double centerLongitude = MapControl1.Center.Position.Longitude;
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 55.6509863734914, Longitude = 37.6680877307923, Altitude = 10 };

            Geopoint cityCenter = new Geopoint(cityPosition);
            my3DElement.Location = cityCenter;
            my3DElement.Model = myModel;

            MapControl1.MapElements.Add(my3DElement);
        }
        public Geopoint SeattleLocation1 { get; set; }
        public Geopoint SeattleLocation2 { get; set; }
        private async void display3DLocation()
        {
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 55.6509863734914, Longitude = 37.6680877307923, Altitude = 10 };
            SeattleLocation1 = new Geopoint(cityPosition);
            Geopoint cityCenter = new Geopoint(cityPosition);
            if (MapControl1.Is3DSupported)
            {
                // Set the aerial 3D view.
                MapControl1.Style = MapStyle.Terrain;

                // Specify the location.
                BasicGeoposition hwGeoposition = new BasicGeoposition() { Latitude = cityCenter.Position.Latitude, Longitude = cityCenter.Position.Longitude, Altitude= cityCenter.Position.Altitude };
                Geopoint hwPoint = new Geopoint(hwGeoposition);

                // Create the map scene.
                MapScene hwScene = MapScene.CreateFromLocationAndRadius(hwPoint,
                                                                                     80, /* show this many meters around */
                                                                                     0, /* looking at it to the North*/
                                                                                     60 /* degrees pitch */);
                // Set the 3D view with animation.
                await MapControl1.TrySetSceneAsync(hwScene, MapAnimationKind.Bow);
            }
            else
            {
                // If 3D views are not supported, display dialog.
                ContentDialog viewNotSupportedDialog = new ContentDialog()
                {
                    Title = "3D is not supported",
                    Content = "\n3D views are not supported on this device.",
                    PrimaryButtonText = "OK"
                };
                await viewNotSupportedDialog.ShowAsync();
            }
        }
        public async void Add3DMapModel()
        {
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 55.6512013566365, Longitude = 37.6681702130651 };
            Geopoint cityCenter = new Geopoint(cityPosition);
            var mugStreamReference = RandomAccessStreamReference.CreateFromUri
                (new Uri("ms-appx:///Assets/mug.3mf"));

            var myModel = await MapModel3D.CreateFrom3MFAsync(mugStreamReference,
                MapModel3DShadingOption.Smooth);

            MapControl1.Layers.Add(new MapElementsLayer
            {
                ZIndex = 1,
                MapElements = new List<MapElement>
       {
          new MapElement3D
          {
              Location = cityCenter,
              Model = myModel,
          },
       },
            });
        }
        public async  void AddElips()
        {
            Ellipse myEllipse = new Ellipse()
            {
                Height = 20,
                Width = 20,
                Stroke = new SolidColorBrush(Windows.UI.Colors.Blue),
                StrokeThickness = 2,

            };


            // Add XAML to the map.
            MapControl1.Children.Add(myEllipse);
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 55.6509863734914, Longitude = 37.6680877307923, Altitude = 10 };
            SeattleLocation1 = new Geopoint(cityPosition);
            Geopoint cityCenter = new Geopoint(cityPosition);
            MapControl.SetLocation(myEllipse, cityCenter);
            MapControl.SetNormalizedAnchorPoint(myEllipse, new Point(0.5, 1));
         

            MessageDialog messageDialog = new MessageDialog(MapControl1.Children.Count.ToString());
            await messageDialog.ShowAsync();

        }
        public void AddLandmarkPhoto()
        {
            // Create MapBillboard.

            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 55.6509863734914, Longitude = 37.6680877307923, Altitude = 0 };
            SeattleLocation1 = new Geopoint(cityPosition);
            Geopoint cityCenter = new Geopoint(cityPosition);

            var mapBillboard = new MapBillboard(MapControl1.ActualCamera)
            {
                Location = cityCenter,
                NormalizedAnchorPoint = new Point(0.5, 1.0),
             
            };

            // Add MapBillboard to a layer on the map control.

            var MyLandmarkPhotos = new List<MapElement>();

            MyLandmarkPhotos.Add(mapBillboard);

            var LandmarksPhotoLayer = new MapElementsLayer
            {
                ZIndex = 1,
                MapElements = MyLandmarkPhotos
            };

            MapControl1.Layers.Add(LandmarksPhotoLayer);
        }
        private async void MapControl1_MapTapped(Windows.UI.Xaml.Controls.Maps.MapControl sender, Windows.UI.Xaml.Controls.Maps.MapInputEventArgs args)
        {
            //Geopoint pos = args.Location;
            //Point pos1 = args.Position;
            // MessageDialog   messageDialog = new MessageDialog(pos.Position.Longitude.ToString()+"  "+ pos.Position.Latitude.ToString());
            //   await messageDialog.ShowAsync();
       
            Ellipse myEllipse = new Ellipse()
            {
                Height = 20,
                Width = 20,
                Stroke = new SolidColorBrush(Windows.UI.Colors.Blue),
                StrokeThickness = 2,

            };


            // Add XAML to the map.
            MapControl1.Children.Add(myEllipse);
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 55.6509863734914, Longitude = 37.6680877307923, Altitude = 10 };
            SeattleLocation1 = new Geopoint(cityPosition);
            Geopoint cityCenter = new Geopoint(cityPosition);
            MapControl.SetLocation(myEllipse, cityCenter);
            MapControl.SetNormalizedAnchorPoint(myEllipse, new Point(0.5, 1));
            // AddLandmarkPhoto();
        }
        public void AddLandmarkPhoto1()
        {
            // Create MapBillboard.
            Ellipse myEllipse = new Ellipse()
            {
                Height = 20,
                Width = 20,
                Stroke = new SolidColorBrush(Windows.UI.Colors.Blue),
                StrokeThickness = 2,

            };
            //RandomAccessStreamReference mapBillboardStreamReference =
            //   RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/billboard.jpg"));
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 55.6509863734914, Longitude = 37.6680877307923, Altitude = 10};
            SeattleLocation1 = new Geopoint(cityPosition);
           


        }
        private async void MapControl1_ZoomLevelChanged(MapControl sender, object args)
        {
                
                





        }
    }
}
