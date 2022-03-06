using Shared.Requests.Address;
using Shared.Responses.Address;

namespace Application.Interfaces
{
    public interface IAddressRepo : IBaseRepo<AddressRequest, AddressResponse>
    {
    }
}
