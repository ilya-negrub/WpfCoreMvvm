using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WpfCoreMvvm.ViewModel.Helpers.Activity
{
    public class ActivityWaitUi : BaseViewModel
    {
        private bool isWaiting = false;
        public bool IsWaiting => isWaiting;


        private void SetWaiting(bool val)
        {
            isWaiting = val;
            System.Windows.Application.Current?.Dispatcher?.Invoke(() => OnPropertyChanged(nameof(IsWaiting)));
        }


        public Task<bool> Begin(Func<Task> action)
        {
            return Begin<bool>(async () =>
            {
                await action();
                return true;
            });
        }

        public Task<TResult> Begin<TResult>(Func<Task<TResult>> action)
        {
            TaskCompletionSource<TResult> tcs = new TaskCompletionSource<TResult>();            
            Task.Factory.StartNew(async () => 
            {
                TResult res = default(TResult);
                Begin();
                try
                {
                    res = await action();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Dialog Exception: {ex.Message}");
                }
                finally
                {
                    End();
                }
                tcs.SetResult(res);
            });
            return tcs.Task;
        }


        public void Begin()
        {
            SetWaiting(true);
        }

        public void End()
        {
            SetWaiting(false);
        }
    }
}
