using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using WpfCoreMvvm.ViewModel.Items;

namespace WpfCoreMvvm.ViewModel
{
    public class MainViewModel : BaseViewModel
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
        public ICommand IncrementTitleCommand => base.GetVmCommand(nameof(IncrementTitleCommand), IncrementTitleClick);


        #region Implementations
        private void IncrementTitleClick()
        {
            OnPropertyChanged(nameof(Title));
        }


        #endregion

        #endregion

    }
}
