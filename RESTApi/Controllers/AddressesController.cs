using Application.Features.Addressess.Commands;
using Application.Features.Addressess.Queries;
using Microsoft.AspNetCore.Mvc;
using Shared.Requests.Address;
using System;
using System.Threading.Tasks;

namespace RESTApi.Controllers
{
    public class AddressesController : BaseController<AddressesController>
    {
        [HttpPost("save")]
        public async Task<IActionResult> Save(AddressRequest request)
        {
            var response = await _mediator.Send(new AddEditAddressCommand() { AddressRequest = request });
            return Ok(response);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllAddressesRequest()));
        }

        [HttpGet("get-paged")]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize)
        {
            var addresses = await _mediator.Send(new GetPagedAddressesRequest(pageNumber, pageSize));

            return Ok(addresses);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetAddressByIdRequest() { Id = id }));
        }
    }
}
