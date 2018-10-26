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

        private async Task<int[]> neutron(int[,] n, string timeSob, double[] masnul, string nemeF, bool bad)//out int[] coutN,
        {
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
                                      Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
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
        public void MaxAmpAndNul(int[] NulLinMaxAndNull, int[,] data1, out Double[] sig, out double[] Amp, ref double[] Nul, out bool bad)
        {
            bad = false;
            sig = new Double[12];
            Amp = new double[12];
            bool obrNoise = ClassUserSetUp.ObrNoise;
           // Nul = new double[12];
            int Nsob = 150;//число точек от начала для поиска нулевой линнии
            for (int i = 0; i < 12; i++)
            {
                int[] sumNul = new int[Nsob];// точки нулевой линии для "a" - го канала
                                             // double sred = Enumerable.Range(0, 2).Select(x => f[x]).Sum();
                for (int a = 0; a < Nsob; a++)
                {
                    // Nul[i] = (Nul[i] + data1[i, a]);
                    sumNul[a] = data1[i, a];// точки нулевой линии для "a"-го канала
                }

                Nul[i] = Enumerable.Range(0, 150).Select(x => data1[i, x]).Average();
                sig[i] = Math.Sqrt(Sum(sumNul, Nul[i]) / Nsob);

            }
            int xbad = 0;
            for (int z = 0; z < 12; z++)
            {
                double Nu = Nul[z];
                

               double max = (Enumerable.Range(0, 1024).Select(x => data1[z, x]).Max())-Nu;
                double min = (Enumerable.Range(0, 1024).Select(x => data1[z, x]).Min())-Nu;
              
                if(obrNoise && Math.Abs(min/max)> ClassUserSetUp.KoefNoise & Math.Abs(max)>ClassUserSetUp.AmpNoise)
                {
                    xbad++;
                }
                
                Amp[z] = max;
            }
            if(xbad>0)
            {
                bad = true;
            }
        }
        private Double Sum(int[] n, double x)
        {
            Double res = 0;
            foreach (int i in n)
            {
                res = res + Math.Pow((i - x), 2);
            }
            return res;
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

                           ParserBAAK12.ParseBinFileBAAK12.ParseBinFileBAAK200H(ObrD.Buf00, out data1, out time1, out dataTail1);
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
            try
            {
              await  Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
        () => {
            MaxAmpAndNul(nul, data1, out sig, out Amp, ref Nul, out bad);
        });

              coutN1 = await Task<int[]>.Run(()=> neutron(dataTail1, time1, Nul, nameFile, bad));
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
