using HotChocolate.Execution;
using HotChocolate.Subscriptions;

public class Subscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Department>> OnDepartmentCreate([Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, Department>("DepartmentCreated", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Employee>> OnEmployeeGet([Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, Employee>("ReturnedEmployee", cancellationToken);
        }
    }