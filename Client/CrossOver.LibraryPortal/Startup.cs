using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrossOver.LibraryPortal.Startup))]
namespace CrossOver.LibraryPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
