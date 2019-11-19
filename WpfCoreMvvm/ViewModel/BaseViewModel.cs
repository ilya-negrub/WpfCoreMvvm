using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace WpfCoreMvvm.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotifyPropertyChanged

        #region Commands
        protected Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

        protected ICommand GetVmCommand(string propName, Action action)
        {
            if (commands.TryGetValue(propName, out ICommand command))
            {
                return command;
            }
            else
            {
                command = new Command(action);
                commands.Add(propName, command);
                return command;
            }
        }

        protected ICommand GetCommand<T>(string propName, Action<T> action)
        {
            if (commands.TryGetValue(propName, out ICommand command))
            {
                return command;
            }
            else
            {
                command = new Command<T>(action);
                commands.Add(propName, command);
                return command;
            }
        }

        #endregion
    }
}
