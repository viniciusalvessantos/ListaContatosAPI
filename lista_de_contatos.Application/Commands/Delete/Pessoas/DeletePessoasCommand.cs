using lista_de_contatos.Application.Responses.Pessoas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Application.Commands.Delete.Pessoas {
    public class DeletePessoasCommand:  IRequest<MessagemResponser> {
        public DeletePessoasCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
