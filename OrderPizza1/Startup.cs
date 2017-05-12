using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OrderPizza1.Startup))]
namespace OrderPizza1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
