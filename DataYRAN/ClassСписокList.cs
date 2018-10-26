using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DataYRAN
{
    [Serializable]
    public class ClassСписокList : INotifyPropertyChanged
    {
       
        public event PropertyChangedEventHandler PropertyChanged;

        public string NameFile { get; set; }
        public string NemePapka { get; set; }
        public ulong size { get; set; }
        public bool status;
        public bool Status
        {
            get { return status; }
            set { Set(ref status, value); }
        }
        public ulong statusSize;
        public ulong StatusSize
        {
            get { return statusSize; }
            set { Set(ref statusSize, value); }
        }
        public StorageFile file1 { get; set; }
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool Set<T>(ref T field, T value,
                             [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
    }
}
