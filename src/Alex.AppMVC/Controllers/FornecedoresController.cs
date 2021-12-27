using Alex.AppMVC.ViewModels;
using Alex.Business.Models.Fornecedores;
using Alex.Business.Models.Fornecedores.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Alex.AppMVC.Controllers {
    public class FornecedoresController : BaseController {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IFornecedorService _fornecedorService;
        private readonly IMapper _mapper;

        public FornecedoresController(IFornecedorRepository fornecedorRepository,
                                    IFornecedorService fornecedorService,
                                    IMapper mapper) {
            _fornecedorRepository = fornecedorRepository;
            _fornecedorService = fornecedorService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult> Index() {
            var produtos = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.GetAll());
            return View(produtos);
        }

        [HttpGet]
        public async Task<ActionResult> Details(Guid id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var fornecedorViewModel = await getFornecedorViewModel(id);
            if (fornecedorViewModel == null) {
                return HttpNotFound();
            }

            return View(fornecedorViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FornecedorViewModel fornecedorViewModel) {
            if (ModelState.IsValid) {
                await _fornecedorRepository.Add(_mapper.Map<Fornecedor>(fornecedorViewModel));
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var fornecedorViewModel = await getFornecedorProdutosEnderecoViewModel(id);
            if (fornecedorViewModel == null) {
                return HttpNotFound();
            }
            return View(fornecedorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, FornecedorViewModel fornecedorViewModel) {
            if (id != fornecedorViewModel.Id) {
                return HttpNotFound();
            }

            if (ModelState.IsValid) {
                await _fornecedorService.Update(_mapper.Map<Fornecedor>(fornecedorViewModel));
                return RedirectToAction("Index");
            }
            return View(fornecedorViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(Guid id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var fornecedorViewModel = await getFornecedorProdutosEnderecoViewModel(id);
            if (fornecedorViewModel == null) {
                return HttpNotFound();
            }
            return View(fornecedorViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var fornecedorViewModel = getFornecedorViewModel(id);
            if (fornecedorViewModel == null) {
                return HttpNotFound(); 
            }

            await _fornecedorService.Remove(id);
            return RedirectToAction("Index");
        }

        private async Task<FornecedorViewModel> getFornecedorViewModel(Guid id) {
            var fornecedorViewModel = _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.GetById(id));
            return fornecedorViewModel;
        }

        private async Task<FornecedorViewModel> getFornecedorEnderecoViewModel(Guid id) {
            var fornecedorViewModel = _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.GetFornecedorEndereco(id));
            return fornecedorViewModel;
        }

        private async Task<FornecedorViewModel> getFornecedorProdutosEnderecoViewModel(Guid id) {
            var fornecedorViewModel = _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.GetFornecedorProdutosEndereco(id));
            return fornecedorViewModel;
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                _fornecedorRepository?.Dispose();
                _fornecedorService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}