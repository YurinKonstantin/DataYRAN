using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataYRAN
{

    public class ClassNeutronStat
    {
        public string nameFile { get; set; }
        public string nameklaster { get; set; }
        public string nameBAAK { get; set; }
        public string time { get; set; }
        public int Amp { get; set; }

        public int Nnut { get; set; }

        public double sig { get; set; }
        public int N { get; set; }
        public int Null { get; set; }
    }
}
