using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.DAL.Domain
{
    public class Caff
    {
        public Guid Id { get; set; }

        public ApplicationUser Uploader { get; set; } = new ApplicationUser();

        public string Creator { get; set; } = string.Empty;

        public DateTime CreationDate { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Price { get; set; }

        public IList<Ciff> Ciffs { get; set; } = new List<Ciff>();

        public IList<Comment> Comments { get; set; } = new List<Comment>();

        public ApplicationUser? BoughtBy { get; set; } = new ApplicationUser();
    }
}
