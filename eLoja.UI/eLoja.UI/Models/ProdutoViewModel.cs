using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLoja.UI.Models
{
	public class ProdutoViewModel
	{
		public Guid Id { get; set; }
		public string Nome { get; set; }
		public int Quantidade { get; set; }
		public decimal Valor { get; set; }
		public string Image { get; set; }

	}
}
