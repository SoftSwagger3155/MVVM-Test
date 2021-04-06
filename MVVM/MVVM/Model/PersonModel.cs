using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace MVVM.Model
{
    public class PersonModel: INotifyPropertyChanged
    {
        private bool isPensionQualified = false;

        protected string name;
        protected int age;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                age = value;

                if (age > 60)
                    IsPensionQualified = true;
                else
                    IsPensionQualified = false;


                OnPropertyChanged(nameof(Age));
            }
        }

        public bool IsPensionQualified
        {
            get { return isPensionQualified; }
            set
            {
               

                isPensionQualified = value;
                OnPropertyChanged(nameof(IsPensionQualified));
                OnPropertyChanged(nameof(PensionQualifiedDisplay));
            }
        }
        public string PensionQualifiedDisplay
        {
            get { return this.IsPensionQualified ? "Qualified" : "Not-Qualified"; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }
}
