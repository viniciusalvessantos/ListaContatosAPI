using lista_de_contatos.Application.Responses.Pessoas;
using lista_de_contatos.Domain.Exceptions;
using lista_de_contatos.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Application.Commands.Update.Pessoas {
    public class UpdatePessoasCommandHandler : IRequestHandler<UpdatePessoasCommand, MessagemResponser> {
        private readonly IPessoaRepository _pessoaRepository;
        public UpdatePessoasCommandHandler(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }
        public async Task<MessagemResponser> Handle(UpdatePessoasCommand request, CancellationToken cancellationToken) {
            try {
                await _pessoaRepository.Update(request.Id, request.Nome, request.SobreNome, request.Telefone, request.Email);
                await _pessoaRepository.CommitAsync();
                return new MessagemResponser("Alterado com sucesso!!");
            } catch (Exception e) {
                throw new PessoaException();
            }
           
        }
    }
}
