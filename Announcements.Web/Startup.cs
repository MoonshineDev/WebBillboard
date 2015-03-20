using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Announcements.Web.Startup))]
namespace Announcements.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
