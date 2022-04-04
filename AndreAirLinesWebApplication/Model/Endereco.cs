using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Http.Services;

namespace AndreAirLinesWebApplication.Model
{
    public class Endereco
    {
        #region Propriedades
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("bairro")]
        public string Bairro { get; set; }
        [JsonProperty("cidade")]
        public string Cidade { get; set; }
        [JsonProperty("cep")]
        public string CEP { get; set; }
        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }
        [JsonProperty("estado")]
        public string Estado { get; set; }
        [JsonProperty("numero")]
        public int Numero { get; set; }
        #endregion

        #region Construtor
        public Endereco()
        {

        }
        public Endereco(string bairro, string cidade, string cEP, string logradouro, string estado)
        {
            Bairro = bairro;
            Cidade = cidade;
            CEP = cEP;
            Logradouro = logradouro;
            Estado = estado;
        }
        #endregion
    }
}
