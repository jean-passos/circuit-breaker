using eLoja.CircuitBreaker;
using eLoja.UI.CircuitBreakers;
using eLoja.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace eLoja.UI.Controllers
{
	public class UsuarioController : Controller
	{

		private readonly UsuarioCircuitBreaker _servicoUsuario;

		public UsuarioController(UsuarioCircuitBreaker servicoUsuario)
		{
			_servicoUsuario = servicoUsuario;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult CadastraUsuario(UsuarioViewModel usuario)
		{
			try
			{
				usuario.Id = _servicoUsuario.CadastraUsuario(usuario);
				usuario.Cadastrado = true;
			}
			catch (CircuitBreakerOpenException) { }
			catch (Exception) { throw; }
			return View("Index", usuario);
		}
	}
}