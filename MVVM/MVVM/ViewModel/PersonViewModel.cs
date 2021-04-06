using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVM.Command;
using MVVM.Model;
using System.ComponentModel;
using System.Windows;

namespace MVVM.ViewModel
{
    public class PersonViewModel: INotifyPropertyChanged
    {
        private PersonModel model = null;
        private ICommand _doSomething;
        private int input_Age;


        public PersonModel Model
        {
            get { return model; }
            set { model = value;
                OnPropertyChanged(nameof(Model));
            }
        }
        public PersonViewModel()
        {
            this.model = new PersonModel();
            this.model.Name = "Stanley";
            this.model.Age = 61;
        }


        public int Input_Age
        {
            get { return input_Age; }
            set { input_Age = value;
                OnPropertyChanged(nameof(Input_Age));
            }
        }
        public ICommand DoSomethingCommand
        {
            get
            {
                if (_doSomething == null)
                {
                    _doSomething = new RelayCommand(
                        p => Model.Age > 0,
                        p => {
                            if (Input_Age < 0)
                                MessageBox.Show("Age must be above 0");
                            else
                                this.Model.Age = this.Input_Age;
                        }
                        );
                }
                return _doSomething;
            }
            set
            {
                _doSomething = value;
                OnPropertyChanged(nameof(DoSomethingCommand));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

    }
}
