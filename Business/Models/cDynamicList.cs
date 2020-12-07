using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Business.Models
{
	public class cDynamicList
	{
		public static List<dynamic> SuggestionsPeople(string pUrl, string pUrlKey)
		{
			dynamic json = dRequestApi.Request(null, pUrl);

			List<dynamic> listSuggestions = new List<dynamic>();

			Random random = new Random();

			int sugestao;
			int[] verificador = new int[3];
			int count = 0;
			int i = 0;

			while(i <= json["residents"].Length || count <= 3)
			{
				Inicio:
				sugestao = random.Next(0, json["residents"].Length);

				if(json["residents"].Length > 1)
				{
					for(int j = 0; j < verificador.Length; j++)
					{
						if(verificador[j] == sugestao)
						{
							goto Inicio;
						}
					}
					verificador[i] = sugestao;
				}

				if(json["residents"][sugestao] != pUrlKey)
				{
					dynamic jSonResident = dRequestApi.Request(null, json["residents"][sugestao]);

					dynamic obj = new ExpandoObject();

					obj.name = jSonResident.name;
					obj.height = jSonResident.height;
					obj.mass = jSonResident.mass;
					obj.gender = jSonResident.gender;
					obj.url = jSonResident.url;

					listSuggestions.Add(obj);

					count += 1;
				}

				if(count == 3)
					break;

				i++;
			}
			/*
			if(listSuggestions != null)
			{
				json.results[i].suggestions = listSuggestions;
			}
			*/

			return listSuggestions;
		}

		public static List<dynamic> People(dynamic listPeople)
		{
			List<dynamic> Pessoas = new List<dynamic>();

			for(int i = 0; i < listPeople.Length; i++)
			{
				dynamic json = dRequestApi.Request(null, listPeople[i]);

				dynamic obj = new ExpandoObject();

				obj.name = json.name;
				obj.height = json.height;
				obj.mass = json.mass;
				obj.gender = json.gender;
				obj.url = json.url;

				Pessoas.Add(obj);
			}

			return Pessoas;
		}

		public static List<dynamic> Films(dynamic listFilms)
		{
			List<dynamic> Filmes = new List<dynamic>();

			for(int i = 0; i < listFilms.Length; i++)
			{
				dynamic json = dRequestApi.Request(null, listFilms[i]);

				dynamic obj = new ExpandoObject();

				obj.title = json.title;
				obj.episode_id = json.episode_id;
				obj.director = json.director;
				obj.producer = json.producer;
				obj.url = json.url;

				Filmes.Add(obj);
			}

			return Filmes;
		}

		public static dynamic Homeworld(string Homeworld)
		{
			dynamic json = dRequestApi.Request(null, Homeworld);

			dynamic obj = new ExpandoObject();

			obj.name = json.name;
			obj.climate = json.climate;
			obj.terrain = json.terrain;
			obj.population = json.population;
			obj.url = json.url;

			return obj;
		}

		public static List<dynamic> Planets(dynamic listPlanets)
		{
			List<dynamic> Planetas = new List<dynamic>();

			for(int i = 0; i < listPlanets.Length; i++)
			{
				dynamic json = dRequestApi.Request(null, listPlanets[i]);

				dynamic obj = new ExpandoObject();

				obj.name = json.name;
				obj.climate = json.climate;
				obj.terrain = json.terrain;
				obj.population = json.population;
				obj.url = json.url;

				Planetas.Add(obj);
			}

			return Planetas;
		}

		public static List<dynamic> Starships(dynamic listStarships)
		{
			List<dynamic> Naves = new List<dynamic>();

			for(int i = 0; i < listStarships.Length; i++)
			{
				dynamic json = dRequestApi.Request(null, listStarships[i]);

				dynamic obj = new ExpandoObject();

				obj.nome = json.nome;
				obj.model = json.model;
				obj.manufacturer = json.manufacturer;
				obj.starship_class = json.starship_class;
				obj.url = json.url;

				Naves.Add(obj);
			}

			return Naves;
		}

		public static List<dynamic> Species(dynamic listSpecies)
		{
			List<dynamic> Especie = new List<dynamic>();

			for(int i = 0; i < listSpecies.Length; i++)
			{
				dynamic json = dRequestApi.Request(null, listSpecies[i]);

				dynamic obj = new ExpandoObject();

				obj.nome = json.nome;
				obj.model = json.model;
				obj.manufacturer = json.manufacturer;
				obj.starship_class = json.starship_class;
				obj.url = json.url;

				Especie.Add(obj);
			}

			return Especie;
		}

		public static List<dynamic> Vehicles(dynamic listvehicles)
		{
			List<dynamic> Especie = new List<dynamic>();

			for(int i = 0; i < listvehicles.Length; i++)
			{
				dynamic json = dRequestApi.Request(null, listvehicles[i]);

				dynamic obj = new ExpandoObject();

				obj.nome = json.nome;
				obj.model = json.model;
				obj.manufacturer = json.manufacturer;
				obj.vehicle_class = json.vehicle_class;
				obj.url = json.url;

				Especie.Add(obj);
			}

			return Especie;
		}
	}
}
