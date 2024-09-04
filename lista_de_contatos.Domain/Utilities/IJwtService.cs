using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Domain.Utilities {
    public interface IJwtService {
        string GenerateJwt(List<Claim> claims);
    }
}
