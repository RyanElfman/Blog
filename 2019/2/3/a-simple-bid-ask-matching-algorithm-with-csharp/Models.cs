[DebuggerDisplay("Price = {Price}, AskHead = {AskHead}, BidHead = {BidHead}")]
public class Limit
{
    public long Price { get; set; }
    public Order AskHead { get; set; }
    public Order BidHead { get; set; }
}

[DebuggerDisplay("Id = {Id}, Shares = {Shares}, Next = {Next}, Prev = {Prev}, ParentLimit = {ParentLimit}, Subscription = {Subscription}")]
public class Order
{
    public long Id { get; set; }
    public int Shares { get; set; }
    public Order Next { get; set; }
    public Order Prev { get; set; }
    public Limit ParentLimit { get; set; }
    public Subscription Subscription { get; set; }
}

[DebuggerDisplay("UserId = {UserId}, Owned = {Owned}")]
public class Subscription
{
    public long UserId { get; set; }
    public int Owned { get; set; }
}