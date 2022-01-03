using System;
using System.Collections.Generic;
using System.Text;

using System.Collections.ObjectModel;
using System.ComponentModel;
using UIApp.Models;
using UIApp.Commands;

namespace UIApp.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
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

        EmployeeService employeeService;
        private ObservableCollection<Employee> employeesList;
        public ObservableCollection<Employee> EmployeesList
        { 
            get => employeesList;
            set { employeesList = value; OnPropertyChanged("EmployeesList"); }
        }

        private Employee currentEmployee;
        public Employee CurrentEmployee
        { 
            get => currentEmployee;
            set { currentEmployee = value; OnPropertyChanged("CurrentEmployee"); }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }


        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }

        private RelayCommand searchCommand;
        public RelayCommand SearchCommand
        {
            get { return searchCommand; }
        }

        private RelayCommand updateCommand;
        public RelayCommand UpdateCommand
        {
            get { return updateCommand; }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get { return removeCommand; }
            set { removeCommand = value; }
        }


        public void Save()
        {
            try
            {
                var IsSaved = employeeService.Add(CurrentEmployee);
                //LoadData();
                if (IsSaved) { Message = "Employee Add"; }
                else { Message = "Save operation failed"; }
            }
            catch (Exception e)
            {

                Message = e.Message;
            }
        }

        public void Search()
        {
            try
            {
                var employee = employeeService.Find(CurrentEmployee.Id);
                if (employee.Id != 0) {
                    CurrentEmployee = employee;
                    Message = CurrentEmployee.Name; 
                }
                else { Message = "Don't find"; }
            }
            catch (Exception e)
            {

                Message = e.Message;
            }
        }
        public void Update()
        {
            try
            {
                var IsUpdated = employeeService.Update(CurrentEmployee);
                if (IsUpdated)
                {
                    LoadData();
                    Message = "Update operation succed";
                }
                else { Message = "Update operation failed"; }
            }
            catch (Exception e)
            {

                Message = e.Message;
            }
        }

        public void Remove()
        {
            try
            {
                var IsDeleted = employeeService.Remove(CurrentEmployee.Id);
                if (IsDeleted)
                {
                    LoadData();
                    Message = "Delete operation succed";
                }
                else { Message = "Delete operation fail"; }
            }
            catch (Exception e)
            {

                Message = e.Message;
            }
        }

        public EmployeeViewModel()
        {
            employeeService = new EmployeeService();
            LoadData();
            CurrentEmployee = new Employee();
            saveCommand = new RelayCommand(Save);
            searchCommand = new RelayCommand(Search);
            updateCommand = new RelayCommand(Update);
            removeCommand = new RelayCommand(Remove);
        }

        private void LoadData()
        {
            EmployeesList = new ObservableCollection<Employee>(employeeService.All());
        }
        // Data Biding with data grid

    }
}
