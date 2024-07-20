using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IAuthorDal : IAsyncRepository<Author,Guid>, IRepository<Author,Guid>
{
}