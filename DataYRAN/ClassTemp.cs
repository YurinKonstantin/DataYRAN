using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataYRAN
{
  public  class ClassTemp
    {
      public  int[] mTemp { get; set; }
      
        public int Temp
        {
            get
            {
                return mTemp.Sum();
            }

          
        }
        public int colSob { get; set; }
        public DateTime dateTime { get; set; }
        public string date()
        {
            return dateTime.Date.ToString();
        }
    }
}
