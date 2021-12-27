using Alex.Business.Core.Models;
using Alex.Business.Models.Produtos;
using System;
using System.Collections.Generic;

namespace Alex.Business.Models.Fornecedores {
    public partial class Fornecedor : Entity {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoFornecedor Tipo { get; set; }
        public Endereco Endereco { get; set; }
        public bool Status { get; set; }

        /* EF Relations*/
        public ICollection<Produto> Produtos { get; set; }
    }
}
