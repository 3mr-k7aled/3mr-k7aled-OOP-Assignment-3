
namespace RefactoringLab;

public interface IShippingCostStrategy
{
    string Carrier { get; }
    decimal Calculate(decimal weightKg);
}

public class AramexShippingStrategy : IShippingCostStrategy
{
    public string Carrier => "Aramex";

    public decimal Calculate(decimal weightKg)
    {
        return weightKg * 12m;
    }
}

public class FedExShippingStrategy : IShippingCostStrategy
{
    public string Carrier => "FedEx";

    public decimal Calculate(decimal weightKg)
    {
        return weightKg * 15m;
    }
}

public class DHLShippingStrategy : IShippingCostStrategy
{
    public string Carrier => "DHL";

    public decimal Calculate(decimal weightKg)
    {
        return weightKg * 18m;
    }
}

public class ShippingCostCalculator
{
    private readonly IEnumerable<IShippingCostStrategy> _strategies;

    public ShippingCostCalculator(
        IEnumerable<IShippingCostStrategy> strategies)
    {
        _strategies = strategies;
    }

    public decimal Calculate(string carrier, decimal weightKg)
    {
        foreach (var strategy in _strategies)
        {
            if (strategy.Carrier.Equals(
                carrier,
                StringComparison.OrdinalIgnoreCase))
            {
                return strategy.Calculate(weightKg);
            }
        }

        throw new ArgumentException($"Unknown carrier: {carrier}");
    }
}