using GraphQL.Types;
using GraphQLNetSample.GraphQL.Types.Inputs;

namespace GraphQLNetSample.GraphQL
{
    public class MyMutation: ObjectGraphType
    {
        public MyMutation()
        {
            FieldAsync<BooleanGraphType>(
                "createInput",
                "create a new input, to trigger subscription",
                new QueryArguments(new QueryArgument<NonNullGraphType<MyInputType>>
                {
                    Name = "myInputType"
                }), async context =>
                {
                    // trigger subscription notify
                    return true;
                });
        }
    }
}