using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Dto;
using Microsoft.AspNetCore.Mvc;
using Copreter.Utils;
using Copreter.Models.Obra;
using Copreter.Domain.Service.Dto.Obra;

namespace Copreter.Controllers
{
    public class Obracontroller : BaseController
    {
        #region Fields

        private readonly IObraService _service;

        private readonly IEstadoObraService _estadoObraService;

        #endregion

        public Obracontroller(IMapper mapper, IObraService service, IEstadoObraService estadoObraService) : base(mapper)
        {
            this._service = service;
            this._estadoObraService = estadoObraService;
        }

        public async Task<IActionResult> Index()
        {
            var resultService = await this._service.ListarAsync();

            var result = new ObraIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<ObraDto>>(resultService)
            };
            return View(result);
        }

        public async Task<IActionResult> _Index()
        {
            var resultService = await this._service.ListarAsync();

            var result = new ObraIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<ObraDto>>(resultService)
            };
            return PartialView(result);
        }

        public async Task<IActionResult> Crear()
        {
            var estadoLista = this.Mapper.Map<IEnumerable<ItemDto>>(await this._estadoObraService.ListarAsync());

            var result = new ObraEditableVM
            {
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
                    return View(dto);
                }

                var result = await this._service.AgregarAsync(this.Mapper.Map<TObra>(dto));
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
    }
}