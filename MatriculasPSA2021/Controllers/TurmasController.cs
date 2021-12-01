using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entidades.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Negocio;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace MatriculasPSA2021.Controllers
{
    public class TurmasController : Controller
    {

        //Aluno é o nosso ApplicationUser
        public readonly UserManager<Aluno> _userManager;

        //Facade
        private readonly TurmaFacade _turmaFacade;

        public TurmasController(UserManager<Aluno> userManager, TurmaFacade turmaFacade)
        {
            _turmaFacade = turmaFacade;
            _userManager = userManager;
        }


        //Consulta todas as turmas
        public async Task<IActionResult> Index(string valorPesquisa)
        {
            ViewData["NameSortParm"] = valorPesquisa;

            List<Turma> turmas = await _turmaFacade.todasTurmas();


            if (!String.IsNullOrEmpty(valorPesquisa))
            {
                turmas = await _turmaFacade.filtro(valorPesquisa);
            }
            else
            {
                turmas = await _turmaFacade.todasTurmas();
            }

            return View(turmas);
        }



        //Consulta Turmas disponíveis
        [Authorize]
        public async Task<IActionResult> Matriculas()
        {
            List<Turma> turmas = new List<Turma>();

            if (turmas == null)
            {
                return NotFound();
            }

            turmas = await _turmaFacade.turmasDisponiveis();
            return View(turmas);
        }


        //Solicitar Matricula
        public async Task<IActionResult> SolicitaMatricula(int? id)
        {
            var usuario = await _userManager.GetUserAsync(User);
            ViewBag.Id = usuario.AlunoId;

            Matricula novaMatricula = new Matricula()
            {
                AlunoId = ViewBag.Id,
                TurmaId = (int)id
            };

            var turmaId = await _turmaFacade.getById((int)id);

            Boolean turma = _turmaFacade.addMatricula(novaMatricula, turmaId);


            if (turma == false)
            {
                if (turmaId.NumeroDeVaga == 0)
                {
                    return RedirectToAction("Matriculanaoefetuada", "Turmas", new { Id = id });
                }

            }

            _turmaFacade.updateStatus(turmaId, (int)id);



            return RedirectToAction("Matriculaefetuada", "Turmas", new { Id = id });

        }


        //Exibe todas as turmas matriculadas
        public async Task<IActionResult> Exibematricula()
        {
            List<Turma> turmas = await _turmaFacade.turmasMatriculadas();

            return View(turmas);
        }


        //Gera PDF com comprovante de matrícula
        public async Task<IActionResult> GeraComprovante()
        {

            Document document = new Document();
            document.SetMargins(3, 2, 3, 2);

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(
              Directory.GetCurrentDirectory() + "\\Comprovante_De_Matricula.pdf", FileMode.Create));
            document.Open();

            //Numero de colunas
            PdfPTable table = new PdfPTable(2);

            Font fonte = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 18);

            Paragraph coluna1 = new Paragraph("NomeTurma", fonte);
            Paragraph coluna2 = new Paragraph("Horario", fonte);

            var cell1 = new PdfPCell();
            var cell2 = new PdfPCell();
           

            cell1.AddElement(coluna1);
            cell1.AddElement(coluna2);

            table.AddCell(cell1);
            table.AddCell(cell2);
            

            var turmaId = await _turmaFacade.getByIdTurmasMatriculadas();

            foreach (var t in turmaId)
            {
                Phrase nome = new Phrase(t.NomeTurma);
                var cell = new PdfPCell(nome);
                table.AddCell(cell);

                Phrase horario = new Phrase(t.Horario);
                cell = new PdfPCell(horario);
                table.AddCell(cell);

            }

            document.Add(table);

            document.Close();
            return RedirectToAction("Downloadefetuado", "Turmas");
        }


        //Cancelar Matricula
        public async Task<IActionResult> CancelaMatricula(int? id)
        {

            //envia a turma daquele id
            var turmaId = await _turmaFacade.getById((int)id);

            _turmaFacade.updateStatusCancelado(turmaId, (int)id);

            return RedirectToAction("Matriculacancelada", "Turmas", new { Id = id });


        }


        //Retorna uma página de sucesso matrícula efetuada 
        public IActionResult Matriculaefetuada()
        {
            ViewData["Titulo"] = "Matrícula efetuada com sucesso!";
            ViewData["Message"] = "Boas aulas.";

            return View();
        }


        //Retorna uma página de download com sucesso 
        public IActionResult Downloadefetuado()
        {
            ViewData["Titulo"] = "Comprovante de matrícula gerado com sucesso!";
            return View();
        }


        //Retorna uma página de erro matrícula não efetuada 
        public IActionResult Matriculanaoefetuada()
        {
            ViewData["Titulo"] = "Matrícula não efetuada!";
            ViewData["Message"] = "Não há mais vagas nesta turma.";

            return View();
        }


        //Retorna uma página de sucesso matrícula cancelada
        public IActionResult Matriculacancelada()
        {
            ViewData["Titulo"] = "Matrícula cancelada com sucesso!";

            return View();
        }

    }
}

