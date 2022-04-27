using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDockerApi.Models;

namespace TesteDockerApi.Services.Interfaces
{
    public interface IUniversidadeService
    {
        Task<IEnumerable<Universidade>> GetTeste();
    }
}
