using Exercise.PrismBasic.Events;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.PrismBasic.ViewModels
{
    public class ViewBViewModel : BindableBase
    {
        public ViewBViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<UpdateEvent>().Subscribe(a=> UpdatedTime = a);
        }

        private string _updatedTime;
        public string UpdatedTime
        {
            get { return _updatedTime; }
            set { SetProperty(ref _updatedTime, value); }
        }

    }
}
