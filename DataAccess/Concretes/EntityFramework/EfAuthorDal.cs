using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework;

public class EfAuthorDal : EfRepositoryBase<Author, Guid, LibraryContext>, IAuthorDal
{
    public EfAuthorDal(LibraryContext context) : base(context)
    {
        
    }
}