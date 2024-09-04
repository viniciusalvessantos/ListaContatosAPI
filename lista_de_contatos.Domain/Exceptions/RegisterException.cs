using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Domain.Exceptions {
    public class RegisterException : Exception {
        public List<string> ValidationMessages { get; set; }
        public RegisterException(IEnumerable<IdentityError> errors) {
            ValidationMessages = errors.Select(x => x.Description).ToList();
        }
    }
}
