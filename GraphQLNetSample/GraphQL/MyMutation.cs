using GraphQL;
using GraphQL.Types;
using GraphQLNetSample.GraphQL.Messaging.Messages;
using GraphQLNetSample.GraphQL.Types.Inputs;
using GraphQLNetSample.Helpers.Interfaces;

namespace GraphQLNetSample.GraphQL
{
    public class MyMutation: ObjectGraphType
    {
        public MyMutation(IMyInputSubjectHelper subjectHelper)
        {
            Field<BooleanGraphType>(
                "createInput",
                "create a new input, to trigger subscription",
                new QueryArguments(new QueryArgument<NonNullGraphType<MyInputType>>
                {
                    Name = "myInputType"
                }),  context =>
                {
                    // trigger subscription notify
                    var myInputMessage = context.GetArgument<MyInputReceivedMessage>("myInputType");
                    
                    subjectHelper.AddNew(myInputMessage);
                    return true;
                });
        }
    }
}