using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyDotNet.Startup))]
namespace VidlyDotNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
