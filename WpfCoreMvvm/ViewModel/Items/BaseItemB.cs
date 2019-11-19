using System;
using System.Collections.Generic;
using System.Text;

namespace WpfCoreMvvm.ViewModel.Items
{
    public class BaseItemB : IItems
    {
        public virtual string Name => $"{this.GetType().Name} : BaseItemB";
    }
}
