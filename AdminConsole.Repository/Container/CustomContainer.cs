using  Microsoft.Extensions.DependencyInjection;
using  Microsoft.Extensions.Configuration;

using AdminConsole.Repository.Factory;
using CodeGen.Repository.Repositories.Interfaces;
using CodeGen.Repository.Repository;
namespace AdminConsole.Repository.Container
{
	public static class CustomContainer
	{
		public static void AddCustomContainer(this IServiceCollection services, IConfiguration configuration)
		{
		ICachDB10ConnectionFactory CachDB10connectionFactory=new CachDB10ConnectionFactory(configuration.GetConnectionString("DBconnectionCachDB10"));
		services.AddSingleton<ICachDB10ConnectionFactory> (CachDB10connectionFactory);

		services.AddScoped<IHierarchyServiceProviderRepository, HierarchyServiceProviderRepository>();
		services.AddScoped<ILevelServiceProvider, LevelServiceProvider>();
		services.AddScoped<ILevelDetailsServiceProvider, LeveDetailslServiceProvider>();
		services.AddScoped<IDesignationServiceProvider, DesignationServiceProvider>();
		services.AddScoped<IFuncServiceProvider, FuncServiceProviderNew>();
		services.AddScoped<IProjectLinkServiceProvider, ProjectLinkServiceProvider>();
		services.AddScoped<IGblLinkServiceProvider, GblLinkServiceProvider>();
		services.AddScoped<IPriLinkServiceProvider, PriLinkServiceProvider>();
		services.AddScoped<ISetPermissionServiceProvider, SetPermissionServiceProvider>();
		services.AddScoped<IUserServiceProvider, UserServiceProvider>();
			//Write code here
		}
	}
}
