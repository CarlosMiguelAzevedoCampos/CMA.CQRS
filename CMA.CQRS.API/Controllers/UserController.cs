using AutoMapper;
using CMA.CQRS.API.Models;
using CMA.CQRS.Domain.Commands.Model;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Mediator;

namespace CMA.CQRS.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediatorHandler _mediator;
        private readonly IMapper _mapper;

        public UserController(IMediatorHandler mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost(Name = "new-user")]
        public IActionResult Create(CreateUserDto userDto)
        {
            NewUserCommand newUserCommand = _mapper.Map<NewUserCommand>(userDto);

            var result = _mediator.SendCommand<NewUserCommand>(newUserCommand);
            return result.Result.IsValid ? Ok() : BadRequest();
        }
    }
}