using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alex.Business.Models.Fornecedores.Validation {
    class EnderecoValidation : AbstractValidator<Endereco> {

        public EnderecoValidation() {
            RuleFor(f => f.Numero)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio.")
                .Length(2, 150).WithMessage("O campo {PropertyName} deve possuir entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(f => f.Logradouro)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio.")
                .Length(2, 150).WithMessage("O campo {PropertyName} deve possuir entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(f => f.CEP)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio.")
                .Length(2, 150).WithMessage("O campo {PropertyName} deve possuir entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(f => f.Bairro)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio.")
                .Length(2, 150).WithMessage("O campo {PropertyName} deve possuir entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(f => f.Cidade)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio.")
                .Length(2, 150).WithMessage("O campo {PropertyName} deve possuir entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(f => f.Estado)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio.")
                .Length(2, 150).WithMessage("O campo {PropertyName} deve possuir entre {MinLength} e {MaxLength} caracteres.");

        }
    }
}
