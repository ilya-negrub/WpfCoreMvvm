using System;
using System.Collections.Generic;
using System.Text;

namespace WpfCoreMvvm.ViewModel.Notifications
{
    public class NotificationMessage : BaseNotification<string>
    {
        private string message = string.Empty;
        public string Message => message;

        protected override void OnShow(string parametrs)
        {
            message = parametrs;
        }
    }
}
