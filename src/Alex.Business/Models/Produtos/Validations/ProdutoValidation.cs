using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alex.Business.Models.Produtos.Validations {
    class ProdutoValidation : AbstractValidator<Produto> {

        public ProdutoValidation() {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio.")
                .Length(2, 150).WithMessage("O campo {PropertyName} deve possuir entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(p => p.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio.")
                .Length(5, 1000).WithMessage("O campo {PropertyName} deve possuir entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(p => p.Valor)
                .GreaterThan(0).WithMessage("O campo {PropertyName} deve ser maior que {ComparisonValue}.");
        }
    }
}
