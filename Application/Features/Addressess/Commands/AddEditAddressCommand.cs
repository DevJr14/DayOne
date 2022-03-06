using MediatR;
using Shared.Requests.Address;
using Shared.Wrappers;
using System;
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
        public async Task<Result<int>> Handle(AddEditAddressCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Validation Passed!");
            return await Result<int>.SuccessAsync("Validation passed");
        }
    }
}
