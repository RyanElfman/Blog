if (!Subscriptions.TryGetValue(userId, out Subscription subscription))
{
    subscription = new Subscription { Owned = 0, UserId = userId };
    Subscriptions.Add(subscription.UserId, subscription);
}

if (shares > 0)
{
    subscription.Owned += originalShares - shares;

    var newOrder = new Order { Id = /*Interlocked.Increment(ref _orderId)*/_orderId++, Shares = shares, Subscription = subscription };

    // At this point Limits is guaranteed to have a single Limit.
    var prevLimit = Limits.ElementAt(index == 0 ? 0 : --index);
    if (prevLimit.Price == price)
    {
        newOrder.ParentLimit = prevLimit;
        if (prevLimit.BidHead == null)
        {
            prevLimit.BidHead = newOrder;
        }
        else
        {
            newOrder.Next = prevLimit.BidHead;
            prevLimit.BidHead.Prev = newOrder;
            prevLimit.BidHead = newOrder;
        }
    }
    else
    {
        var newLimit = new Limit { BidHead = newOrder, Price = price };
        newOrder.ParentLimit = newLimit;
        Limits.Add(newLimit);
    }

    Orders.Add(newOrder.Id, newOrder);
    return newOrder;
}
else
{
    subscription.Owned += originalShares;
}