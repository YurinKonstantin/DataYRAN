using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataYRAN.StatObrabotka.StatSig
{
   public class ClassRasSig
    {
        public double znacRas { get; set; }
        public double[] mNullLine = new double[12];
        public double[] MNullLine
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
