namespace BarbershopManager.BarbershopManager.Application.UseCases.DeleteRevenue
{
    public interface IDeleteRevenue
    {
        Task Execute(Guid id);
    }
}
