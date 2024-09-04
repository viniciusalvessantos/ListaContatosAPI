using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Domain.Entities {
    public class BaseEntity {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public string CriadoPor { get; set; }
        public DateTime DataModificacao { get; set; }
        public string ModificadoPor { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; } //controle de concorrencia usando Timestamp

    }
}
