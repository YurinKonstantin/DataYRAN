using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataYRAN.LIfeTime
{
   public class ClassLifeTime
    {
        public double[] mLT { get; set; }
        public double mLT1
        {
            get
            {
                return mLT[0];
            }
            
        }

        public double mLT2
        {
            get
            {
                return mLT[1];
            }

        }
        public double mLT3
        {
            get
            {
                return mLT[2];
            }

        }
        public double mLT4
        {
            get
            {
                return mLT[3];
            }

        }
        public double mLT5
        {
            get
            {
                return mLT[4];
            }

        }
        public double mLT6
        {
            get
            {
                return mLT[5];
            }

        }
        public double mLT7
        {
            get
            {
                return mLT[6];
            }

        }
        public double mLTURAN
        {
            get
            {
                double min = mLT.Max();
                for(int i =0; i<6; i++)
                {
                    if(mLT[i]<min)
                    {
                        min = mLT[i];
                    }
                }
                return min;
            }

        }

        DateTime dateTime = new DateTime();
        public DateTime _DateTime
        {
            get
            {
                return dateTime;
            }
            set
            {
                dateTime = value;
            }
        }
        public string Date
        {
            get
            {
                return dateTime.ToShortDateString();
            }
           
        }
    }
}
