using lista_de_contatos.Application.Commands.Register.Pessoas;
using lista_de_contatos.Application.Responses.Contatos;
using lista_de_contatos.Domain.Exceptions;
using lista_de_contatos.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Application.Commands.Register.Contatos {
    public class RegisterContatosCommandHandler : IRequestHandler<RegisterContatosCommand, MessagemResponser> {

        private readonly IContatoRepository _contatoRepository;
        public RegisterContatosCommandHandler(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }
        public async Task<MessagemResponser> Handle(RegisterContatosCommand request, CancellationToken cancellationToken) {
            try {
                await _contatoRepository.Add(lista_de_contatos.Domain.Entities.Contatos.New(request.Nome, request.Telefone, request.Email, request.WhatsApp, request.PessoaId));
                await _contatoRepository.CommitAsync();
                return new MessagemResponser("Cadastrado contato com sucesso!!");
            } catch (Exception e) {
                throw new ContatoException();
            }
          
        }
    }
}
