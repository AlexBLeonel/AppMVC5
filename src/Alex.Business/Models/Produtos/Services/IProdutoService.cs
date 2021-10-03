using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alex.Business.Models.Produtos.Services {
    public interface IProdutoService : IDisposable {
        Task Add(Produto produto);
        Task Update(Produto produto);
        Task Remove(Guid id);
    }
}
