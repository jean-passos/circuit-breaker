using eLoja.CircuitBreaker;
using eLoja.UI.CircuitBreakers;
using eLoja.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace eLoja.UI.Controllers
{
	public class HomeController : Controller
	{

		private readonly ProdutoCircuitBreaker _servicoProduto;

		public HomeController(ProdutoCircuitBreaker servicoProduto)
		{
			_servicoProduto = servicoProduto;
		}

		public IActionResult Index()
		{
			string rootImage = "imgs";

			List<ProdutoViewModel> produtos = new List<ProdutoViewModel>
			{
				new ProdutoViewModel{ Id = Guid.NewGuid(), Nome = "Copo", Valor = 10.50m, Image = $@"{rootImage}\copo.jpg" },
				new ProdutoViewModel{ Id = Guid.NewGuid(), Nome = "Microondas", Valor = 200m, Image = $@"{rootImage}\microondas.jpg" },
				new ProdutoViewModel{ Id = Guid.NewGuid(), Nome = "Minimoto", Valor = 4000m, Image = $@"{rootImage}\minimoto.jpg" },
				new ProdutoViewModel{ Id = Guid.NewGuid(), Nome = "Monitor", Valor = 600m, Image = $@"{rootImage}\monitor.jpg" },
				new ProdutoViewModel{ Id = Guid.NewGuid(), Nome = "Smartphone", Valor = 2000m, Image = $@"{rootImage}\smartphone.jpg" }
			};
			return View(produtos);
		}


		[ValidateAntiForgeryToken]
		public IActionResult Pedido(ProdutoViewModel produto)
		{
			PedidoViewModel pedido = new PedidoViewModel();
			pedido.Produto = produto;
			try
			{
				pedido.CodigoPedido = _servicoProduto.GeraPedidoProduto(produto);
				pedido.RealizadoComSucesso = true;
			}
			catch (CircuitBreakerOpenException ex)
			{
				pedido.Mensagem = ex.Message;
			}
			catch (Exception ex)
			{
				pedido.Mensagem = ex.Message;
			}

			return View("Pedido", pedido);
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
