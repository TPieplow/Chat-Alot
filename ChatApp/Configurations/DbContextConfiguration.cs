using Chat_Alot_Library.DbContext;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Configurations;

public static class DbContextConfiguration
{
    public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(x => x.UseSqlServer(configuration.GetConnectionString("SqlServer")));
    }
}
