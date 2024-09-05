using lista_de_contatos.Application.Commands.Delete.Contatos;
using lista_de_contatos.Application.Responses.Contatos;
using lista_de_contatos.Domain.Exceptions;
using lista_de_contatos.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Application.Commands.Update.Contatos {
    public class UpdateContatosCommandHandler : IRequestHandler<UpdateContatosCommand, MessagemResponser> {
        private readonly IContatoRepository _contatoRepository;

        public UpdateContatosCommandHandler(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task<MessagemResponser> Handle(UpdateContatosCommand request, CancellationToken cancellationToken) {
            try {
                await _contatoRepository.Update(request.Id, request.Nome, request.Email , request.Telefone, request.WhatsApp);
                await _contatoRepository.CommitAsync();
                return new MessagemResponser("Alterado com sucesso!!");
            } catch (Exception e) {
                throw new ContatoException();
            }
        }
    }
}
