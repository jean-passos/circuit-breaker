using System.ComponentModel;

namespace eLoja.UI.Models
{
	public class UsuarioViewModel
	{
		public string Id { get; set; }
		public string Nome { get; set; }

		[DisplayName("E-mail")]
		public string Email { get; set; }

		public bool Cadastrado { get; set; }
	}
}
