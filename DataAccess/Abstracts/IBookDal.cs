using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IBookDal : IAsyncRepository<Book,Guid>, IRepository<Book,Guid>
{
}