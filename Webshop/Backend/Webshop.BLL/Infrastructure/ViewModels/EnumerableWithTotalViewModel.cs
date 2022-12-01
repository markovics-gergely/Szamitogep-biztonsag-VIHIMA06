using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.BLL.Infrastructure.ViewModels
{
    public class EnumerableWithTotalViewModel<T>
    {
        public IEnumerable<T> Values { get; set; } = Enumerable.Empty<T>();

        public int Total { get; set; }
    }
}
