using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WpfCoreMvvm.ViewModel.Notifications;

namespace WpfCoreMvvm.ViewModel.Items
{
    public class ItemA1 : BaseItemA
    {
        public override string Name => "Item_A1";
    }

    public class ItemA2 : BaseItemA
    {
        int numNotifi = 0;
        public override string Name => "Item_A2";

        public ICommand ShowNotifiCommand => base.Activitys.Commands.GetCommand(nameof(ShowNotifiCommand), ShowNotifi_Click);
        private void ShowNotifi_Click()
        {
            new NotificationMessage().Show($"({++numNotifi}) Notification: {Name}");
        }
    }

    public class ItemA3 : BaseItemA
    {
        public override string Name => "Item_A3";
    }


    public class ItemB1 : BaseItemB
    {
        public override string Name => "Item_B1";
    }

    public class ItemB2 : BaseItemB
    {
        public ICommand ShowNotifiCommand => base.Activitys.Commands.GetCommand(nameof(ShowNotifiCommand), ShowNotifi_Click);
        private void ShowNotifi_Click()
        {
            new NotificationMessage().Show($"Notification: {Name}");
        }
    }

    public class ItemB3 : BaseItemB
    {
        
    }
}
