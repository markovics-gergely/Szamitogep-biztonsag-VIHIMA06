using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.BLL.Infrastructure.ViewModels
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }

        public string Text { get; set; } = string.Empty;

        public UserNameViewModel Commenter { get; set; } = new UserNameViewModel();
    }
}
