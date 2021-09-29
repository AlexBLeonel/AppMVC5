using Alex.Business.Models.Produtos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alex.Infra.Data.Mappings {
    class ProdutoConfig : EntityTypeConfiguration<Produto> {
        public ProdutoConfig() {
            HasKey(p => p.Id);

            Property(p => p.Nome)
                .IsRequired();
            // Tamanho definido genericamente no contexto AppDB

            Property(p => p.Valor)
                .IsRequired();

            Property(p => p.Status)
                .IsRequired();

            Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(1000);

            Property(p => p.Imagem)
                .IsRequired()
                .HasMaxLength(100);

            HasRequired(p => p.Fornecedor)
                // Define o relacionamento para muitos (N)
                .WithMany(f => f.Produtos)
                .HasForeignKey(p => p.FornecedorId);

            ToTable("Produtos");

        }
    }
}
