using System.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Program.Data;
using Program.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Copreter.Controllers
{
      public class CitaController : Controller
    {
          ApplicationDbContext _context ;

        public CitaController(ApplicationDbContext context)
        {
             _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Solicitar(string id)
        {
            List<TCitum> Cita = await _context.TCita.Include(x=>x.IdObraCitaNavigation).ToListAsync();
            TCitum cita = new TCitum();
            var obj =   (from prod in Cita select prod)
                        .Count();
            int cantRegistro= obj+1;
            cita.IdCita = "Cita-00"+cantRegistro+"-"+id;
            cita.IdObraCita =id;
            ViewBag.ListaObra = await _context.TObras.OrderBy(x => x.IdObra).ToListAsync();
            return View(cita);
        }

        [BindProperty]
        public TCitum cita{get;set;}
        public async Task<IActionResult> Guardar()
        {
             if(!ModelState.IsValid)
            {
               return View(cita);
            }
            _context.TCita.Add(cita);
             await  _context.SaveChangesAsync();
           return Redirect("/Home/VistaAdministrador");
        }

        public async Task<IActionResult> ListarC()
        {
            var model = new ModelCita();
            model.citas = await _context.TCita.Include(x=>x.IdObraCitaNavigation).Where(o => o.IdObraCitaNavigation.IdObraEstado==4).ToListAsync();
            model.obras = await _context.TObras.Where(o => o.IdObraEstado==4).OrderBy(x=>x.IdObra).ToListAsync();
            model.clientes = await _context.TClientes.ToListAsync();
            model.estadosObra = await _context.TEstadoObras.ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> Detalle(string id)
        {
            var Cita = _context.TCita.Find(id);
            ViewBag.Obra = await _context.TObras.Include(x=>x.IdObraEstadoNavigation).Include(x=>x.IdUsuarioObraNavigation).ToListAsync();
            return View(Cita);
        }
        
        public async Task<IActionResult> ObraCitada(string id)
        {
            var _Obra = _context.TObras.Where(x => x.IdObra ==id).SingleOrDefault();
            _Obra.IdObraEstado = 1;
            await _context.SaveChangesAsync();
            return RedirectToAction("ListarC");
        }

        public class ModelCita
        {
            public IEnumerable<TCitum> citas { get; set; }
            public IEnumerable<TObra> obras { get; set; }
            public IEnumerable<TCliente> clientes { get; set; }
            public IEnumerable<TEstadoObra> estadosObra { get; set; }
        }
    }
}