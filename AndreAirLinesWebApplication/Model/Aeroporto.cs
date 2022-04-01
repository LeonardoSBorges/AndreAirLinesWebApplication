using System.ComponentModel.DataAnnotations;

namespace AndreAirLinesWebApplication.Model
{
    public class Aeroporto
    {
        #region Propriedades
        [Key]
        public string Sigla { get; set; }
        public string Nome { get; set; }
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
