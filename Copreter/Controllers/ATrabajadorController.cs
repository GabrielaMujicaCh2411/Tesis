using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Program.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Program.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Copreter.Controllers
{
  public class ATrabajadorController : Controller
    {
         ApplicationDbContext _context ;

        public ATrabajadorController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] Object trabajador)
        {
            var part = JsonConvert.DeserializeObject<ViewModelCotizacion>(trabajador.ToString());
            foreach(var tipo in part.TTrabajadorxCotizacions.ToList()){
                var trabxCot = new TTrabajadorxCotizacion();
                trabxCot.IdCotizacion = tipo.IdCotizacion;
                trabxCot.DniTrabajador = tipo.DniTrabajador;
                _context.TTrabajadorxCotizacions.Add(trabxCot);
                await _context.SaveChangesAsync();
            }
           return Json(Url.Action("ListarAdmin", "Cotizar"));   
        }
        
        public async Task<IActionResult> Detalle(string id)
        {
            var trabajadores = await _context.TTrabajadors.ToListAsync();
            ViewBag.Cotizacion = await _context.TCotizacions.Where(x=> x.IdCotizacion == id).FirstOrDefaultAsync();
            ViewBag.TipoTrabajador = await _context.TTipoTrabajadors.ToListAsync();
            return View(trabajadores);
        }

        public class ViewModelCotizacion
        {
            public string IdCotizacion { get; set; }
            public IEnumerable<TTrabajadorxCotizacion> TTrabajadorxCotizacions { get; set; }
        }
    }
}