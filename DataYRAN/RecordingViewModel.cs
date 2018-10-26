using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataYRAN
{
    public class RecordingViewModel
    {
        private ObservableCollection<ClassSob> classSobs = new ObservableCollection<ClassSob>();
        public ObservableCollection<ClassSob> ClassSobs { get { return this.classSobs; } }

        ObservableCollection<ClassSobNeutron> classSobNeutrons = new ObservableCollection<ClassSobNeutron>();
        public ObservableCollection<ClassSobNeutron> ClassSobNeutrons { get { return this.classSobNeutrons; } }
    }
}
