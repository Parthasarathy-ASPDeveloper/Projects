using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AssetsMVC.Startup))]
namespace AssetsMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
