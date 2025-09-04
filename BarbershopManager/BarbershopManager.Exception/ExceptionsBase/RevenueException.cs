namespace BarbershopManager.BarbershopManager.Exception.ExceptionsBase;

public abstract class RevenueException(string message) : SystemException(message)
{
    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}