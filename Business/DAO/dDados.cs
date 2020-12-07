using Business.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Business.DAO
{
	public class dDados
	{
		//pCategoria = CATEGORIA ESCOLHIDA PELO USUÁRIO
		//pNome = PARAMETRO DE BUSCA POR PARTE DO NOME
		public static cRetorno Dados(string pCategoria, string pNome)
		{
			cRetorno retorno = new cRetorno();

			try
			{
				if(string.IsNullOrEmpty(pCategoria))
				{
					retorno.Erro = true;
					retorno.Mensagem = "Informe uma categoria para pesquisa. [people, species, vehicles, starships, planets, films]";

					return retorno;
				}

				List<object> list = new List<object>();


				//LISTA TODOS OS OBJETOS DA CATEGORIA
				dynamic json = dRequestApi.Request(pCategoria, null);


				//INCLUI OS OBJETOS EM UMA LISTA DINMAICA PARA FILTRAR PELO QUE FOI PESQUISADO
				for(int i = 0; i < json.results.Length; i++)
				{
					if(string.IsNullOrEmpty(pNome))
					{
						list.Add(json.results[i]);
					}
					else
					{
						if(pCategoria.ToLower() == "films")
						{
							if(json.results[i].title.ToLower().Contains(pNome.ToLower()))
							{
								list.Add(json.results[i]);
							}
						}
						else
						{
							if(json.results[i].name.ToLower().Contains(pNome.ToLower()))
							{
								list.Add(json.results[i]);
							}
						}
					}
				}


				dynamic listResults = new ExpandoObject();

				//MAPEIA TODOS DOS DADOS QUE ESTÃO NA LISTA POR CATEGORIA
				switch(pCategoria)
				{
					case "people":
						List<cPeople> peopleList = new List<cPeople>();

						for(int i = 0; i < list.Count; i++)
						{
							peopleList.Add(cMap.MapPeople(list[i]));
						}

						listResults = peopleList;
						break;

					case "species":
						List<cSpecies> speciesList = new List<cSpecies>();
						listResults = speciesList;
						break;

					case "vehicles":
						List<cVehicles> vehiclesList = new List<cVehicles>();
						listResults = vehiclesList;
						break;

					case "starships":
						List<cStarships> starshipsList = new List<cStarships>();

						for(int i = 0; i < list.Count; i++)
						{
							starshipsList.Add(cMap.MapStarships(list[i]));
						}

						listResults = starshipsList;
						break;

					case "planets":
						List<cPlanets> planetsList = new List<cPlanets>();

						for(int i = 0; i < list.Count; i++)
						{
							planetsList.Add(cMap.MapPlanet(list[i]));
						}

						listResults = planetsList;
						break;

					case "films":
						List<cFilms> filmsList = new List<cFilms>();

						for(int i = 0; i < list.Count; i++)
						{
							filmsList.Add(cMap.MapFilms(list[i]));
						}

						listResults = filmsList;
						break;
				}

				dynamic Dados = new ExpandoObject();

				Dados.count = json.count;
				Dados.next = json.next;
				Dados.previous = json.previous;
				Dados.category = pCategoria.ToLower();
				Dados.results = listResults;

				retorno.Erro = false;
				retorno.Dados = Dados;

				//LOG COM OS TERMOS BUSCADOS
				dLog.GravaLog(pCategoria, pNome);
			}
			catch(Exception ex)
			{
				retorno.Erro = true;
				retorno.Mensagem = "Erro ao retornar os dados. " + ex.Message;
			}

			return retorno;
		}
	}
}