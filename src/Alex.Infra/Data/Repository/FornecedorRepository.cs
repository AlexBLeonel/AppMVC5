using Alex.Business.Models.Fornecedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Alex.Infra.Data.Context;

namespace Alex.Infra.Data.Repository {
    public class FornecedorRepository :  Repository<Fornecedor>, IFornecedorRepository {
        public FornecedorRepository(AppDBContext context) : base(context) { }

        public async Task<Fornecedor> GetFornecedorEndereco(Guid id) {
            return await Db.Fornecedores.AsNoTracking()
                .Include(f => f.Endereco).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Fornecedor> GetFornecedorProdutosEndereco(Guid id) {
            return await Db.Fornecedores.AsNoTracking()
                .Include(f => f.Produtos)
                .Include(f => f.Endereco).FirstOrDefaultAsync(f => f.Id == id);
        }

        // Sobrescrevendo o método de apagar, do repositório genérico
        public async override Task Delete(Guid id) {
            var fornecedor = await GetById(id);
            fornecedor.Deleted_at = DateTime.Now;
            await Update(fornecedor);
        }
    }
}
