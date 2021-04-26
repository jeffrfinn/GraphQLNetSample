using GraphQL.Types;
using GraphQLNetSample.GraphQL.Messaging.Messages;

namespace GraphQLNetSample.GraphQL.Types.Messages
{
    public class MyInputRecievedMessageType: ObjectGraphType<MyInputReceivedMessage>
    {
        public MyInputRecievedMessageType()
        {
            Name = "MyInputMutationReceived";
            Field(t => t.Name);
        }
    }
}