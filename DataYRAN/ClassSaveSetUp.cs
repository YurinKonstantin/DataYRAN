using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace DataYRAN
{
   public class ClassSaveSetUp : INotifyPropertyChanged
    {
      StorageFolder folder;
        public StorageFolder Folder
        {
            get
            {
                return folder;
            }
            set
            {
                folder = value;
                OnPropertyChanged("Folder");
            }
        }
      string nameFile;
        public string NameFile
        {
            get
            {
                return nameFile;
            }
            set
            {
                nameFile = value;
                OnPropertyChanged("NameFile");
            }
        }
        public bool save = true;
        public string tip=".txt";
        public async void ViborPath()
        {
            NameFile = "dgdgdg";
            MessageDialog n = new MessageDialog(NameFile+"\n"+ Folder.DisplayName+"\n"+tip);
            await n.ShowAsync();

        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
