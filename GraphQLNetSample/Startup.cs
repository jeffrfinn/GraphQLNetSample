using System;
using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Server;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Types;
using GraphQLNetSample.GraphQL;
using GraphQLNetSample.Helpers;
using GraphQLNetSample.Helpers.Interfaces;
using GraphQLNetSample.Repositories;
using GraphQLNetSample.Repositories.Interfaces;
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
            services.AddSingleton<ISchema,MySchema>();
            services.AddSingleton<MyQuery>();
            services.AddSingleton<MyMutation>();
            services.AddSingleton<MySubscription>();
            services.AddSingleton<MySchema>();
            services.AddTransient<IOrdersStore, OrderStore>();
            services.AddSingleton<IMyInputSubjectHelper, MyInputSubjectHelper>();
            services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
            services.AddSingleton<DataLoaderDocumentListener>();
            services.AddSingleton<IDocumentExecuter,SubscriptionDocumentExecuter>();
            
            services.AddGraphQL((options, provider) =>
                {
                    options.EnableMetrics = true;
                    options.UnhandledExceptionDelegate = ctx =>
                    {
                        Console.WriteLine("error: " + ctx.OriginalException.Message);
                    };
                })
                .AddGraphTypes(typeof(MySchema))
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

            app.UseWebSockets()
                .UseGraphQLWebSockets<MySchema>();
            app.UseGraphQL<MySchema, GraphQLHttpMiddleware<MySchema>>()
                .UseGraphQLAltair();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            });
        }
    }
}