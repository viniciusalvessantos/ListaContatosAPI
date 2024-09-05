using lista_de_contatos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Domain.Interfaces {
    public interface IContatoRepository {
        Task Add(Contatos contatos);
        Task Update(Guid id, string nome, string email, string telefone, string whatsapp);
        Task Delete(Guid id);
        Task<IEnumerable<Contatos>> GetAll(Guid? pessoaId);
        Task<Contatos> Get(Guid id, CancellationToken cancellationToken);
        Task CommitAsync();
    }
}
/*
  Nome = nome;
            Email = email;
            Telefone = telefone;
            WhatsApp = whatsapp;
            PessoaId = pessoaid;
 */
