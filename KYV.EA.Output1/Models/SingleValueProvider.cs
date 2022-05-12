using KYV.EA.Infrastructure;
using Prism.Events;
using Prism.Mvvm;

namespace KYV.EA.Output1.Models
{
    public class SingleValueProvider : BindableBase, ISingleValueProvider
    {
        private int value;

        public int Value
        {
            get { return this.value; }
            private set { this.SetProperty(ref this.value, value); }
        }
        private IEventAggregator eventAggregator;

        public SingleValueProvider(IEventAggregator _eventAggregator)
        {
            this.eventAggregator = _eventAggregator;
            //eventAggregator
            //    .GetEvent<InputValueEvent>()
            //    .Subscribe(x => this.Value = x.Value, ThreadOption.UIThread);
        }

        public void Subcribe()
        {
            eventAggregator
               .GetEvent<InputValueEvent>()
               .Subscribe(sub, ThreadOption.UIThread);
        }

        private void sub(InputValue obj)
        {
            this.Value = obj.Value;
        }

        public void UnSubcribe()
        {
            eventAggregator
               .GetEvent<InputValueEvent>()
               .Unsubscribe(sub);
        }
    }
}
