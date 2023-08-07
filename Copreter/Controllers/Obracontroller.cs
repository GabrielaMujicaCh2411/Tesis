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
   public class Obracontroller : Controller
    {
        ApplicationDbContext _context ;
        [Obsolete]
        IHostingEnvironment  hosting;

        [Obsolete]
        public Obracontroller(ApplicationDbContext context, IHostingEnvironment  _hosting)
        {
            _context = context;
            hosting  = _hosting;
        }
        public async Task<IActionResult> Index(string id)
        {
            List<TObra> Obra = await _context.TObras.Where(x=>x.IdUsuarioObra == id).Include(x=>x.IdObraEstadoNavigation).ToListAsync();
            TObra obra = new TObra();
            ViewBag.Obra=Obra;
            return View(obra);
        }
        
        public async Task<IActionResult> Listar()
        {
            var model = new ModelObra();
            model.obras = await _context.TObras.OrderBy(x=>x.IdObra).ToListAsync();
            model.clientes = await _context.TClientes.ToListAsync();
            model.estadosObra = await _context.TEstadoObras.ToListAsync();
            return View(model);
        }
        public async Task<IActionResult> Solicitar()
        {
            List<TObra> Obras = await _context.TObras.Include(x=>x.IdObraEstadoNavigation).ToListAsync();
            TObra obra = new TObra();
            var obj =   (from prod in Obras select prod)
                        .Count();
            int cantRegistro= obj+1;

            obra.IdObra = "Obra-00"+cantRegistro;
            obra.IdObraEstado = 1;
            ViewBag.ListaUsuario = await _context.TUsuarios.OrderBy(x => x.IdUsuario).ToListAsync();
            ViewBag.ListaObra = await _context.TEstadoObras.OrderBy(x => x.IdEstadoObra).ToListAsync();
            
              return View(obra);

        }
        [BindProperty]
        public TObra obra{get;set;}
        public async Task<IActionResult> Guardar()
        {
            string guidImage = null;
            if(obra.Foto !=null)
            {
                string ficherosImagenes =Path.Combine(hosting.WebRootPath,"images");
                guidImage = Guid.NewGuid().ToString() + obra.Foto.FileName;
                string rutaDefinitiva = Path.Combine(ficherosImagenes,guidImage);
                obra.Foto.CopyTo(new FileStream(rutaDefinitiva,FileMode.Create));
            } else {
                guidImage = "ArchivoVacio.txt";
            }

              if(!ModelState.IsValid)
            {
               return View(obra);
            }
            
             obra.Imagen= guidImage;            
            _context.TObras.Add(obra);
             await  _context.SaveChangesAsync();
           return Redirect("/Home/VistaAdministrador");
        }

        public async Task<IActionResult> ListarP()
        {
            var model = new ModelObra();
            model.obras = await _context.TObras.Where(o => o.IdObraEstado==1 || o.IdObraEstado==3).OrderBy(x=>x.IdObra).ToListAsync();
            model.clientes = await _context.TClientes.ToListAsync();
            model.estadosObra = await _context.TEstadoObras.ToListAsync();
            return View(model);
        }
        public async Task<IActionResult> ListarA()
        {
            var model = new ModelObra();
            model.obras = await _context.TObras.Where(o => o.IdObraEstado==2).OrderBy(x=>x.IdObra).ToListAsync();
            model.clientes = await _context.TClientes.ToListAsync();
            model.estadosObra = await _context.TEstadoObras.ToListAsync();
            return View(model);
        }
        public async Task<IActionResult> Detalle(string id)
        {
            var Obra = _context.TObras.Find(id);
            ViewBag.EstadoObra = await _context.TEstadoObras.ToListAsync();
            return View(Obra);
        }
        public async Task<IActionResult> DetalleAdmin(string id)
        {
            var Obra = _context.TObras.Find(id);
            ViewBag.EstadoObra = await _context.TEstadoObras.ToListAsync();
            return View(Obra);
        }
        public async Task<IActionResult> ObraObservada(string id)
        {
            var _Obra = _context.TObras.Where(x => x.IdObra ==id).SingleOrDefault();
            _Obra.IdObraEstado = 3;
            await _context.SaveChangesAsync();
            return RedirectToAction("ListarP");
        }

        public async Task<IActionResult> ObraRechazada(string id)
        {
            var _Obra = _context.TObras.Where(x => x.IdObra ==id).SingleOrDefault();
            _Obra.IdObraEstado = 6;
            await _context.SaveChangesAsync();
            return Redirect("/Home/VistaAdministrador");
        }
        public async Task<IActionResult> ObraAceptada(string id)
        {
            var _Obra = _context.TObras.Where(x => x.IdObra ==id).SingleOrDefault();
            _Obra.IdObraEstado = 2;
            await _context.SaveChangesAsync();
            return Redirect("/Home/VistaAdministrador");
        }
        public async Task<IActionResult> ObraTerminada(string id)
        {
            var _Obra = _context.TObras.Where(x => x.IdObra ==id).SingleOrDefault();
            _Obra.IdObraEstado = 10;
            await _context.SaveChangesAsync();
            return RedirectToAction("Listar");
        }


        public class ModelObra
        {
            public IEnumerable<TObra> obras { get; set; }
            public IEnumerable<TCliente> clientes { get; set; }
            public IEnumerable<TEstadoObra> estadosObra { get; set; }
        }
    }
}