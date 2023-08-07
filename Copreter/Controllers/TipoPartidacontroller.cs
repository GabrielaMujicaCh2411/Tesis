using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Program.Data;
using Program.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Copreter.Controllers
{
    public class TipoPartidacontroller : Controller
    {
        ApplicationDbContext _context ;
        public TipoPartidacontroller(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Listar()
        {
          
            List<TTipoPartidum> TipoPartida = await _context.TTipoPartida.ToListAsync();
            TTipoPartidum tipopartida = new TTipoPartidum();
            ViewBag.TipoPartida=TipoPartida;
            return View(tipopartida);
        
        }
      public IActionResult Agregar()
        {
             
            return View();
        }
        [BindProperty]
        public TTipoPartidum tipopartida{get;set;}
        public async Task<IActionResult> Registrar()
        {
            if(!ModelState.IsValid)
            {
                return View(tipopartida);
            }
            _context.TTipoPartida.Add(tipopartida);
           await _context.SaveChangesAsync();
            return RedirectToAction("Listar");
        }
         public  IActionResult Actualizar(int id)
        {
            var TipoPartida = _context.TTipoPartida.Find(id);
            
            if(TipoPartida == null)
            {

                return Redirect("/TipoPartida");
            }
            
            return View(TipoPartida);
        }
         public async Task<IActionResult> GuardarActualizacion()      
        {
            if(!ModelState.IsValid)
            {
                 return View(tipopartida);
            }
            var _TipoPartida = _context.TTipoPartida.Where(x=>x.IdTipoPartida==tipopartida.IdTipoPartida).SingleOrDefault(); 
            if(_TipoPartida ==null)
            {
              _context.TTipoPartida.Add(tipopartida);
            }
            else
            {
                _TipoPartida.NombreTipoPartida= tipopartida.NombreTipoPartida;
                _TipoPartida.DescripcionTipoPartida= tipopartida.DescripcionTipoPartida;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Listar");
        }
        public IActionResult Eliminar()
        {
            return View();
        }

       public IActionResult Detalle(int id)
        {
            var TipoPartida = _context.TTipoPartida.Find(id);
            return View(TipoPartida);
        }
    }
}