using System.Net.Security;
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
using Rotativa.AspNetCore;
using System.Data.Common;
using System.IO;

namespace Copreter.Controllers
{
       public class Cotizarcontroller : Controller
    {

       ApplicationDbContext _context ;
        public Cotizarcontroller(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] Object partida)
        {
            var part = JsonConvert.DeserializeObject<ViewModelCotizacion>(partida.ToString());
            foreach(var tipo in part.TObraxPartida.ToList()){
                var obraxPart = new TObraxPartidum();
                obraxPart.IdPartida = tipo.IdPartida;
                obraxPart.IdObra = tipo.IdObra;
                obraxPart.Metrado = tipo.Metrado;
                obraxPart.Unidad = tipo.Unidad;
                obraxPart.Parcial = tipo.Parcial;
                _context.TObraxPartida.Add(obraxPart);
                await _context.SaveChangesAsync();
            }
            var coti = new TCotizacion();
            var cotizaciones = await _context.TCotizacions.ToListAsync();
            int cantRegistro= cotizaciones.Count() + 1;
            coti.IdCotizacion = "Cotizacion-00"+cantRegistro;
            coti.Fecha = DateTime.Now;
            coti.Total = Convert.ToDecimal(part.Total);
            coti.IdObraCotizacion = part.IdObra;
            coti.IdCotizacionEstado = 1;
            _context.TCotizacions.Add(coti);
            await _context.SaveChangesAsync(); 

            return Json(Url.Action("Listar", "Cotizar"));   
        }
        public async Task<IActionResult> Listar()
        {
            List<TCotizacion> Cotizacion = await _context.TCotizacions.Include(x=>x.IdObraCotizacionNavigation).Include(x=>x.IdCotizacionEstadoNavigation).ToListAsync();
            TCotizacion cotizacion = new TCotizacion();
            ViewBag.Cotizacion=Cotizacion;
            return View(cotizacion);
        }
        public async Task<IActionResult> ListarAdmin()
        {
            List<TCotizacion> Cotizacion = await _context.TCotizacions.Include(x=>x.IdObraCotizacionNavigation).Include(x=>x.IdCotizacionEstadoNavigation).ToListAsync();
            TCotizacion cotizacion = new TCotizacion();
            ViewBag.Cotizacion=Cotizacion;
            return View(cotizacion);
        }
        public async Task<IActionResult> Detalle(string id)
        {
            var partidas = await _context.TPartida.ToListAsync();
            ViewBag.Obra = await _context.TObras.Where(x=> x.IdObra == id).FirstOrDefaultAsync();
            ViewBag.TipoPartida = await _context.TTipoPartida.ToListAsync();
            return View(partidas);
        }
        public async Task<IActionResult> Index(string id)
        {
            List<TCotizacion> Cotizacion = await _context.TCotizacions.Include(x=>x.IdObraCotizacionNavigation).Include(x=>x.IdCotizacionEstadoNavigation).ToListAsync();
            TCotizacion cotizacion = new TCotizacion();
            ViewBag.Cotizacion=Cotizacion;
            return View(cotizacion);
        }

        public   IActionResult ListarPdf(string id)
        {

            return new ViewAsPdf("ListarPdf");
        }
        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
        public class ViewModelCotizacion
        {
            public double Total { get; set; }
            public string IdObra { get; set; }
            public IEnumerable<TObraxPartidum> TObraxPartida { get; set; }
        }
        public async Task<IActionResult> DetalleCoti(string id)
        {
            var factura = await _context.TFacturas
                    .Include(s => s.IdCotizacionFacturaNavigation)    
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.IdCotizacionFacturaNavigation.IdObraCotizacion == id);
            return View(factura);
        }

    }
}