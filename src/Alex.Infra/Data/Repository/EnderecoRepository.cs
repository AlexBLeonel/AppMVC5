using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Alex.Business.Models.Fornecedores;
using Alex.Infra.Data.Context;

namespace Alex.Infra.Data.Repository {
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository {

        public EnderecoRepository(AppDBContext context) : base(context) { }

        public async Task<Endereco> GetEnderecoByFornededorId(Guid fornecedorId) {
            return await GetById(fornecedorId);
        }
    }
}
