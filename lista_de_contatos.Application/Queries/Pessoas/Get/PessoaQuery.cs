using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace lista_de_contatos.Application.Queries.Pessoas.Get {
    public class PessoaQuery : IRequest<lista_de_contatos.Domain.Entities.Pessoas> {

        public PessoaQuery(Guid id)
        {
            Id = id;
        }
        [JsonIgnore]
        public Guid Id { get; private set; }

        public void UpdateId(Guid id) {
            Id = id;
        }
    }
}
