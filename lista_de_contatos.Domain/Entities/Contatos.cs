using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Domain.Entities {
    public class Contatos : BaseEntity {

        private Contatos()
        {}
        private Contatos(string nome, string email, string telefone, string whatsapp, Guid pessoaid)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            WhatsApp = whatsapp;
            PessoaId = pessoaid;
        }
        [MaxLength(60)]
        public string Nome { get; private set; }
        [EmailAddress]
        public string Email { get; private set; }
        [MaxLength(11)]
        public string Telefone { get; private set; }
        [MaxLength(11)]
        public string WhatsApp { get; private set; }

        [ForeignKey("Pessoas")]
        public Guid PessoaId { get; private set; }
        public virtual Pessoas Pessoas { get; private set; }

        public void UpdateNome(string nome) {
            if (!string.IsNullOrWhiteSpace(nome) && nome.Length <= 60) {
                Nome = nome;
            } else {
                throw new ArgumentException("Não e um nome valido !!");
            }
        }
        public void UpdateWhatsApp(string whatsapp) {
            if (!string.IsNullOrWhiteSpace(whatsapp) && whatsapp.Length == 11) {
                WhatsApp = whatsapp;
            } else {
                throw new ArgumentException("Não e um whatsapp valido !!");
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

     


        public static Contatos New(string nome, string telefone, string email, string whatsapp, Guid pessoaid) {
            if (nome.Length > 60) {
                throw new ArgumentException("Nome invalido.");
            }
            if (whatsapp.Length < 11) {
                throw new ArgumentException("WhatsApp invalido.");
            }
            if (telefone.Length < 11) {
                throw new ArgumentException("Telefone invalido");
            }

            return new Contatos(nome, email, telefone, whatsapp, pessoaid);
        }



    }
}
