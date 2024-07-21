using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework;

public class EfForgotPasswordDal : EfRepositoryBase<ForgotPassword, Guid, LibraryContext>, IForgotPasswordDal
{
    public EfForgotPasswordDal(LibraryContext context) : base(context)
    {
    }
}