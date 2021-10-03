using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Alex.Business.Core.Validations.Documentos.DocumentsValidation;

namespace Alex.Business.Models.Fornecedores.Validation {
    class FornecedorValidation : AbstractValidator<Fornecedor> {

        public FornecedorValidation() {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser informado.")
                .Length(2, 150).WithMessage("O campo {PropertyName} deve possuir de {MinLength} à {MaxLength} caracteres.");

            When(f => f.Tipo == Fornecedor.TipoFornecedor.PessoaFisica, () => {
                RuleFor(f => f.Documento.Length).Equal(CpfValidacao.TamanhoCpf)
                    .WithMessage("O campo {PropertyName} deve possuir {ComparisonValue} números, o valor fornecido possui apenas {PropertyValue}.");

                RuleFor(f => CpfValidacao.Validar(f.Documento)).Equal(true)
                    .WithMessage("O {PropertyName} informado é inválido.");
            });

            When(f => f.Tipo == Fornecedor.TipoFornecedor.PessoaJuridica, () => {
                RuleFor(f => f.Documento.Length).Equal(CnpjValidacao.TamanhoCnpj)
                    .WithMessage("O campo {PropertyName} deve possuir {ComparisonValue} números, o valor fornecido possui apenas {PropertyValue}.");

                RuleFor(f => CnpjValidacao.Validar(f.Documento)).Equal(true)
                    .WithMessage("O {PropertyName} informado é inválido.");
            });
        }
    }
}
