using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Program.Data;
using Program.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Copreter.Controllers
{
   
    public class Unidadcontroller : Controller
    {
        ApplicationDbContext _context ;
        [Obsolete]
        IHostingEnvironment  hosting;

        [Obsolete]
        public Unidadcontroller(ApplicationDbContext context, IHostingEnvironment  _hosting)
        {
            _context = context;
            hosting  = _hosting;
        }
        public async Task<IActionResult> Listar()
        {
          
            List<TUnidad> Unidad = await _context.TUnidads.Include(x=>x.IdEstadoUnidadNavigation).Include(x=>x.IdTipoUnidadNavigation).ToListAsync();
            TUnidad unidad = new TUnidad();
            ViewBag.Unidad=Unidad;
            return View(unidad);
        
        }
         public async Task<IActionResult> Registrar()
        {
            ViewBag.ListaEstadoUnidad = await _context.TEstadoUnidads.OrderBy(x => x.IdEstadoUnidad).ToListAsync();
            ViewBag.ListaTipoUnidad   = await _context.TTipoUnidads.OrderBy(x => x.IdTipoUnidad).ToListAsync();
            return View();
        }
        
        [BindProperty]
        public TUnidad unidad{get;set;}
        public async Task<IActionResult> Guardar()
        {
            string guidImage = null;
            if(unidad.Foto !=null)
            {
                string ficherosImagenes =Path.Combine(hosting.WebRootPath,"images");
                guidImage = Guid.NewGuid().ToString() + unidad.Foto.FileName;
                string rutaDefinitiva = Path.Combine(ficherosImagenes,guidImage);
                unidad.Foto.CopyTo(new FileStream(rutaDefinitiva,FileMode.Create));
            }
            if(!ModelState.IsValid)
            {

                return View(unidad);
            }
            unidad.Imagen= guidImage;            
            _context.TUnidads.Add(unidad);
            await  _context.SaveChangesAsync();
            return RedirectToAction("Listar");
        }

        public async Task<IActionResult> Actualizar(string id)
        {
            var Unidad = _context.TUnidads.Find(id);

            if(Unidad == null)
            {

            return Redirect("/Unidad");
            }

            ViewBag.ListaEstadoUnidad = await _context.TEstadoUnidads.OrderBy(x => x.IdEstadoUnidad).ToListAsync();
            ViewBag.ListaTipoUnidad   = await _context.TTipoUnidads.OrderBy(x => x.IdTipoUnidad).ToListAsync();
            return View(Unidad);
        }

        public async Task<IActionResult> GuardarActualizacion()
        {
            if(!ModelState.IsValid)
            {
            
            return View(unidad);
            
            }
            var _Unidad = _context.TUnidads.Where(x=>x.Serie==unidad.Serie).SingleOrDefault(); 
            if(_Unidad ==null)
            {
            
            _context.TUnidads.Add(unidad);
            
            }
            else
            {
            
            _Unidad.Nombre= unidad.Nombre;
            _Unidad.Modelo= unidad.Modelo;
            _Unidad.Marca= unidad.Marca;
            _Unidad.Precio= unidad.Precio;
            _Unidad.Cantidad= unidad.Cantidad;
            _Unidad.Precio= unidad.Precio;
            _Unidad.Descripcion= unidad.Descripcion;
            _Unidad.Caracteristica1= unidad.Caracteristica1;
            _Unidad.Caracteristica2= unidad.Caracteristica2;
            _Unidad.Caracteristica3= unidad.Caracteristica3;
            _Unidad.Imagen= unidad.Imagen;
            _Unidad.IdTipoUnidad= unidad.IdTipoUnidad;
            _Unidad.IdEstadoUnidad= unidad.IdEstadoUnidad;
            
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Listar");
        }

        public async Task<IActionResult> Detalle(string id)
        {
            var Unidad = _context.TUnidads.Find(id);
            ViewBag.TipoUnidad= await _context.TTipoUnidads.OrderBy(x => x.IdTipoUnidad).ToListAsync();
            ViewBag.EstadoUnidad= await _context.TEstadoUnidads.OrderBy(x => x.IdEstadoUnidad).ToListAsync();
            return View(Unidad);
        }
        public async Task<IActionResult> DetalleC(string id)
        {
            var Unidad = _context.TUnidads.Find(id);
            ViewBag.TipoUnidad= await _context.TTipoUnidads.OrderBy(x => x.IdTipoUnidad).ToListAsync();
            ViewBag.EstadoUnidad= await _context.TEstadoUnidads.OrderBy(x => x.IdEstadoUnidad).ToListAsync();
            return View(Unidad);
        }
        public async Task<IActionResult> Catalogo()
        {
          
            List<TUnidad> Unidad = await _context.TUnidads.Where(x=> x.IdEstadoUnidad == 1).Include(x=>x.IdEstadoUnidadNavigation).Include(x=>x.IdTipoUnidadNavigation).ToListAsync();
            TUnidad unidad = new TUnidad();
            ViewBag.Unidad=Unidad;
            return View(unidad);
        
        }
        public async Task<IActionResult> CatalogoH()
        {
          
            List<TUnidad> Unidad = await _context.TUnidads.Where(x=>x.IdTipoUnidad == 2 && x.IdEstadoUnidad == 1).Include(x=>x.IdEstadoUnidadNavigation).Include(x=>x.IdTipoUnidadNavigation).ToListAsync();
            TUnidad unidad = new TUnidad();
            ViewBag.Unidad=Unidad;
            return View(unidad);
        
        }
        public async Task<IActionResult> CatalogoM()
        {
          
            List<TUnidad> Unidad = await _context.TUnidads.Where(x=>x.IdTipoUnidad == 1  && x.IdEstadoUnidad == 1).Include(x=>x.IdEstadoUnidadNavigation).Include(x=>x.IdTipoUnidadNavigation).ToListAsync();
            TUnidad unidad = new TUnidad();
            ViewBag.Unidad=Unidad;
            return View(unidad);
        
        }


    }
}