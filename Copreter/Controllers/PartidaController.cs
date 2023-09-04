using Microsoft.AspNetCore.Mvc;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Model.DbModel;
using AutoMapper;
using Copreter.Domain.Service.Dto.Partida;
using Copreter.Models.Partida;

namespace Copreter.Controllers
{
    public class PartidaController : BaseController
    {
        #region Fields

        private readonly ILogger<PartidaController> _logger;

        private readonly IPartidaService _service;

        #endregion

        public PartidaController(IMapper mapper, ILogger<PartidaController> logger, IPartidaService service) : base(mapper)
        {
            this._logger = logger;
            this._service = service;
        }


        public async Task<IActionResult> Index()
        {
            var resultService = await this._service.ListarAsync();

            var result = new PartidaIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<PartidaDto>>(resultService)
            };
            return View(result);
        }

        public async Task<IActionResult> _Index()
        {
            var resultService = await this._service.ListarAsync();

            var result = new PartidaIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<PartidaDto>>(resultService)
            };
            return PartialView(result);
        }

        // GET: Partida/Create
        public async Task<IActionResult> Crear()
        {
            return View();
        }

        // POST: Partida/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind()] PartidaDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(dto);
                }

                var result = await this._service.AgregarAsync(this.Mapper.Map<TPartida>(dto));
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(dto);
            }
            catch
            {
                return View();
            }
        }

        // GET: Partida/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));

            var result = await this._service.ObtenerAsync(id.Value);
            return View(result);
        }

        // POST: Partida/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind()] PartidaDto dto)
        {
            try
            {
                if (id != dto.IdTipoPartida)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    var result = await this._service.ActualizarAsync(id, this.Mapper.Map<TPartida>(dto));
                    if (result)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                return View(dto);
            }
            catch
            {
                return View();
            }
        }

        // GET: Partida/Delete/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));

            var result = await this._service.ObtenerAsync(id.Value);
            return View(result);
        }
    }
}