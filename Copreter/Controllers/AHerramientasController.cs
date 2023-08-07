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
   
   public class AHerramientasController : Controller
    {
      ApplicationDbContext _context ;

        public AHerramientasController(ApplicationDbContext context)
        {
             _context = context;
        }

       [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] Object unidad)
        {
            var part = JsonConvert.DeserializeObject<ViewModelCotizacion>(unidad.ToString());
            foreach(var tipo in part.TCotizacionxUnidads.ToList()){
                var unixCot = new TCotizacionxUnidad();
                unixCot.IdSerie = tipo.IdSerie;
                unixCot.IdCotizacion = tipo.IdCotizacion;
                 unixCot.Cantidad = tipo.Cantidad;
                _context.TCotizacionxUnidads.Add(unixCot);
                await _context.SaveChangesAsync();
            }
           return Json(Url.Action("ListarAdmin", "Cotizar"));   
        }

        public async Task<IActionResult> Detalle(string id)
        {
            var unidades = await _context.TUnidads.ToListAsync();
            ViewBag.Cotizacion = await _context.TCotizacions.Where(x=> x.IdCotizacion == id).FirstOrDefaultAsync();
            ViewBag.TipoUnidad = await _context.TTipoUnidads.ToListAsync();
            return View(unidades);
        }
        
        public class ViewModelCotizacion
        {
            
            public string IdCotizacion { get; set; }
            public IEnumerable<TCotizacionxUnidad> TCotizacionxUnidads { get; set; }
        }
    }
}