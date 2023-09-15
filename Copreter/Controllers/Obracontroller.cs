using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Dto;
using Microsoft.AspNetCore.Mvc;
using Copreter.Utils;
using Copreter.Models.Obra;
using Copreter.Domain.Service.Dto.Obra;
using System.Security.Claims;
using Copreter.Domain.Model.Model.Obra;
using Copreter.Domain.Model.Enums;
using Microsoft.AspNetCore.Authorization;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Copreter.Controllers
{
    [Authorize]
    public class Obracontroller : BaseController
    {
        #region Fields

        private readonly ILogger<Obracontroller> _logger;

        private readonly IObraService _service;

        private readonly IEstadoObraService _estadoObraService;

        #endregion

        public Obracontroller(IMapper mapper, ILogger<Obracontroller> logger, IHostingEnvironment hosting,
            IObraService service, IEstadoObraService estadoObraService) : base(mapper)
        {
            this._logger = logger;
            this._service = service;
            this._estadoObraService = estadoObraService;
            this._hosting = _hosting;
        }

        public async Task<IActionResult> Index(int? userId = 0, int? idEstado = 0)
        {
            if(this.RolId() == ERolEnum.Cliente)
            {
                userId = this.UserId();
            }

            var resultService = await this._service.ListarAsync(new ObraFilter() { IdUsuario = userId, IdEstado = idEstado });

            var estadoLista = this.Mapper.Map<IEnumerable<ItemDto>>(await this._estadoObraService.ListarAsync());

            var result = new ObraIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<ObraDto>>(resultService),
                Filtro = new ObraFilterDto(),
                EstadoLista = estadoLista.GetItems(),

            };
            return View(result);
        }

        public async Task<IActionResult> _Index(int? userId, int? idEstado = 0)
        {
            if (this.RolId() == ERolEnum.Cliente)
            {
                userId = this.UserId();
            }

            var resultService = await this._service.ListarAsync(new ObraFilter() { IdUsuario = userId, IdEstado = idEstado });

            var estadoLista = this.Mapper.Map<IEnumerable<ItemDto>>(await this._estadoObraService.ListarAsync());

            var result = new ObraIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<ObraDto>>(resultService),
                Filtro = new ObraFilterDto(),
                EstadoLista = estadoLista.GetItems(),
            };
            return PartialView(result);
        }

        public async Task<IActionResult> Crear()
        {
            var estadoLista = this.Mapper.Map<IEnumerable<ItemDto>>(await this._estadoObraService.ListarAsync());

            var result = new ObraEditableVM
            {
                FechaInicio = DateTime.Now,
                EstadoLista = estadoLista.GetItems()
            };
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind()] ObraDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var resultInvalid = this.Mapper.Map<ObraEditableVM>(dto);
                    return View(resultInvalid);
                }

                if (dto.Foto != null)
                {
                    string ficherosImagenes = Path.Combine(this._hosting.WebRootPath, "images");
                    var guidImage = Guid.NewGuid().ToString() + dto.Foto.FileName;
                    string rutaDefinitiva = Path.Combine(ficherosImagenes, guidImage);
                    dto.Foto.CopyTo(new FileStream(rutaDefinitiva, FileMode.Create));
                    dto.Imagen = guidImage;
                }

                dto.IdUsuario = this.UserId();
                dto.IdUsuarioRegistro = this.UserId();
                var result = await this._service.AgregarAsync(this.Mapper.Map<TObra>(dto));
                if (result)
                {
                    return RedirectToAction(nameof(Index), new { userId = dto.IdUsuario });
                }
                return View(dto);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return View();
            }
        }

        public async Task<IActionResult> Detalle(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));

            var resultService = await this._service.ObtenerAsync(id.Value);

            var estadoLista = this.Mapper.Map<IEnumerable<ItemDto>>(await this._estadoObraService.ListarAsync());

            var result = this.Mapper.Map<ObraEditableVM>(resultService);
            result.EstadoLista = estadoLista.GetItems();

            return View(result);
        }

        public async Task<IActionResult> ActualizarEstado(int? id, int idEstado)
        {
            if (id == null) return RedirectToAction(nameof(Index));

            var resultService = await this._service.ActualizarEstado(id.Value, (Domain.Model.Enums.EObraEstado)idEstado, this.UserId());


            return RedirectToAction(nameof(Index));
        }
    }
}