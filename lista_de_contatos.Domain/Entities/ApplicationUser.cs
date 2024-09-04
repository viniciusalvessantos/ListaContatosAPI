using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Domain.Entities {
    public class ApplicationUser : IdentityUser {
        private ApplicationUser()
        {       
        }
        private ApplicationUser(string username, string nome)
        {
            UserName = username;
            Nome = nome;
        }
        public string Nome { get; private set; }

        public void UpdateNome(string nome) {
            Nome = nome;
        }

        public static ApplicationUser New(string username, string nome) {
            return new ApplicationUser(username, nome);
        }
    }
}
