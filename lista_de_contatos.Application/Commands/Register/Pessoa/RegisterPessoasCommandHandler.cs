using lista_de_contatos.Application.Responses.Pessoas;
using lista_de_contatos.Domain.Exceptions;
using lista_de_contatos.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lista_de_contatos.Domain.Entities;

namespace lista_de_contatos.Application.Commands.Register.Pessoas {
    public class RegisterPessoasCommandHandler : IRequestHandler<RegisterPessoasCommand, RegisterResponser> {

        private readonly IPessoaRepository _pessoaRepository;
        public RegisterPessoasCommandHandler(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<RegisterResponser> Handle(RegisterPessoasCommand request, CancellationToken cancellationToken) {
            try {
                await _pessoaRepository.Add(lista_de_contatos.Domain.Entities.Pessoas.New(request.Nome, request.SobreNome, request.Telefone, request.Email));
                await _pessoaRepository.CommitAsync();
                return new RegisterResponser("Cadastrado com sucesso!!");
            } catch (Exception ex) {
                throw new PessoaException();

            }
           

        }
    }
}
