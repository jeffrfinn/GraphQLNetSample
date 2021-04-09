using GraphQL.Instrumentation;
using GraphQL.Types;
using GraphQLNetSample.Models;

namespace GraphQLNetSample.GraphQL.Types.Queries
{
    public class MyQueryType: ObjectGraphType<MyObject>
    {
        public MyQueryType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
        }
    }
}