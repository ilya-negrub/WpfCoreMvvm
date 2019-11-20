using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WpfCoreMvvm.ViewModel.Helpers.Activity
{
    public class ActivityCommand
    {
        protected Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

        public ICommand GetCommand(string propName, Action action)
        {
            if (!commands.TryGetValue(propName, out ICommand command))
            {
                command = new Command(action);
                commands.Add(propName, command);
            }
            return command;
        }

        public ICommand GetCommand<T>(string propName, Action<T> action)
        {
            if (!commands.TryGetValue(propName, out ICommand command))
            {
                command = new Command<T>(action);
                commands.Add(propName, command);
            }
            return command;
        }
    }
}
