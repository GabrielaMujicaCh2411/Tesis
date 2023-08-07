using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Program.Data;
using Program.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Copreter.Controllers
{
    public class TipoUnidadcontroller : Controller
    {
        ApplicationDbContext _context ;
        public TipoUnidadcontroller(ApplicationDbContext context )
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.ListaTipoUnidad = _context.TTipoUnidads.ToList();
            return View();
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() 
        {
            return View();
        }

    }
}