using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.UI.Popups;

namespace DataYRAN
{
    [Serializable]
    class ClassProject
    {
        public ObservableCollection<ClassСписокList> КолекцияФайловРазверткиP { get; set; }
     static public async void SaveProgect(ObservableCollection<ClassSob> classSobsColec)
        {
            DataSet bookStore = new DataSet("Project");
            DataTable booksTable = new DataTable("Sob");
            DataTable NeutronTable = new DataTable("Neutrom");
            // добавляем таблицу в dataset
            bookStore.Tables.Add(booksTable);
            bookStore.Tables.Add(NeutronTable);


            DataColumn idColumnN = new DataColumn("Id", Type.GetType("System.Int32"));
            idColumnN.Unique = true; // столбец будет иметь уникальное значение
            idColumnN.AllowDBNull = false; // не может принимать null
            idColumnN.AutoIncrement = true; // будет автоинкрементироваться
            idColumnN.AutoIncrementSeed = 1; // начальное значение
            idColumnN.AutoIncrementStep = 1; // приращении при добавлении новой строки

            DataColumn FileColumnN = new DataColumn("file", Type.GetType("System.String"));
            DataColumn DColumnN = new DataColumn("D", Type.GetType("System.Int32"));
            DataColumn AColumnN = new DataColumn("Amp", Type.GetType("System.Int32"));
            DataColumn TimeColumnN = new DataColumn("Time", Type.GetType("System.String"));
            DataColumn tFColumnN = new DataColumn("tF", Type.GetType("System.Int32"));
            DataColumn tF3ColumnN = new DataColumn("tF3", Type.GetType("System.Int32"));
            DataColumn tMaxColumnN = new DataColumn("tMax", Type.GetType("System.Int32"));
            DataColumn tEndColumnN = new DataColumn("tEnd", Type.GetType("System.Int32"));
            DataColumn tEnd3ColumnN = new DataColumn("tEnd3", Type.GetType("System.Int32"));


            NeutronTable.Columns.Add(idColumnN);
            NeutronTable.Columns.Add(FileColumnN);
            NeutronTable.Columns.Add(DColumnN);
            NeutronTable.Columns.Add(AColumnN);
            NeutronTable.Columns.Add(TimeColumnN);
            NeutronTable.Columns.Add(tFColumnN);
            NeutronTable.Columns.Add(tF3ColumnN);
            NeutronTable.Columns.Add(tMaxColumnN);
            NeutronTable.Columns.Add(tEndColumnN);
            NeutronTable.Columns.Add(tEnd3ColumnN);
    



            // создаем столбцы для таблицы Books
            DataColumn idColumn = new DataColumn("Id", Type.GetType("System.Int32"));
            idColumn.Unique = true; // столбец будет иметь уникальное значение
            idColumn.AllowDBNull = false; // не может принимать null
            idColumn.AutoIncrement = true; // будет автоинкрементироваться
            idColumn.AutoIncrementSeed = 1; // начальное значение
            idColumn.AutoIncrementStep = 1; // приращении при добавлении новой строки


          



            DataColumn FileColumn = new DataColumn("file", Type.GetType("System.String"));
            DataColumn klColumn = new DataColumn("kl", Type.GetType("System.String"));

            // priceColumn.DefaultValue = 100; // значение по умолчанию
            DataColumn TimeColumn = new DataColumn("Time", Type.GetType("System.String"));
            DataColumn SAColumn = new DataColumn("SA", Type.GetType("System.Int32"));
            DataColumn SNColumn = new DataColumn("SN", Type.GetType("System.Int32"));
            DataColumn AD1Column = new DataColumn("AD1", Type.GetType("System.Int32"));
            DataColumn AD2Column = new DataColumn("AD2", Type.GetType("System.Int32"));
            DataColumn AD3Column = new DataColumn("AD3", Type.GetType("System.Int32"));
            DataColumn AD4Column = new DataColumn("AD4", Type.GetType("System.Int32"));
            DataColumn AD5Column = new DataColumn("AD5", Type.GetType("System.Int32"));
            DataColumn AD6Column = new DataColumn("AD6", Type.GetType("System.Int32"));
            DataColumn AD7Column = new DataColumn("AD7", Type.GetType("System.Int32"));
            DataColumn AD8Column = new DataColumn("AD8", Type.GetType("System.Int32"));
            DataColumn AD9Column = new DataColumn("AD9", Type.GetType("System.Int32"));
            DataColumn AD10Column = new DataColumn("AD10", Type.GetType("System.Int32"));
            DataColumn AD11Column = new DataColumn("AD11", Type.GetType("System.Int32"));
            DataColumn AD12Column = new DataColumn("AD12", Type.GetType("System.Int32"));

            DataColumn ND1Column = new DataColumn("ND1", Type.GetType("System.Int32"));
            DataColumn ND2Column = new DataColumn("ND2", Type.GetType("System.Int32"));
            DataColumn ND3Column = new DataColumn("ND3", Type.GetType("System.Int32"));
            DataColumn ND4Column = new DataColumn("ND4", Type.GetType("System.Int32"));
            DataColumn ND5Column = new DataColumn("ND5", Type.GetType("System.Int32"));
            DataColumn ND6Column = new DataColumn("ND6", Type.GetType("System.Int32"));
            DataColumn ND7Column = new DataColumn("ND7", Type.GetType("System.Int32"));
            DataColumn ND8Column = new DataColumn("ND8", Type.GetType("System.Int32"));
            DataColumn ND9Column = new DataColumn("ND9", Type.GetType("System.Int32"));
            DataColumn ND10Column = new DataColumn("ND10", Type.GetType("System.Int32"));
            DataColumn ND11Column = new DataColumn("ND11", Type.GetType("System.Int32"));
            DataColumn ND12Column = new DataColumn("ND12", Type.GetType("System.Int32"));

            DataColumn Sig1Column = new DataColumn("Sig1", Type.GetType("System.Decimal"));
            DataColumn Sig2Column = new DataColumn("Sig2", Type.GetType("System.Decimal"));
            DataColumn Sig3Column = new DataColumn("Sig3", Type.GetType("System.Decimal"));
            DataColumn Sig4Column = new DataColumn("Sig4", Type.GetType("System.Decimal"));
            DataColumn Sig5Column = new DataColumn("Sig5", Type.GetType("System.Decimal"));
            DataColumn Sig6Column = new DataColumn("Sig6", Type.GetType("System.Decimal"));
            DataColumn Sig7Column = new DataColumn("Sig7", Type.GetType("System.Decimal"));
            DataColumn Sig8Column = new DataColumn("Sig8", Type.GetType("System.Decimal"));
            DataColumn Sig9Column = new DataColumn("Sig9", Type.GetType("System.Decimal"));
            DataColumn Sig10Column = new DataColumn("Sig10", Type.GetType("System.Decimal"));
            DataColumn Sig11Column = new DataColumn("Sig11", Type.GetType("System.Decimal"));
            DataColumn Sig12Column = new DataColumn("Sig12", Type.GetType("System.Decimal"));

            DataColumn NullD1Column = new DataColumn("NullD1", Type.GetType("System.Decimal"));
            DataColumn NullD2Column = new DataColumn("NullD2", Type.GetType("System.Decimal"));
            DataColumn NullD3Column = new DataColumn("NullD3", Type.GetType("System.Decimal"));
            DataColumn NullD4Column = new DataColumn("NullD4", Type.GetType("System.Decimal"));
            DataColumn NullD5Column = new DataColumn("NullD5", Type.GetType("System.Decimal"));
            DataColumn NullD6Column = new DataColumn("NullD6", Type.GetType("System.Decimal"));
            DataColumn NullD7Column = new DataColumn("NullD7", Type.GetType("System.Decimal"));
            DataColumn NullD8Column = new DataColumn("NullD8", Type.GetType("System.Decimal"));
            DataColumn NullD9Column = new DataColumn("NullD9", Type.GetType("System.Decimal"));
            DataColumn NullD10Column = new DataColumn("NullD10", Type.GetType("System.Decimal"));
            DataColumn NullD11Column = new DataColumn("NullD11", Type.GetType("System.Decimal"));
            DataColumn NullD12Column = new DataColumn("NullD12", Type.GetType("System.Decimal"));

            DataColumn TD1Column = new DataColumn("TD1", Type.GetType("System.Int32"));
            DataColumn TD2Column = new DataColumn("TD2", Type.GetType("System.Int32"));
            DataColumn TD3Column = new DataColumn("TD3", Type.GetType("System.Int32"));
            DataColumn TD4Column = new DataColumn("TD4", Type.GetType("System.Int32"));
            DataColumn TD5Column = new DataColumn("TD5", Type.GetType("System.Int32"));
            DataColumn TD6Column = new DataColumn("TD6", Type.GetType("System.Int32"));
            DataColumn TD7Column = new DataColumn("TD7", Type.GetType("System.Int32"));
            DataColumn TD8Column = new DataColumn("TD8", Type.GetType("System.Int32"));
            DataColumn TD9Column = new DataColumn("TD9", Type.GetType("System.Int32"));
            DataColumn TD10Column = new DataColumn("TD10", Type.GetType("System.Int32"));
            DataColumn TD11Column = new DataColumn("TD11", Type.GetType("System.Int32"));
            DataColumn TD12Column = new DataColumn("TD12", Type.GetType("System.Int32"));
            // discountColumn.Expression = "Price * 0.2";

            booksTable.Columns.Add(idColumn);
            booksTable.Columns.Add(FileColumn);
            booksTable.Columns.Add(klColumn);
            booksTable.Columns.Add(TimeColumn);
            booksTable.Columns.Add(SAColumn);
            booksTable.Columns.Add(SNColumn);

            booksTable.Columns.Add(AD1Column);
            booksTable.Columns.Add(AD2Column);
            booksTable.Columns.Add(AD3Column);
            booksTable.Columns.Add(AD4Column);
            booksTable.Columns.Add(AD5Column);
            booksTable.Columns.Add(AD6Column);
            booksTable.Columns.Add(AD7Column);
            booksTable.Columns.Add(AD8Column);
            booksTable.Columns.Add(AD9Column);
            booksTable.Columns.Add(AD10Column);
            booksTable.Columns.Add(AD11Column);
            booksTable.Columns.Add(AD12Column);

            booksTable.Columns.Add(ND1Column);
            booksTable.Columns.Add(ND2Column);
            booksTable.Columns.Add(ND3Column);
            booksTable.Columns.Add(ND4Column);
            booksTable.Columns.Add(ND5Column);
            booksTable.Columns.Add(ND6Column);
            booksTable.Columns.Add(ND7Column);
            booksTable.Columns.Add(ND8Column);
            booksTable.Columns.Add(ND9Column);
            booksTable.Columns.Add(ND10Column);
            booksTable.Columns.Add(ND11Column);
            booksTable.Columns.Add(ND12Column);

            booksTable.Columns.Add(Sig1Column);
            booksTable.Columns.Add(Sig2Column);
            booksTable.Columns.Add(Sig3Column);
            booksTable.Columns.Add(Sig4Column);
            booksTable.Columns.Add(Sig5Column);
            booksTable.Columns.Add(Sig6Column);
            booksTable.Columns.Add(Sig7Column);
            booksTable.Columns.Add(Sig8Column);
            booksTable.Columns.Add(Sig9Column);
            booksTable.Columns.Add(Sig10Column);
            booksTable.Columns.Add(Sig11Column);
            booksTable.Columns.Add(Sig12Column);

            booksTable.Columns.Add(NullD1Column);
            booksTable.Columns.Add(NullD2Column);
            booksTable.Columns.Add(NullD3Column);
            booksTable.Columns.Add(NullD4Column);
            booksTable.Columns.Add(NullD5Column);
            booksTable.Columns.Add(NullD6Column);
            booksTable.Columns.Add(NullD7Column);
            booksTable.Columns.Add(NullD8Column);
            booksTable.Columns.Add(NullD9Column);
            booksTable.Columns.Add(NullD10Column);
            booksTable.Columns.Add(NullD11Column);
            booksTable.Columns.Add(NullD12Column);

            booksTable.Columns.Add(TD1Column);
            booksTable.Columns.Add(TD2Column);
            booksTable.Columns.Add(TD3Column);
            booksTable.Columns.Add(TD4Column);
            booksTable.Columns.Add(TD5Column);
            booksTable.Columns.Add(TD6Column);
            booksTable.Columns.Add(TD7Column);
            booksTable.Columns.Add(TD8Column);
            booksTable.Columns.Add(TD9Column);
            booksTable.Columns.Add(TD10Column);
            booksTable.Columns.Add(TD11Column);
            booksTable.Columns.Add(TD12Column);
            // определяем первичный ключ таблицы books
            booksTable.PrimaryKey = new DataColumn[] { booksTable.Columns["Id"] };

            foreach(ClassSob classSob in classSobsColec)
            {
                DataRow row = booksTable.NewRow();
                row.ItemArray = new object[] { null, classSob.nameFile, classSob.nameklaster, classSob.time, classSob.SumAmp, classSob.SumNeu, classSob.mAmp[0], classSob.mAmp[1], classSob.mAmp[2], classSob.mAmp[3],
                classSob.mAmp[4],classSob.mAmp[5],classSob.mAmp[6],classSob.mAmp[7],classSob.mAmp[8],classSob.mAmp[9],classSob.mAmp[10], classSob.mAmp[11], classSob.Nnut0,  classSob.Nnut1,  classSob.Nnut2,  classSob.Nnut3,
                classSob.Nnut4,  classSob.Nnut5,  classSob.Nnut6,  classSob.Nnut7,  classSob.Nnut8,  classSob.Nnut9,  classSob.Nnut10,  classSob.Nnut11,  classSob.sig0,  classSob.sig1,  classSob.sig2,  classSob.sig3,
                 classSob.sig4,  classSob.sig5,  classSob.sig6,  classSob.sig7,  classSob.sig8,  classSob.sig9,  classSob.sig10,  classSob.sig11,  classSob.Nnull0, classSob.Nnull1, classSob.Nnull2, classSob.Nnull3,
                classSob.Nnull4, classSob.Nnull5, classSob.Nnull6, classSob.Nnull7, classSob.Nnull8, classSob.Nnull9, classSob.Nnull10, classSob.Nnull11, classSob.mTimeD[0], classSob.mTimeD[1], classSob.mTimeD[2],
                classSob.mTimeD[3], classSob.mTimeD[4], classSob.mTimeD[5], classSob.mTimeD[6], classSob.mTimeD[7], classSob.mTimeD[8], classSob.mTimeD[9], classSob.mTimeD[10], classSob.mTimeD[11] };
                booksTable.Rows.Add(row); // добавляем первую строку

                if(classSob.SumNeu>0)
                {
                    foreach (ClassSobNeutron sobNeutron in classSob.classSobNeutronsList)
                    {
                        DataRow rowN = NeutronTable.NewRow();
                        rowN.ItemArray = new object[] { null, classSob.nameFile, sobNeutron.D, sobNeutron.Amp, classSob.time, sobNeutron.TimeFirst, sobNeutron.TimeFirst3,
                            sobNeutron.TimeAmp, sobNeutron.TimeEnd, sobNeutron.TimeEnd3};
                        NeutronTable.Rows.Add(rowN);
                
                    }
                     

                }
              

            }

            var folderPicker = new Windows.Storage.Pickers.FolderPicker();
            folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add("*");

            Windows.Storage.StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                // Application now has read/write access to all contents in the picked folder
                // (including other sub-folder contents)
                Windows.Storage.AccessCache.StorageApplicationPermissions.
                FutureAccessList.AddOrReplace("PickedFolderToken", folder);

                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

               
           
              


                    // ObservableCollection<ClassSobColl> classSobs = new ObservableCollection<ClassSobColl>();
                    using (StreamWriter writer =
              new StreamWriter(await folder.OpenStreamForWriteAsync(
              "Progect.uranprog", CreationCollisionOption.OpenIfExists)))
                    {

                    bookStore.WriteXml(writer);

                    }
                

            }
            else
            {

            }
            MessageDialog messageDialog = new MessageDialog("Сохранено");
         await   messageDialog.ShowAsync();


        }
       static public async Task<ObservableCollection<ClassSob>> OpenP()
        {
            


                ObservableCollection<ClassSob> classSobsC = new ObservableCollection<ClassSob>();
            try
            {
                var picker = new Windows.Storage.Pickers.FileOpenPicker();
                picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
                picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
                picker.FileTypeFilter.Add(".uranprog");
                picker.FileTypeFilter.Add(".xml");


                Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
                if (file != null)
                {
                    // Application now has read/write access to the picked file
               //     this.textBlock.Text = "Picked photo: " + file.Name;
             //   }
             //   else
             //   {
              //      this.textBlock.Text = "Operation cancelled.";
              //  }


             //   var folderPicker = new Windows.Storage.Pickers.FolderPicker();
               // folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
               // folderPicker.FileTypeFilter.Add("*");

               // Windows.Storage.StorageFolder folder = await folderPicker.PickSingleFolderAsync();
              //  if (folder != null)
               // {
                    // Application now has read/write access to all contents in the picked folder
                    // (including other sub-folder contents)
                  //  Windows.Storage.AccessCache.StorageApplicationPermissions.
                   // FutureAccessList.AddOrReplace("PickedFolderToken", folder);

                   // StorageFolder storageFolder = ApplicationData.Current.LocalFolder;






               
                    using (StreamReader writer =
              new StreamReader(await file.OpenStreamForReadAsync() ))
                    {
                        
                        DataSet ds = new DataSet();

                        ds.ReadXml(writer);
                        
                        // выбираем первую таблицу
                        DataTable SobT = ds.Tables[0];

                      

                    
                        // перебор всех строк таблицы
                        foreach (DataRow row in SobT.Rows)
                        {
                            Debug.WriteLine(row.ItemArray[0].ToString());
                            List<ClassSobNeutron> cll = new List<ClassSobNeutron>();
                            var cells = row.ItemArray;
                       
                            
                            string[] strTime = row.ItemArray[3].ToString().Split('.');



                            //  Debug.WriteLine(time1);
                            DataTimeUR dataTimeUR = new DataTimeUR(0, 0, Convert.ToInt16(strTime[0]), Convert.ToInt16(strTime[1]), Convert.ToInt16(strTime[2]), Convert.ToInt16(strTime[3]),
                                         Convert.ToInt16(strTime[4]), Convert.ToInt16(strTime[5]), Convert.ToInt16(strTime[6]));
                            if (row.ItemArray[1].ToString().Contains("Test"))
                            {
                                string[] vs = row.ItemArray[1].ToString().Split("_");
                                string gg = vs[0] + "_" + vs[2];
                                dataTimeUR.corectTime(gg);
                            }
                            else
                            {
                                dataTimeUR.corectTime(row.ItemArray[1].ToString());
                            }

                            int[] mA = new int[12];
                            for (int i = 0; i < 12; i++)
                            {
                                mA[i] = Convert.ToInt32(row.ItemArray[i + 6]);
                            }
                            
                            int[] mT = new int[12];
                            for (int i = 0; i < 12; i++)
                            {
                                mT[i] = Convert.ToInt32(row.ItemArray[i + 54]);
                            }
                          
                            double[] sT = new double[12];
                            for (int i = 0; i < 12; i++)
                            {
                               // MessageDialog messageDialog4 = new MessageDialog(row.ItemArray[i+30].ToString()+"\t"+i.ToString());
                               // await messageDialog4.ShowAsync();
                            
                                sT[i] = Convert.ToDouble((row.ItemArray[i + 30].ToString().Replace(".", ",")));
                            }
                          
                            if (Convert.ToInt32(row.ItemArray[5]) > 0)
                            {
                               
                                DataTable dNeutron = ds.Tables[1];
                                foreach (DataRow rowN in dNeutron.Rows)
                                {
                                    var cellsN = rowN.ItemArray;
                           
                                    if ((row.ItemArray[1].ToString() == rowN.ItemArray[1].ToString()) && (dataTimeUR.TimeString() == rowN.ItemArray[4].ToString()))
                                    {

 
    cll.Add(new ClassSobNeutron()
    {
        D = Convert.ToInt32(rowN.ItemArray[2]),
        Amp = Convert.ToInt32(rowN.ItemArray[3]),
        TimeAmp = Convert.ToInt32(rowN.ItemArray[7]),
        TimeEnd = Convert.ToInt32(rowN.ItemArray[8]),
        TimeEnd3 = Convert.ToInt32(rowN.ItemArray[9]),
        TimeFirst = Convert.ToInt32(rowN.ItemArray[5]),
        TimeFirst3 = Convert.ToInt32(rowN.ItemArray[6])
    });

                                   
                                    }
                                }

                            }
                     

                            try
                            {


                                classSobsC.Add(new ClassSob()
                                {
                                    nameFile = row.ItemArray[1].ToString(),
                                    nameklaster = row.ItemArray[2].ToString(),
                                    nameBAAK = "У1",
                                    time = dataTimeUR.TimeString(),
                                    mAmp = mA,
                                    dateUR = dataTimeUR,


                                    TimeS0 = Convert.ToString(row.ItemArray[54]),
                                    TimeS1 = Convert.ToString(row.ItemArray[55]),
                                    TimeS2 = Convert.ToString(row.ItemArray[56]),
                                    TimeS3 = Convert.ToString(row.ItemArray[57]),
                                    TimeS4 = Convert.ToString(row.ItemArray[58]),
                                    TimeS5 = Convert.ToString(row.ItemArray[59]),
                                    TimeS6 = Convert.ToString(row.ItemArray[60]),
                                    TimeS7 = Convert.ToString(row.ItemArray[61]),
                                    TimeS8 = Convert.ToString(row.ItemArray[62]),
                                    TimeS9 = Convert.ToString(row.ItemArray[63]),
                                    TimeS10 = Convert.ToString(row.ItemArray[64]),
                                    TimeS11 = Convert.ToString(row.ItemArray[65]),
                                    mTimeD = mT,
                                    sig0 = Convert.ToDouble((row.ItemArray[30].ToString().Replace(".", ","))),
                                    sig1 = Convert.ToDouble((row.ItemArray[31].ToString().Replace(".", ","))),
                                    sig2 = Convert.ToDouble((row.ItemArray[32].ToString().Replace(".", ","))),
                                    sig3 = Convert.ToDouble((row.ItemArray[33].ToString().Replace(".", ","))),
                                    sig4 = Convert.ToDouble((row.ItemArray[34].ToString().Replace(".", ","))),
                                    sig5 = Convert.ToDouble((row.ItemArray[35].ToString().Replace(".", ","))),
                                    sig6 = Convert.ToDouble((row.ItemArray[36].ToString().Replace(".", ","))),
                                    sig7 = Convert.ToDouble((row.ItemArray[37].ToString().Replace(".", ","))),
                                    sig8 = Convert.ToDouble((row.ItemArray[38].ToString().Replace(".", ","))),
                                    sig9 = Convert.ToDouble((row.ItemArray[39].ToString().Replace(".", ","))),
                                    sig10 = Convert.ToDouble((row.ItemArray[40].ToString().Replace(".", ","))),
                                    sig11 = Convert.ToDouble((row.ItemArray[41].ToString().Replace(".", ","))),

                                    Nnull0 = Convert.ToInt16(row.ItemArray[42]),
                                    Nnull1 = Convert.ToInt16(row.ItemArray[43]),
                                    Nnull2 = Convert.ToInt16(row.ItemArray[44]),
                                    Nnull3 = Convert.ToInt16(row.ItemArray[45]),
                                    Nnull4 = Convert.ToInt16(row.ItemArray[46]),
                                    Nnull5 = Convert.ToInt16(row.ItemArray[47]),
                                    Nnull6 = Convert.ToInt16(row.ItemArray[48]),
                                    Nnull7 = Convert.ToInt16(row.ItemArray[49]),
                                    Nnull8 = Convert.ToInt16(row.ItemArray[50]),
                                    Nnull9 = Convert.ToInt16(row.ItemArray[51]),
                                    Nnull10 = Convert.ToInt16(row.ItemArray[52]),
                                    Nnull11 = Convert.ToInt16(row.ItemArray[53]),
                                    classSobNeutronsList = cll

                                });
                            }
                            catch(Exception ex)
                            {
                                MessageDialog messageDialogf1 = new MessageDialog("dfsfs"+ex.ToString());
                                await messageDialogf1.ShowAsync();
                            }
                            //booksTable.Columns.Add(idColumn);
                            // booksTable.Columns.Add(FileColumn);
                            //booksTable.Columns.Add(klColumn);
                            //    booksTable.Columns.Add(TimeColumn);
                            // booksTable.Columns.Add(SAColumn);
                            //   booksTable.Columns.Add(SNColumn);

                            /*   booksTable.Columns.Add(AD1Column);
                               booksTable.Columns.Add(AD2Column);
                               booksTable.Columns.Add(AD3Column);
                               booksTable.Columns.Add(AD4Column);
                               booksTable.Columns.Add(AD5Column);
                               booksTable.Columns.Add(AD6Column);
                               booksTable.Columns.Add(AD7Column);
                               booksTable.Columns.Add(AD8Column);
                               booksTable.Columns.Add(AD9Column);
                               booksTable.Columns.Add(AD10Column);
                               booksTable.Columns.Add(AD11Column);
                               booksTable.Columns.Add(AD12Column);

                               booksTable.Columns.Add(ND1Column);
                               booksTable.Columns.Add(ND2Column);
                               booksTable.Columns.Add(ND3Column);
                               booksTable.Columns.Add(ND4Column);
                               booksTable.Columns.Add(ND5Column);
                               booksTable.Columns.Add(ND6Column);
                               booksTable.Columns.Add(ND7Column);
                               booksTable.Columns.Add(ND8Column);
                               booksTable.Columns.Add(ND9Column);
                               booksTable.Columns.Add(ND10Column);
                               booksTable.Columns.Add(ND11Column);
                               booksTable.Columns.Add(ND12Column);

                               booksTable.Columns.Add(Sig1Column);
                               booksTable.Columns.Add(Sig2Column);
                               booksTable.Columns.Add(Sig3Column);
                               booksTable.Columns.Add(Sig4Column);
                               booksTable.Columns.Add(Sig5Column);
                               booksTable.Columns.Add(Sig6Column);
                               booksTable.Columns.Add(Sig7Column);
                               booksTable.Columns.Add(Sig8Column);
                               booksTable.Columns.Add(Sig9Column);
                               booksTable.Columns.Add(Sig10Column);
                               booksTable.Columns.Add(Sig11Column);
                               booksTable.Columns.Add(Sig12Column);

                               booksTable.Columns.Add(NullD1Column);
                               booksTable.Columns.Add(NullD2Column);
                               booksTable.Columns.Add(NullD3Column);
                               booksTable.Columns.Add(NullD4Column);
                               booksTable.Columns.Add(NullD5Column);
                               booksTable.Columns.Add(NullD6Column);
                               booksTable.Columns.Add(NullD7Column);
                               booksTable.Columns.Add(NullD8Column);
                               booksTable.Columns.Add(NullD9Column);
                               booksTable.Columns.Add(NullD10Column);
                               booksTable.Columns.Add(NullD11Column);
                               booksTable.Columns.Add(NullD12Column);

                               booksTable.Columns.Add(TD1Column);
                               booksTable.Columns.Add(TD2Column);
                               booksTable.Columns.Add(TD3Column);
                               booksTable.Columns.Add(TD4Column);
                               booksTable.Columns.Add(TD5Column);
                               booksTable.Columns.Add(TD6Column);
                               booksTable.Columns.Add(TD7Column);
                               booksTable.Columns.Add(TD8Column);
                               booksTable.Columns.Add(TD9Column);
                               booksTable.Columns.Add(TD10Column);
                               booksTable.Columns.Add(TD11Column);
                               booksTable.Columns.Add(TD12Column);
                               */


                        }

                    }


                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageDialog messageDialogf = new MessageDialog(ex.ToString());
                await messageDialogf.ShowAsync();
            }
            return classSobsC;
            
         
        }
    }
}
