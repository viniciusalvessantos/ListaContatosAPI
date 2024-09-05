using lista_de_contatos.Application.Queries.Usuarios.Login;
using lista_de_contatos.Application.Responses.Usuarios;
using lista_de_contatos.Domain.Entities;
using lista_de_contatos.Domain.Exceptions;
using lista_de_contatos.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Application.Queries.Pessoas.Get {
    public class PessoaQueryHandler : IRequestHandler<PessoaQuery, lista_de_contatos.Domain.Entities.Pessoas> {

        private readonly IPessoaRepository _pessoaRepository;
        public PessoaQueryHandler(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }
        public async Task<Domain.Entities.Pessoas> Handle(PessoaQuery request, CancellationToken cancellationToken) {
            try {
                var pessoa =  await _pessoaRepository.Get(request.Id, cancellationToken);
                if (pessoa == null) {
                    throw new PessoaException();
                }
                return pessoa!;
            
            } catch (Exception e) {
                throw new PessoaException();
            }
        }
    }
}
