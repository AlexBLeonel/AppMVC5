using Alex.Business.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alex.Business.Models.Fornecedores {
    interface IEnderecoRepository : IRepository<Endereco> {
        Task<Endereco> GetEnderecoByFornededorId(Guid fornecedorId);
    }
}
