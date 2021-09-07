using Alex.Business.Models.Fornecedores;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alex.Infra.Data.Mappings {
    class EnderecoConfig : EntityTypeConfiguration<Endereco> {
        public EnderecoConfig() {
            HasKey(e => e.Id);

            Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(200);

            Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(10);

            Property(e => e.Complemento)
                .HasMaxLength(200);

            Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(100);

            Property(e => e.Cidade)
                .IsRequired()
                .HasMaxLength(150);

            Property(e => e.Estado)
                .IsRequired()
                .HasMaxLength(80);

            Property(e => e.CEP)
                .IsRequired()
                .HasMaxLength(8)
                .IsFixedLength();

            ToTable("Enderecos");
        }
    }
}
