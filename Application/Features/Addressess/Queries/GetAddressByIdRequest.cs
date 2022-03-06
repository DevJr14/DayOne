using Application.Interfaces;
using MediatR;
using Shared.Responses.Address;
using Shared.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Addressess.Queries
{
    public class GetAddressByIdRequest : IRequest<Result<AddressResponse>>
    {
        public int Id { get; set; }
    }

    public class GetAddressByIdRequestHandler : IRequestHandler<GetAddressByIdRequest, Result<AddressResponse>>
    {
        private readonly IAddressRepo _repository;

        public GetAddressByIdRequestHandler(IAddressRepo repository)
        {
            _repository = repository;
        }

        public async Task<Result<AddressResponse>> Handle(GetAddressByIdRequest Request, CancellationToken cancellationToken)
        {
            var address = await _repository.GetByIdAsync(Request.Id);
            if (address != null)
            {
                return await Result<AddressResponse>.SuccessAsync(address);
            }
            return await Result<AddressResponse>.FailAsync("Address Not Found.");
        }
    }
}