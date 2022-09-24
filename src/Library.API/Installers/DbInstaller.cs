using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Installers
{
    public class DbInstaller : IInstaller

    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LibraryContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("LibraryCS")));
        }
    }
}
