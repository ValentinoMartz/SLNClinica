using Microsoft.AspNetCore.Mvc;
using SLNClinica.Data;
using SLNClinica.Models;
using System.Linq;

namespace SLNClinica.Controllers
{
    public class MedicoController : Controller
    {
        private readonly DBClinicaMVCContext context;

        public MedicoController(DBClinicaMVCContext context)
        {
            this.context = context;
        }

        //GET /medico
        //GET /medico/index
        [HttpGet]
        public IActionResult Index()
        {
            var medicos = context.Medicos.ToList();
            return View(medicos);
        }

        //Get medico/create
        [HttpGet]
        public ActionResult Create()
        {
            Medico medico = new Medico();
            return View("Create", medico);
        }

        //Post medico/create
        [HttpPost]
        public ActionResult Create(Medico medico)
        {
            if (ModelState.IsValid)
            {
                context.Medicos.Add(medico);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medico);
        }

        //Get opera/Details/4
        [HttpGet]
        public ActionResult Details(int id)
        {
            var medico = TraerUno(id);
            if (medico == null)
            {
                return NotFound();
            }
            else
            {
                return View("Detalle", medico);
            }
        }

        //Get medico/delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var medico = TraerUno(id);
            if (medico == null)
            {
                return NotFound();
            }
            else
            {
                return View("Delete", medico);//Devuelve el hmlt(View) al cliente
            }
        }

        //Post medico/delete/1
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var medico = TraerUno(id);
            if (medico == null)
            {
                return NotFound();
            }
            else
            {
                context.Medicos.Remove(medico);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        //Get medico/edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Medico medico = TraerUno(id);
            return View("Edit", medico);
        }

        //Edit medico/edit/1
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(int id, Medico medico)
        {
            if (id != medico.Id)
            {
                return NotFound();
            }
            else
            {
                context.Entry(medico).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }



        private Medico TraerUno(int id)
        {
            return context.Medicos.Find(id);
        }
    }
}
