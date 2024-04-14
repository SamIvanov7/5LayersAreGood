using Library.Core.Common;
using Library.Core.Domain.Authors.Common;
using Library.Infrastructure.Core.Common;
using Library.Infrastructure.Core.Domain.Authors.Common;
using Library.Infrastructure.Processing;
using Library.Infrastructure.Core.Domain.Bocks.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Library.Core.Domain.Bocks.Common;

namespace Library.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // checkers
            services.AddScoped<IAuthorMustExistChecker, AuthorMustExistChecker>();
            services.AddScoped<IBockMustExistChecker, BockMustExistChecker>();

            // repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthorsRepository, AuthorsRepository>();
            services.AddScoped<IBocksAuthorsRepository, BocksAuthorsRepository>();

            // processing
            services.AddScoped<IEnumerationIgnorer, EnumerationIgnorer>();
        }
    }
}
