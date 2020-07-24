
using Microsoft.Extensions.DependencyInjection;
using MultiStoreShoppingCart.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiStoreShoppingCart.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IInvoiceDetailsRepository, InvoiceDetailsRepository>();

            services.AddScoped<IInvoiceRepository, InvoiceRepository>();

            services.AddScoped<IMembershipRepository, MembershipRepository>();

            services.AddScoped<IPackageRepository, PackageRepository>();

            services.AddScoped<IPhotoRepository, PhotoRepository>();

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IRoleRepository, RoleRepository>();

            services.AddScoped<ISlideShowRepository, SlideShowRepository>();
        }
    }
}
