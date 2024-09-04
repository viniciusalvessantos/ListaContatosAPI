using lista_de_contatos.Domain.Entities;
using lista_de_contatos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Infrastructure.Repository {
    public class PessoaRepository : IPessoaRepository {
        private readonly ApplicationDbContext _dbContext;

        public PessoaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(Pessoas pessoas) {
            await _dbContext.AddAsync(pessoas);
        }

        public Task CommitAsync() {
            return _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id) {
            var existePessoa = await _dbContext.Pessoas.FindAsync(id);
            if (existePessoa is null) {
                throw new KeyNotFoundException($"A pessoa de id {id} não existe!!!");
            }
            _dbContext.Pessoas.Remove(existePessoa);

        }

        public Task<Pessoas> Get(Guid id, CancellationToken cancellationToken) {
            return _dbContext.Pessoas.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)!;
        }

        public async Task<IEnumerable<Pessoas>> GetAll() {
            return await _dbContext.Pessoas.ToListAsync();
        }

        public async Task Update(Guid id, string nome, string sobrenome, string telefone, string email) {
            var existePessoa = await _dbContext.Pessoas.FindAsync(id);
            if (existePessoa is null) {
                throw new KeyNotFoundException($"A pessoa de id {id} não existe!!!");
            }
            existePessoa.UpdateNome(nome);
            existePessoa.UpdateSobreNome(sobrenome);
            existePessoa.UpdateEmail(email);
            existePessoa.UpdateTelefone(telefone);

            _dbContext.Pessoas.Update(existePessoa);
        }
    }
}
