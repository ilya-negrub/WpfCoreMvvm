using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfCoreMvvm.ViewModel.Dialogs.Parametrs
{
    public class DialogParametrsMessage : IDialogParametrs
    {
        private string header = string.Empty;
        public string Header => header;

        public DialogParametrsMessage(string header)
        {
            this.header = header;
        }
    }
}
