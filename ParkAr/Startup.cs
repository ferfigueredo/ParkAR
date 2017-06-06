using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ParkAr.Startup))]
namespace ParkAr
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
