using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace DataYRAN
{
   public class ClassSobV
    {
        public string nameTip;
        public string nameFile { get; set; }
        public string nameklaster { get; set; }
        public string nameBAAK { get; set; }
        int SsumAmp = 0;
        public int SumAmp
        {
            get
            {
                return Amp0 + Amp1 + Amp2 + Amp3 + Amp4 + Amp5 + Amp6 + Amp7 + Amp8 + Amp9 + Amp10 + Amp11;
            }
            set
            {
                SsumAmp = value;
            }
                }
        public int[] maxTimeV { get; set; }
        int[] polmaxTimeV = new int[12];
        public int[] PolmaxTimeV
        {
            get
            {
                return polmaxTimeV;
            }

            set
            {
                polmaxTimeV = value;
            }
        }
        public string time { get; set; }
        public short Amp0 { get; set; }
        public short Amp1 { get; set; }
        public short Amp2 { get; set; }
        public short Amp3 { get; set; }
        public short Amp4 { get; set; }
        public short Amp5 { get; set; }
        public short Amp6 { get; set; }
        public short Amp7 { get; set; }
        public short Amp8 { get; set; }
        public short Amp9 { get; set; }
        public short Amp10 { get; set; }
        public short Amp11 { get; set; }

        public double sig0 { get; set; }
        public double sig1 { get; set; }
        public double sig2 { get; set; }
        public double sig3 { get; set; }
        public double sig4 { get; set; }
        public double sig5 { get; set; }
        public double sig6 { get; set; }
        public double sig7 { get; set; }
        public double sig8 { get; set; }
        public double sig9 { get; set; }
        public double sig10 { get; set; }
        public double sig11 { get; set; }
        public short Nnull0 { get; set; }
        public short Nnull1 { get; set; }
        public short Nnull2 { get; set; }
        public short Nnull3 { get; set; }
        public short Nnull4 { get; set; }
        public short Nnull5 { get; set; }
        public short Nnull6 { get; set; }
        public short Nnull7 { get; set; }
        public short Nnull8 { get; set; }
        public short Nnull9 { get; set; }
        public short Nnull10 { get; set; }
        public short Nnull11 { get; set; }

 
        public double QS0 { get; set; }
        public double QS1 { get; set; }
        public double QS2 { get; set; }
        public double QS3 { get; set; }
        public double QS4 { get; set; }
        public double QS5 { get; set; }
        public double QS6 { get; set; }
        public double QS7 { get; set; }
        public double QS8 { get; set; }
        public double QS9 { get; set; }
        public double QS10 { get; set; }
        public double QS11 { get; set; }
        /// <summary>
        /// Детектор где был нейтрон
        /// </summary>
        public int nV { get; set; }
        public int AmpNV { get; set; }
        /// <summary>
        /// Время начала сигнала в отсчетах
        /// </summary>
        public int[] FirstTimeV { get; set; }
        /// <summary>
        /// Время максимального хначения амплитуды в отсчетах
        /// </summary>
        public int MaxTime { get; set; }

        public short[] AmpSum()
        {
            return new short[12] { Amp0, Amp1, Amp2, Amp3, Amp4, Amp5, Amp6, Amp7, Amp8, Amp9, Amp10, Amp11 };
        }
        public List<string> ShovSelect()
        {
            List<string> vs = new List<string>();
            vs.Add(vs.Count.ToString() + " " + Amp0.ToString() + " " + sig0.ToString());

            return vs;
        }

        public double[] Qsum
        {
            get
            {
                double[] vs = new double[12];
                vs[0] = QS0;
                vs[1] = QS1;
                vs[2] = QS2;
                vs[3] = QS3;
                vs[4] = QS4;
                vs[5] = QS5;
                vs[6] = QS6;
                vs[7] = QS7;
                vs[8] = QS8;
                vs[9] = QS9;
                vs[10] = QS10;
                vs[11] = QS11;

                return vs;
            }


        }
    }
}
