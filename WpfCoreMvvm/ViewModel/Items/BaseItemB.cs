using System;
using System.Collections.Generic;
using System.Text;
using WpfCoreMvvm.ViewModel.Helpers;
using WpfCoreMvvm.ViewModel.Helpers.Activitys;

namespace WpfCoreMvvm.ViewModel.Items
{
    public class BaseItemB : BaseActivityViewModel<ActivitysCommand>, IItems
    {
        public virtual string Name => $"{this.GetType().Name} : BaseItemB";
    }
}
