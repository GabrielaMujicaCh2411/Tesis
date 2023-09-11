using AutoMapper;
using Copreter.Domain.Model.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        public int UserId()
        {
            if (User != null && User.Identity != null && User.Identity.IsAuthenticated)
            {
                return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            return 1;
        }

        public ERolEnum RolId()
        {
            if (User != null && User.Identity != null && User.Identity.IsAuthenticated)
            {
                var rolId = int.Parse(User.FindFirstValue(ClaimTypes.Role));
                return (ERolEnum)rolId;
            }
            return  ERolEnum.SinAsignar;
        }
    }
}
