using lista_de_contatos.Application.Responses.Contatos;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Application.Commands.Register.Contatos {
    public class RegisterContatosCommand : IRequest<RegisterResponser> {
        public RegisterContatosCommand(string nome, string email, string telefone, string whatsapp, Guid pessoaid)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            WhatsApp = whatsapp;
            PessoaId = pessoaid;
        }
        public string Nome { get; }
 
        public string Email { get; }
     
        public string Telefone { get;  }
  
        public string WhatsApp { get;  }

        public Guid PessoaId { get;  }
    }
}
