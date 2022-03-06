using Application.Interfaces;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IAddressRepo addressRepo)
        {
            Address = addressRepo;
        }
        public IAddressRepo Address { get; }
    }
}
