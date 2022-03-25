using MVVM_Demo.Command;
using MVVM_Demo.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVVM_Demo.ViewModel
{
    public class PersonViewModel:BaseViewModel
    {
        private ObservableCollection<Person> persons;

        public ObservableCollection<Person> Persons
        {
            get { return persons; }
            set { persons = value; OnPropertyChanged("Persons"); }
        }



        private Person person;
        public Person Person
        {
            get { return person; }
            set { person = value; OnPropertyChanged("Person"); }
        }


        public PersonViewModel()
        {
            Person = new Person();
            Persons = new ObservableCollection<Person>();

        }
       


        private ICommand _SubmitCommand;

        public ICommand SubmitCommand
        {
            get 
            { 
                if( _SubmitCommand == null)
                {
                    _SubmitCommand = new RelayCommand(SubmitExecute, CanSubmitExecute, false);
                }
                return _SubmitCommand; 
            }
            
        }

        private bool CanSubmitExecute(object arg)
        {
            if (string.IsNullOrEmpty(Person.FirstName)||string.IsNullOrEmpty(Person.LastName))
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        /// <summary>
        /// Submit button click event
        /// </summary>
        /// <param name="obj"></param>
        private void SubmitExecute(object obj)
        {

            Persons.Add(Person);
            
        }
    }
}
