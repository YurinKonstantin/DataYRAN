using System;
using System.Collections.Generic;using System.Linq;

using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Core;



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

        private  int[] neutron(int[,] n, string timeSob, double[] masnul, string nemeF, bool bad, List<ClassSobNeutron> listNet)//out int[] coutN,
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
                                v = n[i, countendtime];
                            }

                            v = Amp;
                            countfirsttime = countfirsttime3;
                            while (v > Nu)
                            {
                                countfirsttime--;
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
                                    listNet.Add(new ClassSobNeutron() { nameFile = nemeF, D = dd, Amp = Amp, time = timeSob, TimeAmp = countmaxtime, TimeEnd = countendtime, TimeEnd3 = countendtime3, TimeFirst = countfirsttime, TimeFirst3 = countfirsttime3});
                               // });
                                    //  Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                                     //   {
                                       //     ViewModel.ClassSobNeutrons.Add(new ClassSobNeutron()
                                        //    { nameFile = nemeF, D = dd, Amp = Amp, time = timeSob, TimeAmp = countmaxtime, TimeEnd = countendtime, TimeEnd3 = countendtime3, TimeFirst = countfirsttime, TimeFirst3 = countfirsttime3 });
                                       // });
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
                    // var messgu = new MessageDialog("Есть событие");
                    // await messgu.ShowAsync();// КолПакетовОчер++;

                    MyclasDataizFile ObrD = new MyclasDataizFile();
                    OcherediNaObrab.TryDequeue(out ObrD);
                    if (ObrD != null)
                    {
                       
                        int[,] data1 = new int[12, 1024];
                        int[,] dataTail1 = new int[12, 20000];
                        int[] coutN1 = new int[12];
                        string time1 = null;
                        if(ClassUserSetUp.TipTail)
                        {
                            ParserBAAK12.ParseBinFileBAAK12.ParseBinFileBAAK200H(ObrD.Buf00, out data1, out time1, out dataTail1);
                        }
                       else
                        {

                            ParserBAAK12.ParseBinFileBAAK12.ParseBinFileBAAK200(ObrD.Buf00, 1, out data1, out time1);
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


                          await Task.Run(()=> ObrSigData(ObrD.НулеваяЛиния, ObrD.NameFile, ObrD.NameBaaR12.ToString(), data1, dataTail1, time1));
                        }
                        catch
                        {

                        }
                       
                            
                     
                        ObrD = null;
                        //_СписокФайловОбработки = null;

                    }
                }
                catch 
                {
                    // var mess = new MessageDialog("ошибка1");
                    // await mess.ShowAsync();// КолПакетовОчер++;
                }
            }
        }

        public async void ObrSigData(int[] nul, string nameFile, string nemeBAAK,   int[,] data1, int[,] dataTail1, string time1)
        {
            double[] Amp = new double[12];
            double[] Nul = new double[12];
            int[] coutN1 = new int[12];
            Double[] sig = new Double[12];
            bool bad = false;
            string[] timeS = new string[12];
            try
            {
                ClassUserSetUp classUserSetUp = new ClassUserSetUp();
                if(ClassUserSetUp.TipTail)
                {
                    ParserBAAK12.ParseBinFileBAAK12.MaxAmpAndNul(data1, out sig, out Amp, ref Nul, out bad, ClassUserSetUp.ObrNoise, ClassUserSetUp.KoefNoise, classUserSetUp.PorogS);

                }
                else
                {
                    ParserBAAK12.ParseBinFileBAAK12.MaxAmpAndNul(data1, out sig, out Amp, ref Nul, out bad, ClassUserSetUp.ObrNoise, ClassUserSetUp.KoefNoise, classUserSetUp.PorogS);

                }
                List<ClassSobNeutron> listNet = new List<ClassSobNeutron>();
                if(ClassUserSetUp.TipTail)
                {
                    coutN1 = await Task<int[]>.Run(() => neutron(dataTail1, time1, Nul, nameFile, bad, listNet));
                    foreach (var vv in listNet)
                    {
                        Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => {
                            ViewModel.ClassSobNeutrons.Add(new ClassSobNeutron() { nameFile = vv.nameFile, D = vv.D, Amp = vv.Amp, time = vv.time, TimeAmp = vv.TimeAmp, TimeEnd = vv.TimeEnd, TimeEnd3 = vv.TimeEnd3, TimeFirst = vv.TimeFirst, TimeFirst3 = vv.TimeFirst3 });
                        });
                    }

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
               Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
        () => {
            ViewModel.ClassSobs.Add(new ClassSob()
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
               
            }
            else
            {
              Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
        () => {
            _DataColecSobPlox.Add(new ClassSob()
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
               
            }
        }
    }
}
