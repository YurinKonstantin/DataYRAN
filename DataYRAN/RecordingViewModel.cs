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
        /// <summary>
        /// Коллекция сигналов БААК12-200Т
        /// </summary>
        public ObservableCollection<ClassSob> ClassSobsT { get { return this.classSobs; } }
        /// <summary>
        /// Коллекция событий платы БААК12-200
        /// </summary>
        public ObservableCollection<ClassSob> ClassSobsN = new ObservableCollection<ClassSob>();
        /// <summary>
        /// Коллекция событий платы БААК12-100
        /// </summary>
        public ObservableCollection<ClassSob> ClassSobsV = new ObservableCollection<ClassSob>();
        ObservableCollection<ClassSobNeutron> classSobNeutrons = new ObservableCollection<ClassSobNeutron>();
        public ObservableCollection<ClassSobNeutron> ClassSobNeutrons { get { return this.classSobNeutrons; } }
        public ObservableCollection<ClassSaveSetUp> _DataColecViewSaveMenedger = new ObservableCollection<ClassSaveSetUp>();

       /// <summary>
       /// Коллекция шумовых сигналов платы БААК12-200Т
       /// </summary>
       public ObservableCollection<ClassSob> _DataColecSobPloxT = new ObservableCollection<ClassSob>();

        /// <summary>
        /// Коллекция шумовых сигналов платы БААК12-200
        /// </summary>
        public ObservableCollection<ClassSob> _DataColecSobPloxN = new ObservableCollection<ClassSob>();

        /// <summary>
        /// Коллекция шумовых сигналов платы БААК12-100
        /// </summary>
        public ObservableCollection<ClassSob> _DataColecSobPloxV = new ObservableCollection<ClassSob>();

        /// <summary>
        /// Коллекция общих событий кластеров УРАН
        /// </summary>
       public ObservableCollection<ClassSobColl> _DataSobColli = new ObservableCollection<ClassSobColl>();
        /// <summary>
        /// Коллекция промежуточного результата общих событий кластеров УРАН
        /// </summary>
       public ObservableCollection<ClassSob> _DataColecSobCopy = new ObservableCollection<ClassSob>();
    }
}
