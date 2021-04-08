using GraphiQl;
using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
using GraphQLNetSample.GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQLNetSample
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MySchema>();
            services.AddGraphQL((options, provider) =>
                {
                    options.EnableMetrics = true;
                    // options.UnhandledExceptionDelegate = ctx => Log.Error("{Error} occurred", ctx.OriginalException.Message);
                })
                .AddGraphTypes()
                .AddSystemTextJson()
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
                .AddDataLoader()
                .AddWebSockets();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();
            app.UseGraphQLWebSockets<MySchema>()
                .UseGraphQL<MySchema>()
                .UseGraphiQl("/graphiql")
                .UseGraphiQLServer(new GraphiQLOptions());
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            });
        }
    }
}