using GraphQL.Types;
using GraphQLNetSample.Models;

namespace GraphQLNetSample.GraphQL.Types.Queries
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType()
        {
            Field(x => x.Id);
            Field(x => x.Description);
        }
    }
}