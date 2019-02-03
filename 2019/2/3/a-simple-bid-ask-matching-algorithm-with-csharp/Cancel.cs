public void Cancel(long orderId)
{
    lock (_orderLock)
    {
        if (Orders.TryGetValue(orderId, out Order order))
        {
            if (order.Prev != null)
            {
                order.Prev.Next = order.Next;
            }

            if (order.Next != null)
            {
                order.Next.Prev = order.Prev;
            }

            if (order.ParentLimit.AskHead == order)
            {
                order.ParentLimit.AskHead = order.Next;
            }
            else if (order.ParentLimit.BidHead == order)
            {
                order.ParentLimit.BidHead = order.Next;
            }

            Orders.Remove(orderId);
        }
    }
}