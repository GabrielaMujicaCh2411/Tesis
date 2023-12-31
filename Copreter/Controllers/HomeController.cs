﻿using Copreter.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static Copreter.Utils.Keys;
using Copreter.Models.Home;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Model.Enums;

namespace Copreter.Controllers
{
    public class HomeController : Controller
    {
        #region Fields

        private readonly ILogger<HomeController> _logger;

        private readonly IUnidadService _unidadService;

        private readonly IObraService _obraService;

        private readonly ITrabajadorService _trabajadorService;

        private readonly ICotizacionService _cotizacionService;

        private readonly IAccesoService _accesoService;

        private readonly IPedidoService _pedidoService;

        private readonly IPagoService _pagoService;


        #endregion

        public HomeController(ILogger<HomeController> logger, IUnidadService unidadService, 
            IObraService obraService, ITrabajadorService trabajadorService, 
            ICotizacionService cotizacionService, IAccesoService accesoService,
            IPedidoService pedidoService, IPagoService pagoService)
        {
            this._logger = logger;
            this._unidadService = unidadService;
            this._obraService = obraService;
            this._trabajadorService = trabajadorService;
            this._cotizacionService = cotizacionService;
            this._accesoService = accesoService;
            this._pedidoService = pedidoService;
            this._pagoService = pagoService;
        }

        public IActionResult Index()
        {
            return View();
        }

		public IActionResult Nosotros()
		{
			return View();
		}

		public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> IndexAdmin()
		{
            var result = new HomeIndexVM
            {
                HerramientasEnMantenimiento = await this._unidadService.CountAsync(3),
                HerramientasDisponibles = await this._unidadService.CountAsync((int)EUnidadEstado.Disponible),
                TrabajadoresDisponibles = await this._trabajadorService.CountAsync(),
                ObrasEnContruccion = await this._obraService.CountAsync(9),
                ObrasTerminadas = await this._obraService.CountAsync(10),
                NuevasCoticaciones = await this._cotizacionService.CountAsync(1),
                UsuariosTotales = await this._accesoService.CountAsync(2),
                HerramientasPorDevolver = await this._pedidoService.CountAsync((int)EPedidoEstado.PendienteDevolucion),
                HerramientasAlquiladas = await this._pedidoService.CountAsync((int)EPedidoEstado.Aceptado),
                DineroEnMes = await this._pagoService.DineroEnMesAsync()
            };
            return View(result);
        }

		public async Task<IActionResult> LogOut()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction(ActionKeys.Login, ControllerKeys.Auth);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
