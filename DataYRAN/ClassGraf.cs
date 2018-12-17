using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataYRAN
{
   public class ClassGraf
    {
        public string name { get; set; }
        ObservableCollection<int> _collectionGraf = new ObservableCollection<int>();
       public ObservableCollection<int> collectionGraf
        {
            get
            {
                return _collectionGraf;
            }
            set
            {
                _collectionGraf = value;
            }
        }
    }
}
