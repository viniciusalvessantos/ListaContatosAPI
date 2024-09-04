using lista_de_contatos.Application.Responses.Pessoas;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Application.Commands.Register.Pessoas {
    public class RegisterPessoasCommand : IRequest<RegisterResponser> {
        public RegisterPessoasCommand(string nome, string sobrenome, string telefone, string email)
        {
            Nome = nome;
            SobreNome = sobrenome;
            Telefone = telefone;
            Email = email;
        }
        public string Nome { get;  }
       
        public string SobreNome { get;  }
       
        public string Telefone { get; }
      
        public string Email { get; }
    }
}
