using lista_de_contatos.Application.Responses.Usuarios;
using lista_de_contatos.Domain.Entities;
using lista_de_contatos.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Application.Commands.Register.Usuarios {
    public class RegisterUsuariosCommandHandler : IRequestHandler<RegisterUsuariosCommand, RegisterResponser> {

        private readonly UserManager<ApplicationUser> _userManager;
        public RegisterUsuariosCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RegisterResponser> Handle(RegisterUsuariosCommand request, CancellationToken cancellationToken) {
            var identity = await _userManager.CreateAsync(ApplicationUser.New(request.UserName, request.Name), request.Password);
            if (!identity.Succeeded)
                throw new RegisterException(identity.Errors);
            return new RegisterResponser("Cadastrado com sucesso!!");
        }
    }
}
