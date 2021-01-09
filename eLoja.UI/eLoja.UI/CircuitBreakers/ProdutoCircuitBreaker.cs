using eLoja.CircuitBreaker;
using eLoja.UI.Models;
using eLoja.UI.ServiceCaller;
using System;

namespace eLoja.UI.CircuitBreakers
{
	public class ProdutoCircuitBreaker : CircuitBreakerBase
	{
		public ProdutoCircuitBreaker() : base(new TimeSpan(0, 1, 0)) { }

		public string GeraPedidoProduto(ProdutoViewModel produto)
		{
			string codigoPedido = string.Empty;

			SenderAgent<ProdutoViewModel> senderAgent = new SenderAgent<ProdutoViewModel>("http://localhost:5001/api/");

			ExecuteAction(() => codigoPedido = senderAgent.SendPost(produto, "pedido"));

			return codigoPedido;
		}
	}
}
