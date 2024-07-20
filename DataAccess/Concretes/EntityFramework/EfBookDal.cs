using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework;

public class EfBookDal : EfRepositoryBase<Book, Guid, LibraryContext>, IBookDal
{
    public EfBookDal(LibraryContext context) : base(context)
    {
        
    }
}