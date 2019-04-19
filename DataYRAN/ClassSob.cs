using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace DataYRAN
{
    public class ClassSob
    {
        public int count { get; set; }
        public string nameTip;
        public string nameFile { get; set; }
        public string nameklaster { get; set; }
        public string nameBAAK { get; set; }

        int sumAmp = 0;
        public int SumAmp
        {
            get
            {
                return mAmp.Sum();
            }
                
                set
            {
                sumAmp = value;
            }
        }

        int sumNeu = 0;
        public int SumNeu {

            get
            {
                return mCountN.Sum();
            }
            set
            {
                sumNeu = value;
            }
        }
        public string time { get; set; }
        public int[] mAmp { get; set; }
        public int[] mCountN { get; set; } 
        public int[] mTimeD { get; set; }
        public short Nnut0 { get; set; }
        public short Nnut1 { get; set; }
        public short Nnut2 { get; set; }
        public short Nnut3 { get; set; }
        public short Nnut4 { get; set; }
        public short Nnut5 { get; set; }
        public short Nnut6 { get; set; }
        public short Nnut7 { get; set; }
        public short Nnut8 { get; set; }
        public short Nnut9 { get; set; }
        public short Nnut10 { get; set; }
        public short Nnut11 { get; set; }
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

        public string TimeS0 { get; set; }
        public string TimeS1 { get; set; }
        public string TimeS2 { get; set; }
        public string TimeS3 { get; set; }
        public string TimeS4 { get; set; }
        public string TimeS5 { get; set; }
        public string TimeS6 { get; set; }
        public string TimeS7 { get; set; }
        public string TimeS8 { get; set; }
        public string TimeS9 { get; set; }
        public string TimeS10 { get; set; }
        public string TimeS11 { get; set; }

        public int[] masTime()
        {
            int[] mas = new int[12];
            mas[0] = Convert.ToInt32(TimeS0);
            mas[1] = Convert.ToInt32(TimeS1);
            mas[2] = Convert.ToInt32(TimeS2);
            mas[3] = Convert.ToInt32(TimeS3);
            mas[4] = Convert.ToInt32(TimeS4);
            mas[5] = Convert.ToInt32(TimeS5);
            mas[6] = Convert.ToInt32(TimeS6);
            mas[7] = Convert.ToInt32(TimeS7);
            mas[8] = Convert.ToInt32(TimeS8);
            mas[9] = Convert.ToInt32(TimeS9);
            mas[10] = Convert.ToInt32(TimeS10);
            mas[11] = Convert.ToInt32(TimeS11);

            return mas;
        }
     //  public short[] AmpSum()
       // {
       //  return new short[12] { Amp0, Amp1, Amp2, Amp3, Amp4, Amp5, Amp6, Amp7, Amp8, Amp9, Amp10, Amp11 };
     //  }
       public List<string> ShovSelect()
        {
            List<string> vs = new List<string>();
            vs.Add(vs.Count.ToString() + " " + mAmp[0].ToString() + " " + sig0.ToString());

           return vs;
        }

    









    }
 
}
