using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Application.Responses.Pessoas {
    public class MessagemResponser {
        public MessagemResponser(string menssagem) {
            MessagemsResponser = menssagem;
        }
        public string MessagemsResponser { get; }
    }
}
