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
        { get { return sumClastUp; } set { sumClastUp = value; } }
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

    }
}
