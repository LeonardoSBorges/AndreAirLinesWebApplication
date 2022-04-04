using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AndreAirLinesWebApplication.Model
{
    public class Classe
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("valorPorcentagem")]
        public double ValorPorcentagem { get; set; }
        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        public Classe()
        {

        }

        public Classe(double valorPorcentagem, string descricao)
        {
            ValorPorcentagem = valorPorcentagem;
            Descricao = descricao;
        }
    }
}