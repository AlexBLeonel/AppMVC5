using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alex.Business.Models.Fornecedores.Services {
    interface IFornecedorService : IDisposable {
        Task Add(Fornecedor fornecedor);
        Task Update(Fornecedor fornecedor);
        Task Remove(Guid id);
        Task UpdateEndereco(Endereco endereco);
    }
}
