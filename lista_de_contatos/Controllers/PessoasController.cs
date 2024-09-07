using Infrastructure.Exceptions;
using lista_de_contatos.Application.Commands.Delete.Contatos;
using lista_de_contatos.Application.Commands.Delete.Pessoas;
using lista_de_contatos.Application.Commands.Register.Pessoas;
using lista_de_contatos.Application.Commands.Update.Pessoas;
using lista_de_contatos.Application.Queries.Pessoas.Get;
using lista_de_contatos.Application.Queries.Pessoas.GetAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lista_de_contatos.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> Delete(DeletePessoasCommand request) =>
        Ok(await _mediator.Send(request));


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        [Route("update/{id}")]
        public async Task<ActionResult> Update(Guid id ,UpdatePessoasCommand request) {
            request.UpdateId(id);
            return Ok(await _mediator.Send(request));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Route("visualizar/{id}")]
        public async Task<ActionResult> Visualizar(Guid id) {
            var request = new PessoaQuery(id);
            return Ok(await _mediator.Send(request));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult> Listar() {
            var request = new PessoaAllQuery();
            return Ok(await _mediator.Send(request));
        }


    }

}
