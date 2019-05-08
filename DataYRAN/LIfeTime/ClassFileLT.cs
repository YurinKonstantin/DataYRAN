using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataYRAN.LIfeTime
{
  public class ClassFileLT
    {
        public int nomer { get; set; }
        public string nameFile { get; set; }

       string timeOpen = String.Empty;
        public string TimeOpen
        {
            get
            {
                return timeOpen;
            }
            set
            {
                timeOpen = value;
            }
        }
        public DateTime DateTimeOpen
        {
            get
            {
                string[] ftime0 = TimeOpen.Split(' ');
                string[] ftime = ftime0[1].Split('.');
                string[] dtime = ftime0[0].Split('.'); ;
                DateTime dateTime = new DateTime(Convert.ToInt32(dtime[2]), Convert.ToInt32(dtime[1]), Convert.ToInt32(dtime[0]), Convert.ToInt32(ftime[0]), Convert.ToInt32(ftime[1]), Convert.ToInt32(ftime[1]), 0);

                return dateTime;
            }
            
        }
        string timeClose = String.Empty;
        public string TimeClose
        {
            get
            {
                return timeClose;
            }
            set
            {
                timeClose = value;
            }
        }
        public DateTime DateTimeClose
        {
            get
            {
                
                string[] ftime0 = TimeClose.Split(' ');
                string[] ftime = ftime0[1].Split('.');
                string[] dtime = ftime0[0].Split('.'); ;
                DateTime dateTime = new DateTime(Convert.ToInt32(dtime[2]), Convert.ToInt32(dtime[1]), Convert.ToInt32(dtime[0]), Convert.ToInt32(ftime[0]), Convert.ToInt32(ftime[1]), Convert.ToInt32(ftime[2]), 0);
        
                return dateTime;
            }

        }
        public double DurTime
        {
            get
            {

                return DateTimeClose.Subtract(DateTimeOpen).TotalHours;
            }

        }
        public int Klaster
        {
            get
            {

                string[] ftime0 = nameFile.Split('_');
             
                return Convert.ToInt32(ftime0[0]);
            }

        }
        public string Tip
        {
            get
            {

                string[] ftime0 = nameFile.Split('_');

                return ftime0[2];
            }

        }
        public string nameRun { get; set; }

    }
}
