using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Alex.Business.Models.Fornecedores;

namespace Alex.Infra.Data.Repository {
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository {
        public async Task<Endereco> GetEnderecoByFornededorId(Guid fornecedorId) {
            return await GetById(fornecedorId);
        }
    }
}
