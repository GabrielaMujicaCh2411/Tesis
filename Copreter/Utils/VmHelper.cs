using Copreter.Domain.Service.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Copreter.Utils
{
    public static class VmHelper
    {
        public static List<SelectListItem> GetItems(this IEnumerable<ItemDto> list)
        {
            if (list == null || !list.Any()) return new List<SelectListItem>();

            var result = new List<SelectListItem>() { new SelectListItem() { Value = string.Empty, Text = string.Empty } };
            result.AddRange(list.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList());
            return result;
        }
    }
}
