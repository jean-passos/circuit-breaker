using eLoja.CircuitBreaker;
using eLoja.UI.Models;
using eLoja.UI.ServiceCaller;

namespace eLoja.UI.CircuitBreakers
{
	public class UsuarioCircuitBreaker : CircuitBreakerBase
	{

		public string CadastraUsuario(UsuarioViewModel usuario)
		{
			string codigoUsuario = string.Empty;
			SenderAgent<UsuarioViewModel> senderAgent = new SenderAgent<UsuarioViewModel>("http://localhost:5002/api/");

			ExecuteAction(() => codigoUsuario = senderAgent.SendPost(usuario, "usuario"));

			return codigoUsuario;
		}
	}
}
