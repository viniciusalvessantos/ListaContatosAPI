using lista_de_contatos.Application.Commands.Register.Contatos;
using lista_de_contatos.Application.Responses.Contatos;
using lista_de_contatos.Domain.Exceptions;
using lista_de_contatos.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Application.Commands.Delete.Contatos {
    public class DeleteContatosCommandHandler : IRequestHandler<DeleteContatosCommand, MessagemResponser> {

        private readonly IContatoRepository _contatoRepository;
        public DeleteContatosCommandHandler(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }
        public async Task<MessagemResponser> Handle(DeleteContatosCommand request, CancellationToken cancellationToken) {
            try {
                await _contatoRepository.Delete(request.Id);
                await _contatoRepository.CommitAsync();
                return new MessagemResponser("Excluido contato com sucesso!!");
            } catch (Exception e) {

                throw new ContatoException();
            }
            
        }
    }
}
