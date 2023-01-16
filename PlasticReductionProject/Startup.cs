using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlasticReductionProject.Startup))]
namespace PlasticReductionProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
