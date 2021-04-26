using System;
using GraphQLNetSample.GraphQL.Messaging.Messages;

namespace GraphQLNetSample.Helpers.Interfaces
{
    public interface IMyInputSubjectHelper
    {
        IObservable<MyInputReceivedMessage> GetInput();
        MyInputReceivedMessage AddNew(MyInputReceivedMessage myInputMessage);
    }
}