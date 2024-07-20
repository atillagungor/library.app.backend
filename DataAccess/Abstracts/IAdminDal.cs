using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IAdminDal : IAsyncRepository<Admin, Guid>, IRepository<Admin, Guid>
{
}