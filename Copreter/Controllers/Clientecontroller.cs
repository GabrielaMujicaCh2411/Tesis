using System.Security.Cryptography.X509Certificates;
using System.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Program.Data;
using Program.Models;

namespace Copreter.Controllers
{
    public class Clientecontroller : Controller
    {
         ApplicationDbContext _context ;
         
        public Clientecontroller(ApplicationDbContext context)
        {
            _context = context;
           
        }

       
        public IActionResult Registrar()
        {
            
            return View();
        }


        [BindProperty]
        public TCliente cliente{get;set;}
        public IActionResult Guardar()
        {
            if(!ModelState.IsValid)
            {
               return View(cliente);         
            }
            _context.TClientes.Add(cliente);
            _context.SaveChanges();
            return Redirect("/Usuario/Login");
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

       
        [HttpPost]  
        public ActionResult GuardarActualizacion()
    {
            if(!ModelState.IsValid)
            {
                return View(cliente);
            }

            var _Cliente = _context.TClientes.Where(x=>x.Dni==cliente.Dni).SingleOrDefault(); 
            if(_Cliente ==null)
            {
              _context.TClientes.Add(cliente);
            }
            else
            {
                _Cliente.Dni=cliente.Dni;
                _Cliente.Nombre= cliente.Nombre;
                _Cliente.Apellido= cliente.Apellido;
                _Cliente.Celular= cliente.Celular;
                 _Cliente.Correo=cliente.Correo;
                _Cliente.Direccion= cliente.Direccion;
            }
            _context.SaveChanges();
            return Redirect("/Home/VistaAdministrador");
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}