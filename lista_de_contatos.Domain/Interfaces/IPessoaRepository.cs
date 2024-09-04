using lista_de_contatos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Domain.Interfaces {
    public interface IPessoaRepository {
        Task Add(Pessoas pessoas);
        Task Update(Guid id, string nome, string sobrenome,string telefone, string email);
        Task Delete(Guid id);
        Task<IEnumerable<Pessoas>> GetAll();

        Task<Pessoas> Get(Guid id, CancellationToken cancellationToken);
        Task CommitAsync();
    }
}
/*
  Nome = nome;
            SobreNome = sobrenome;
            Telefone = telefone;    
            Email = email;
 */