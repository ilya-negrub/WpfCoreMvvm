using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using WpfCoreMvvm.ViewModel.Dialogs.Parametrs;
using WpfCoreMvvm.ViewModel.Helpers;
using System.Linq;

namespace WpfCoreMvvm.ViewModel.Dialogs
{
    public enum ResultDialogMessage
    {
        Ok = 1,
        Yes = 2,
        No = 3,
        Cancel = 4,
    }

    public class DialogMessage : BaseDialog<DialogParametrsMessage, ResultDialogMessage>
    {
        private ObservableCollection<DialogMessageButtons> buttonsSource = new ObservableCollection<DialogMessageButtons>();

        public ObservableCollection<DialogMessageButtons> ButtonsSource => buttonsSource;

        protected override void OnShow(DialogParametrsMessage parametrs)
        {

            if (parametrs.CustomButtons == null || parametrs.CustomButtons.Count() == 0)
            {
                if ((parametrs.Buttons & DialogButtons.Ok) == DialogButtons.Ok)
                    buttonsSource.Add(new DialogMessageButtons("Ok", () => ResultDialogMessage.Ok));

                if ((parametrs.Buttons & DialogButtons.Yes) == DialogButtons.Yes)
                    buttonsSource.Add(new DialogMessageButtons("Yes", () => ResultDialogMessage.Yes));

                if ((parametrs.Buttons & DialogButtons.No) == DialogButtons.No)
                    buttonsSource.Add(new DialogMessageButtons("No", () => ResultDialogMessage.No));

                if ((parametrs.Buttons & DialogButtons.Cancel) == DialogButtons.Cancel)
                    buttonsSource.Add(new DialogMessageButtons("Cancel", () => ResultDialogMessage.Cancel));
            }
            else
            {
                parametrs.CustomButtons.ToList().ForEach(f => buttonsSource.Add(f));
            }

            buttonsSource.ToList().ForEach(f => f.OnResult += (sender, res) => base.SendResult(res));

        }
    }
}
