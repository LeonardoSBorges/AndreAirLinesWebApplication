using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AndreAirLinesWebApplication.Model
{
    public class Aeronave
    {
        #region Properties
        [Key]
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("capacidade")]
        public int Capacidade { get; set; }
        #endregion
        #region Constructor
        public Aeronave()
        {

        }
        public Aeronave(string id, string nome, int capacidade)
        {
            Id = id;
            Nome = nome;
            Capacidade = capacidade;
        }
        #endregion

    }
}
