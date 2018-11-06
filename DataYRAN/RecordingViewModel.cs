using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace DataYRAN
{
    public class RecordingViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // Raise the PropertyChanged event, passing the name of the property whose value has changed.
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        ClassUserSetUp cclassUserSetUp { get; set; }
        public RecordingViewModel()
            {
            cclassUserSetUp = new ClassUserSetUp();
            cclassUserSetUp.SetPush1();
            }
        public int PorogS
        {
            get
            {
                return cclassUserSetUp.PorogS;
            }
            set
            {
                try
                {
                    cclassUserSetUp.PorogS = value;
                    this.OnPropertyChanged();
                }
                catch(Exception ex)
                {
                    MessageDialog messageDialog = new MessageDialog(ex.ToString());
                    messageDialog.ShowAsync();
                }
            }

        }
        public void SaveUserSetUp()
        {
            cclassUserSetUp.saveUseSet1();
            ClassUserSetUp.saveUseSet();
        }
        private ObservableCollection<ClassSob> classSobs = new ObservableCollection<ClassSob>();
        public ObservableCollection<ClassSob> ClassSobs { get { return this.classSobs; } }

        ObservableCollection<ClassSobNeutron> classSobNeutrons = new ObservableCollection<ClassSobNeutron>();
        public ObservableCollection<ClassSobNeutron> ClassSobNeutrons { get { return this.classSobNeutrons; } }
    }
}
