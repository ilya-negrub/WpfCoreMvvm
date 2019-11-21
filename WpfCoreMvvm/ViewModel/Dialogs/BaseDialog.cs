using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using WpfCoreMvvm.ViewModel.Dialogs.Parametrs;
using WpfCoreMvvm.ViewModel.Helpers;

namespace WpfCoreMvvm.ViewModel.Dialogs
{
    public abstract class BaseDialog : BaseActivityViewModel<Helpers.Activitys.ActivitysCommandWait>
    {
        protected static ObservableCollection<BaseDialog> dialogsSource = new ObservableCollection<BaseDialog>();

        public static ObservableCollection<BaseDialog> DialogsSource => dialogsSource;
    }

    public abstract class BaseDialog<TParametrs, TResult> : BaseDialog
        where TParametrs : IDialogParametrs
    {
        private Action<TResult> trySetResult;

        private IDialogParametrs parametrs;

        public IDialogParametrs Parametrs => parametrs;
        
        public async Task<TResult> Show(TParametrs parametrs)
        {
            this.parametrs = parametrs;
            OnShow(parametrs);
            AddDialog(this);
            return await WaitsResponse();
        }

        protected virtual void OnShow(TParametrs parametrs) { }

        public void Close()
        {
            OnClose();
            RemoveDialog(this);
        }

        protected virtual void OnClose() { }

        private Task<TResult> WaitsResponse()
        {
            TaskCompletionSource<TResult> tcs = new TaskCompletionSource<TResult>();
            trySetResult = tcs.SetResult;
            return tcs.Task;
        }

        protected void SendResult(TResult result, bool isClose = true)
        {
            trySetResult?.Invoke(result);
            if (isClose) Close();
        }

        protected static void AddDialog(BaseDialog<TParametrs, TResult> dialog)
        {
            System.Windows.Application.Current?.Dispatcher?.BeginInvoke(new Action(() => { dialogsSource.Add(dialog); }));
        }

        protected static void RemoveDialog(BaseDialog<TParametrs, TResult> dialog)
        {
            System.Windows.Application.Current?.Dispatcher?.BeginInvoke(new Action(() => { dialogsSource.Remove(dialog); }));
        }
    }

}
