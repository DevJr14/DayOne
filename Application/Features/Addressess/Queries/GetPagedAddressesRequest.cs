using Application.Extensions;
using Application.Interfaces;
using MediatR;
using Shared.Responses.Address;
using Shared.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Addressess.Queries
{
    public class GetPagedAddressesRequest : IRequest<PaginatedResult<AddressResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetPagedAddressesRequest(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
    public class GetPagedAddressesRequestHandler : IRequestHandler<GetPagedAddressesRequest, PaginatedResult<AddressResponse>>
    {
        private readonly IAddressRepo _repository;

        public GetPagedAddressesRequestHandler(IAddressRepo repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedResult<AddressResponse>> Handle(GetPagedAddressesRequest request, CancellationToken cancellationToken)
        {
            var addresses = await _repository.GetAllAsync();
            var pagedAddresses = addresses
                .ToPaginatedList(request.PageNumber, request.PageSize);
            return pagedAddresses;
        }
    }
}
