using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TryHarder.Startup))]
namespace TryHarder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
