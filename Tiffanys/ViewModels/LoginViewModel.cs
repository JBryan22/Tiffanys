using System.ComponentModel.DataAnnotations;
using Tiffanys.Models;

namespace Tiffanys.ViewModels
{
	public class LoginViewModel
	{
		public string Email { get; set; }
		public string Password { get; set; }

		public bool hasLoggedIn { get; set; }


	}
}