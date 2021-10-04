using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Alex.Business.ViewModels
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Fornecedor")]
        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(150, ErrorMessage = "O campo {0} deve ter de {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(1000, ErrorMessage = "O campo {0} deve ter de {2} e {1} caracteres.", MinimumLength = 5)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Imagem do Produto")]
        public HttpPostedFileBase UploadImagem { get; set; }

        public string Imagem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public decimal Valor { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        [DisplayName("Status")]
        public bool Status { get; set; }

        /*
         * Fornecedor que representa o produto
         */
        public FornecedorViewModel fornecedor { get; set; }

        /*
         * Lista de fornecedores para popular input select de fornecederes
         */
        public IEnumerable<FornecedorViewModel> fornecedores { get; set; }
    }
}
