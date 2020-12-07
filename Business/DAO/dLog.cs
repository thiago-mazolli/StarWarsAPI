using Business.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.Web.Helpers;

namespace Business.DAO
{
	public class dLog
	{
		public static cRetorno ConsultaLog()
		{
			cRetorno retorno = new cRetorno();

			MongoClient dbClient = new MongoClient(dConfig.ObterConteudo().MongoDBconn);

			try
			{
				var database = dbClient.GetDatabase("MongoDB");

				var sort = Builders<dynamic>.Sort.Descending("count");


				var collection = database.GetCollection<dynamic>("Log");
				var listLog = collection.Find(Builders<dynamic>.Filter.Empty).Sort(sort).ToList();


				var collectionTerms = database.GetCollection<dynamic>("LogTerm");
				var listTerm = collectionTerms.Find(Builders<dynamic>.Filter.Empty).Sort(sort).ToList();

				//List<object> listCategory = new List<object>();

				dynamic Log = new ExpandoObject();
				Log.category = listLog;
				Log.terms = listTerm;


				retorno.Erro = false;
				retorno.Dados = Log;
			}
			catch(Exception ex)
			{
				retorno.Erro = true;
				retorno.Mensagem = "Erro ao consultar o log: " + ex.Message;
			}

			return retorno;
		}

		public static void GravaLog(string pCategoria, string pParametro)
		{
			MongoClient dbClient = new MongoClient(dConfig.ObterConteudo().MongoDBconn);

			try
			{
				var database = dbClient.GetDatabase("MongoDB");

				//CATEGORIAS
				var collection = database.GetCollection<BsonDocument>("Log");
				var filter = Builders<BsonDocument>.Filter.Eq("category", pCategoria);
				var exist = collection.Find(filter).FirstOrDefault();

				if(exist == null)
				{
					var document = new BsonDocument
					{
						{ "category", pCategoria},
						{ "count", 1}
					};

					collection.InsertOne(document);
				}
				else
				{
					var update = Builders<BsonDocument>.Update.Set("count", exist.GetElement("count").Value.ToInt32() + 1);
					collection.UpdateOne(filter, update);
				}


				//TERMOS
				var collectionTerm = database.GetCollection<BsonDocument>("LogTerm");

				var filterTerm = Builders<BsonDocument>.Filter.Eq("term", pParametro);
				var existTerm = collectionTerm.Find(filterTerm).FirstOrDefault();

				if(existTerm == null)
				{
					var document = new BsonDocument
					{
						{ "term", pParametro},
						{ "count", 1}
					};

					collectionTerm.InsertOne(document);
				}
				else
				{
					var updateTerm = Builders<BsonDocument>.Update.Set("count", existTerm.GetElement("count").Value.ToInt32() + 1);
					collectionTerm.UpdateOne(filterTerm, updateTerm);
				}
			}
			catch(Exception ex)
			{
				throw new FaultException("Erro ao gravar log: " + ex.Message);
			}
		}
	}
}
