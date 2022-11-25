using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.BLL.Infrastructure.ViewModels
{
    public class CaffDetailsViewModel
    {
        public Guid Id { get; set; }

        public string Creator { get; set; } = string.Empty;

        public int Price { get; set; }

        public DateTime CreationDate { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public IEnumerable<CiffViewModel> Ciffs { get; set; } = Enumerable.Empty<CiffViewModel>();

        public IEnumerable<CommentViewModel> Comments { get; set; } = Enumerable.Empty<CommentViewModel>();

        public UserNameViewModel Uploader { get; set; } = new UserNameViewModel();
    }
}
