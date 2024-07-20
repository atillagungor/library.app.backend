using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DataAccess.Contexts;

namespace DataAccess;
public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {

#if _WINDOWS
        services.AddDbContext<LibraryContext>(options => options.UseSqlServer(configuration.GetConnectionString("LibraryAppDb")));
#else
        services.AddDbContext<LibraryContext>(options => options.UseSqlServer(configuration.GetConnectionString("LibraryAppDb")));
#endif

        services.AddScoped<IUserDal, EfUserDal>();
        services.AddScoped<ICategoryDal, EfCategoryDal>();

        return services;
    }
}