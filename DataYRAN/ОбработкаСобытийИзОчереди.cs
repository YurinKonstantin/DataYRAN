using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Popups;


namespace DataYRAN
{
    public sealed partial class BlankPageObrData
    {

     
        public async Task WriteInFileIzOcherediAsync(CancellationToken cancellationToken, ClassUserSetUp classUserSetUp)//работа с данными из очереди
        {


            try
            {


                while (true)
                {
                   
                    if (cancellationToken.IsCancellationRequested)
                    {
                        //Thread.Sleep(50);
                        while (OcherediNaObrab.Count != 0)
                        {
                            await Obr(classUserSetUp);
                        }
                        break;
                    }
                    await Obr(classUserSetUp);
                }
            }
            catch(Exception ex)
            {

            }
        }
        object locker = new object();
        private async Task<List<ClassSobNeutron>> neutron(int[,] n, double[] masnul, bool bad)//out int[] coutN,
        {
           
            //List<ClassSobNeutron> listNet= new List<ClassSobNeutron>();
            int? dlitOtb = ClassUserSetUp.DlitN3;
            int? AmpOtbora = ClassUserSetUp.PorogN;
            int[] coutN = new int[12];
           
            int Nu;
            int? AmpOtbora1;
            List<ClassSobNeutron> clasNeu = new List<ClassSobNeutron>(); 
            for (int i = 0; i < 12; i++)
            {

              
                Nu = Convert.ToInt32(masnul[i]);
                AmpOtbora1 = AmpOtbora + Nu;
                

                for (int j = 100; j < 20000; j++) 
                {
                  
                    int Amp = n[i, j];
                    if (Amp >= AmpOtbora1)//ищем претендента на нейтрон по порогу
                    {
                        int countmaxtime = j;
                        int countfirsttime = j;
                        int countendtime = j;
                        int countfirsttime3 = j;
                        int countendtime3 = j;
                       
                        
                        int v = Amp;
                        int v1 = Amp;
                        while (v > Nu+3 && v1> Nu + 3)//Ищем конец сигнала претендента нейтрона на уровне 3
                        {
                            countendtime3++;
                            countfirsttime3--;
                            if (countendtime3 < 20000)
                            {
                                v = n[i, countendtime3];
                            }
                            else
                            {
                                countendtime3--;
                               
                            }
                            if (countfirsttime3 > 100)
                            {
                                v1 = n[i, countfirsttime3];

                            }
                            else
                            {
                                countfirsttime3++;
                            }
                        }
                       

                        if (countendtime3 - countfirsttime3 >= dlitOtb)
                        {
                            countendtime = countendtime3;
                            countfirsttime = countfirsttime3;
                            v = Amp;
                            v1 = Amp;
                            while (v > Nu && v1>Nu)
                            {
                                countendtime++;
                                countfirsttime--;
                                if (countendtime >19999 || countfirsttime < 90)
                                {
                                    break;
                                }
                                v = n[i, countendtime];
                                v1 = n[i, countfirsttime];
                            }

                         
                           
                       

                            for (int v11 = countfirsttime3; v11 <= countendtime3; v11++)//точка максимум и значение максимум
                            {

                                if (Amp <= n[i, v11])
                                {
                                    Amp = n[i, v11];
                                    countmaxtime = v11;

                                }

                            }
                           
                                try
                                {
                                    int dd = i + 1;
                                    Amp = Amp - Nu;
                                 
                                    if (!bad)
                                    {
                                   
                               
                                
                                    
                                            clasNeu.Add(new ClassSobNeutron()
                                            { D = dd, Amp = Amp, TimeAmp = countmaxtime, TimeEnd = countendtime, TimeEnd3 = countendtime3, TimeFirst = countfirsttime, TimeFirst3 = countfirsttime3 });
                                       
                                    }
                                }
                                catch 
                                {
                                   
                                }
                        }
                        if (countendtime + 2 < 19999)
                            j = countendtime + 2;
                    }
                   
                }

              
  
            }

            return clasNeu;

        }
      
