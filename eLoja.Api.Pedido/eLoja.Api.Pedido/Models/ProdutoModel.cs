using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLoja.Api.Pedido.Models
{
	public class ProdutoModel
	{
		public Guid Id { get; set; }
		public string Nome { get; set; }
		public int Quantidade { get; set; }
		public decimal Valor { get; set; }
	}
}
