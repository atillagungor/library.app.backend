using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework;

public class EfUserDal : EfRepositoryBase<User, Guid, LibraryContext>, IUserDal
{
    public EfUserDal(LibraryContext context) : base(context)
    {
        
    }
}