using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Alex.Business.Models.Produtos;
using Alex.Infra.Data.Context;

namespace Alex.Infra.Data.Repository {
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository {
        public ProdutoRepository(AppDBContext context)  : base(context) { }

        public async Task<Produto> GetProdutoFornecedor(Guid id) {
            return await Db.Produtos.AsNoTracking()
                .Include(p => p.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> GetProdutosFornecedores() {
            return await Db.Produtos.AsNoTracking()
                .Include(f => f.Fornecedor)
                .OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> GetProdutosByFornecedor(Guid FornecedorId) {
            return await Search(p => p.FornecedorId == FornecedorId);
        }
    }
}
