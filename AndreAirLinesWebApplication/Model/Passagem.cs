using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace AndreAirLinesWebApplication.Model
{
    public class Passagem
    {
        [Key]
        [JsonProperty("id")]
        public Guid Id { get; set; } 
        [JsonProperty("voo")]
        public Voo Voo { get; set; }
        [JsonProperty("passageiro")]
        public Passageiro Passageiro { get; set; }
        [JsonProperty("valor")]
        public double Valor { get; set; }
        [JsonProperty("classe")]
        public Classe Classe { get; set; }
        [JsonProperty("dataCadastro")]
        public DateTime DataCadastro { get; set; }

        public Passagem()
        {

        }

        public Passagem(Voo voo, Passageiro passageiro, double valor, Classe classe)
        {
            Id = new Guid();
            Voo = voo;
            Passageiro = passageiro;
            Valor = valor;
            Classe = classe;
            DataCadastro = DateTime.Now;
        }
    }
}
