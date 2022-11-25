using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.DAL.Domain
{
    public class Comment
    {
        public Guid Id { get; set; }

        public string Text { get; set; } = string.Empty;

        public ApplicationUser Commenter { get; set; } = new ApplicationUser();

        public Caff CommentedCaff { get; set; } = new Caff();
    }
}