        public async Task Obr(ClassUserSetUp classUserSetUp)
        {
            
            if (OcherediNaObrab.Count > 0)
            {
               
                   
                    string time1 = String.Empty;
                    OcherediNaObrab.TryDequeue(out MyclasDataizFile ObrD);
                    if (ObrD != null)
                    {
                        
                        
                        switch (ObrD.tipName)
                        {
                           
                            case "T":
                                try
                                {


                                    string ss = ParserBAAK12.ParseBinFileBAAK12.ParseBinFileBAAK200H(ObrD.Buf00, out int[,] data1, out time1, out int[,] dataTail1);
                                 
                                   
                                        if(SaveFileDelegate !=null)
                                        {
                                            await SaveFileDelegate?.Invoke(data1, dataTail1, time1, ObrD.NameFile);
                                        }
                                     
                                 
                                    
                                    
                                        if (ss == "1")
                                        {
                                            int t = 0;
                                            string[] strTime = time1.Split('.');
                                            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                () =>
                {
                    t = Convert.ToInt32(TimeCorect.Text);
                });
                                    DataTimeUR dataTimeUR = new DataTimeUR(0,0, Convert.ToInt16(strTime[0]), Convert.ToInt16(strTime[1]), Convert.ToInt16(strTime[2])+t, Convert.ToInt16(strTime[3]),
                                         Convert.ToInt16(strTime[4]), Convert.ToInt16(strTime[5]), Convert.ToInt16(strTime[6]));
                                    dataTimeUR.corectTime(ObrD.NameFile);
                                            time1 = strTime[0] + "." + strTime[1] + "." + (Convert.ToInt32(strTime[2]) + t).ToString("00") + "." + strTime[3] + "." + strTime[4] + "." + strTime[5] + "." + strTime[6];

                                            await ObrSigData(ObrD.NameFile, ObrD.NameBaaR12.ToString(), data1, dataTail1, time1, ObrD.tipName, classUserSetUp, dataTimeUR);
                                        }
                                    
                                   
                                

                                    ObrD = null;
                                }
                                catch(Exception ex)
                                {

                                }

                                break;
                            case "N":
                                try
                                {
                                    int[,] dataTail1 = new int[12, 20000];
                                    ParserBAAK12.ParseBinFileBAAK12.ParseBinFileBAAK200(ObrD.Buf00, 1, out int[,] data1, out time1);
                                    try
                                    {
                                       
                                        await SaveFileDelegate(data1, dataTail1, time1, ObrD.NameFile);
                                    }
                                    catch
                                    {

                                    }
                                    try
                                    {
                                        int t = 0;
                                        string[] strTime = time1.Split('.');
                                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
            () =>
            {
                t = Convert.ToInt32(TimeCorect.Text);
            });
                                        time1 = strTime[0] + "." + strTime[1] + "." + (Convert.ToInt32(strTime[2]) + t).ToString() + "." + strTime[3] + "." + strTime[4] + "." + strTime[5] + "." + strTime[6];

                                        await ObrSigData(ObrD.НулеваяЛиния, ObrD.NameFile, ObrD.NameBaaR12.ToString(), data1, time1, ObrD.tipName, classUserSetUp);
                                    }
                                    catch (Exception ex)
                                    {
                                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
            () =>
            {
                var mess = new MessageDialog("dss" + "\n" + ex.Message.ToString() + "\n" + ex.ToString());
                mess.ShowAsync();// КолПакетовОчер++;
        });
                                    }

                                    ObrD = null;
                                }
                                catch(Exception ex)
                                {

                                }
                                break;

                            case "V":
                                try
                                {

                                    int[,] dataTail1 = new int[12, 20000];
                                    ParserBAAK12.ParseBinFileBAAK12.ParseBinFileBAAK200(ObrD.Buf00, 2, out int[,] data1, out time1);
                                    try
                                    {
                                        
                                        await SaveFileDelegate(data1, dataTail1, time1, ObrD.NameFile);
                                    }
                                    catch
                                    {

                                    }
                                    try
                                    {
                                        int t = 0;
                                        string[] strTime = time1.Split('.');
                                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
            () =>
            {
                t = Convert.ToInt32(TimeCorect.Text);
            });
                                        time1 = strTime[0] + "." + strTime[1] + "." + (Convert.ToInt32(strTime[2]) + t).ToString() + "." + strTime[3] + "." + strTime[4] + "." + strTime[5] + "." + strTime[6];

                                        await ObrSigData(ObrD.НулеваяЛиния, ObrD.NameFile, ObrD.NameBaaR12.ToString(), data1, time1, ObrD.tipName, classUserSetUp);
                                    }
                                    catch (Exception ex)
                                    {
                                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
            () =>
            {
                var mess = new MessageDialog("dss" + "\n" + ex.Message.ToString() + "\n" + ex.ToString());
                mess.ShowAsync();// КолПакетовОчер++;
        });
                                    }

