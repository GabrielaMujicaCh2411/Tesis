using System.Net.Http;
using System.Net;
using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Program.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Program.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace Copreter.Controllers
{
 
     public class Usuariocontroller : Controller
    {
       const string SessionUser = "_User";
        ApplicationDbContext _context;
        public Usuariocontroller(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(TUsuario tusuario)
        {
            if (ModelState.IsValid)
            {
                var _Usuario = _context.TUsuarios.Find(tusuario.IdUsuario);

                if (_Usuario.Contraseña != tusuario.Contraseña)
                {
                   ModelState.AddModelError("", "Contraseña invalida");
                   return Redirect("/Usuario/Login");
                }
                if (_Usuario == null)
                {
                   ModelState.AddModelError("", "Usuario no registrado");
                   return Redirect("/Usuario/Login");
                }
                if (_Usuario.IdUsuario == tusuario.IdUsuario && _Usuario.Contraseña == tusuario.Contraseña)
                {
                    var _Cliente = _context.TClientes.Where(x => x.Correo == tusuario.IdUsuario).FirstOrDefault();
                    HttpContext.Session.SetString("RolId", _Usuario.IdRolUsuario.ToString());
                    HttpContext.Session.SetString("usuarioID", tusuario.IdUsuario);
                    HttpContext.Session.SetString("Nombre", _Cliente.Nombre);
                    HttpContext.Session.SetString("Apellido", _Cliente.Apellido);
                    HttpContext.Session.SetString("Dni", _Cliente.Dni.ToString());
                    return RedirectToAction("VistaAdministrador", "Home");
                }

            }
            return View(tusuario);
        }

        public async Task<IActionResult> ListarUsuarios()
        {

            List<TUsuario> Usuario = await _context.TUsuarios.Include(x=>x.IdRolUsuarioNavigation).Include(x=>x.DniUsuarioNavigation).ToListAsync();
            TUsuario usuario = new TUsuario();
            ViewBag.usuario=Usuario;
            return View(usuario);

        }
          public async Task<IActionResult> Asignar(string id)
        {
            // var Usuario = _context.TUsuarios.Find(id);
            var Usuario =  _context.TUsuarios.Where(x=>x.IdUsuario==id).Include(x=>x.IdRolUsuarioNavigation).Include(x=>x.DniUsuarioNavigation).SingleOrDefault();
            ViewBag.ListarRol = await _context.TRols.OrderBy(x=>x.IdRol).ToListAsync();
            if(Usuario == null)
            {
                return Redirect("/Usuario");
            }
            
           return View (Usuario);
        }
        [BindProperty]
        public TUsuario usuario{get;set;}
        

         public async Task< IActionResult> GuardarAsignar()
        {
            if(!ModelState.IsValid)
            {
                return Redirect("/Usuario/");
            }
            var _Usuario = _context.TUsuarios.Where(x=>x.IdUsuario==usuario.IdUsuario).SingleOrDefault(); 
            if(_Usuario ==null)
            {
              _context.TUsuarios.Add(usuario);
            }
            else
            {
                _Usuario.Contraseña= usuario.Contraseña;
                _Usuario.DniUsuario= usuario.DniUsuario;
                _Usuario.IdRolUsuario= usuario.IdRolUsuario;
              
            }
           await _context.SaveChangesAsync();
            return RedirectToAction("ListarUsuarios");
        }
        public IActionResult Agregar()
        {
            
            return View();
        }
        
     
       public TCliente cliente{get;set;}
        public IActionResult Guardar()
        {
            if(!ModelState.IsValid)
            {
               return View(cliente);         
            }
            _context.TClientes.Add(cliente);
            _context.SaveChanges();
            return Redirect("/Usuario/ListarUsuarios");
        }
            
        
         public IActionResult Detalle(int id)
        {
            var Cliente = _context.TClientes.Find(id);
            return View(Cliente);
        }
        public IActionResult Actualizar(int id)
        {
         var Cliente = _context.TClientes.Find(id);
            //var Cliente = _context.TClientes.Where(x=>x.Dni==id).SingleOrDefault();
            if(Cliente == null)
            {
                return Redirect("/Cliente");
            }
            
            return View(Cliente);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
       
    }
}