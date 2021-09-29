using Alex.Business.Models.Fornecedores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alex.Infra.Data.Mappings {
    // Fluent API
    class FornecedorConfig : EntityTypeConfiguration<Fornecedor> {
        public FornecedorConfig() {
            HasKey(f => f.Id);

            Property(f => f.Nome)
                .IsRequired();

            Property(f => f.Documento)
                .IsRequired()
                .HasMaxLength(14)
                .HasColumnAnnotation("Index_Documento", 
                    new IndexAnnotation (
                        new IndexAttribute { IsUnique = true } ));

            HasRequired(f => f.Endereco)
                // Define o relacionamento para 1
                .WithRequiredPrincipal(e => e.Fornecedor);

            Property(f => f.Deleted_at)
                .IsOptional();

            ToTable("Fornecedores");
        }
    }
}
