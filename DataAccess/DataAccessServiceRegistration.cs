using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DataAccess.Contexts;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;

namespace DataAccess;
public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {

#if _WINDOWS
        services.AddDbContext<LibraryContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
#else
        services.AddDbContext<LibraryContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
#endif

        services.AddScoped<IUserDal, EfUserDal>();
        services.AddScoped<ICategoryDal, EfCategoryDal>();
        services.AddScoped<IBookDal, EfBookDal>();
        services.AddScoped<IAdminDal, EfAdminDal>();
        services.AddScoped<IAuthorDal, EfAuthorDal>();
        services.AddScoped<IForgotPasswordDal, EfForgotPasswordDal>();
        services.AddScoped<IUserOperationClaimDal, EfUserOperationClaimDal>();
        services.AddScoped<IOperationClaimDal, EfOperationClaimDal>();

        return services;
    }
}