                                    ObrD = null;
                                }
                                catch(Exception ex)
                                {

                                }
                                break;
                            default:
                                
                                break;
                        }
                      


                    }
                
            }
        }

        public async Task ObrSigData(string nameFile, string nemeBAAK,   int[,] data1, int[,] dataTail1, string time1, string tipN, ClassUserSetUp classUserSetUp, DataTimeUR dataTimeUR)
        {

    
            int[] Amp = new int[12];
            double[] Nul = new double[12];
            int[] coutN1 = new int[12];
            double[] sig = new double[12];
            bool bad = false;
            int[] timeS = new int[12];
            List<ClassSobNeutron> cll = new List<ClassSobNeutron>();


            try
            {
               
                     ParserBAAK12.ParseBinFileBAAK12.MaxAmpAndNul(data1, ref sig, ref Amp, ref Nul, ref bad, ClassUserSetUp.ObrNoise, ClassUserSetUp.KoefNoise, classUserSetUp.PorogS);
            
                if (!bad)
                {


                    cll = await neutron(dataTail1, Nul, bad);
                    timeS = ParserBAAK12.ParseBinFileBAAK12.TimeS(data1, classUserSetUp.PorogS, Amp, Nul);
                }
             
            }

            catch (Exception ex)
            {

            }
           
            string[] array = nameFile.Split('_');
            string nameFileNew = String.Empty;
            string nameKlNew = String.Empty;
            if(array.Length>2)
            {
                nameFileNew = nameFile;
                nameKlNew = array[0];
            }
            if(array.Length==2)
            {
                nameFileNew = array[0].Split("№")[1]+"_"+array[1]+"_"+"T";
                nameKlNew= array[0].Split("№")[1];
            }

            if (!bad)
            {
             
                
                            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
     () =>
     {
         ViewModel.ClassSobsT.Add(new ClassSob()
         {
             nameFile = nameFileNew,
             nameklaster = nameKlNew,
             nameBAAK = nemeBAAK,
             time = dataTimeUR.TimeString(),
             mAmp=Amp,
         dateUR=dataTimeUR,
             /*Amp0 = Convert.ToInt16(Amp[0]),
             Amp1 = Convert.ToInt16(Amp[1]),
             Amp2 = Convert.ToInt16(Amp[2]),
             Amp3 = Convert.ToInt16(Amp[3]),
             Amp4 = Convert.ToInt16(Amp[4]),
             Amp5 = Convert.ToInt16(Amp[5]),
             Amp6 = Convert.ToInt16(Amp[6]),
             Amp7 = Convert.ToInt16(Amp[7]),
             Amp8 = Convert.ToInt16(Amp[8]),
             Amp9 = Convert.ToInt16(Amp[9]),
             Amp10 = Convert.ToInt16(Amp[10]),
             Amp11 = Convert.ToInt16(Amp[11]),
             */
             //Nnut0 = Convert.ToInt16(coutN1[0]),
             //Nnut1 = Convert.ToInt16(coutN1[1]),
            // Nnut2 = Convert.ToInt16(coutN1[2]),
            // Nnut3 = Convert.ToInt16(coutN1[3]),
             //Nnut4 = Convert.ToInt16(coutN1[4]),
             //Nnut5 = Convert.ToInt16(coutN1[5]),
           //  Nnut6 = Convert.ToInt16(coutN1[6]),
            // Nnut7 = Convert.ToInt16(coutN1[7]),
            // Nnut8 = Convert.ToInt16(coutN1[8]),
           //  Nnut9 = Convert.ToInt16(coutN1[9]),
            // Nnut10 = Convert.ToInt16(coutN1[10]),
            // Nnut11 = Convert.ToInt16(coutN1[11]),
             TimeS0 = timeS[0].ToString(),
             TimeS1 = timeS[1].ToString(),
             TimeS2 = timeS[2].ToString(),
             TimeS3 = timeS[3].ToString(),
             TimeS4 = timeS[4].ToString(),
             TimeS5 = timeS[5].ToString(),
             TimeS6 = timeS[6].ToString(),
             TimeS7 = timeS[7].ToString(),
             TimeS8 = timeS[8].ToString(),
             TimeS9 = timeS[9].ToString(),
             TimeS10 = timeS[10].ToString(),
             TimeS11 = timeS[11].ToString(),
             mTimeD=timeS,
             sig0 = sig[0],
             sig1 = sig[1],
             sig2 = sig[2],
             sig3 = sig[3],
             sig4 = sig[4],
             sig5 = sig[5],
             sig6 = sig[6],
             sig7 = sig[7],
             sig8 = sig[8],
             sig9 = sig[9],
             sig10 = sig[10],
             sig11 = sig[11],
            // SumAmp = Convert.ToInt32(Amp.Sum()),
             //SumNeu = coutN1.Sum(),
             Nnull0 = Convert.ToInt16(Nul[0]),
             Nnull1 = Convert.ToInt16(Nul[1]),
             Nnull2 = Convert.ToInt16(Nul[2]),
             Nnull3 = Convert.ToInt16(Nul[3]),
             Nnull4 = Convert.ToInt16(Nul[4]),
             Nnull5 = Convert.ToInt16(Nul[5]),
             Nnull6 = Convert.ToInt16(Nul[6]),
             Nnull7 = Convert.ToInt16(Nul[7]),
             Nnull8 = Convert.ToInt16(Nul[8]),
             Nnull9 = Convert.ToInt16(Nul[9]),
             Nnull10 = Convert.ToInt16(Nul[10]),
             Nnull11 = Convert.ToInt16(Nul[11]),
             classSobNeutronsList=cll


         });
         ViewModel.CountObrabSob++;

     });
                        
                      
 
            }
            else
            {

               
                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
 () => {
     ViewModel._DataColecSobPloxT.Add(new ClassSob()
     {
         nameFile = nameFile,
         nameklaster = array[0],
         nameBAAK = nemeBAAK,
         time = time1,
         mAmp = Amp,
         /* Amp0 = Convert.ToInt16(Amp[0]),
          Amp1 = Convert.ToInt16(Amp[1]),
          Amp2 = Convert.ToInt16(Amp[2]),
          Amp3 = Convert.ToInt16(Amp[3]),
          Amp4 = Convert.ToInt16(Amp[4]),
          Amp5 = Convert.ToInt16(Amp[5]),
          Amp6 = Convert.ToInt16(Amp[6]),
          Amp7 = Convert.ToInt16(Amp[7]),
          Amp8 = Convert.ToInt16(Amp[8]),
          Amp9 = Convert.ToInt16(Amp[9]),
          Amp10 = Convert.ToInt16(Amp[10]),
          Amp11 = Convert.ToInt16(Amp[11]),
          */
       //  Nnut0 = Convert.ToInt16(coutN1[0]),
        // Nnut1 = Convert.ToInt16(coutN1[1]),
        // Nnut2 = Convert.ToInt16(coutN1[2]),
        // Nnut3 = Convert.ToInt16(coutN1[3]),
       //  Nnut4 = Convert.ToInt16(coutN1[4]),
        // Nnut5 = Convert.ToInt16(coutN1[5]),
        //Nnut6 = Convert.ToInt16(coutN1[6]),
       //  Nnut7 = Convert.ToInt16(coutN1[7]),
        // Nnut8 = Convert.ToInt16(coutN1[8]),
       //  Nnut9 = Convert.ToInt16(coutN1[9]),
       //  Nnut10 = Convert.ToInt16(coutN1[10]),
       //  Nnut11 = Convert.ToInt16(coutN1[11]),
         TimeS0 = timeS[0].ToString(),
         TimeS1 = timeS[1].ToString(),
         TimeS2 = timeS[2].ToString(),
         TimeS3 = timeS[3].ToString(),
         TimeS4 = timeS[4].ToString(),
         TimeS5 = timeS[5].ToString(),
         TimeS6 = timeS[6].ToString(),
         TimeS7 = timeS[7].ToString(),
         TimeS8 = timeS[8].ToString(),
         TimeS9 = timeS[9].ToString(),
         TimeS10 = timeS[10].ToString(),
         TimeS11 = timeS[11].ToString(),
         mTimeD=timeS,
         sig0 = sig[0],
         sig1 = sig[1],
         sig2 = sig[2],
         sig3 = sig[3],
         sig4 = sig[4],
         sig5 = sig[5],
         sig6 = sig[6],
         sig7 = sig[7],
         sig8 = sig[8],
         sig9 = sig[9],
         sig10 = sig[10],
         sig11 = sig[11],
        // SumAmp = Convert.ToInt32(Amp.Sum()),
         //SumNeu = coutN1.Sum(),
         Nnull0 = Convert.ToInt16(Nul[0]),
         Nnull1 = Convert.ToInt16(Nul[1]),
         Nnull2 = Convert.ToInt16(Nul[2]),
         Nnull3 = Convert.ToInt16(Nul[3]),
         Nnull4 = Convert.ToInt16(Nul[4]),
         Nnull5 = Convert.ToInt16(Nul[5]),
         Nnull6 = Convert.ToInt16(Nul[6]),
         Nnull7 = Convert.ToInt16(Nul[7]),
         Nnull8 = Convert.ToInt16(Nul[8]),
         Nnull9 = Convert.ToInt16(Nul[9]),
         Nnull10 = Convert.ToInt16(Nul[10]),
         Nnull11 = Convert.ToInt16(Nul[11]),



     });

 });
                      
                  
                   
                
            }
          


        }
        public async Task ObrSigData(int[] nul, string nameFile, string nemeBAAK, int[,] data1, string time1, string tipN, ClassUserSetUp classUserSetUp)
        {


            int[] Amp = new int[12];
            double[] Nul = new double[12];
            int[] coutN1 = new int[12];
            Double[] sig = new Double[12];
            bool bad = false;
            int[] timeS = new int[12];
            double[] sumDetQ = new double[12];
            double[,] data1S = new double[12, 1024];
            int[] maxTime = new int[12];
            int[] PolovmaxTime = new int[12];
            int[] maxAmp = new int[12];
            int d = 1;
            int[] firstTimeN = new int[12];


            try
            {

             

                switch (tipN)
                {
                    
                    case "N":
                        ParserBAAK12.ParseBinFileBAAK12.MaxAmpAndNul(data1, ref sig, ref Amp, ref Nul, ref bad, ClassUserSetUp.ObrNoise, ClassUserSetUp.KoefNoise, classUserSetUp.PorogS);

                        for (int i = 0; i < 12; i++)
                        {


                            for (int j = 0; j < 1024; j++)
                            {
                                data1S[i, j] = Convert.ToDouble(data1[i, j]) - Nul[i];
                            }


                        }

                        ParserBAAK12.ParseBinFileBAAK12.SumSig(data1S, out sumDetQ);
                        break;
                    case "V":



                        ParserBAAK12.ParseBinFileBAAK12.MaxAmpAndNul(data1, ref sig, ref Amp, ref Nul, ref bad, ClassUserSetUp.ObrNoise, ClassUserSetUp.KoefNoise, classUserSetUp.PorogS);
                        ObrabotcaURAN.Obrabotca.AmpAndTime(data1, Nul, out maxTime, out maxAmp);
                        bool dN = ObrabotcaURAN.Obrabotca.Dneutron(maxAmp, classUserSetUp.PorogSN, out d);
                        firstTimeN = ObrabotcaURAN.Obrabotca.FirstTme(maxTime, maxAmp, classUserSetUp.PorogS, data1, Nul, ref PolovmaxTime);
                        var mess = new MessageDialog("dss" + "\n" + PolovmaxTime[0]);
                        await mess.ShowAsync();// КолПакетовОчер++;
                        break;
                    default:

                        break;
                }


              
                timeS = ParserBAAK12.ParseBinFileBAAK12.TimeS(data1, classUserSetUp.PorogS, Amp, Nul);
            }

            catch (Exception ex)
            {

            }

            string[] array = nameFile.Split('_');
            string nameFileNew = String.Empty;
            string nameKlNew = String.Empty;
            if (array.Length > 2)
            {
                nameFileNew = nameFile;
                nameKlNew = array[0];
            }
            if (array.Length == 2)
            {
                nameFileNew = array[0].Split("№")[1] + "_" + array[1] + "_" + "T";
                nameKlNew = array[0].Split("№")[1];
            }

            if (!bad)
            {
                switch (tipN)
                {
                    
                    case "N":
                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
     () => {
         ViewModel.ClassSobsN.Add(new ClassSobN()
         {
             nameFile = nameFile,
             nameklaster = array[0],
             nameBAAK = nemeBAAK,
             time = time1,
             Amp0 = Convert.ToInt16(Amp[0]),
             Amp1 = Convert.ToInt16(Amp[1]),
             Amp2 = Convert.ToInt16(Amp[2]),
             Amp3 = Convert.ToInt16(Amp[3]),
             Amp4 = Convert.ToInt16(Amp[4]),
             Amp5 = Convert.ToInt16(Amp[5]),
             Amp6 = Convert.ToInt16(Amp[6]),
             Amp7 = Convert.ToInt16(Amp[7]),
             Amp8 = Convert.ToInt16(Amp[8]),
             Amp9 = Convert.ToInt16(Amp[9]),
             Amp10 = Convert.ToInt16(Amp[10]),
             Amp11 = Convert.ToInt16(Amp[11]),

             TimeS0 = timeS[0].ToString(),
             TimeS1 = timeS[1].ToString(),
             TimeS2 = timeS[2].ToString(),
             TimeS3 = timeS[3].ToString(),
             TimeS4 = timeS[4].ToString(),
             TimeS5 = timeS[5].ToString(),
             TimeS6 = timeS[6].ToString(),
             TimeS7 = timeS[7].ToString(),
             TimeS8 = timeS[8].ToString(),
             TimeS9 = timeS[9].ToString(),
             TimeS10 = timeS[10].ToString(),
             TimeS11 = timeS[11].ToString(),
            
             sig0 = sig[0],
             sig1 = sig[1],
             sig2 = sig[2],
             sig3 = sig[3],
             sig4 = sig[4],
             sig5 = sig[5],
             sig6 = sig[6],
             sig7 = sig[7],
             sig8 = sig[8],
             sig9 = sig[9],
             sig10 = sig[10],
             sig11 = sig[11],
             SumAmp = Convert.ToInt32(Amp.Sum()),


             QS0 = sumDetQ[0],
             QS1 = sumDetQ[1],
             QS2 = sumDetQ[2],
             QS3 = sumDetQ[3],
             QS4 = sumDetQ[4],
             QS5 = sumDetQ[5],
             QS6 = sumDetQ[6],
             QS7 = sumDetQ[7],
             QS8 = sumDetQ[8],
             QS9 = sumDetQ[9],
             QS10 = sumDetQ[10],
             QS11 = sumDetQ[11]

         });
         ViewModel.CountObrabSob++;

     });
                        break;
                    case "V":
                        try
                        {


                            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
        () =>
        {

            ViewModel.ClassSobsV.Add(new ClassSobV()
            {
                nameFile = nameFile,
                nameklaster = array[0],
                nameBAAK = nemeBAAK,
                time = time1,
                Amp0 = Convert.ToInt16(maxAmp[0]),
                Amp1 = Convert.ToInt16(maxAmp[1]),
                Amp2 = Convert.ToInt16(maxAmp[2]),
                Amp3 = Convert.ToInt16(maxAmp[3]),
                Amp4 = Convert.ToInt16(maxAmp[4]),
                Amp5 = Convert.ToInt16(maxAmp[5]),
                Amp6 = Convert.ToInt16(maxAmp[6]),
                Amp7 = Convert.ToInt16(maxAmp[7]),
                Amp8 = Convert.ToInt16(maxAmp[8]),
                Amp9 = Convert.ToInt16(maxAmp[9]),
                Amp10 = Convert.ToInt16(maxAmp[10]),
                Amp11 = Convert.ToInt16(maxAmp[11]),
                maxTimeV = maxTime,
                PolmaxTimeV = PolovmaxTime,

                sig0 = sig[0],
                sig1 = sig[1],
                sig2 = sig[2],
                sig3 = sig[3],
                sig4 = sig[4],
                sig5 = sig[5],
                sig6 = sig[6],
                sig7 = sig[7],
                sig8 = sig[8],
                sig9 = sig[9],
                sig10 = sig[10],
                sig11 = sig[11],

                Nnull0 = Convert.ToInt16(Nul[0]),
                Nnull1 = Convert.ToInt16(Nul[1]),
                Nnull2 = Convert.ToInt16(Nul[2]),
                Nnull3 = Convert.ToInt16(Nul[3]),
                Nnull4 = Convert.ToInt16(Nul[4]),
                Nnull5 = Convert.ToInt16(Nul[5]),
                Nnull6 = Convert.ToInt16(Nul[6]),
                Nnull7 = Convert.ToInt16(Nul[7]),
                Nnull8 = Convert.ToInt16(Nul[8]),
                Nnull9 = Convert.ToInt16(Nul[9]),
                Nnull10 = Convert.ToInt16(Nul[10]),
                Nnull11 = Convert.ToInt16(Nul[11]),
                AmpNV = maxAmp[d - 1],
                nV = d,
                FirstTimeV = firstTimeN,
                MaxTime = maxTime[d - 1]



            });
            ViewModel.CountObrabSob++;

        });
                        }
                        catch (Exception ex)
                        {
                            MessageDialog messageDialog = new MessageDialog(ex.ToString());
                            await messageDialog.ShowAsync();
                        }
                        break;
                    default:

                        break;
                }




            }
            else
            {

                switch (tipN)
                {
                   
                    case "N":
                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
     () => {
         ViewModel._DataColecSobPloxN.Add(new ClassSobN()
         {
             nameFile = nameFile,
             nameklaster = array[0],
             nameBAAK = nemeBAAK,
             time = time1,
             Amp0 = Convert.ToInt16(Amp[0]),
             Amp1 = Convert.ToInt16(Amp[1]),
             Amp2 = Convert.ToInt16(Amp[2]),
             Amp3 = Convert.ToInt16(Amp[3]),
             Amp4 = Convert.ToInt16(Amp[4]),
             Amp5 = Convert.ToInt16(Amp[5]),
             Amp6 = Convert.ToInt16(Amp[6]),
             Amp7 = Convert.ToInt16(Amp[7]),
             Amp8 = Convert.ToInt16(Amp[8]),
             Amp9 = Convert.ToInt16(Amp[9]),
             Amp10 = Convert.ToInt16(Amp[10]),
             Amp11 = Convert.ToInt16(Amp[11]),

             TimeS0 = timeS[0].ToString(),
             TimeS1 = timeS[1].ToString(),
             TimeS2 = timeS[2].ToString(),
             TimeS3 = timeS[3].ToString(),
             TimeS4 = timeS[4].ToString(),
             TimeS5 = timeS[5].ToString(),
             TimeS6 = timeS[6].ToString(),
             TimeS7 = timeS[7].ToString(),
             TimeS8 = timeS[8].ToString(),
             TimeS9 = timeS[9].ToString(),
             TimeS10 = timeS[10].ToString(),
             TimeS11 = timeS[11].ToString(),
             sig0 = sig[0],
             sig1 = sig[1],
             sig2 = sig[2],
             sig3 = sig[3],
             sig4 = sig[4],
             sig5 = sig[5],
             sig6 = sig[6],
             sig7 = sig[7],
             sig8 = sig[8],
             sig9 = sig[9],
             sig10 = sig[10],
             sig11 = sig[11],
             SumAmp = Convert.ToInt32(Amp.Sum()),

             QS0 = sumDetQ[0],
             QS1 = sumDetQ[1],
             QS2 = sumDetQ[2],
             QS3 = sumDetQ[3],
             QS4 = sumDetQ[4],
             QS5 = sumDetQ[5],
             QS6 = sumDetQ[6],
             QS7 = sumDetQ[7],
             QS8 = sumDetQ[8],
             QS9 = sumDetQ[9],
             QS10 = sumDetQ[10],
             QS11 = sumDetQ[11]

         });

     });
                        break;
                    case "V":
                        ViewModel._DataColecSobPloxV.Add(new ClassSobV()
                        {
                            nameFile = nameFile,
                            nameklaster = array[0],
                            nameBAAK = nemeBAAK,
                            time = time1,
                            Amp0 = Convert.ToInt16(maxAmp[0]),
                            Amp1 = Convert.ToInt16(maxAmp[1]),
                            Amp2 = Convert.ToInt16(maxAmp[2]),
                            Amp3 = Convert.ToInt16(maxAmp[3]),
                            Amp4 = Convert.ToInt16(maxAmp[4]),
                            Amp5 = Convert.ToInt16(maxAmp[5]),
                            Amp6 = Convert.ToInt16(maxAmp[6]),
                            Amp7 = Convert.ToInt16(maxAmp[7]),
                            Amp8 = Convert.ToInt16(maxAmp[8]),
                            Amp9 = Convert.ToInt16(maxAmp[9]),
                            Amp10 = Convert.ToInt16(maxAmp[10]),
                            Amp11 = Convert.ToInt16(maxAmp[11]),
                            PolmaxTimeV = PolovmaxTime,

                            sig0 = sig[0],
                            sig1 = sig[1],
                            sig2 = sig[2],
                            sig3 = sig[3],
                            sig4 = sig[4],
                            sig5 = sig[5],
                            sig6 = sig[6],
                            sig7 = sig[7],
                            sig8 = sig[8],
                            sig9 = sig[9],
                            sig10 = sig[10],
                            sig11 = sig[11],

                            Nnull0 = Convert.ToInt16(Nul[0]),
                            Nnull1 = Convert.ToInt16(Nul[1]),
                            Nnull2 = Convert.ToInt16(Nul[2]),
                            Nnull3 = Convert.ToInt16(Nul[3]),
                            Nnull4 = Convert.ToInt16(Nul[4]),
                            Nnull5 = Convert.ToInt16(Nul[5]),
                            Nnull6 = Convert.ToInt16(Nul[6]),
                            Nnull7 = Convert.ToInt16(Nul[7]),
                            Nnull8 = Convert.ToInt16(Nul[8]),
                            Nnull9 = Convert.ToInt16(Nul[9]),
                            Nnull10 = Convert.ToInt16(Nul[10]),
                            Nnull11 = Convert.ToInt16(Nul[11]),
                            AmpNV = maxAmp[d],
                            nV = d,
                            FirstTimeV = firstTimeN,
                            MaxTime = maxTime[d]



                        });
                        break;
                    default:

                        break;
                }
            }



        }
    }
}
