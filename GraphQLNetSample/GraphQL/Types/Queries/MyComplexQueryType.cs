using System.Collections.Generic;
using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQLNetSample.Models;
using GraphQLNetSample.Repositories.Interfaces;

namespace GraphQLNetSample.GraphQL.Types.Queries
{
    public class MyComplexQueryType: ObjectGraphType<MyComplexObject>
    {
        public MyComplexQueryType(IDataLoaderContextAccessor accessor, IOrdersStore orders)
        {
            Field<ListGraphType<OrderType>, IEnumerable<Order>>()
                .Name("Orders")
                .ResolveAsync(ctx =>
                {
                    // Get or add a collection batch loader with the key "GetOrdersByUserId"
                    // The loader will call GetOrdersByUserIdAsync with a batch of keys
                    var ordersLoader = accessor.Context.GetOrAddCollectionBatchLoader<int, Order>("GetOrdersByUserId",
                        orders.GetOrdersByUserIdAsync);

                    // Add this UserId to the pending keys to fetch data for
                    // The execution strategy will trigger the data loader to fetch the data via GetOrdersByUserId() at the
                    //   appropriate time, and the field will be resolved with an instance of IEnumerable<Order> once
                    //   GetOrdersByUserId() returns with the batched results
                    return ordersLoader.LoadAsync(ctx.Source.Id);
                });
        }
    }
}