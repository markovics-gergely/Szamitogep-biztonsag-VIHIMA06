using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.BLL.Infrastructure.DataTransferObjects
{
    public class GetCaffsDTO
    {
        public string? Search { get; set; }

        public int PageSize { get; set; }

        public int PageCount { get; set; }
    }
}
