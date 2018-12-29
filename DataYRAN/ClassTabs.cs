using LiveCharts;
using LiveCharts.Uwp;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Binding = Windows.UI.Xaml.Data.Binding;

namespace DataYRAN
{
   public class ClassTabs
    {
        public string name { get; set; }
        public string tag { get; set; }
        DataTable _booksTable;
        public DataTable booksTable
        {
            get
            {
                return _booksTable;
            }
            set
            {
                _booksTable = value;
               
            }
        }
        public SeriesCollection ss =  new SeriesCollection { };
    public void NewAddLine()
        {
            if(ss!=null)
            ss.Add(new LineSeries() { Values = new ChartValues<double> {},  Fill = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0)) });
            else
            {
                NewAddSeriaCol();
                ss.Add(new LineSeries() { Values = new ChartValues<double> { }, Fill = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0)) });
                

            }
        }
        public void NewAddSeriaCol()
        {
            ss = new SeriesCollection { };
        }
        public void NewAddColumnSeries()
        {
            ss.Add(new ColumnSeries() { Values = new ChartValues<double> { } });
        }
        public void NewAddPpoin(int ser, double point)
        {
            ss[ser].Values.Add(point);
        }
        public DataGrid dataGrid = new DataGrid();
        public void newTabl()
        {
         
            dataGrid.AutoGenerateColumns = false;
            //  bookStore = new DataSet("BookStore");
            booksTable = new DataTable(name);

            collection = new ObservableCollection<DataRow>();
            // bookStore.Tables.Add(booksTable);
            DataColumn idColumn = new DataColumn("I", Type.GetType("System.Int32"));
            idColumn.Unique = true; // столбец будет иметь уникальное значение
            idColumn.AllowDBNull = false; // не может принимать null
            idColumn.AutoIncrement = true; // будет автоинкрементироваться
            idColumn.AutoIncrementSeed = 1; // начальное значение
            idColumn.AutoIncrementStep = 1; // приращении при добавлении новой строки

            booksTable.Columns.Add(idColumn);
        
            // определяем первичный ключ таблицы books
            booksTable.PrimaryKey = new DataColumn[] { booksTable.Columns["I"] };
            //newColums("Колонка 1", dataGrid1);


            DataGrid1_Loading();
          
        
           
            Grid grid = new Grid() { Tag = name };
            grid.Children.Add(dataGrid);
            collectionPage.Add(grid);
            dataGrid.ItemsSource = collection;

            // добавляем вторую строку
        }
        private void DataGrid1_Loading()
        {

          
           
            if (booksTable != null) // table is a DataTable
            {
                dataGrid.Columns.Clear();
                int i = 0;
                foreach (DataColumn col in booksTable.Columns)
                {
                    // booksTable.Columns.Add(
                    //  new DataGridTextColumn
                    //  {
                    //    Header = col.ColumnName,

                    //   Binding = new Binding(string.Format("[{0}]", col.ColumnName))



                    //  });

                    dataGrid.Columns.Add(new Microsoft.Toolkit.Uwp.UI.Controls.DataGridTextColumn()
                    {
                        Header = col.ColumnName,
                        Binding = new Binding { Path = new PropertyPath("[" + col.ColumnName.ToString() + "]") },
                        IsReadOnly = false
                    });

                }

            }
        }
        public string newColums()
        {
            if (booksTable != null) // table is a DataTable
            {
                int x = booksTable.Columns.Count;
                DataColumn priceColumn = new DataColumn("Колонка " + x.ToString(), Type.GetType("System.Int32"));
                string nameKolun = "Колонка " + x.ToString();
                priceColumn.AllowDBNull = true;
                booksTable.Columns.Add(priceColumn);
                dataGrid.Columns.Add(new Microsoft.Toolkit.Uwp.UI.Controls.DataGridTextColumn()
                {
                    Header = nameKolun,
                    Binding = new Binding { Path = new PropertyPath("[" + nameKolun + "]") },
                    IsReadOnly = false
                });
                return "Колонка " + x.ToString();

            }
            return null;
        }
        ObservableCollection<DataRow> _collection=new ObservableCollection<DataRow>();
        public ObservableCollection<DataRow> collection
        {
            get
            {
                return _collection;
            }
            set
            {
                _collection = value;
            }
        }
        public ObservableCollection<ClassGraf> collectionGraf = new ObservableCollection<ClassGraf>();
        public void newGrafSer(List<int> vs)
        {
         
            ClassGraf classGrafSer;
           for(int i=0; i<vs.Count; i++)
            {
                classGrafSer = new ClassGraf();
                classGrafSer.name = "Колонка "+i.ToString();
                        for (int j = 0; j < collection.Count; j++)
                        {
                         classGrafSer.collectionGraf.Add((int)collection.ElementAt(j).ItemArray[vs.ElementAt(i)]);
                        }                   
                        collectionGraf.Add(classGrafSer);                    
                    //classGrafSer = new ClassGraf();                
            }
         
        }
        public  void newRows(int[] mas)
        {
            // row.ItemArray = new object[] { null, "Война и мир", 200 };
            DataRow row = booksTable.NewRow();
            int x = booksTable.Columns.Count - 1;
            int x1 = 0;
         
            for (int i = 0; i < mas.Length; i++)
            {
                row[i + 1] = mas[i];
                
            }
            _collection.Add(row);
            booksTable.AcceptChanges();



        }
      public  Page page { get; set; }
        ObservableCollection<Grid> _collectionPage = new ObservableCollection<Grid>();
        public ObservableCollection<Grid> collectionPage
        {
            get
            {
                return _collectionPage;
            }
            set
            {
                _collectionPage = value;
            }
        }
    }
}
