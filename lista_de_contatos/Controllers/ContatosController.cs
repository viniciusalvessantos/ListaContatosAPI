using Infrastructure.Exceptions;
using lista_de_contatos.Application.Commands.Delete.Contatos;
using lista_de_contatos.Application.Commands.Register.Contatos;
using lista_de_contatos.Application.Commands.Register.Pessoas;
using lista_de_contatos.Application.Commands.Update.Contatos;
using lista_de_contatos.Application.Commands.Update.Pessoas;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lista_de_contatos.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase {
        private readonly IMediator _mediator;
        public ContatosController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(RegisterContatosCommand request) =>
            Ok(await _mediator.Send(request));


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> Delete(DeleteContatosCommand request) =>
            Ok(await _mediator.Send(request));

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        [Route("update/{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateContatosCommand request) {
            request.UpdateId(id);
            return Ok(await _mediator.Send(request));
        }

    }
}
