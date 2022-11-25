using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.BLL.Infrastructure.DataTransferObjects
{
    public class UploadCaffDTO
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public IEnumerable<IFormFile> Caffs { get; set; } = Enumerable.Empty<IFormFile>();
    }
}
