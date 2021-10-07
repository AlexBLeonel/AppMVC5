using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Alex.Business.ViewModels {
    public class EnderecoViewModel {
        public EnderecoViewModel() {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(200, ErrorMessage = "O campo {0} deve ter de {2} a {1} caracteres", MinimumLength = 2)]
        public string Logradouro { get; set; }

        [DisplayName("Número")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(10, ErrorMessage = "O campo {0} deve ter de {2} a {1} caracteres", MinimumLength = 1)]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo {0} deve ter de {2} a {1} caracteres", MinimumLength = 5)]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(8, ErrorMessage = "O campo {0} deve ter de {2} a {1} caracteres", MinimumLength = 1)]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(150, ErrorMessage = "O campo {0} deve ter de {2} a {1} caracteres", MinimumLength = 1)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(150, ErrorMessage = "O campo {0} deve ter de {2} a {1} caracteres", MinimumLength = 1)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(150, ErrorMessage = "O campo {0} deve ter de {2} a {1} caracteres", MinimumLength = 1)]
        public string Estado { get; set; }

        [HiddenInput]
        public Guid FornecedorId { get; set; }
    }
}
