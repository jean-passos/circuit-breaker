using eLoja.Api.Pedido.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace eLoja.Api.Pedido.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
		[HttpPost]
		public IActionResult GeraPedidoProduto(ProdutoModel produto)
		{
			return Ok(Guid.NewGuid());
		}
    }
}