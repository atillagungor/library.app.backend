using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework;
public class EfUserOperationClaimDal : EfRepositoryBase<UserOperationClaim, Guid, LibraryContext>, IUserOperationClaimDal
{
    public EfUserOperationClaimDal(LibraryContext context) : base(context)
    {
    }
}