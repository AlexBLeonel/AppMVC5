using Alex.Business.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alex.Business.Models.Fornecedores {
    interface IFornecedorRepository : IRepository<Fornecedor> {
        // Retorna o Fornecedor e seu Endereço
        Task<Fornecedor> GetFornecedorEndereco(Guid id);

        // Retorna o Fornecedor, seus produtos e seu Endereço
        Task<Fornecedor> GetFornecedorProdutosEndereco(Guid id);
    }
}
