using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IUserDal : IAsyncRepository<User, Guid>, IRepository<User, Guid>
{
}