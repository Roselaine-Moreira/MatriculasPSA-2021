using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entidades.Models;
using Microsoft.AspNetCore.Authorization;
using Negocio;

namespace MatriculasPSA2021.Controllers
{
    [Authorize]
    public class HistoricosController : Controller
    {
        //Facade
        private readonly TurmaFacade _turmaFacade;


        public HistoricosController(TurmaFacade turmaFacade)
        {
            _turmaFacade = turmaFacade;
        }

        // GET: Historicos
        [Authorize]
        public async Task<IActionResult> Index()
        {
            List<Historico> historicos = await _turmaFacade.todosHistoricos();
            return View(historicos);
        }

       
    }
}
