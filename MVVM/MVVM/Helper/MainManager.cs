using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM.Model;
using MVVM.ViewModel;


namespace MVVM.Helper
{
    public class MainManager
    {
        private PersonModel personModel = null;
        private PersonViewModel personViewModel = null; 

        public PersonModel PersonModel
        {
            get { return personModel; }
        }
        public PersonViewModel PersonViewModel
        {
            get { return personViewModel; }
        }

        public static string path = $@"{Directory.GetCurrentDirectory()}\System";
        public MainManager()
        {
            
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            CreateInstance();
        }

        private void CreateInstance()
        {
            string path = MainManager.path + "\\" + "PersonModel.xml";
            var temp = XmlHelper.LoadXml(typeof(PersonModel), path);
            personModel = new PersonModel();
            personModel = (PersonModel)temp;
            personModel.Name = personModel.PersonModels[0].Name;
            personModel.Age = personModel.PersonModels[0].Age;
            personViewModel = new PersonViewModel(personModel);

            //personModel.PersonModels.Add(new PersonModel() { Name = "Selena", Age = 18 });
            
           
            
        }

        public void Save()
        {
            XmlHelper.SaveXml(typeof(PersonModel), this.personModel, Directory.GetCurrentDirectory());
        }
    }
}
