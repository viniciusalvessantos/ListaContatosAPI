using lista_de_contatos.Application.Responses.Usuarios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Application.Queries.Usuarios.Login {
    public class LoginQuery : IRequest<LoginResponse> {
        public LoginQuery(string userName, string password) {
            UserName = userName;
            Password = password;
        }
        public string UserName { get; }
        public string Password { get; }
    }
}
