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
    public class PedidoController : Controller
    {
           ApplicationDbContext _context ;

         public PedidoController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListarC(string id)
        {
            List<TPedido> Pedido = await _context.TPedidos.Where(x=> x.IdUsuarioPedido == id).Include(x=>x.IdEstadoPedidoNavigation).Include(x=>x.IdTrabajadorPedidoNavigation).Include(x=>x.IdUnidadPedidoNavigation).Include(x=>x.IdUsuarioPedidoNavigation).ToListAsync();
            TPedido pedido = new TPedido();
            ViewBag.Pedido=Pedido;
            return View(pedido);
        }
        public async Task<IActionResult> ListarA()
        {
            List<TPedido> Pedido = await _context.TPedidos.Include(x=>x.IdEstadoPedidoNavigation).Include(x=>x.IdTrabajadorPedidoNavigation).Include(x=>x.IdUnidadPedidoNavigation).Include(x=>x.IdUsuarioPedidoNavigation).ToListAsync();
            TPedido pedido = new TPedido();
            ViewBag.Pedido=Pedido;
            return View(pedido);
        
        }

        public async Task<IActionResult> ListarOp()
        {
            List<TPedido> Pedido = await _context.TPedidos.Include(x=>x.IdEstadoPedidoNavigation).Include(x=>x.IdTrabajadorPedidoNavigation).Include(x=>x.IdUnidadPedidoNavigation).Include(x=>x.IdUsuarioPedidoNavigation).ToListAsync();
            TPedido pedido = new TPedido();
            ViewBag.Pedido=Pedido;
            return View(pedido);
        
        }

         public async Task<IActionResult> Registrar(string id)
        {
            List<TPedido> Pedidos = await _context.TPedidos.Include(x=>x.IdEstadoPedidoNavigation).Include(x=>x.IdTrabajadorPedidoNavigation).Include(x=>x.IdUsuarioPedidoNavigation).ToListAsync();
            TPedido pedido = new TPedido();
            TUnidad unidad = _context.TUnidads.Find(id);

            var obj =   (from prod in Pedidos select prod)
                        .Count();
            int cantRegistro= obj+1;

            pedido.IdPedido = "Pedi-00"+cantRegistro;
            pedido.IdEstadoPedido = 1;
            pedido.IdUnidadPedido=id;
            pedido.PrecioPedido= unidad.Precio;
            ViewBag.ListaUsuario = await _context.TUsuarios.OrderBy(x => x.IdUsuario).ToListAsync();
            ViewBag.ListaEstado = await _context.TEstadoPedidos.OrderBy(x => x.IdEstadoPedido).ToListAsync();
            ViewBag.ListaTrabajador = await _context.TTrabajadors.OrderBy(x => x.Dni).ToListAsync();
            
              return View(pedido);

        }
         [BindProperty]
        public TPedido pedido{get;set;}
        public async Task<IActionResult> Guardar()
        {
             if(!ModelState.IsValid)
            {
               return View(pedido);
            }
            _context.TPedidos.Add(pedido);
             await  _context.SaveChangesAsync();
           return Redirect("/Home/VistaAdministrador");
        }
         public async Task<IActionResult> AsignarOp(string id)
        {
            var Pedido = _context.TPedidos.Find(id);
            
            if(Pedido == null)
            {

                return Redirect("/Pedido");
            }
            Pedido.IdEstadoPedido=3;
            ViewBag.ListarEstadoPedido= await _context.TEstadoPedidos.OrderBy(x => x.IdEstadoPedido).ToListAsync();
             ViewBag.ListarTrabajadorPedido= await _context.TTrabajadors.Where(x=> x.IdTipoTrabajador == 3).OrderBy(x => x.Dni).ToListAsync();
            return View(Pedido);
        }
         public async Task<IActionResult> GuardarOp()      
        {
            if(!ModelState.IsValid)
            {
                 return View(pedido);
            }
            var _Pedido = _context.TPedidos.Where(x=>x.IdPedido==pedido.IdPedido).SingleOrDefault(); 
            if(_Pedido ==null)
            {
              _context.TPedidos.Add(pedido);
            }
            else
            {
                _Pedido.FechaEntrega      = pedido.FechaEntrega;
                _Pedido.IdTrabajadorPedido= pedido.IdTrabajadorPedido;
                _Pedido.IdEstadoPedido= pedido.IdEstadoPedido;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("ListarOp");
        }

        public async Task<IActionResult> PedAcep(string id)
        {
            var _Pedido = _context.TPedidos.Where(x => x.IdPedido ==id).SingleOrDefault();
            _Pedido.IdEstadoPedido = 2;
            await _context.SaveChangesAsync();
            return RedirectToAction("ListarA");
        }
          public async Task<IActionResult> PedRec(string id)
        {
            var _Pedido = _context.TPedidos.Where(x => x.IdPedido ==id).SingleOrDefault();
            _Pedido.IdEstadoPedido = 6;
            await _context.SaveChangesAsync();
            return RedirectToAction("ListarA");
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}