namespace Business.Models
{
	public class cMap
	{
		public static cPeople MapPeople(dynamic objPeople)
		{
			cPeople people = new cPeople();

			people.name = objPeople.name;
			people.height = objPeople.height;
			people.mass = objPeople.mass;
			people.hair_color = objPeople.hair_color;
			people.skin_color = objPeople.skin_color;
			people.eye_color = objPeople.eye_color;
			people.birth_year = objPeople.birth_year;
			people.gender = objPeople.gender;

			//URL DO PLANETA
			people.homeworld = cDynamicList.Homeworld(objPeople.homeworld);

			//cMap.MapPlanet(dRequestApi.Request(null, objPeople.homeworld));

			//URL DOS FILMES
			people.films = cDynamicList.Films(objPeople.films);

			//URL DAS ESPÉCIES
			people.species = cDynamicList.Species(objPeople.species);

			//URL DOS VEÍCULOS
			people.vehicles = cDynamicList.Species(objPeople.vehicles);

			//URL DAS NAVES
			people.starships = cDynamicList.Starships(objPeople.starships);

			people.created = objPeople.created;
			people.edited = objPeople.edited;
			people.url = objPeople.url;

			people.peopleSuggestions = cDynamicList.SuggestionsPeople(objPeople.homeworld, objPeople.url);

			return people;
		}

		public static cPlanets MapPlanet(dynamic objPlanets)
		{
			cPlanets planetas = new cPlanets();

			planetas.name = objPlanets.name;
			planetas.rotation_period = objPlanets.rotation_period;
			planetas.orbital_period = objPlanets.orbital_period;
			planetas.diameter = objPlanets.diameter;
			planetas.climate = objPlanets.climate;
			planetas.gravity = objPlanets.gravity;
			planetas.terrain = objPlanets.terrain;
			planetas.surface_water = objPlanets.surface_water;
			planetas.population = objPlanets.population;

			planetas.residents = cDynamicList.People(objPlanets.residents);

			planetas.films = cDynamicList.Films(objPlanets.films);

			planetas.created = objPlanets.created;
			planetas.edited = objPlanets.edited;
			planetas.url = objPlanets.url;

			return planetas;
		}

		public static cFilms MapFilms(dynamic objFilms)
		{
			cFilms filmes = new cFilms();

			filmes.title = objFilms.title;
			filmes.episode_id = objFilms.episode_id;
			filmes.opening_crawl = objFilms.opening_crawl;
			filmes.director = objFilms.director;
			filmes.producer = objFilms.producer;
			filmes.release_date = objFilms.release_date;

			filmes.characters = cDynamicList.People(objFilms.characters);

			filmes.planets = cDynamicList.Planets(objFilms.planets);
			
			filmes.starships = cDynamicList.Starships(objFilms.starships);
			
			filmes.vehicles = cDynamicList.Vehicles(objFilms.vehicles);
			
			filmes.species = cDynamicList.Species(objFilms.species);

			filmes.created = objFilms.created;
			filmes.edited = objFilms.edited;
			filmes.url = objFilms.url;

			return filmes;
		}

		public static cStarships MapStarships(dynamic objStarships)
		{
			cStarships starships = new cStarships();
			
			starships.name = objStarships.name;
			starships.model = objStarships.model;
			starships.manufacturer = objStarships.manufacturer;
			starships.cost_in_credits = objStarships.cost_in_credits;
			starships.length = objStarships.length;
			starships.max_atmosphering_speed = objStarships.max_atmosphering_speed;
			starships.crew = objStarships.crew;
			starships.passengers = objStarships.passengers;
			starships.cargo_capacity = objStarships.cargo_capacity;
			starships.consumables = objStarships.consumables;
			starships.hyperdrive_rating = objStarships.hyperdrive_rating;
			starships.MGLT = objStarships.MGLT;
			starships.starship_class = objStarships.starship_class;

			starships.pilots = cDynamicList.People(objStarships.pilots);

			starships.films = cDynamicList.Films(objStarships.films);

			starships.created = objStarships.tittle;
			starships.edited = objStarships.tittle;
			starships.url = objStarships.tittle;

			return starships;
		}
	}
}