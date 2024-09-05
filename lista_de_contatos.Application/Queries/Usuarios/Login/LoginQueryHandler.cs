using lista_de_contatos.Application.Responses.Usuarios;
using lista_de_contatos.Domain.Entities;
using lista_de_contatos.Domain.Exceptions;
using lista_de_contatos.Domain.Utilities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Application.Queries.Usuarios.Login {
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResponse> {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtService _jwtService;
        public LoginQueryHandler(UserManager<ApplicationUser> userManager, IJwtService jwtService) {
            _userManager = userManager;
            _jwtService = jwtService;
        }
        public async Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken) {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password)) {
                throw new LoginException();
            }


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim("X-User-ID", user.Id),
            };
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles) {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
          

            return new LoginResponse(_jwtService.GenerateJwt(claims));
        }
    }
}
