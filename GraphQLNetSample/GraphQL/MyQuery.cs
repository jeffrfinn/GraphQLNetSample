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
                resolve: async c => new MyObject
                {
                    Id = 1,
                    Name = "Kowoga"
                });

            FieldAsync<MyComplexQueryType>(
                "GetComplexType",
                "",
                resolve: async c => new MyComplexObject());
        }
    }
}