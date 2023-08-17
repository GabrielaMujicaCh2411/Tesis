using Copreter.Domain.Model.DbModel;
using Microsoft.AspNetCore.Mvc;

namespace Copreter.Controllers
{
    public class AuthController : Controller
    {
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
                //var _Usuario = _context.TUsuarios.Find(tusuario.IdUsuario);

                //if (_Usuario.Contraseña != tusuario.Contraseña)
                //{
                //    ModelState.AddModelError("", "Contraseña invalida");
                //    return Redirect("/Usuario/Login");
                //}
                //if (_Usuario == null)
                //{
                //    ModelState.AddModelError("", "Usuario no registrado");
                //    return Redirect("/Usuario/Login");
                //}
                //if (_Usuario.IdUsuario == tusuario.IdUsuario && _Usuario.Contraseña == tusuario.Contraseña)
                //{
                //    var _Cliente = _context.TClientes.Where(x => x.Correo == tusuario.IdUsuario).FirstOrDefault();
                //    HttpContext.Session.SetString("RolId", _Usuario.IdRolUsuario.ToString());
                //    HttpContext.Session.SetString("usuarioID", tusuario.IdUsuario);
                //    HttpContext.Session.SetString("Nombre", _Cliente.Nombre);
                //    HttpContext.Session.SetString("Apellido", _Cliente.Apellido);
                //    HttpContext.Session.SetString("Dni", _Cliente.Dni.ToString());
                //    return RedirectToAction("VistaAdministrador", "Home");
                //}

            }
            return View(tusuario);
        }
    }
}
