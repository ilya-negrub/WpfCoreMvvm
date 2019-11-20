using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WpfCoreMvvm.ViewModel.Dialogs.Parametrs;

namespace WpfCoreMvvm.ViewModel.Dialogs
{
    public enum ResultDialogMessage
    {
        Ok,
        No,
        Cancel,
    }

    public class DialogMessage : BaseDialog<Parametrs.DialogParametrsMessage, ResultDialogMessage>
    {

        public ICommand OkCommand => base.Activitys.Commands.GetCommand(nameof(OkCommand), OkClick);

        private void OkClick()
        {
            base.SendResult(ResultDialogMessage.Ok);
        }
    }
}
