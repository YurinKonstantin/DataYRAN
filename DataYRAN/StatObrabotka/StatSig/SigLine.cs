using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataYRAN.StatObrabotka.StatSig
{
  public  class SigLine
    {
        public double[] mNullLine { get; set; }



        public DateTime dateTime { get; set; }
        public string date()
        {
            return dateTime.Date.ToString();
        }
    }
}
