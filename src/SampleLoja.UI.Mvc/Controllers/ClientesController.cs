using System;
using System.Web.Mvc;
using AutoMapper;
using SampleLoja.Apresentation.Interfaces;
using SampleLoja.Apresentation.ViewModels;
using SampleLoja.Domain.Entidades;

namespace SampleLoja.UI.Mvc.Controllers
{
  public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }
    
        // GET: Clientes
        public ActionResult Index()
        {
            /* Examplo vamos supor que voc~e deseja coloca um método para trazer todos clientes desativados
            */
            var cliente = new Cliente {DataCadastro = DateTime.Now, Nome = "Nome"};
            var clienteVM = Mapper.Map<ClienteViewModel>(cliente);

            var clieteVM = _clienteAppService.BuscarPorFiltro(filtro: f => f.Ativo.Equals(true));
            return View(clieteVM);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel clienteView)
        {
            if(ModelState.IsValid)
            {
                

                return RedirectToAction("Index");
            }

            return View(clienteView);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
