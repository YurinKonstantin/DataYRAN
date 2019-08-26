using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.Storage.FileProperties;

namespace DataYRAN
{
    [Serializable]
    public class ClassСписокList : INotifyPropertyChanged
    {
        public String Text { get; set; }
        public ICommand Command { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
     public   BasicProperties basicProperties { get; set; }
        public string NameFile { get; set; }
        public string NemePapka { get; set; }
        public ulong size { get; set; }
        public bool status;
        public bool Status
        {
            get { return status; }
            set { Set(ref status, value); }
        }
        public ulong sizeF
        {
            get
            {
                return basicProperties.Size / 1048576;
            }
        }
        public bool statusP;
        public bool StatusP
        {
            get { return statusP; }
            set { Set(ref statusP, value); }
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
