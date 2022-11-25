using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.BLL.Infrastructure.ViewModels
{
    public class CiffViewModel
    {
        public Guid Id { get; set; }

        public IEnumerable<string> Tags { get; set; } = Enumerable.Empty<string>();

        public string Caption { get; set; } = string.Empty;

        public int Duration { get; set; }

        public string DisplayUrl { get; set; } = string.Empty;
    }
}
