using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Copreter.Controllers
{
    public class BaseController : Controller
    {
        #region Fields

        public readonly IMapper Mapper;

        #endregion

        public BaseController(IMapper mapper)
        {
            this.Mapper = mapper;
        }
    }
}
