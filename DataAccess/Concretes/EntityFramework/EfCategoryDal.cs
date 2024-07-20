using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework;

public class EfCategoryDal : EfRepositoryBase<Category, Guid, LibraryContext>, ICategoryDal
{
    public EfCategoryDal(LibraryContext context) : base(context)
    {
        
    }
}