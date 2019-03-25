using System;
using System.Collections.Generic;using System.Linq;

using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Popups;


namespace DataYRAN
{
    public sealed partial class BlankPageObrData
    {

     
        public async Task WriteInFileIzOcherediAsync(CancellationToken cancellationToken)//работа с данными из очереди
        {

            

                while (true)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        //Thread.Sleep(50);
                        while (OcherediNaObrab.Count != 0)
                        {
                          await  Obr();
                        }
                    break;
                    }
                 await Obr();
                }
        }

        private async Task<int[]> neutron(int[,] n, string timeSob, double[] masnul, string nemeF, bool bad)//out int[] coutN,
        {
            //List<ClassSobNeutron> listNet= new List<ClassSobNeutron>();
            int? dlitOtb = ClassUserSetUp.DlitN3;
            int? AmpOtbora = ClassUserSetUp.PorogN;
            int[] coutN = new int[12];
     
            for (int i = 0; i < 12; i++)
            {

                int countnutron = 0;
                int Nu = Convert.ToInt32(masnul[i]);
                int? AmpOtbora1 = AmpOtbora + Nu;
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
                        while (v > Nu+3)//Ищем конец сигнала претендента нейтрона на уровне 3
                        {
                            countendtime3++;
                            if (countendtime3 < 20000)
                            {
                                v = n[i, countendtime3];
                            }
                            else
                            {
                                countendtime3--;
                                break;
                            }
                        }
                        v = Amp;
                        
                        while (v > Nu+3)//Ищем конец сигнала претендента нейтрона
                        {
                            countfirsttime3--;
                            v = n[i, countfirsttime3];
                        }

                        if (countendtime3 - countfirsttime3 >= dlitOtb)
                        {
                            countendtime = countendtime3;
                            v = Amp;
                            while (v > Nu)
                            {
                                countendtime++;
                                if(countendtime >19999)
                                {
                                    break;
                                }
                                v = n[i, countendtime];
                            }

                            v = Amp;
                            countfirsttime = countfirsttime3;
                            while (v > Nu)
                            {
                                countfirsttime--;
                                if (countfirsttime < 0)
                                    break;
                                v = n[i, countfirsttime];
                            }

                            for (int v1 = countfirsttime3; v1 <= countendtime3; v1++)//точка максимум и значение максимум
                            {

                                if (Amp < n[i, v1])
                                {
                                    Amp = n[i, v1];
                                    countmaxtime = v1;

                                }

                            }
                           
                                try
                                {
                                    int dd = i + 1;
                                    Amp = Amp - Nu;
                                    countnutron++;
                                    if (!bad)
                                    {
                                  
                                    await  Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                                        {
                                            ViewModel.ClassSobNeutrons.Add(new ClassSobNeutron()
                                            { nameFile = nemeF, D = dd, Amp = Amp, time = timeSob, TimeAmp = countmaxtime, TimeEnd = countendtime, TimeEnd3 = countendtime3, TimeFirst = countfirsttime, TimeFirst3 = countfirsttime3 });
                                        });
                                    }
                                }
                                catch 
                                {
                                   
                                }
                        }
                        if (countendtime + 1 < 19999)
                            j = countendtime + 1;
                    }
                }

               coutN[i] = countnutron;
  
            }
            
            return coutN;

        }
      
        public async Task Obr()
        {
            if (OcherediNaObrab.Count != 0)
            {
                try
                {
                  
                    OcherediNaObrab.TryDequeue(out MyclasDataizFile ObrD);
                    if (ObrD != null)
                    {
                       
                        int[,] data1 = new int[12, 1024];
                      
                        int[,] dataTail1 = new int[12, 20000];
                        int[] coutN1 = new int[12];
                        string time1 = null;
                      //  MessageDialog messageDialog = new MessageDialog(ObrD.tipName);
                     //  await messageDialog.ShowAsync();
                        switch (ObrD.tipName)
                        {
                           
                            case "T":
                                ParserBAAK12.ParseBinFileBAAK12.ParseBinFileBAAK200H(ObrD.Buf00, out data1, out time1, out dataTail1);
                                break;
                            case "N":
                                ParserBAAK12.ParseBinFileBAAK12.ParseBinFileBAAK200(ObrD.Buf00, 1, out data1, out time1);
                                break;
                            case "V":
                                ParserBAAK12.ParseBinFileBAAK12.ParseBinFileBAAK200(ObrD.Buf00, 1, out data1, out time1);
                                break;
                            default:
                                
                                break;
                        }
                      
                    
                        try
                        {
                           await SaveFileDelegate(data1, dataTail1, time1, ObrD.NameFile);
                        }
                        catch
                        {

                        }
                      
                        try
                        {
                            int t =0;
                            string[] strTime = time1.Split('.');
                            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
() =>
{
    t =Convert.ToInt32(TimeCorect.Text);
});
                            time1 = strTime[0] + "." + strTime[1] + "." + (Convert.ToInt32(strTime[2]) + t).ToString() + "." + strTime[3] + "." + strTime[4] + "." + strTime[5] + "." + strTime[6];

                            await ObrSigData(ObrD.НулеваяЛиния, ObrD.NameFile, ObrD.NameBaaR12.ToString(), data1, dataTail1, time1, ObrD.tipName);
                        }
                        catch(Exception ex)
                        {
                            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
() =>
{
var mess = new MessageDialog("dss"+"\n"+ex.Message.ToString() + "\n" + ex.ToString());
mess.ShowAsync();// КолПакетовОчер++;
});
                        }
                       
                        ObrD = null;
                        //_СписокФайловОбработки = null;

                    }
                }
                catch (Exception ex)
                {
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
() =>
{
    var mess = new MessageDialog(ex.Message.ToString()+"\n"+ ex.ToString());
    mess.ShowAsync();// КолПакетовОчер++;
});

                }
            }
        }

        public async Task ObrSigData(int[] nul, string nameFile, string nemeBAAK,   int[,] data1, int[,] dataTail1, string time1, string tipN)
        {
            double[] Amp = new double[12];
            double[] Nul = new double[12];
            int[] coutN1 = new int[12];
            Double[] sig = new Double[12];
            bool bad = false;
            string[] timeS = new string[12];
            double[] sumDetQ = new double[12];
            double[,] data1S = new double[12, 1024];
            int[] maxTime = new int[12];
            int[] maxAmp=new int[12];
            int d = 0;
            int firstTimeN = 0;


            try
            {
                ClassUserSetUp classUserSetUp = new ClassUserSetUp();
                switch (tipN)
                {
                    case "T":
                        ParserBAAK12.ParseBinFileBAAK12.MaxAmpAndNul(data1, out sig, out Amp, ref Nul, out bad, ClassUserSetUp.ObrNoise, ClassUserSetUp.KoefNoise, classUserSetUp.PorogS);
                        coutN1 = await neutron(dataTail1, time1, Nul, nameFile, bad);
                        break;
                    case "N":
                        ParserBAAK12.ParseBinFileBAAK12.MaxAmpAndNul(data1, out sig, out Amp, ref Nul, out bad, ClassUserSetUp.ObrNoise, ClassUserSetUp.KoefNoise, classUserSetUp.PorogS);

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
                       
                        ParserBAAK12.ParseBinFileBAAK12.MaxAmpAndNul(data1, out sig, out Amp, ref Nul, out bad, ClassUserSetUp.ObrNoise, ClassUserSetUp.KoefNoise, classUserSetUp.PorogS);
                        ObrabotcaURAN.Obrabotca.AmpAndTime(data1, Nul, out maxTime, out maxAmp);
                      bool dN=  ObrabotcaURAN.Obrabotca.Dneutron(maxTime, classUserSetUp.PorogSN, out d);
                        if(dN)
                        {
                            firstTimeN= ObrabotcaURAN.Obrabotca.FirstTme(maxTime[d], maxAmp[d], classUserSetUp.PorogS, data1, Nul, d);
                        }
                    
                        break;
                    default:

                        break;
                }
            
              
                classUserSetUp.SetPush1();
                timeS = ParserBAAK12.ParseBinFileBAAK12.TimeS(data1, classUserSetUp.PorogS, Amp, Nul);
            }

            catch 
            {

            }
        
            string[] array = nameFile.Split('_');
            if (!bad)
            {
                switch (tipN)
                {
                    case "T":
                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
 () => {
     ViewModel.ClassSobsT.Add(new ClassSob()
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
         Nnut0 = Convert.ToInt16(coutN1[0]),
         Nnut1 = Convert.ToInt16(coutN1[1]),
         Nnut2 = Convert.ToInt16(coutN1[2]),
         Nnut3 = Convert.ToInt16(coutN1[3]),
         Nnut4 = Convert.ToInt16(coutN1[4]),
         Nnut5 = Convert.ToInt16(coutN1[5]),
         Nnut6 = Convert.ToInt16(coutN1[6]),
         Nnut7 = Convert.ToInt16(coutN1[7]),
         Nnut8 = Convert.ToInt16(coutN1[8]),
         Nnut9 = Convert.ToInt16(coutN1[9]),
         Nnut10 = Convert.ToInt16(coutN1[10]),
         Nnut11 = Convert.ToInt16(coutN1[11]),
         TimeS0 = timeS[0],
         TimeS1 = timeS[1],
         TimeS2 = timeS[2],
         TimeS3 = timeS[3],
         TimeS4 = timeS[4],
         TimeS5 = timeS[5],
         TimeS6 = timeS[6],
         TimeS7 = timeS[7],
         TimeS8 = timeS[8],
         TimeS9 = timeS[9],
         TimeS10 = timeS[10],
         TimeS11 = timeS[11],
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
         SumNeu = coutN1.Sum(),
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
         Nnull11 = Convert.ToInt16(Nul[11])


     });

 });
                        break;
                    case "N":
                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
     () => {
         ViewModel.ClassSobsN.Add(new ClassSob()
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
       
             TimeS0 = timeS[0],
             TimeS1 = timeS[1],
             TimeS2 = timeS[2],
             TimeS3 = timeS[3],
             TimeS4 = timeS[4],
             TimeS5 = timeS[5],
             TimeS6 = timeS[6],
             TimeS7 = timeS[7],
             TimeS8 = timeS[8],
             TimeS9 = timeS[9],
             TimeS10 = timeS[10],
             TimeS11 = timeS[11],
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
                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
    () => {
        ViewModel.ClassSobsV.Add(new ClassSob()
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
           
            TimeS0 = maxTime[0].ToString(),
            TimeS1 = maxTime[1].ToString(),
            TimeS2 = maxTime[2].ToString(),
            TimeS3 = maxTime[3].ToString(),
            TimeS4 = maxTime[4].ToString(),
            TimeS5 = maxTime[5].ToString(),
            TimeS6 = maxTime[6].ToString(),
            TimeS7 = maxTime[7].ToString(),
            TimeS8 = maxTime[8].ToString(),
            TimeS9 = maxTime[9].ToString(),
            TimeS10 = maxTime[10].ToString(),
            TimeS11 = maxTime[11].ToString(),
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
            nV=d,
            FirstTimeV= firstTimeN,
            MaxTime= maxTime[d]

           

        });

    });
                        break;
                    default:

                        break;
                }


         
               
            }
            else
            {

                switch (tipN)
                {
                    case "T":
                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
 () => {
     ViewModel._DataColecSobPloxT.Add(new ClassSob()
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
         Nnut0 = Convert.ToInt16(coutN1[0]),
         Nnut1 = Convert.ToInt16(coutN1[1]),
         Nnut2 = Convert.ToInt16(coutN1[2]),
         Nnut3 = Convert.ToInt16(coutN1[3]),
         Nnut4 = Convert.ToInt16(coutN1[4]),
         Nnut5 = Convert.ToInt16(coutN1[5]),
         Nnut6 = Convert.ToInt16(coutN1[6]),
         Nnut7 = Convert.ToInt16(coutN1[7]),
         Nnut8 = Convert.ToInt16(coutN1[8]),
         Nnut9 = Convert.ToInt16(coutN1[9]),
         Nnut10 = Convert.ToInt16(coutN1[10]),
         Nnut11 = Convert.ToInt16(coutN1[11]),
         TimeS0 = timeS[0],
         TimeS1 = timeS[1],
         TimeS2 = timeS[2],
         TimeS3 = timeS[3],
         TimeS4 = timeS[4],
         TimeS5 = timeS[5],
         TimeS6 = timeS[6],
         TimeS7 = timeS[7],
         TimeS8 = timeS[8],
         TimeS9 = timeS[9],
         TimeS10 = timeS[10],
         TimeS11 = timeS[11],
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
         SumNeu = coutN1.Sum(),
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
         Nnull11 = Convert.ToInt16(Nul[11])


     });

 });
                        break;
                    case "N":
                        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
     () => {
         ViewModel._DataColecSobPloxN.Add(new ClassSob()
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

             TimeS0 = timeS[0],
             TimeS1 = timeS[1],
             TimeS2 = timeS[2],
             TimeS3 = timeS[3],
             TimeS4 = timeS[4],
             TimeS5 = timeS[5],
             TimeS6 = timeS[6],
             TimeS7 = timeS[7],
             TimeS8 = timeS[8],
             TimeS9 = timeS[9],
             TimeS10 = timeS[10],
             TimeS11 = timeS[11],
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
                        ViewModel._DataColecSobPloxV.Add(new ClassSob()
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

                            TimeS0 = maxTime[0].ToString(),
                            TimeS1 = maxTime[1].ToString(),
                            TimeS2 = maxTime[2].ToString(),
                            TimeS3 = maxTime[3].ToString(),
                            TimeS4 = maxTime[4].ToString(),
                            TimeS5 = maxTime[5].ToString(),
                            TimeS6 = maxTime[6].ToString(),
                            TimeS7 = maxTime[7].ToString(),
                            TimeS8 = maxTime[8].ToString(),
                            TimeS9 = maxTime[9].ToString(),
                            TimeS10 = maxTime[10].ToString(),
                            TimeS11 = maxTime[11].ToString(),
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
