using lista_de_contatos.Application.Responses.Contatos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Application.Commands.Delete.Contatos {
    public class DeleteContatosCommand : IRequest<MessagemResponser> {

        public DeleteContatosCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get;}
    }
}
