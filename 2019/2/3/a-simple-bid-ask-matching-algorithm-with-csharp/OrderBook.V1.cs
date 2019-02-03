public class OrderBook
{
    public const int ScaleFactor = 10_000;

    public OrderBook()
    {
        // Always want a single limit so we can have less checks in the Ask and Bid methods.
        Limits = new RankedSet<Limit>(new LimitPriceComparer()) { new Limit { Price = 1 * ScaleFactor } };
        Subscriptions = new Dictionary<long, Subscription>();
        Orders = new Dictionary<long, Order>();
    }

    private protected RankedSet<Limit> Limits { get; }
    private protected IDictionary<long, Subscription> Subscriptions { get; }
    private protected IDictionary<long, Order> Orders { get; }
}