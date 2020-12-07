using Business.DAO;
using Business.Models;
using System.Collections.Generic;

namespace Business.Controllers
{
	public class cController
	{
		public cRetorno Dados(string pCategoria, string pParametro)
		{
			return dDados.Dados(pCategoria, pParametro);
		}

		public cRetorno ConsultaLog()
		{
			return dLog.ConsultaLog();
		}
	}
}