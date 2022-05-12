using KYV.EA.Output1.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYV.EA.Output1.ViewModels
{
    public class Output1ViewModel : BindableBase
    {
        public string Title { get; } = "SingleValue";

        private string output;

        public string Output
        {
            get { return this.output; }
            set { this.SetProperty(ref this.output, value); }
        }

        private ISingleValueProvider singleValueProvider;

        private bool subcribe = true;

        public bool Subcribe
        {
            get { return this.subcribe; }
            set {
                this.SetProperty(ref this.subcribe, value);
                if (singleValueProvider != null)
                {
                    if (value)
                    {
                        singleValueProvider.Subcribe();
                    }
                    else
                    {
                        singleValueProvider.UnSubcribe();
                    }
                }
            }
        }

        public Output1ViewModel(ISingleValueProvider _singleValueProvider)
        {
            singleValueProvider = _singleValueProvider;
            singleValueProvider.Subcribe();
            singleValueProvider
                .PropertyChanged += (_, e) =>
                {
                    if (e.PropertyName == "Value")
                    {
                        this.Output = $"Input value is {singleValueProvider.Value}";
                    }
                };
        }
    }
}
