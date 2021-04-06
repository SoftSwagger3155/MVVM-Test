using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MVVM.ViewModel;

namespace MVVM.View
{
    /// <summary>
    /// CtrlPerson.xaml 的交互逻辑
    /// </summary>
    public partial class CtrlPerson : UserControl
    {
        public CtrlPerson()
        {
            InitializeComponent();
        }

        PersonViewModel vmPerson = null;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.vmPerson = new PersonViewModel();
            this.DataContext = vmPerson.Model;
        }

        private void _btn_AgeChange_Click(object sender, RoutedEventArgs e)
        {
            int age = Convert.ToInt32(_tbx_Age.Text);
            this.vmPerson.Model.Age = age;
        }
    }
}
