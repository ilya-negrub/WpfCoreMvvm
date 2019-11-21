using System;
using System.Collections.Generic;
using System.Text;
using WpfCoreMvvm.ViewModel.Helpers;
using WpfCoreMvvm.ViewModel.Helpers.Activitys;

namespace WpfCoreMvvm.ViewModel.Items
{
    public abstract class BaseItemA : BaseActivityViewModel<ActivitysCommand>, IItems
    {
        public abstract string Name { get; }
    }
}
