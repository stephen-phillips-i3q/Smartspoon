using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smartspoon.Repository.Configuration;
using Smartspoon.Repository.Repositories;

namespace Smartspoon.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // add MVC framework services
            services.AddMvc();

            // add IOptions<T> for your settings.
            services.AddOptions();

            // add custom settings class
            services.Configure<DataConnectionSettings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("DataConnection:ConnectionString").Value;
                options.Database = Configuration.GetSection("DataConnection:Database").Value;
            });

            // add DI settings
            services.AddSingleton<ITagRepository, TagRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
