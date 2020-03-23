using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.DependencyInjection;

namespace cangular
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2);
			/*
			services.AddHttpsRedirection(options =>
			{
				options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
				options.HttpsPort = 44381;
			});
			*/
			/*
			services.AddNodeServices(options =>
			{
				options.ProjectPath = "ClientApp";
			});
			*/

			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "client/dist";
			});

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}




			app.UseSpa(spa =>
			{
				spa.Options.SourcePath = "client";
				if (env.IsDevelopment())
				{
					spa.UseAngularCliServer(npmScript: "start");
//					spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
				}


			});
			app.UseStaticFiles();
			app.UseSpaStaticFiles();
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller}/{action=Index}/{id?}");
			});


		}

	}
}
			/*
						app.Run(async (context) =>
						{
							await context.Response.WriteAsync("Hello World!");
						});
			*/
		
	

