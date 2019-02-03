if (userId <= 0 || price <= 0 || shares <= 0)
{
    return null;
}

price = price* ScaleFactor;

lock (_orderLock)
{
    var index = 0;
    var originalShares = shares;
    while (index < Limits.Count && shares > 0)
    {
        var currentLimit = Limits.ElementAt(index);
        if (currentLimit.Price > price)
        {
            break;
        }

        // ...

        index++;
    }

    // ...