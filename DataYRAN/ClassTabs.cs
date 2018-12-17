using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace DataYRAN
{
   public class ClassTabs
    {
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

        public DataGrid dataGrid = new DataGrid();
        public void newTab(string name)
        {
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
          
           


            // добавляем вторую строку
        }

        public string newColums(string nameKolun)
        {
            if (booksTable != null) // table is a DataTable
            {
                int x = booksTable.Columns.Count;
                DataColumn priceColumn = new DataColumn("Колонка " + x.ToString(), Type.GetType("System.Int32"));
                priceColumn.AllowDBNull = true;
                booksTable.Columns.Add(priceColumn);

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
        public ObservableCollection<ClassGraf> newGrafSer(List<string> vs)
        {
         
            ClassGraf classGrafSer = new ClassGraf();
            foreach (string vv in vs)
            {
                int x = 0;
                foreach (DataColumn column in _booksTable.Columns)
                {
                    if (column.ColumnName == vv)
                    {
                        classGrafSer.name = vv;
                        for (int j = 0; j < collection.Count; j++)
                        {
                           
                            classGrafSer.collectionGraf.Add((int)collection.ElementAt(j).ItemArray[x+1]);

                        }
                    
                        collectionGraf.Add(classGrafSer);
                    }
                    classGrafSer = new ClassGraf();
                    x++;
                }

            }
            return collectionGraf;
        }
        public void newRows(int[] mas)
        {
            // row.ItemArray = new object[] { null, "Война и мир", 200 };
            DataRow row = booksTable.NewRow();
            int x = booksTable.Columns.Count - 1;
            int x1 = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                row[i + 1] = mas[x1];
            }
            collection.Add(row);
            booksTable.AcceptChanges();



        }
    }
}
