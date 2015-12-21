using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExemploAjax.Startup))]
namespace ExemploAjax
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
