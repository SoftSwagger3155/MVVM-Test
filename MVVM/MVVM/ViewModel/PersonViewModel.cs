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
using MVVM.Helper;
using System.IO;

namespace MVVM.ViewModel
{
    public class PersonViewModel: INotifyPropertyChanged
    {
        private PersonModel model = null;
        private ICommand _doSomething;
        private ICommand _doSave;
        private int input_Age;


        public PersonModel Model
        {
            get { return model; }
        }
        public PersonViewModel(PersonModel model)
        {
            this.model = model;
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
                        p => model.Age > 0,
                        p => {
                            if (Input_Age < 0)
                                MessageBox.Show("Age must be above 0");
                            else
                                this.model.Age = this.Input_Age;
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

        public ICommand DoSaveCommand
        {
            get
            {
                if (_doSave == null)
                {
                    _doSave = new RelayCommand(
                        p => true,
                        p => {
                            string path = MainManager.path +"\\"+"PersonModel.xml"; 
                            XmlHelper.SaveXml(typeof(PersonModel), this.Model, path);
                        }
                        );
                }
                return _doSave;
            }
            set
            {
                _doSave = value;
                OnPropertyChanged(nameof(DoSaveCommand));
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
