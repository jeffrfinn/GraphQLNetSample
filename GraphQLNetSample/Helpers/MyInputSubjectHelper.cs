using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using GraphQL.Subscription;
using GraphQLNetSample.GraphQL.Messaging.Messages;
using GraphQLNetSample.Helpers.Interfaces;

namespace GraphQLNetSample.Helpers
{
    public class MyInputSubjectHelper: IMyInputSubjectHelper
    {
        private readonly ISubject<MyInputReceivedMessage> _myInputStream = new ReplaySubject<MyInputReceivedMessage>(1);       

        public IObservable<MyInputReceivedMessage> GetInput()
        {
            return _myInputStream;
        }

        public MyInputReceivedMessage AddNew(MyInputReceivedMessage myInputMessage)
        {
            _myInputStream.OnNext(myInputMessage);
            return myInputMessage;
        }
    }
}