using KYV.EA.Infrastructure;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace KYV.EA.Output2.Models
{
    public class MultiValueProvider : IMultiValueProvider
    {
        private ObservableCollection<int> Source { get; } = new ObservableCollection<int>();

        public IReadOnlyCollection<int> Values { get; }

        private SubscriptionToken Token { get; }

        private IEventAggregator eventAggregator;

        public MultiValueProvider(IEventAggregator _eventAggregator)
        {
            this.eventAggregator = _eventAggregator;
            this.Values = new ReadOnlyObservableCollection<int>(this.Source);
        }

        public void Subcribe()
        {
            eventAggregator
               .GetEvent<InputValueEvent>()
               .Subscribe(sub,ThreadOption.UIThread);
        }

        private void sub(InputValue obj)
        {
            this.Source.Insert(0, obj.Value);
        }

        public void UnSubcribe()
        {
            eventAggregator
               .GetEvent<InputValueEvent>()
               .Unsubscribe(sub);
        }
    }
}
