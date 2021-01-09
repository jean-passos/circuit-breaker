using eLoja.Api.Usuario.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace eLoja.Api.Usuario.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

		[HttpPost]
		public IActionResult CadastraUsuario(UsuarioModel usuario)
		{
			return Ok(Guid.NewGuid());
		}
    }
}