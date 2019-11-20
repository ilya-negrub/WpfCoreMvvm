using System;
using System.Collections.Generic;
using System.Text;
using WpfCoreMvvm.ViewModel.Helpers.Activitys;

namespace WpfCoreMvvm.ViewModel.Helpers
{
    public abstract class BaseActivityViewModel<TActivitys> : BaseViewModel
        where TActivitys : IActivitysViewModel, new()
    {
        internal TActivitys Activitys { get; } = new TActivitys();
    }
}
