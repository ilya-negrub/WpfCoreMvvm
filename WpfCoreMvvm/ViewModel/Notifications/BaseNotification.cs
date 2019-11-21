using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using WpfCoreMvvm.ViewModel.Helpers;
using WpfCoreMvvm.ViewModel.Helpers.Activitys;

namespace WpfCoreMvvm.ViewModel.Notifications
{
    public class BaseNotification : BaseActivityViewModel<ActivitysCommandWait>
    {
        private static ObservableCollection<BaseNotification> notificationsSource = new ObservableCollection<BaseNotification>();

        public static ObservableCollection<BaseNotification> NotificationsSource => notificationsSource;

        protected static void AddDialog(BaseNotification notification)
        {
            //System.Windows.Application.Current?.Dispatcher?.BeginInvoke(new Action(() => { notificationsSource.Add(notification); }));
            System.Windows.Application.Current?.Dispatcher?.BeginInvoke(new Action(() => { notificationsSource.Insert(0, notification); }));
        }

        protected static void RemoveDialog(BaseNotification notification)
        {
            System.Windows.Application.Current?.Dispatcher?.BeginInvoke(new Action(() => { notificationsSource.Remove(notification); }));
        }
    }

    public class BaseNotification<TParametrs> : BaseNotification
    {        
        private TParametrs parametrs;
        private System.Timers.Timer timer = new System.Timers.Timer();

        public TParametrs Parametrs => parametrs;
        public TimeSpan Duration { get; set; } = TimeSpan.FromMilliseconds(10000);

        public void Show(TParametrs parametrs)
        {
            this.parametrs = parametrs;
            timer.Interval = Duration.TotalMilliseconds;
            timer.Elapsed += Timer_Elapsed;
            OnShow(parametrs);
            AddDialog(this);
            timer.Start();
        }

        protected virtual void OnShow(TParametrs parametrs) { }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {   
            Close();
        }

        public void Close()
        {
            timer.Stop();
            RemoveDialog(this);
            OnClose();
        }

        protected virtual void OnClose() { }


        public ICommand CloseCommand => base.Activitys.Commands.GetCommand(nameof(CloseCommand), Close);
    }
}
