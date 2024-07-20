using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IRoleDal : IAsyncRepository<Role, Guid>, IRepository<Role, Guid>
{
}