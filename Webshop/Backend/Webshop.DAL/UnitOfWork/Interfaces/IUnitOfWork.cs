using Webshop.DAL.Domain;
using Webshop.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.DAL.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<ApplicationUser> UserRepository { get; }

        IGenericRepository<Caff> CaffRepository { get; }

        IGenericRepository<Ciff> CiffRepository { get; }

        IGenericRepository<Comment> CommentRepository { get; }

        Task Save();
    }
}
