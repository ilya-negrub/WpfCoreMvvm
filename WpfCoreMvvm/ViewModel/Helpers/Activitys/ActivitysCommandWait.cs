using System;
using System.Collections.Generic;
using System.Text;
using WpfCoreMvvm.ViewModel.Helpers.Activity;

namespace WpfCoreMvvm.ViewModel.Helpers.Activitys
{
    public class ActivitysCommandWait : IActivitysViewModel
    {
        public ActivityCommand Commands { get; } = new ActivityCommand();
        public ActivityWaitUi WaitUi { get; } = new ActivityWaitUi();
    }
}
