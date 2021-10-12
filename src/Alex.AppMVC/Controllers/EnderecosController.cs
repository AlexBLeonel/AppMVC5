using Alex.Business.Models.Fornecedores;
using Alex.Business.ViewModels;
using AutoMapper;
using System;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Alex.AppMVC.Controllers {
    public class EnderecosController : Controller {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public EnderecosController(IEnderecoRepository enderecoRepository,
                                    IMapper mapper) {
            _enderecoRepository = enderecoRepository;
            _mapper             = mapper;
        }

        [Route("enderecos")]
        [HttpGet]
        public async Task<ActionResult> Index() {
            return View(await _enderecoRepository.GetAll());
        }

        [HttpGet]
        public async Task<ActionResult> Details(Guid id) {
            var enderecoViewModel = await getEnderecoViewModel(id);
            if (enderecoViewModel == null) {
                return HttpNotFound();
            }
            return View(enderecoViewModel);
        }

        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EnderecoViewModel enderecoViewModel) {
            if (ModelState.IsValid) {
                var endereco = _mapper.Map<Endereco>(enderecoViewModel);
                await _enderecoRepository.Add(endereco);
                return RedirectToAction("Index");
            }
            return View(enderecoViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid id) {
            var enderecoViewModel = await getEnderecoViewModel(id);
            if (enderecoViewModel == null) {
                return HttpNotFound();
            }
            return View(enderecoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EnderecoViewModel enderecoViewModel) {
            if (ModelState.IsValid) {
                var endereco = _mapper.Map<Endereco>(enderecoViewModel);
                await _enderecoRepository.Update(endereco);
                return RedirectToAction("Index");
            }
            return View(enderecoViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(Guid id) {
            var enderecoViewModel = await getEnderecoViewModel(id);
            if (enderecoViewModel == null) {
                return HttpNotFound();
            }
            return View(enderecoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id) {
            var enderecoViewModel = await getEnderecoViewModel(id);

            if (enderecoViewModel == null) {
                return HttpNotFound();
            }

            await _enderecoRepository.Delete(id);
            return RedirectToAction("Index");
        }

        // Retorna uma ViewModel de Endereço já mapeada
        public async Task<EnderecoViewModel> getEnderecoViewModel(Guid id) {
            var EnderecoViewModel = _mapper.Map<EnderecoViewModel>(await _enderecoRepository.GetById(id));
            return EnderecoViewModel;
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                _enderecoRepository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
