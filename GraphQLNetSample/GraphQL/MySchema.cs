using System;
using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLNetSample.GraphQL
{
    public class MySchema: Schema
    {
        public MySchema(IServiceProvider serviceProvider): base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<MyQuery>();

            // var listener = serviceProvider.GetRequiredService<DataLoaderDocumentListener>();
            //
            // var executer = new DocumentExecuter();
            //
            // var result = executer.ExecuteAsync(opts => 
            // {
            //     opts.Listeners.Add(listener);
            // });
        }
    }
}