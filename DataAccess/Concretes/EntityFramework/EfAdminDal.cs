using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework;

public class EfAdminDal : EfRepositoryBase<Admin, Guid, LibraryContext>, IAdminDal
{
    public EfAdminDal(LibraryContext context) : base(context)
    {
        
    }
}