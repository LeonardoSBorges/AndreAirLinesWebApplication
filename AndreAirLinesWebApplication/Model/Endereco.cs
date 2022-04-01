
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Http.Services;

namespace AndreAirLinesWebApplication.Model
{
    public class Endereco
    {
        #region Propriedades
        public int Id { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Estado { get; set; }
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
