using lista_de_contatos.Application.Responses.Pessoas;
using MediatR;
using System.Text.Json.Serialization;

namespace lista_de_contatos.Application.Commands.Update.Pessoas {
    public class UpdatePessoasCommand : IRequest<MessagemResponser> {

        public UpdatePessoasCommand(Guid id,string nome, string sobrenome, string telefone, string email)
        {
            Id = id;
            Nome = nome;
            SobreNome = sobrenome;
            Telefone = telefone;
            Email = email;
        }
        [JsonIgnore]
        public Guid Id { get; private set; }
        public string Nome { get; }

        public string SobreNome { get; }

        public string Telefone { get; }

        public string Email { get; }

        public void UpdateId(Guid id) {
            Id = id;
        }
    }
}
