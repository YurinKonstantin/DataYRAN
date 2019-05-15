using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataYRAN.StatObrabotka.StatNulLine
{
   public class ClassRasNul
    {
      public  int znacRas { get; set; }
      public  int[] mNullLine = new int[12];
        public int[] MNullLine
        {
            get
            {
                return mNullLine;
            }
            set
            {
                mNullLine = value;
            }
        }
    }
}
