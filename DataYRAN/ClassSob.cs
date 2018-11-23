using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace DataYRAN
{
    public class ClassSob
    {
        public string nameFile { get; set; }
        public string nameklaster { get; set; }
        public string nameBAAK { get; set; }
        public int SumAmp { get; set; }
        public int SumNeu { get; set; }
        public string time { get; set; }
        public short Amp0 { get; set; }
        public short Amp1 { get; set; }
        public short Amp2 { get; set; }
        public short Amp3 { get; set; }
        public short Amp4 { get; set; }
        public short Amp5 { get; set; }
        public short Amp6 { get; set; }
        public short Amp7 { get; set; }
        public short Amp8 { get; set; }
        public short Amp9 { get; set; }
        public short Amp10 { get; set; }
        public short Amp11 { get; set; }
        public short Nnut0 { get; set; }
        public short Nnut1 { get; set; }
        public short Nnut2 { get; set; }
        public short Nnut3 { get; set; }
        public short Nnut4 { get; set; }
        public short Nnut5 { get; set; }
        public short Nnut6 { get; set; }
        public short Nnut7 { get; set; }
        public short Nnut8 { get; set; }
        public short Nnut9 { get; set; }
        public short Nnut10 { get; set; }
        public short Nnut11 { get; set; }
        public double sig0 { get; set; }
        public double sig1 { get; set; }
        public double sig2 { get; set; }
        public double sig3 { get; set; }
        public double sig4 { get; set; }
        public double sig5 { get; set; }
        public double sig6 { get; set; }
        public double sig7 { get; set; }
        public double sig8 { get; set; }
        public double sig9 { get; set; }
        public double sig10 { get; set; }
        public double sig11 { get; set; }
        public short Nnull0 { get; set; }
        public short Nnull1 { get; set; }
        public short Nnull2 { get; set; }
        public short Nnull3 { get; set; }
        public short Nnull4 { get; set; }
        public short Nnull5 { get; set; }
        public short Nnull6 { get; set; }
        public short Nnull7 { get; set; }
        public short Nnull8 { get; set; }
        public short Nnull9 { get; set; }
        public short Nnull10 { get; set; }
        public short Nnull11 { get; set; }

        public string TimeS0 { get; set; }
        public string TimeS1 { get; set; }
        public string TimeS2 { get; set; }
        public string TimeS3 { get; set; }
        public string TimeS4 { get; set; }
        public string TimeS5 { get; set; }
        public string TimeS6 { get; set; }
        public string TimeS7 { get; set; }
        public string TimeS8 { get; set; }
        public string TimeS9 { get; set; }
        public string TimeS10 { get; set; }
        public string TimeS11 { get; set; }
        public async void openCom()
        {
            MessageDialog messageDialog = new MessageDialog("gffhf");
            await messageDialog.ShowAsync();
        }

    }
 
}
