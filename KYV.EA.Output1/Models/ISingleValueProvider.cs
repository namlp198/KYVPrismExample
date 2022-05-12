using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYV.EA.Output1.Models
{
    public interface ISingleValueProvider : INotifyPropertyChanged
    {
        int Value { get; }

        void Subcribe();
        void UnSubcribe();
    }
}
