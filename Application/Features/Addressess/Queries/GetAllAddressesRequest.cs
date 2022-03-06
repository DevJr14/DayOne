using Application.Interfaces;
using MediatR;
using Shared.Responses.Address;
using Shared.Wrappers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Addressess.Queries
{
    public class GetAllAddressesRequest : IRequest<Result<List<AddressResponse>>>
    {
    }

    public class GetAllAddressesRequestHandler : IRequestHandler<GetAllAddressesRequest, Result<List<AddressResponse>>>
    {
        private readonly IAddressRepo _addressRepository;

        public GetAllAddressesRequestHandler(IAddressRepo addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<Result<List<AddressResponse>>> Handle(GetAllAddressesRequest request, CancellationToken cancellationToken)
        {
            var addresses = await _addressRepository.GetAllAsync();

            if (addresses.Count > 0)
            {
                return await Result<List<AddressResponse>>.SuccessAsync(addresses);
            }
            return await Result<List<AddressResponse>>.FailAsync("No Addresses Found.");
        }
    }
}
