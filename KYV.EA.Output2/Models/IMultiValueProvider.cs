using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYV.EA.Output2.Models
{
    public interface IMultiValueProvider
    {
        IReadOnlyCollection<int> Values { get; }

        void Subcribe();
        void UnSubcribe();
    }
}
