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
 public class Facturacontroller : Controller
    {
        ApplicationDbContext _context ;
          IHostingEnvironment  hosting;
         public Facturacontroller(ApplicationDbContext context, IHostingEnvironment  _hosting)
        {
            _context = context;
            hosting  = _hosting;
        }
        public async Task<IActionResult> Enviar(string id)
        {
             List<TFactura> Factura = await _context.TFacturas.ToListAsync();
            TFactura fact = new TFactura();
            var obj =   (from prod in Factura select prod)
                        .Count();
            int cantRegistro= obj+1;
            fact.IdFactura = "Factura-00"+cantRegistro;
            fact.IdCotizacionFactura =id;
            return View(fact);
        } 
        
        [BindProperty]
        public TFactura factura{get;set;}
        public async Task<IActionResult> Guardar()
        {
          string guidImage = null;
            if(factura.Foto !=null)
            {
                string ficherosImagenes =Path.Combine(hosting.WebRootPath,"images");
                guidImage = Guid.NewGuid().ToString() + factura.Foto.FileName;
                string rutaDefinitiva = Path.Combine(ficherosImagenes,guidImage);
                factura.Foto.CopyTo(new FileStream(rutaDefinitiva,FileMode.Create));
            }

              if(!ModelState.IsValid)
            {
               return View(factura);
            }
            
             factura.Imagen= guidImage;            
            _context.TFacturas.Add(factura);
             await  _context.SaveChangesAsync();
           return Redirect("/Home/VistaAdministrador");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}