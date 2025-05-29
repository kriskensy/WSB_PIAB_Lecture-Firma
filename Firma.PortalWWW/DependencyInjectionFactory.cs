using Firma.Interfaces.CMS;
using Firma.Interfaces.Shop;
using Firma.Services.CMS;
using Firma.Services.Shop;

namespace Firma.PortalWWW
{
    public static class DependencyInjectionFactory
    {
        public static void Resolve(IServiceCollection services, IConfiguration conf)
        {
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<IPageService, PageService>();
            services.AddScoped<IGoodService, GoodService>();
            services.AddScoped<ITypeOfService, TypeOfService>();
        }
    }
}
