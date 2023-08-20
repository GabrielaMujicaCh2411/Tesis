using System.ComponentModel.DataAnnotations;

namespace Copreter.Domain.Service.Dto.Auth
{
	public class LoginDto
	{
		[Required(ErrorMessage = "Please Enter Username")]
		[Display(Name = "Please Enter Username")]
		public string? Email { get; set; }

		[Required(ErrorMessage = "Please Enter Password")]
		[Display(Name = "Please Enter Password")]
		[DataType(DataType.Password)]
		public string? Password { get; set; }

		public bool RememberMe { get; set; }
	}
}
