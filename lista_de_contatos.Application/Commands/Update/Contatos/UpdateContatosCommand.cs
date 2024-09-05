using lista_de_contatos.Application.Responses.Contatos;
using MediatR;
using System.Text.Json.Serialization;

namespace lista_de_contatos.Application.Commands.Update.Contatos {
    public class UpdateContatosCommand : IRequest<MessagemResponser> {


        public UpdateContatosCommand(Guid id, string nome, string email, string telefone, string whatsapp)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            WhatsApp = whatsapp;
        }
        [JsonIgnore]
        public Guid Id { get; private set; }
        public string Nome { get; }
        public string Email { get; }
        public string Telefone { get; }
        public string WhatsApp { get; }

        public void UpdateId(Guid id) {
            Id = id;
        }

        /*Guid id, string nome, string email, string telefone, string whatsapp, Guid pessoaid*/
    }
}
