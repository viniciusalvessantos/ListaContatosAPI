using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Domain.Entities {
    public class Pessoas : BaseEntity {
        private Pessoas()
        {}
        private Pessoas(string nome, string sobrenome, string telefone, string email)
        {
            Nome = nome;
            SobreNome = sobrenome;
            Telefone = telefone;    
            Email = email;
        }
        [MaxLength(60)]
        public string Nome { get; private set; }
        [MaxLength(60)]
        public string SobreNome { get; private set; }
        [MaxLength(11)]
        public string Telefone { get; private set; }
        [EmailAddress]
        public string Email { get; private set; }
        public virtual ICollection<Contatos> Contatos { get; private set; }

        public void UpdateNome(string nome) {
            if (!string.IsNullOrWhiteSpace(nome) && nome.Length <= 60) {
                Nome = nome;
            } else {
                throw new ArgumentException("Não e um nome valido !!");
            }
        }
        public void UpdateSobreNome(string sobrenome) {
            if (!string.IsNullOrWhiteSpace(sobrenome) && sobrenome.Length <= 60) {
                SobreNome = sobrenome;
            } else {
                throw new ArgumentException("Não e um sobrenome valido !!");
            }
        }
        public void UpdateTelefone(string telefone) {
            if (!string.IsNullOrWhiteSpace(telefone) && telefone.Length == 11) {
                Telefone = telefone;
            } else {
                throw new ArgumentException("Não e um telefone valido !!");
            }
        }
        public void UpdateEmail(string email) {
            if (!string.IsNullOrWhiteSpace(email)) {
                Email = email;
            } else {
                throw new ArgumentException("Não e um email valido !!");
            }
        }

        public static Pessoas New(string nome, string sobrenome, string telefone, string email) {
            if (nome.Length > 60) {
                throw new ArgumentException("Nome invalido.");
            }
            if (sobrenome.Length > 60) {
                throw new ArgumentException("SobreNome invalido.");
            }
            if (telefone.Length < 11) {
                throw new ArgumentException("Telefone invalido");
            }
  
            return new Pessoas(nome,sobrenome,telefone,email);
        }
    }
}
