using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Application.Responses.Usuarios {
    public class LoginResponse {
        public LoginResponse(string token) {
            Token = token;
        }
        public string Token { get; }
    }
}
