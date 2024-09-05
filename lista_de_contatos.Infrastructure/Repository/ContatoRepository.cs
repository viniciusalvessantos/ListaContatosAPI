using lista_de_contatos.Domain.Entities;
using lista_de_contatos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Infrastructure.Repository {
    public class ContatoRepository : IContatoRepository {
        private readonly ApplicationDbContext _dbContext;
        public ContatoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(Contatos contatos) {
            await _dbContext.AddAsync(contatos);
        }

        public Task CommitAsync() {
            return _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id) {
            var existeContato = await _dbContext.Contatos.FindAsync(id);
            if (existeContato is null) {
                throw new KeyNotFoundException($"O contato de id {id} não existe!!!");
            }
            _dbContext.Contatos.Remove(existeContato);
        }

        public Task<Contatos> Get(Guid id, CancellationToken cancellationToken) {
            return _dbContext.Contatos.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)!;
        }

        public async Task<IEnumerable<Contatos>> GetAll() {
            return await _dbContext.Contatos.ToListAsync();
        }

        public async Task<IEnumerable<Contatos>> GetContatosPessoaALL(Guid pessoaId){
            return await _dbContext.Contatos.Where(c=>c.PessoaId == pessoaId).ToListAsync();
        }

        public async Task Update(Guid id, string nome, string email, string telefone, string whatsapp) {
            var existeContato = await _dbContext.Contatos.FindAsync(id);
            if (existeContato is null) {
                throw new KeyNotFoundException($"O contato de id {id} não existe!!!");
            }
            existeContato.UpdateNome(nome);
            existeContato.UpdateWhatsApp(whatsapp);
            existeContato.UpdateEmail(email);
            existeContato.UpdateTelefone(telefone);

            _dbContext.Contatos.Update(existeContato);
        }
    }
}
