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

            Property(f => f.Nome).IsRequired();

            Property(f => f.Documento)
                .IsRequired()
                .HasMaxLength(14)
                .HasColumnAnnotation("Index_Documento", 
                    new IndexAnnotation ( new IndexAttribute { IsUnique = true } ));

            // Define o relacionamento para 1 
            HasRequired(f => f.Endereco).WithRequiredPrincipal(e => e.Fornecedor);

            Property(f => f.Crated_at).IsRequired();
            Property(f => f.Updated_at).IsOptional();
            Property(f => f.Deleted_at).IsOptional();

            ToTable("Fornecedores");
        }
    }
}
