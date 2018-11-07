using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace DataYRAN
{
    public class ClassUserSetUp : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // Raise the PropertyChanged event, passing the name of the property whose value has changed.
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        static Windows.Storage.ApplicationDataContainer localSettings =
      Windows.Storage.ApplicationData.Current.LocalSettings;
        static Windows.Storage.StorageFolder localFolder =
               Windows.Storage.ApplicationData.Current.LocalFolder;
        static public void saveUseSet()
        {
            // Composite setting

            Windows.Storage.ApplicationDataCompositeValue composite =
                new Windows.Storage.ApplicationDataCompositeValue();
            composite["intPorog"] = PorogN;
            composite["intDlit3"] = DlitN3;
            composite["intAutoSeting"] = AutoSeting;
            composite["intAutoSeting"] = AutoSeting;
            composite["intSaveRaz"] = SaveRaz;
            composite["intObrSig"] = ObrSig;
            composite["boolObrNoise"] = ObrNoise;
            composite["KoefNoise"] = KoefNoise;
            composite["AmpNoise"] = AmpNoise;
           // composite["intPorogS"] = PorogS;
            localSettings.Values["exampleCompositeSetting"] = composite;
         

        }
        public void saveUseSet1()
        {
            // Composite setting

            Windows.Storage.ApplicationDataCompositeValue composite1 =
                new Windows.Storage.ApplicationDataCompositeValue();
      
            composite1["intPorogS"] = PorogS;
            localSettings.Values["exampleCompositeSetting1"] = composite1;


        }

        static public void SetPush()
        {


            Windows.Storage.ApplicationDataCompositeValue composite =
               (Windows.Storage.ApplicationDataCompositeValue)localSettings.Values["exampleCompositeSetting"];

            if (composite == null)
            {
                // No data
            }
            else
            {
                PorogN = Convert.ToInt32(composite["intPorog"]);
                DlitN3 = Convert.ToInt32(composite["intDlit3"]);
                AutoSeting = Convert.ToBoolean(composite["intAutoSeting"]);
                SaveRaz = Convert.ToBoolean(composite["intSaveRaz"]);
                ObrSig = Convert.ToBoolean(composite["intObrSig"]);
                ObrNoise= Convert.ToBoolean(composite["boolObrNoise"]);
                 KoefNoise=Convert.ToDouble(composite["KoefNoise"]);
                AmpNoise=Convert.ToInt32(composite["AmpNoise"]);
               // PorogS=Convert.ToInt32(composite["intPorogS"]);

            }
        }
        public void SetPush1()
        {


            Windows.Storage.ApplicationDataCompositeValue composite1 =
               (Windows.Storage.ApplicationDataCompositeValue)localSettings.Values["exampleCompositeSetting1"];

            if (composite1 == null)
            {
                // No data
            }
            else
            {
                
                PorogS = Convert.ToInt32(composite1["intPorogS"]);

            }
        }
        static int? porogN = 5;
        static public int? PorogN
        {
            get
            {
                return porogN;
            }
            set
            {
                porogN = value;
            }
        }
         int porogS = 10;
        public int PorogS
        {
            get
            {
                return porogS;
            }
            set
            {
                    porogS = value;
                    this.OnPropertyChanged();
                
            }
        }
        static int? dlitN3 = 2;
        static public int? DlitN3
        {
            get
            {
                return dlitN3;
            }
            set
            {
                dlitN3 = value;
            }
        }
        static bool autoSeting = false;
        static public bool AutoSeting
        {
            get
            {
                return autoSeting;
            }
            set
            {
                autoSeting = value;
            }
        }
        static bool obrNoise = false;
        static public bool ObrNoise
        {
            get
            {
                return obrNoise;
            }
            set
            {
                obrNoise = value;
            }
        }
        static bool tipTail = true;
        static public bool TipTail
        {
            get
            {
                return tipTail;
            }
            set
            {
                tipTail = value;
            }
        }
        static bool saveRaz = false;
        static public bool SaveRaz
        {
            get
            {
                return saveRaz;
            }
            set
            {
                saveRaz = value;
            }
        }
        static bool obrSig = true;
        static public bool ObrSig
        {
            get
            {
                return obrSig;
            }
            set
            {
                obrSig = value;
            }
        }

        static bool flagFileBig = true;
        static public bool FlagFileBig
        {
            get
            {
                return flagFileBig;
            }
            set
            {
                flagFileBig = value;
            }
        }




        static int? timeGate = 100;
        static public int? TimeGate
        {
            get
            {
                return timeGate;
            }
            set
            {
                timeGate = value;
            }
        }
        static int? minAmplDetec = 100;
        static public int? MinAmplDetec
        {
            get
            {
                return minAmplDetec;
            }
            set
            {
                minAmplDetec = value;
            }
        }
        static int? minDetectUp = 100;
        static public int? MinDetectUp
        {
            get
            {
                return minDetectUp;
            }
            set
            {
                minDetectUp = value;
            }
        }
        static int? minClustDec = 100;
        static public int? MinClustDec
        {
            get
            {
                return minClustDec;
            }
            set
            {
                minClustDec = value;
            }
        }

        static int? stepsAmpl = 100;
        static public int? StepsAmpl
        {
            get
            {
                return stepsAmpl;
            }
            set
            {

                stepsAmpl = value;
            }
        }

        static double koefNoise =0.6;
        static public double KoefNoise
        {
            get
            {
                return koefNoise;
            }
            set
            {

                koefNoise = value;
            }
        }
        static int? ampNoise = 5;
        static public int?  AmpNoise
        {
            get
            {
                return ampNoise;
            }
            set
            {

                ampNoise = value;
            }
        }

        static string cult = "ru";
        static public string Cult
        {
            get
            {
                return cult;
            }
            set
            {

                cult = value;
            }
        }
    }
}
