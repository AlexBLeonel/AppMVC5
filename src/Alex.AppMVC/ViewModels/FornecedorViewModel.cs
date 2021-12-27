using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static Alex.Business.Models.Fornecedores.Fornecedor;

namespace Alex.AppMVC.ViewModels {
    public class FornecedorViewModel {
        public FornecedorViewModel() {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id {
            get; set;
        }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(150, ErrorMessage = "O campo {0} deve ter de {2} a {1} caracteres", MinimumLength = 2)]
        public string Nome {
            get; set;
        }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(14, ErrorMessage = "O campo {0} deve ter de {2} a {1} caracteres", MinimumLength = 11)]
        public string Documento {
            get; set;
        }

        [DisplayName("Tipo")]
        public TipoFornecedor Tipo {
            get; set;
        }

        public EnderecoViewModel Endereco {
            get; set;
        }

        [DisplayName("Status")]
        public bool Status {
            get; set;
        }

        [ScaffoldColumn(false)]
        public DateTime Deleted_at {
            get; set;
        }

        public IEnumerable<ProdutoViewModel> Produtos {
            get; set;
        }

    }
}