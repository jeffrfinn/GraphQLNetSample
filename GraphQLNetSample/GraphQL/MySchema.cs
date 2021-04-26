using System;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLNetSample.GraphQL
{
    public class MySchema: Schema
    {
        public MySchema(IServiceProvider serviceProvider): base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<MyQuery>();
            Mutation = serviceProvider.GetRequiredService<MyMutation>();
            Subscription = serviceProvider.GetRequiredService<MySubscription>();
        }
    }
}