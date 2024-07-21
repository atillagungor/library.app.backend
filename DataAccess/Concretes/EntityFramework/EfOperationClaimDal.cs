using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework;
public class EfOperationClaimDal : EfRepositoryBase<OperationClaim, Guid, LibraryContext>, IOperationClaimDal
{
    public EfOperationClaimDal(LibraryContext context) : base(context)
    {
    }
}