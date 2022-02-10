using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchKata
{
    public interface IDb
    {
        IQueryable<string> CityNames { get; }
    }
}
