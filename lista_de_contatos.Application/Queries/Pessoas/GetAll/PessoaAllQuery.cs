using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Application.Queries.Pessoas.GetAll {
    public class PessoaAllQuery : IRequest<IEnumerable<lista_de_contatos.Domain.Entities.Pessoas>> {
    }
}
