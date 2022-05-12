using KYV.EA.Output2.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Prism.Mvvm;

namespace KYV.EA.Output2.ViewModels
{
    public class Output2ViewModel: BindableBase
    {
        IMultiValueProvider multiValueProvider;

        public string Title { get; } = "Multi values"; 
        
        private bool subcribe = true;

        public bool Subcribe
        {
            get { return this.subcribe; }
            set {
                this.SetProperty(ref this.subcribe, value);
                if (multiValueProvider != null)
                {
                    if (value)
                    {
                        multiValueProvider.Subcribe();
                    }
                    else
                    {
                        multiValueProvider.UnSubcribe();
                    }
                }
            }
        }

        public ReadOnlyObservableCollection<string> Values { get; }

        public Output2ViewModel(IMultiValueProvider _multiValueProvider)
        {
            multiValueProvider = _multiValueProvider;
            multiValueProvider.Subcribe();
            var source = new ObservableCollection<string>();
            this.Values = new ReadOnlyObservableCollection<string>(source);
            ((INotifyCollectionChanged)multiValueProvider.Values).CollectionChanged += (_, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    source.Insert(e.NewStartingIndex, e.NewItems.Cast<int>().Select(x => $"Input value is {x}").First());
                }
            };
        }
    }
}
