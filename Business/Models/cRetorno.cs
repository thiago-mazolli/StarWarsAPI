using System.Data;

namespace Business.Models
{
	public class cRetorno
	{
		public bool Erro { get; set; }

		public string Mensagem { get; set; }

		public dynamic Dados { get; set; }
	}
}