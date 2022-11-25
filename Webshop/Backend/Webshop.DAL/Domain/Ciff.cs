using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.DAL.Domain
{
    public class Ciff
    {
        public Guid Id { get; set; }

        public Caff Caff { get; set; } = new Caff();

        public string PhysicalPath { get; set; } = string.Empty;

        public string DisplayPath { get; set; } = string.Empty;

        public double Size { get; set; }

        public string Tags { get; set; } = string.Empty;

        public int Duration { get; set; }

        public string Caption { get; set; } = string.Empty;
    }
}
