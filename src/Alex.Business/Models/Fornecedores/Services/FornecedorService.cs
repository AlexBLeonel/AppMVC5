using Alex.Business.Core.Notifications;
using Alex.Business.Core.Services;
using Alex.Business.Models.Fornecedores.Validation;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Alex.Business.Models.Fornecedores.Services {
    public class FornecedorService : BaseService, IFornecedorService {

        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository, 
                                 IEnderecoRepository enderecoRepository,
                                 INotifier notifier) : base(notifier) {
            _fornecedorRepository = fornecedorRepository;
            _enderecoRepository   = enderecoRepository;
        }

        public async Task Add(Fornecedor fornecedor) {
            if (RunValidation(new FornecedorValidation(), fornecedor)
                || RunValidation(new EnderecoValidation(), fornecedor.Endereco)) {
                if (await FornecedorAlreadyExists(fornecedor)) {
                    return;
                } else {
                    await _fornecedorRepository.Add(fornecedor);
                }
            } else {
                return;
            }
        }

        public async Task Remove(Guid id) {
            var fornecedor = await _fornecedorRepository.GetFornecedorProdutosEndereco(id);
            if (fornecedor.Produtos.Any()) {
                Notify("O fornecedor possui produtos cadastrados!");
                return;
            } else {
                if (fornecedor.Endereco != null) {
                    await _enderecoRepository.Delete(fornecedor.Endereco.Id);
                }
                await _fornecedorRepository.Delete(id); 
            }
        }

        public async Task Update(Fornecedor fornecedor) {
            if (RunValidation(new FornecedorValidation(), fornecedor)) {
                if (await FornecedorAlreadyExists(fornecedor)) {
                    return;
                } else {
                    await _fornecedorRepository.Update(fornecedor);
                }
            } else {
                return;
            }
        }

        public async Task<bool> FornecedorAlreadyExists(Fornecedor fornecedor) {
            var check = await _fornecedorRepository.Search(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id);

            if (check.Any())
            {
                Notify("O documento informado já pertence a outro fornecedor.");
                return true;
            } else
            {
                return false;
            }
        }

        public async Task UpdateEndereco(Endereco endereco) {
            if (RunValidation(new EnderecoValidation(), endereco)) {
                await _enderecoRepository.Update(endereco);
            } else {
                return;
            }
        }

        public void Dispose() {
            _fornecedorRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }
    }
}
