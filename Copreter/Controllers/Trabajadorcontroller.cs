using System.Xml;
using System.Xml.Schema;
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
  
   public class Trabajadorcontroller : Controller
    {
        ApplicationDbContext _context ;
       
        public Trabajadorcontroller(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ListaTrabajador()
        {
            List<TTrabajador> Trabajador = await _context.TTrabajadors.Include(x=>x.IdTipoTrabajadorNavigation).Include(x=>x.IdEstadoTrabajadorNavigation).ToListAsync();
            TTrabajador trabajador = new TTrabajador();
            ViewBag.Trabajador=Trabajador;
            return View(trabajador);
        }

        public async Task<IActionResult> Registrar()
        {
            ViewBag.ListaTipoTrabajador= await _context.TTipoTrabajadors.OrderBy(x => x.IdTipoTrabajador).ToListAsync();
            ViewBag.ListaEstadoTrabajador= await _context.TEstadoTrabajadors.OrderBy(x => x.IdEstadoTrabajador).ToListAsync();
            return View();
        }
        
        [BindProperty]
        public TTrabajador trabajador{get;set;}
        public async Task<IActionResult> Guardar()
        {
            if(!ModelState.IsValid)
            {
              return View(trabajador);        
            }
            _context.TTrabajadors.Add(trabajador);
           await _context.SaveChangesAsync();
            return RedirectToAction("ListaTrabajador");
        }
        
        public async Task<IActionResult> Actualizar(int id)
        {
            var Trabajador = _context.TTrabajadors.Find(id);
            
            if(Trabajador == null)
            {

                return Redirect("/Trabajador");
            }
            ViewBag.ListaTipoTrabajador= await _context.TTipoTrabajadors.OrderBy(x => x.IdTipoTrabajador).ToListAsync();
            ViewBag.ListaEstadoTrabajador= await _context.TEstadoTrabajadors.OrderBy(x => x.IdEstadoTrabajador).ToListAsync();
            return View(Trabajador);
        }
        
        public async Task<IActionResult> GuardarActualizacion()      
        {
            if(!ModelState.IsValid)
            {
                  return View(trabajador);        
            }
            var _Trabajador = _context.TTrabajadors.Where(x=>x.Dni==trabajador.Dni).SingleOrDefault(); 
            if(_Trabajador ==null)
            {
              _context.TTrabajadors.Add(trabajador);
            }
            else
            {
                _Trabajador.Nombre= trabajador.Nombre;
                _Trabajador.Apellido= trabajador.Apellido;
                _Trabajador.Celular= trabajador.Celular;
                _Trabajador.IdTipoTrabajador= trabajador.IdTipoTrabajador;
                _Trabajador.IdEstadoTrabajador= trabajador.IdEstadoTrabajador;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("ListaTrabajador");
        }

         public async Task<IActionResult> Detalle(int id)
        {
            var Trabajador = _context.TTrabajadors.Find(id);
              ViewBag.ListaTipoTrabajador= await _context.TTipoTrabajadors.OrderBy(x => x.IdTipoTrabajador).ToListAsync();
            ViewBag.ListaEstadoTrabajador= await _context.TEstadoTrabajadors.OrderBy(x => x.IdEstadoTrabajador).ToListAsync();
            return View(Trabajador);
        }
       
    }
}