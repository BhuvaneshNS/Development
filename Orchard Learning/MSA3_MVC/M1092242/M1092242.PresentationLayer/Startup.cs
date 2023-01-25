using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(M1092242.PresentationLayer.Startup))]
namespace M1092242.PresentationLayer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
