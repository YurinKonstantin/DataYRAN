using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.UI.Popups;

namespace DataYRAN
{
    public sealed partial class BlankPageObrData
    {
        bool tipOpera = true;
        public async void FirstDiagnosticFile(List<ClassСписокList> storageFiles)
        {
            ulong countLine = 0;
            foreach(ClassСписокList classСписокList in storageFiles)
            {
                string tipN = "T";
         
                string[] fileParset = classСписокList.file1.DisplayName.Split('_');
                if(fileParset.Length==2)
                {
                    tipN = "T";
                }
                if(fileParset.Length == 3)
                {
                    tipN = fileParset[2];
                }
               BasicProperties basicProperties =
       await classСписокList.file1.GetBasicPropertiesAsync();
                switch (tipN)
                {

                    case "T":
                        countLine += basicProperties.Size/504648;
                        break;
                    case "N":
                        countLine += basicProperties.Size / 24604;
                        break;
                    case "V":
                        countLine += basicProperties.Size / (24604*2);
                        break;
                    default:

                        break;
                }


            }
            countLine += (ulong)ViewModel.ClassSobsT.Count;
            ViewModel.CountNaObrabSob = (int)countLine;
            if(countLine>4000)
            {
              //  tipOpera = false;
               // MessageDialog mes = new MessageDialog("Данные будут доступны только после сохранения!!!");
             // await  mes.ShowAsync();
            }
            else
            {
                tipOpera = true;
            }
        }
    }
}
