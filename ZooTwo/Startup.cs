using Microsoft.Owin;
using Owin;
using ZooTwo;

[assembly: OwinStartup(typeof (Startup))]

namespace ZooTwo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}