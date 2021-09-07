using Alex.Business.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alex.Business.Models.Produtos {
    interface IProdutoRepository : IRepository<Produto> {
        // Obtém uma lista produtos de um fornecedor
        Task<IEnumerable<Produto>> GetProdutosByFornecedor(Guid FornecedorId);

        //  Obtém uma lista de produtos e seus fornecedores
        Task<IEnumerable<Produto>> GetProdutosFornecedores();

        // Obtém o produto e seu fornecedor
        Task<Produto> GetProdutoFornecedor(Guid id);
    }
}
