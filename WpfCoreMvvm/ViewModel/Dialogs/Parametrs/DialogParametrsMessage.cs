using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfCoreMvvm.ViewModel.Dialogs.Parametrs
{
    public enum DialogButtons
    {
        Ok     = 0b0001,
        Yes    = 0b0010,
        No     = 0b0100,
        Cancel = 0b1000,
    }


    public class DialogParametrsMessage : IDialogParametrs
    {
        private string header = string.Empty;
        private string message = string.Empty;
        public string Header => header;
        public string Message => message;

        public DialogButtons Buttons { get; set; } = DialogButtons.Ok;

        public IEnumerable<DialogMessageButtons> CustomButtons { get; set; }

        public DialogParametrsMessage(string header, string message)
        {
            this.header = header;
            this.message = message;
        }
    }
}
