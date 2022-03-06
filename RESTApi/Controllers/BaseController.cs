using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace RESTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        private IMediator _mediatorInstance;
        protected IMediator _mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
