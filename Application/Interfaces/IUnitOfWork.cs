namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        IAddressRepo Address { get; }
    }
}
