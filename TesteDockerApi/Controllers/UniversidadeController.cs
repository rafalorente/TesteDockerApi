using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TesteDockerApi.Data;
using TesteDockerApi.Models;
using TesteDockerApi.Services.Interfaces;

namespace TesteDockerApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UniversidadeController : ControllerBase
    {
        //http://universities.hipolabs.com
        //http://universities.hipolabs.com/search?name=middle
        //http://universities.hipolabs.com/search?name=middle&country=turkey

        private IUniversidadeService _universidadeService;

        public UniversidadeController(IUniversidadeService universidadeService)
        {
            _universidadeService = universidadeService;
        }


        // Get para ser usado direto no mongoDB
        [HttpGet("GetUniversidadeBrasilMongoDb")]
        public async Task<ActionResult<IAsyncEnumerable<Universidade>>> GetUniversidadeBrasilMongoDb()
        {
            try
            {
                var universidade = await _universidadeService.GetUniversidadeBrasilMongoDb();
                return Ok(universidade);
            }
            catch 
            {
                return BadRequest("Request inválido");
            }
        }

        // Get para ser usado direto pela URL
        [HttpGet("GetUniversidadePorPais")]
        public async Task<List<Universidade>> GetUniversidadePorPais(string pais) 
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new System.Uri("http://universities.hipolabs.com");
                HttpResponseMessage response = await httpClient.GetAsync($"/search?name=&country={pais}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Universidade>>(content);
                }
                else
                {
                    return new List<Universidade> { new Universidade() };
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
