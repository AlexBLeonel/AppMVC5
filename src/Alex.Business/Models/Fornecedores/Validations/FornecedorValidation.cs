using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alex.Business.Models.Fornecedores.Validations {
    class FornecedorValidation : AbstractValidator<Fornecedor> {

        public FornecedorValidation() {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser informado.")
                .Length(2, 150).WithMessage("O campo {PropertyName} deve possuir de {MinLength} à {MaxLength}");
        }
    }
}
