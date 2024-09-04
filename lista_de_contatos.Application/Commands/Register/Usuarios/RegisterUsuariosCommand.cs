using lista_de_contatos.Application.Responses.Usuarios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Application.Commands.Register.Usuarios {
    public class RegisterUsuariosCommand : IRequest<RegisterResponser>  {

        public RegisterUsuariosCommand(string userName, string password, string name) {
            UserName = userName;
            Password = password;
            Name = name;
        }

        public string UserName { get; }
        public string Password { get; }
        public string Name { get; }

    }
}
