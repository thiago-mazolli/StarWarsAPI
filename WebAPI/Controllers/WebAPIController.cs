using Bild_WebAPI.Models;
using Business.Controllers;
using Business.Models;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Bild_WebAPI.Controllers
{
	[EnableCors("*", "*", "*")]
	[RoutePrefix("api/WebAPI")]
	public class WebAPIController : ApiController
	{
		// GET: api/StarWarsAPI
		[AcceptVerbs("GET", "POST")]
		[HttpPost]
		[Route("Teste")]
		public string Teste()
		{
			return "Teste API OK";
		}

		//[AcceptVerbs("GET", "POST")]
		[AcceptVerbs("GET")]
		[HttpPost]
		[Route("Lista")]
		public IHttpActionResult Lista([FromBody]cJson pJson)
		{
			cRetorno retorno = new cRetorno();

			try
			{
				//ATRIBUI OS DADOS DO JSON PARA A CLASSE
				cJson Json = new cJson();
				Json = pJson;

				cController Controller = new cController();

				//LISTA OS DADOS DA CONSULTA
				retorno = Controller.Dados(Json.Categoria, Json.Nome);

				return Ok(retorno);
			}
			catch(Exception ex)
			{
				retorno.Erro = true;
				retorno.Mensagem = "Erro ao retornar os dados. Verique a estrutura da chamada. " + ex.Message;

				return Ok(retorno);
			}
		}

		//[AcceptVerbs("GET", "POST")]
		[AcceptVerbs("GET")]
		[HttpPost]
		[Route("Log")]
		public IHttpActionResult ConsultaLog()
		{
			cRetorno retorno = new cRetorno();

			try
			{
				cController Controller = new cController();

				retorno = Controller.ConsultaLog();

				return Ok(retorno);
			}
			catch(Exception ex)
			{
				retorno.Erro = true;
				retorno.Mensagem = "Erro ao retornar os dados: " + ex.Message;

				return Ok(retorno);
			}
		}
	}
}