// Get the users subscription.
if (!Subscriptions.TryGetValue(userId, out Subscription subscription))
{
    // TODO: Return a message or something.
    return null;
}