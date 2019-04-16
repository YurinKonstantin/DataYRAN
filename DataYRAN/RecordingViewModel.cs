using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Telerik.Core.Data;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media;

namespace DataYRAN
{
    public class RecordingViewModel : INotifyPropertyChanged
    {
        int countNaObrab = 0;
        public int CountNaObrab
        {
            get
            {
                return countNaObrab;
            }
            set
            {
                countNaObrab = value;
                this.OnPropertyChanged(nameof(CountNaObrab));
            }
        }
        int countObrabSob = 0;
        public int CountObrabSob
        {
            get
            {
                return countObrabSob;
            }
            set
            {
                countObrabSob = value;
                this.OnPropertyChanged(nameof(CountObrabSob));
            }
        }
        int countNaObrabSob = 0;
        public int CountNaObrabSob
        {
            get
            {
                return countNaObrabSob;
            }
            set
            {
                countNaObrabSob = value;
                this.OnPropertyChanged(nameof(CountNaObrabSob));
            }
        }
       
        
        ObservableCollection<ClassСписокList> _DataColec = new ObservableCollection<ClassСписокList>();
        public ObservableCollection<ClassСписокList> DataColec
            {
            get
            {
                return _DataColec;
            }
            set
            {
                _DataColec = value;
                CountNaObrab = DataColec.Count;
            }
            }
        public void AddFile(ClassСписокList classСписокList)
        {
            DataColec.Add(classСписокList);
            CountNaObrab = DataColec.Count;
        }
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

        public int CountSob
        {
            get
            {
                return ClassSobsT.Count;
            }
        }
     
        /// <summary>
        /// Коллекция событий платы БААК12-200
        /// </summary>
        public ObservableCollection<ClassSobN> ClassSobsN = new ObservableCollection<ClassSobN>();
        /// <summary>
        /// Коллекция событий платы БААК12-100
        /// </summary>
        public ObservableCollection<ClassSobV> ClassSobsV = new ObservableCollection<ClassSobV>();
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
        public ObservableCollection<ClassSobN> _DataColecSobPloxN = new ObservableCollection<ClassSobN>();

        /// <summary>
        /// Коллекция шумовых сигналов платы БААК12-100
        /// </summary>
        public ObservableCollection<ClassSobV> _DataColecSobPloxV = new ObservableCollection<ClassSobV>();

        /// <summary>
        /// Коллекция общих событий кластеров УРАН
        /// </summary>
       public ObservableCollection<ClassSobColl> _DataSobColli = new ObservableCollection<ClassSobColl>();
        /// <summary>
        /// Коллекция промежуточного результата общих событий кластеров УРАН
        /// </summary>
       public ObservableCollection<ClassSob> _DataColecSobCopy = new ObservableCollection<ClassSob>();
        public void ClearData()
        {
            ClassSobsT.Clear();
            ClassSobsN.Clear();
            ClassSobsV.Clear();
            ClassSobNeutrons.Clear();
            _DataColecSobPloxT.Clear();
            _DataColecSobPloxN.Clear();
            _DataSobColli.Clear();
        }
        public void ClearDataBAAK12_200T()
        {
            ClassSobsT.Clear();
            ClassSobsN.Clear();
            ClassSobNeutrons.Clear();
            _DataColecSobPloxT.Clear();
         
        }
        public void ClearDataBAAK12_200()
        {
            ClassSobsN.Clear();
            _DataColecSobPloxN.Clear();

        }
        public void ClearDataBAAK12_100()
        {
            ClassSobsV.Clear();
            _DataColecSobPloxV.Clear();

        }
        public void ClearDataBAAK12_200TAll()
        {
            ClassSobsV.Clear();
            _DataColecSobPloxV.Clear();

        }
        Brush masDetectors = new SolidColorBrush(Windows.UI.Colors.Black);
        public Brush MasDetectors
        {
            get
            {
                return masDetectors;
            }
            set
            {
               
                masDetectors = value;
        
                this.OnPropertyChanged(nameof(MasDetectors));
            }
        }
     
     
    }
}
