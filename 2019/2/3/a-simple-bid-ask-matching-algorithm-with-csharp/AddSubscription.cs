public void AddSubscription(Subscription subscription)
{
    if (!Subscriptions.ContainsKey(subscription.UserId))
    {
        Subscriptions.Add(subscription.UserId, subscription);
    }
}