using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HitIt.Startup))]
namespace HitIt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
