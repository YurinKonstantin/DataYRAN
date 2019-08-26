using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataYRAN.StatObrabotka.Raspred
{
   public class ClassRasAmp
    {
        public int znacRas { get; set; }
        public int[] mAmp = new int[13];
        public int[] MAmp
        {
            get
            {
                return mAmp;
            }
            set
            {
                mAmp = value;
            }
        }
        public int[] mAmpC = new int[13];
        public int[] MAmpC
        {
            get
            {
                return mAmpC;
            }
            set
            {
                mAmpC = value;
            }
        }
    }
}
