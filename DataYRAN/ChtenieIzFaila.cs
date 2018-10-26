using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;

namespace DataYRAN
{
    public sealed partial class BlankPageObrData
    {
       

        class MyclasDataizFile
        {

            int lenghtChenel = 2;
            string nameFile = "r";

            string ran = "0";
            string nameBaaR12 = "У1";
            int[] нулеваяЛиния = new int[12];
            Byte[] buf00 = new Byte[21024];
            public string NameFile { get => nameFile; set => nameFile = value; }
            public Byte[] Buf00 { get => buf00; set => buf00 = value; }
            public int LenghtChenel { get => lenghtChenel; set => lenghtChenel = value; }

            public int[] НулеваяЛиния { get => нулеваяЛиния; set => нулеваяЛиния = value; }
            public string NameBaaR12 { get => nameBaaR12; set => nameBaaR12 = value; }
            public string Ran { get => ran; set => ran = value; }
        }
     
      
    }
}
