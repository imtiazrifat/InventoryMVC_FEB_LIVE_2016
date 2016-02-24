using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InventoryMVC.Startup))]
namespace InventoryMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
