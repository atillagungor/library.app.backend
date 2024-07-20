using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework;

public class EfRoleDal : EfRepositoryBase<Role, Guid, LibraryContext>, IRoleDal
{
    public EfRoleDal(LibraryContext context) : base(context)
    {
        
    }
}