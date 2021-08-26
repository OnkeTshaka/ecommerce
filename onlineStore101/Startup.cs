using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(onlineStore101.Startup))]
namespace onlineStore101
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
