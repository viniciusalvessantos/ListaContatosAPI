using lista_de_contatos.Application.Queries.Contatos.Get;
using lista_de_contatos.Domain.Exceptions;
using lista_de_contatos.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Application.Queries.Contatos.GetAll {
    public class ContatoAllQueryHandler : IRequestHandler<ContatoAllQuery, IEnumerable<lista_de_contatos.Domain.Entities.Contatos>> {
        private readonly IContatoRepository _contatoRepository;
        public ContatoAllQueryHandler(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }
        public async Task<IEnumerable<Domain.Entities.Contatos>> Handle(ContatoAllQuery request, CancellationToken cancellationToken) {
            try {

                var contato = await _contatoRepository.GetAll(request.PessoaId);
                if (contato == null) {
                    throw new ContatoException();
                }
                return contato!;

            } catch (Exception e) {
                throw new ContatoException();
            }
        }
    }
}
