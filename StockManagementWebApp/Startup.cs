using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StockManagementWebApp.Startup))]
namespace StockManagementWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
