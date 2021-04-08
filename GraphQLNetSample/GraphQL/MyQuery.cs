using GraphQL.Types;
using GraphQLNetSample.GraphQL.Types.Queries;
using GraphQLNetSample.Models;

namespace GraphQLNetSample.GraphQL
{
    public class MyQuery: ObjectGraphType
    {
        public MyQuery()
        {
            FieldAsync<MyQueryType>
            (
                "GetMyType",
                "Retrieve MyType",
                resolve: async c => new MyType
                {
                    Id = 1,
                    Name = "Kowoga"
                });
        }
    }
}