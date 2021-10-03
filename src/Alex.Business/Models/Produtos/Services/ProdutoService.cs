using Alex.Business.Core.Services;
using Alex.Business.Models.Produtos.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alex.Business.Models.Produtos.Services {
    public class ProdutoService : BaseService, IProdutoService {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository) {
            _produtoRepository = produtoRepository;
        }

        public async Task Add(Produto produto) {
            if (RunValidation(new ProdutoValidation(), produto)) {
                await _produtoRepository.Add(produto);
            } else {
                return;
            }
        }

        public async Task Remove(Guid id) {
            await _produtoRepository.Delete(id);
        }

        public async Task Update(Produto produto) {
            if (RunValidation(new ProdutoValidation(), produto)) {
                await _produtoRepository.Update(produto);
            } else {
                return;
            }
        }
        public void Dispose() {
            _produtoRepository?.Dispose();
        }
    }
}
