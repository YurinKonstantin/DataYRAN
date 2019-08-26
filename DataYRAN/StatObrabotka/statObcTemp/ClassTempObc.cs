using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataYRAN.StatObrabotka.statObcTemp
{
  public  class ClassTempObc
    {
        public int Temp { get; set; }

     
        public int colSob { get; set; }
      
        public DateTime dateTime { get; set; }
        public string date()
        {
            return dateTime.Date.ToString();
        }
    }
}
