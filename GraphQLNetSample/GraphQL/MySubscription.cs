using GraphQL.Resolvers;
using GraphQL.Types;
using GraphQLNetSample.GraphQL.Messaging.Messages;
using GraphQLNetSample.GraphQL.Types.Messages;
using GraphQLNetSample.Helpers.Interfaces;

namespace GraphQLNetSample.GraphQL
{
    public class MySubscription: ObjectGraphType
    {
        public MySubscription(IMyInputSubjectHelper subjectHelper)
        {
            Name = "Subscription"; 
            Description = "Subscribe to new myInput mutations";
            AddField(new EventStreamFieldType
            {
                Name = "myInputMutationReceived",
                Description = "A MyInput mutation was received",
                Type = typeof(MyInputRecievedMessageType),
                Resolver = new FuncFieldResolver<MyInputReceivedMessage>(x => x.Source as MyInputReceivedMessage ),
                Subscriber = new  EventStreamResolver<MyInputReceivedMessage>(x => subjectHelper.GetInput()),
            });
        }
    }
}