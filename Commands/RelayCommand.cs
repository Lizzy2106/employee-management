using System;
using System.Collections.Generic;
using System.Text;

//
// For ICommand Interface :
// https://docs.microsoft.com/fr-fr/dotnet/api/system.windows.input.icommand?view=net-6.0
//      Provid events and a set of method
//      that we'll use to invoce the behavior of our view component
//
using System.Windows.Input;

namespace UIApp.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action DoWork; //Delegate

        public RelayCommand(Action work)
        {
            DoWork = work;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            DoWork();
        }
        
    }
}
