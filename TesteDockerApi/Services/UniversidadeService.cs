using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDockerApi.Data;
using TesteDockerApi.Models;
using TesteDockerApi.Services.Interfaces;

namespace TesteDockerApi.Services
{
    public class UniversidadeService : IUniversidadeService
    {
        IMongoCollection<Universidade> _universidade;

      
        public UniversidadeService(MongoDBContext mongoDbContext)
        {
            _universidade = mongoDbContext.DB.GetCollection<Universidade>("Universidade");
        }

        public async Task<IEnumerable<Universidade>> GetUniversidadeBrasilMongoDb()
        {
            return await _universidade.AsQueryable().ToListAsync();
        }

    }
}
