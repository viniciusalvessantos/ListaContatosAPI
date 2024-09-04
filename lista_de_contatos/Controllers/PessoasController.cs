using Infrastructure.Exceptions;
using lista_de_contatos.Application.Commands.Register.Pessoas;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lista_de_contatos.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase {
        private readonly IMediator _mediator;
        public PessoasController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(RegisterPessoasCommand request) =>
            Ok(await _mediator.Send(request));
    }
}
