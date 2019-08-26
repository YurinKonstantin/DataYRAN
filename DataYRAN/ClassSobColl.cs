using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataYRAN
{
  public  class ClassSobColl
    {
        string startTime;
        public string StartTime
        { get { return startTime; } set { startTime = value; } }
        string endTime;
        public string EndTime
        { get { return endTime; } set { endTime = value; } }
        int summAmpl;
        public int SummAmpl
        { get { return summAmpl; } set { summAmpl = value; } }
        int summNeu;
        public int SummNeu
        { get { return summNeu; } set { summNeu = value; } }
        int sumClast;
        public int SumClast
        { get { return sumClast; } set { sumClast = value; } }


        int sumClastUp;
        public int SumClastUp
        {
            get
            {
                int x = 0;
                foreach (ClassSob classSob in col)
                {
                    for(int i=0; i<12; i++)
                    {
                        if(classSob.mAmp[i]>10)
                        {
                            x++;
                        }
                    }
                

                }
                return x;
            }
            set { sumClastUp = value; } }
        public void SumAmpAndNeutronAndClaster()
        {
            foreach(ClassSob classSob in col)
            {
                SummAmpl = SummAmpl + classSob.SumAmp;
                SummNeu = SummNeu + classSob.SumNeu;
                
            }
            SumClast = col.Count;
        }
        public void FirstTimeS()
        {
            foreach (ClassSob classSob in col)
            {
                SummAmpl = SummAmpl + classSob.SumAmp;
                SummNeu = SummNeu + classSob.SumNeu;

            }
        }
       public List<ClassSob> col = new List<ClassSob>();
        public DataTimeUR dateUR { get; set; }
        public string klSob
        {
            
            get
            {
                string ki = String.Empty;
                foreach (ClassSob classSob in col)
                {
                    ki += classSob.nameklaster.ToString() + ",";

                }
                return ki;
            }
        }
        public int NDn
        {

            get
            {
                int x = 0;
                foreach (ClassSob classSob in col)
                {
                   if(classSob.Nnut0>0)
                    {
                        x++;
                    }
                    if (classSob.Nnut1 > 0)
                    {
                        x++;
                    }
                    if (classSob.Nnut2 > 0)
                    {
                        x++;
                    }
                    if (classSob.Nnut3 > 0)
                    {
                        x++;
                    }
                    if (classSob.Nnut4 > 0)
                    {
                        x++;
                    }
                    if (classSob.Nnut5 > 0)
                    {
                        x++;
                    }
                    if (classSob.Nnut6 > 0)
                    {
                        x++;
                    }
                    if (classSob.Nnut7 > 0)
                    {
                        x++;
                    }
                    if (classSob.Nnut8 > 0)
                    {
                        x++;
                    }
                    if (classSob.Nnut9 > 0)
                    {
                        x++;
                    }
                    if (classSob.Nnut10 > 0)
                    {
                        x++;
                    }
                    if (classSob.Nnut11 > 0)
                    {
                        x++;
                    }

                }
                return x;
            }
        }

    }
}
