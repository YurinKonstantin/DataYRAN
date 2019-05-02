using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataYRAN
{
   public struct DataTimeUR
    {
        public int GG { get; set; }
        public int MM{ get; set; }
        public int DD { get; set; }
        public int HH { get; set; }
        public int Min { get; set; }
        public int CC { get; set; }
        public int Mil { get; set; }
        public int ML { get; set; }
        public int NN { get; set; }
        public DataTimeUR(int gg, int mm, int dd, int hh, int min, int s, int mil, int ml, int nn )
        {
            GG = gg;
            MM = mm;
            DD = dd;
            HH = hh;
            Min = min;
            CC = s;
            Mil = mil;
            ML = ml;
            NN = nn;
        }
        public void corectTime(string time)
        {
            string[] t = time.Split('_')[1].Split(' ')[0].Split('.');

            DateTime g = new DateTime(Convert.ToInt32(t[2]), Convert.ToInt32(t[1]), Convert.ToInt32(t[0]));
         
            DateTime f = new DateTime(Convert.ToInt32(t[2]), Convert.ToInt32(t[1]), Convert.ToInt32(t[0]));
           
            if(DD!=f.Day || DD!=g.AddDays(-1).Day)
            {
                DD = f.Day;
                MM = f.Month;
                GG = f.Year;

            }
            else
            {
                if(DD == f.Day)
                {
                    MM = f.Month;
                    GG = f.Year;
                }
                else
                {
                    MM = g.Month;
                    GG = g.Year;
                }
                
                
            }

        }
       public string TimeString()
        {
            return DD.ToString("00") + "." + HH.ToString("00") + "." + Min.ToString("00") + "." + CC.ToString("00") + "." + Mil.ToString("00") + "." + ML.ToString("00") + "." + NN.ToString("00");
        }
    }
}
