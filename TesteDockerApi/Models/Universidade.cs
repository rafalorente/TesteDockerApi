using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace TesteDockerApi.Models
{
    [BsonIgnoreExtraElements]
    public class Universidade
    {

        //[JsonProperty("state-province")]
        [BsonElement("state-province")]
        public string Provincia { get; set; }

        [BsonElement("country")]
        //[JsonProperty("country")]
        public string Pais { get; set; }

        [BsonElement("name")]
        //[JsonProperty("name")]
        public string Nome { get; set; }

        //[BsonElement("web_pages")]
        public string Site { get; set; }

        //[BsonElement("domains")]
        public string Dominio { get; set; }

        [BsonElement("alpha_two_code")]
        //[JsonProperty("alpha_two_code")]
        public string UF { get; set; }
    }
}
