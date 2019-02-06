using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AndroidMonitoringURAN
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ListKl.ItemsSource = ListSostoKl;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // if (viewModel.Items.Count == 0)
            //    viewModel.LoadItemsCommand.Execute(null);
            await ConnServTCP("Hello, World!");
        }
        private ObservableCollection<ClassSostoKl> listSostoKl = new ObservableCollection<ClassSostoKl>();
        public ObservableCollection<ClassSostoKl> ListSostoKl { get { return this.listSostoKl; } }
        TcpClient client;
        private async Task ConnServTCP(string t1) //
        {
            client = new TcpClient();
            try
            {

                await client.ConnectAsync("192.168.1.155", 8888); //соединение с сервером               
                                                           // StColor.Color = Color.Green; // установка цвета
                await GD(t1); // чтение данных   
            
                client.Close();
                client.Dispose();
            }
            catch
            {
                await DisplayAlert("Alert","Ошибка", "OK");
                // StColor.Color = Color.Red;
            }
        }
        private async Task GD(string tt)
        {
            byte[] data = new byte[256];

           
                if (client.Connected) // проверяю если соединение есть
                {
                ListSostoKl.Clear();
                var v = client.GetStream(); // получил NetworkStream
                   // string request = "Hello, World!";
                string request = tt;
                byte[] data1 = Encoding.UTF8.GetBytes(request);

                    await v.WriteAsync(data1, 0, data1.Length);
                    // do
                    //{
                    int bytes = v.Read(data, 0, data.Length); // считал данные
                  //  await DisplayAlert("Alert", Encoding.UTF8.GetString(data, 0, bytes), "OK");
                var str = Encoding.UTF8.GetString(data, 0, bytes);
                string[] vs = str.Split('\n');
                LRData.Text = vs[0]; // у Label на форме поменял значение  
            // await   DisplayAlert("Alert", vs.Length.ToString(), "OK");
                for (int i = 1; i < vs.Length - 1; i++)
                {

                    string vss = vs[i];
                    string[] vs1 = vss.Split('\t');
                   // await DisplayAlert("Alert", vs1.Length.ToString(), "OK");
                    try
                    {
                       // await DisplayAlert("Alert", vs1[1].ToString()+"_"+ vs1[2].ToString() + "_" + vs1[3].ToString() + "_" + vs1[4].ToString(), "OK");
                        listSostoKl.Add(new ClassSostoKl() { NomerKl = Convert.ToInt32(vs1[1]), SostoKl = vs1[2], KolPac = Convert.ToInt32(vs1[3]), KolTemp = Convert.ToInt32(vs1[4]) });
                    }
                 catch(Exception ex)
                    {
                        await DisplayAlert("Alert", ex.ToString(), "OK");
                    }


                }
                //  }
                // while (v.DataAvailable); // до тех пор пока есть данные                   
                // await Task.Delay(1000); //жду секунду        

            }
                else
            {
                LRData.Text = "Нет соединения";
            }
            


        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
           bool x= await DisplayAlert("Внимание", "Установка УРАН будет остановлена"+"\n"+"Продолжить?", "Да", "Отмена");
            if(x)
            {
                await ConnServTCP("Stop");
            }        
            else
            {

            }
            await ConnServTCP("Hello, World!");
        }
        async void OnRefresh(object sender, EventArgs e)
        {
            await ConnServTCP("Hello, World!");
            ListKl.IsRefreshing = false;
        }
    }
}
