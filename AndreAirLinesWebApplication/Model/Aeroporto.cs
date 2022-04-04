using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AndreAirLinesWebApplication.Model
{
    public class Aeroporto
    {
        #region Propriedades
        [Key]
        [JsonProperty("sigla")]
        public string Sigla { get; set; }
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("endereco")]
        public Endereco Endereco { get; set; }
        #endregion

        #region Constructor
        public Aeroporto(string sigla, string nome, Endereco endereco)
        {
            Sigla = sigla;
            Nome = nome;
            Endereco = endereco;
        }
        public Aeroporto()
        {

        }
        #endregion
    }
}
