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
   public class PagoController : Controller
    {
         ApplicationDbContext _context ;

        public PagoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public  async Task<IActionResult> Pagar(string id)
        {
            List<TPago> Pago = await _context.TPagos.Include(x=>x.IdCotizacionPagoNavigation).ToListAsync();
             var cotizacion = await _context.TCotizacions                  
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.IdCotizacion == id);
            TPago pago = new TPago();
            var obj =   (from prod in Pago select prod)
                        .Count();
            int cantRegistro= obj+1;
            pago.IdPago="Pago-00"+cantRegistro+"-"+id;
            pago.IdCotizacionPago=id;
            pago.Fecha= DateTime.Now;
            pago.Pago1= Convert.ToDecimal(cotizacion.Total)/2;
             pago.Pago2=0;
            return View(pago);
        }
        [BindProperty]
        public TPago pago{get;set;}
        public async Task<IActionResult> Guardar()
        {
             if(!ModelState.IsValid)
            {
               return View(pago);
            }
            _context.TPagos.Add(pago);
             await  _context.SaveChangesAsync();
           return Redirect("/Home/VistaAdministrador");
        }

         public async Task<IActionResult> Pagar2(string id)
        {
            var pagar = await _context.TPagos
                    .Include(s => s.IdCotizacionPagoNavigation)    
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.IdCotizacionPago == id);
              pagar.Fecha= DateTime.Now;     
            return View(pagar);
        }
       public async Task<IActionResult> GuardarA()
        {
             if(!ModelState.IsValid)
            {
                return View(pago);
            }
              var _Pago = _context.TPagos.Where(x=>x.IdPago==pago.IdPago).SingleOrDefault(); 
            if(_Pago ==null)
            {
              _context.TPagos.Add(pago);
            }
            else
            {
                _Pago.IdPago= pago.IdPago;
                _Pago.Fecha= pago.Fecha;
                _Pago.Pago1= pago.Pago1;
                _Pago.Pago2= pago.Pago2;
                _Pago.IdCotizacionPago= pago.IdCotizacionPago;
                
            }
            await _context.SaveChangesAsync();
            return Redirect("/Home/VistaAdministrador");
 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}