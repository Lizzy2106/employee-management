using System;
using System.Collections.Generic;
using System.Text;

//
// For INotifyPropertyChanged Interface :
// https://docs.microsoft.com/fr-fr/dotnet/api/system.componentmodel.inotifypropertychanged?view=net-6.0
//      Whenever a property change in the Model
//      It'll be update in the Views
//      And vice versa
// Another option is to use header dependancy property 
//
//
using System.ComponentModel;

namespace UIApp.Models
{
    public class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            // Lever une l'évenement lorsque la valeur de propertyName change
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private int id;
        private string name;
        private int age;

        public int Id {
            get => id;
            set { id = value; OnPropertyChanged("Id");}
        }
        public string Name {
            get => name; 
            set { name = value; OnPropertyChanged("Name"); }
        }
        public int Age {
            get => age; 
            set { age = value; OnPropertyChanged("Age");}
        }

    }

    public class EmployeeService
    {
        private static List<Employee> employees;
        public List<Employee> All() => employees;
        public EmployeeService()
        {
            employees = new List<Employee>() {
                new Employee{ Id=100, Age=20, Name="Uno" },
                new Employee{ Id=101, Age=21, Name="Dos" },
                new Employee{ Id=102, Age=22, Name="Tres" }
            };
        }
        public bool Add(Employee e)
        {
            
            if (e.Age < 20)
            {
                throw new ArgumentException("Invalid age limit for employee");
            }
            else
            {
                employees.Add(e);
                return true;
            }
        }

        public bool Update(Employee e)
        {
            foreach (Employee em in employees)
            {
                if (em.Id == e.Id)
                {
                    em.Age = e.Age;
                    em.Name = e.Name;
                    return true;
                }
            }
            throw new ArgumentException("This guy doesn't work here");
        }
        
        public bool Remove(Employee e)
        {
            foreach(Employee em in employees)
            {
                if(em.Id == e.Id)
                {
                    employees.Remove(e);
                    return true;
                }
            }
            throw new ArgumentException("This guy doesn't work here");
        }

        public bool Remove(int id)
        {
            foreach (Employee em in employees)
            {
                if (em.Id == id)
                {
                    employees.Remove(em);
                    return true;
                }
            }
            throw new ArgumentException("This guy doesn't work here");
        }

        public Employee Find(int id)
        {
            return employees.Find(e => e.Id == id);
        }

        public Employee Find(Employee e)
        {
            return employees.Find(em => em.Id == e.Id);
        }
    }
}
