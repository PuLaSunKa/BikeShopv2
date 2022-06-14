using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BikeShopv2.Startup))]
namespace BikeShopv2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
