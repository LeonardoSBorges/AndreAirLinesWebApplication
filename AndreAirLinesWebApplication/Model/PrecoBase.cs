using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace AndreAirLinesWebApplication.Model
{
    public class PrecoBase
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("origem")]
        public Aeroporto Origem { get; set; }
        [JsonProperty("destino")]
        public Aeroporto Destino { get; set; }
        [JsonProperty("valor")]
        public double Valor { get; set; }
        [JsonProperty("sigla")]
        public Classe Classe { get; set; }
        [JsonProperty("sigla")]
        public DateTime DataInclusao { get; set; }

        public PrecoBase()
        {

        }

        public PrecoBase(Aeroporto origem, Aeroporto destino, double valor, Classe classe, DateTime dataInclusao)
        {
            Origem = origem;
            Destino = destino;
            Valor = valor;
            Classe = classe;
            DataInclusao = dataInclusao;
        }
    }
}
