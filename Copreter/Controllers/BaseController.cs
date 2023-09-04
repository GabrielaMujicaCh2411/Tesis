using AutoMapper;
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
    }
}
