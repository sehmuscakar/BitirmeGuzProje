using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BusinessLayer.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection LoadBusinessLayerExtension(this IServiceCollection services) // burda confige ihtiyacımız yok 
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddScoped<IContactCompanyDal, ContactCompanyDal>();
            services.AddScoped<IContactCompanyManager, ContactCompanyManager>();

            services.AddScoped<IHeroDal, HeroDal>();
            services.AddScoped<IHeroManager, HeroManager>();

            services.AddScoped<IBusinessModuleDal, BusinessModuleDal>();
            services.AddScoped<IBusinessModuleManager, BusinessModuleManager>();

            services.AddScoped<IMenuCategoryDal, MenuCategoryDal>();
            services.AddScoped<IMenuCategoryManager, MenuCategoryManager>();

            services.AddScoped<IMenuDal, MenuDal>();
            services.AddScoped<IMenuManager, MenuManager>();

            services.AddScoped<IServiceDal, ServiceDal>();
            services.AddScoped<IServiceManager, ServiceManager>();

            services.AddScoped<IPostContactDal, PostContactDal>();
            services.AddScoped<IPostContactManager, PostContactManager>();

            services.AddScoped<IBookingDal, BookingDal>();
            services.AddScoped<IBookingManager, BookingManager>();

            services.AddScoped<IGalleryDal, GalleryDal>();
            services.AddScoped<IGalleryManager, GalleryManager>();

            services.AddScoped<ITeamDal,TeamDal>();
            services.AddScoped<ITeamManager, TeamManager>();

            services.AddAutoMapper(assembly);// assembly ;automapper ın sisteme add lendi yani eklendiği ,bu ksıım auto mapperın dependis ejenşın olan kütüphanesi ile oluyor ona dikket et.
            return services;

        }

    }
}
