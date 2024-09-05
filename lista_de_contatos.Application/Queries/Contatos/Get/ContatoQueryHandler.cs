
using lista_de_contatos.Domain.Exceptions;
using lista_de_contatos.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Application.Queries.Contatos.Get {
    public class ContatoQueryHandler : IRequestHandler<ContatoQuery, lista_de_contatos.Domain.Entities.Contatos> {
        private readonly IContatoRepository _contatoRepository;
        public ContatoQueryHandler(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }
        public async Task<Domain.Entities.Contatos> Handle(ContatoQuery request, CancellationToken cancellationToken) {
            try {
                var contato = await _contatoRepository.Get(request.Id, cancellationToken);
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
