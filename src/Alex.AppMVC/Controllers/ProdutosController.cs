using Alex.Business.Core.Notifications;
using Alex.Business.Models.Produtos;
using Alex.Business.Models.Produtos.Services;
using Alex.Business.ViewModels;
using Alex.Infra.Data.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Alex.AppMVC.Controllers {
    public class ProdutosController : Controller {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository,
                                  IProdutoService produtoService,
                                  IMapper mapper) {
            _produtoRepository = produtoRepository;
            _produtoService    = produtoService;
            _mapper            = mapper;
        }

        [Route("produtos")]
        [HttpGet]
        public async Task<ActionResult> Index() {
            // _mapper.Map<O que deve ser retornado>(Entrada de dados para mapeamento)
            var produtosViewModel = _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.GetAll());
            return View(produtosViewModel);
        }

        [Route("dados-produto/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Details(Guid id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var produtoViewModel = await getProdutoViewModel(id);
            if (produtoViewModel == null) {
                return HttpNotFound();
            }
            return View(produtoViewModel);
        }

        [Route("adicionar-produto")]
        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        [Route("adicionar-produto")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProdutoViewModel produtoViewModel) {
            if (ModelState.IsValid) {
                await _produtoRepository.Add(_mapper.Map<Produto>(produtoViewModel));
                return RedirectToAction("Index");
            }
            return View(produtoViewModel);
        }

        [Route("editar-produto/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var produtoViewModel = await getProdutoViewModel(id);
            if (produtoViewModel == null) {
                return HttpNotFound();
            }
            return View(produtoViewModel);
        }

        [Route("editar-produto/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProdutoViewModel produtoViewModel) {
            if (ModelState.IsValid) {
                await _produtoRepository.Update(_mapper.Map<Produto>(produtoViewModel));
                return RedirectToAction("Index");
            }
            return View(produtoViewModel);
        }

        [Route("apagar-produto")]
        [HttpGet]
        public async Task<ActionResult> Delete(Guid id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var produtoViewModel = await getProdutoViewModel(id);
            if (produtoViewModel == null) {
                return HttpNotFound();
            }
            return View(produtoViewModel);
        }

        [Route("apagar-produto")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id) {
            var produtoViewModel = getProdutoViewModel(id);

            if (produtoViewModel == null) {
                return HttpNotFound();
            }

            await _produtoRepository.Delete(id);
            return RedirectToAction("Index");
        }

        // Retorna uma ViewModel de Produto já mapeada
        public async Task<ProdutoViewModel> getProdutoViewModel(Guid id) {
            var produtoViewModel = _mapper.Map<ProdutoViewModel>(await _produtoRepository.GetProdutoFornecedor(id));
            return produtoViewModel;
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                _produtoRepository?.Dispose();
                _produtoService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
