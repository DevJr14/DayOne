using Application.Interfaces;
using MediatR;
using Shared.Requests.Address;
using Shared.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Addressess.Commands
{
    public class AddEditAddressCommand : IRequest<Result<int>>
    {
        public AddressRequest AddressRequest { get; set; }
    }

    public class AddEditAddressCommandHandler : IRequestHandler<AddEditAddressCommand, Result<int>>
    {
        private readonly IAddressRepo _repository;

        public AddEditAddressCommandHandler(IAddressRepo repository)
        {
            _repository = repository;
        }

        public async Task<Result<int>> Handle(AddEditAddressCommand request, CancellationToken cancellationToken)
        {
            if (request.AddressRequest.Id > 0)
            {
                //Edit
                var address = await _repository.GetByIdAsync(request.AddressRequest.Id);
                if (address == null)
                {
                    var response = await _repository.UpdateAsync(request.AddressRequest);
                    if (response <= 0)
                    {
                        return await Result<int>.FailAsync("Failed to update new address.");
                    }
                    return await Result<int>.SuccessAsync(response, "Address successfully updated.");                    
                }
                else
                {
                    return await Result<int>.FailAsync($"Address with Id {request.AddressRequest.Id} not found.");
                }
            }
            else
            {
                //Add new
                var response = await _repository.AddAsync(request.AddressRequest);
                if (response <= 0)
                {
                    return await Result<int>.FailAsync("Failed to create new address.");
                }
                return await Result<int>.SuccessAsync(response, "Address successfully created.");
            }
        }
    }
}
