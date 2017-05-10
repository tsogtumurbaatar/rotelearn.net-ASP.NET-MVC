using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(rotelearn.Startup))]
namespace rotelearn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
