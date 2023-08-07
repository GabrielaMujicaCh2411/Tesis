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

     public class Partidascontroller : Controller
    {
        ApplicationDbContext _context ;
        public Partidascontroller(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Listar()
        {
          
            List<TPartidum> Partidas = await _context.TPartida.Include(x=>x.IdTipoPartidaNavigation).ToListAsync();
            TPartidum partidas = new TPartidum();
            ViewBag.Partidas=Partidas;
            return View(partidas);
        
        }
        public async Task<IActionResult> Agregar()
        {
            ViewBag.ListarTipoPartida= await _context.TTipoPartida.OrderBy(x => x.IdTipoPartida).ToListAsync();

            return View();
        }
        [BindProperty]
        public TPartidum partida{get;set;}
        public async Task<IActionResult> Guardar()
        {
            if(!ModelState.IsValid)
            {
               return View(partida);
            }
            _context.TPartida.Add(partida);
           await _context.SaveChangesAsync();
            return RedirectToAction("Listar");
        }
        public async Task<IActionResult> Actualizar(string id)
        {
            var Partida = _context.TPartida.Find(id);
            
            if(Partida == null)
            {

                return Redirect("/Partida");
            }
            ViewBag.ListarTipoPartida= await _context.TTipoPartida.OrderBy(x => x.IdTipoPartida).ToListAsync();
            return View(Partida);
        }
         public async Task<IActionResult> GuardarActualizacion()      
        {
            if(!ModelState.IsValid)
            {
                 return View(partida);
            }
            var _Partida = _context.TPartida.Where(x=>x.IdPartida==partida.IdPartida).SingleOrDefault(); 
            if(_Partida ==null)
            {
              _context.TPartida.Add(partida);
            }
            else
            {
                _Partida.NombrePartida= partida.NombrePartida;
                _Partida.PrecioUnidad= partida.PrecioUnidad;
                _Partida.IdTipoPartida= partida.IdTipoPartida;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Listar");
        }
        
          public async Task<IActionResult> Detalle(string id)
        {
            var Partida = _context.TPartida.Find(id);
            ViewBag.TipoPartida= await _context.TTipoPartida.OrderBy(x => x.IdTipoPartida).ToListAsync();
            return View(Partida);
        }
    }
}