using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace lista_de_contatos.Application.Queries.Contatos.GetAll {
    public class ContatoAllQuery : IRequest<IEnumerable<lista_de_contatos.Domain.Entities.Contatos>> {

        public ContatoAllQuery(Guid? pessoaid)
        {
            PessoaId = pessoaid;
        }
        [JsonIgnore]
        public Guid? PessoaId { get; private set; }

        public void UpdateId(Guid pessoaid) {
            PessoaId = pessoaid;
        }
    }
}
