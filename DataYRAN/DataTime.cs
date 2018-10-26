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
       
    }
}
