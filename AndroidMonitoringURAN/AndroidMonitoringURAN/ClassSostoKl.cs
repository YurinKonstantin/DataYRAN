using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidMonitoringURAN
{
   public class ClassSostoKl
    {
        int nomerKl = 0;
        public int NomerKl
        {
            get
            {
                return nomerKl;
            }
            set
            {
                nomerKl = value;
            }
        }
        int kolPac = 0;
        public int KolPac
        {
            get
            {
                return kolPac;
            }
            set
            {
                kolPac = value;
            }
        }
        int kolTemp = 0;
        public int KolTemp
        {
            get
            {
                return kolTemp;
            }
            set
            {
                kolTemp = value;
            }
        }
        string sostoKl = String.Empty;
        public string SostoKl
        {
            get
            {
                return sostoKl;
            }
            set
            {
                sostoKl = value;
            }
        }



    }
}
