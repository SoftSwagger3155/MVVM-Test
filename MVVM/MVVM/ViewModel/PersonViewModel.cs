using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM.Model;

namespace MVVM.ViewModel
{
    public class PersonViewModel
    {
        public PersonModel Model = new PersonModel();
        public PersonViewModel()
        {
           // this.Model = new PersonModel();
            this.Model.Name = "Stanley";
            this.Model.Age = 61;
        }


    }
}
