using Webshop.DAL.Domain;
using Webshop.DAL.Repository.Implementations;
using Webshop.DAL.Repository.Interfaces;
using Webshop.DAL.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.DAL.UnitOfWork.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WebshopDbContext context;
        private readonly IGenericRepository<ApplicationUser> userRepository;
        private readonly IGenericRepository<Caff> caffRepository;
        private readonly IGenericRepository<Ciff> ciffRepository;
        private readonly IGenericRepository<Comment> commentRepository;

        public IGenericRepository<ApplicationUser> UserRepository => userRepository;

        public IGenericRepository<Caff> CaffRepository => caffRepository;

        public IGenericRepository<Ciff> CiffRepository => ciffRepository;

        public IGenericRepository<Comment> CommentRepository => commentRepository;

        public UnitOfWork(WebshopDbContext context, 
            IGenericRepository<ApplicationUser> userRepository,
            IGenericRepository<Caff> caffRepository,
            IGenericRepository<Ciff> ciffRepository,
            IGenericRepository<Comment> commentRepository)
        {
            this.context = context;
            this.userRepository = userRepository;
            this.caffRepository = caffRepository;
            this.ciffRepository = ciffRepository;
            this.commentRepository = commentRepository;
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
