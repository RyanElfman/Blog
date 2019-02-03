Order order = currentLimit.AskHead;
while (order != null && shares > 0)
{
    if (order.Subscription.UserId == userId)
    {
        if (order.Next == null)
        {
            break;
        }
        else
        {
            order = order.Next;
        }
    }

    if (order.Shares >= shares)
    {
        order.Subscription.Owned -= shares;
        order.Shares -= shares;
        shares = 0;
    }
    else
    {
        order.Subscription.Owned -= order.Shares;
        shares -= order.Shares;
        order.Shares = 0;
    }

    order = order.Next;
}