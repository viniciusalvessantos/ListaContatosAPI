using lista_de_contatos.Application.Commands.Delete.Contatos;
using lista_de_contatos.Application.Responses.Pessoas;
using lista_de_contatos.Domain.Exceptions;
using lista_de_contatos.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Application.Commands.Delete.Pessoas {
    public class DeletePessoasCommandHandler : IRequestHandler<DeletePessoasCommand, MessagemResponser> {

        private readonly IPessoaRepository _pessoaRepository;
        public DeletePessoasCommandHandler(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }
        public async Task<MessagemResponser> Handle(DeletePessoasCommand request, CancellationToken cancellationToken) {
            try {
                await _pessoaRepository.Delete(request.Id);
                await _pessoaRepository.CommitAsync();
                return new MessagemResponser("Pessoa excluida com sucesso!!");
            } catch (Exception e) {
                throw new PessoaException();
            }
        }
    }
}
