using Alex.Business.Core.Models;
using Alex.Business.Models.Fornecedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alex.Business.Models.Produtos {
    public class Produto : Entity {
        public Guid FornecedorId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Status{ get; set; }
        
        /* EF Relations*/
        public Fornecedor Fornecedor { get; set; }
    }
}
