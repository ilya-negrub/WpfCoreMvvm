using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using WpfCoreMvvm.ViewModel.Dialogs;
using WpfCoreMvvm.ViewModel.Dialogs.Parametrs;
using WpfCoreMvvm.ViewModel.Helpers;
using WpfCoreMvvm.ViewModel.Items;

namespace WpfCoreMvvm.ViewModel
{
    public class MainViewModel : BaseActivityViewModel<Helpers.Activitys.ActivitysCommandWait>
    {
        private int cntTitle = 1;
        private ObservableCollection<IItems> itemsSource = new ObservableCollection<IItems>()
        {
            new ItemA3(),
            new ItemA1(),
            new ItemA2(),
            new ItemA3(),
            new ItemB1(),
            new ItemB2(),
            new ItemB2(),
            new ItemB3(),
        };

        public string Title => GetTitle(cntTitle++);
        public ObservableCollection<IItems> ItemsSource => itemsSource;

        private string GetTitle(int cnt) => $"Hello World {cnt}";

        #region Commands
        public ICommand IncrementTitleCommand => base.Activitys.Commands.GetCommand(nameof(IncrementTitleCommand), IncrementTitleClick);


        #region Implementations
        private async void IncrementTitleClick()
        {
            ResultDialogMessage result = ResultDialogMessage.Cancel;

            await base.Activitys.WaitUi.Begin(async () =>
            {
                result = await new DialogMessage().Show(
                    new DialogParametrsMessage("DialogMessage", $"Next index: {cntTitle}")
                    {
                        Buttons = DialogButtons.Ok | DialogButtons.Cancel,
                        //CustomButtons = GetCustomButtons()
                    });
            });

            if (result == ResultDialogMessage.Ok)
            {
                OnPropertyChanged(nameof(Title));
            }
        }

        private IEnumerable<DialogMessageButtons> GetCustomButtons()
        {
            yield return new DialogMessageButtons("Custom Ok", () => ResultDialogMessage.Ok);
            yield return new DialogMessageButtons("Custom Cancel", () => ResultDialogMessage.Cancel);
        }


        #endregion

        #endregion

    }
}
