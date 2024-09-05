using Infrastructure.Exceptions;
using lista_de_contatos.Application.Commands.Register.Usuarios;
using lista_de_contatos.Application.Queries.Usuarios.Login;
using lista_de_contatos.Application.Responses.Usuarios;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lista_de_contatos.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase {
        private readonly IMediator _mediator;
        public UsuariosController(IMediator mediator) {
            _mediator = mediator;
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [Route("register")]

        public async Task<ActionResult> Register(RegisterUsuariosCommand request) =>
           Ok(await _mediator.Send(request));


        [HttpPost]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("login")]
        public async Task<ActionResult<LoginResponse>> LogIn(LoginQuery request)
         => Ok(await _mediator.Send(request));
    }
}
