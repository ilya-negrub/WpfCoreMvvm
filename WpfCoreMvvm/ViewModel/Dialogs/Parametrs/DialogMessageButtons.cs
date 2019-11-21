using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WpfCoreMvvm.ViewModel.Helpers;

namespace WpfCoreMvvm.ViewModel.Dialogs.Parametrs
{
    public class DialogMessageButtons : BaseActivityViewModel<Helpers.Activitys.ActivitysCommand>
    {
        public event EventHandler<ResultDialogMessage> OnResult;

        private string name;
        private Func<ResultDialogMessage> func;

        public string Name => name;

        public ICommand Command => base.Activitys.Commands.GetCommand("Command", CommandInvoke);


        public DialogMessageButtons(string name, Func<ResultDialogMessage> func)
        {
            this.name = name;
            this.func = func;
        }

        private void CommandInvoke()
        {
            OnResult?.Invoke(this, func.Invoke());
        }
    }
}
