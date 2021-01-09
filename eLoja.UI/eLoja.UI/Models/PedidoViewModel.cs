using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLoja.UI.Models
{
	public class PedidoViewModel
	{
		public ProdutoViewModel Produto { get; set; }
		public string CodigoPedido { get; set; }

		public bool RealizadoComSucesso { get; set; }
		public string Mensagem { get; set; }

		public decimal ValorPedido { get => Produto.Valor * Produto.Quantidade; }
	}
}
