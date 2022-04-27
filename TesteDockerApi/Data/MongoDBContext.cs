using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;

namespace TesteDockerApi.Data
{
    public class MongoDBContext
    {

        public IMongoDatabase DB { get; }

        public MongoDBContext(IConfiguration configuration)
        {
            try
            {
                var client = new MongoClient(configuration["ConnectionStrings:MongoConnection"]);
                DB = client.GetDatabase("TesteInatel");
            }
            catch (Exception ex)
            {

                throw new MongoException("Conexão não concluída", ex);
            }
        }
    }
}
