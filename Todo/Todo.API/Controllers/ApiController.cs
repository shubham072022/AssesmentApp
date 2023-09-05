using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Todo.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        public ISender mediator = null;
        protected ISender Mediator => mediator ?? HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
