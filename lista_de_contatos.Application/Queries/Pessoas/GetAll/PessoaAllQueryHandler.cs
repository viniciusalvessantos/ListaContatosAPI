using lista_de_contatos.Application.Queries.Pessoas.Get;
using lista_de_contatos.Domain.Exceptions;
using lista_de_contatos.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Application.Queries.Pessoas.GetAll {
    public class PessoaAllQueryHandler : IRequestHandler<PessoaAllQuery, IEnumerable<lista_de_contatos.Domain.Entities.Pessoas>> {

        private readonly IPessoaRepository _pessoaRepository;
        public PessoaAllQueryHandler(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }
        public async Task<IEnumerable<Domain.Entities.Pessoas>> Handle(PessoaAllQuery request, CancellationToken cancellationToken) {
            try {
                var pessoas = await _pessoaRepository.GetAll();
                if (pessoas == null) {
                    throw new PessoaException();
                }
                return pessoas!;

            } catch (Exception e) {
                throw new PessoaException();
            }
        }
    }
}
