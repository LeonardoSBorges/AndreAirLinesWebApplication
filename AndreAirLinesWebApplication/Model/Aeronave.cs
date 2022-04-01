using System.ComponentModel.DataAnnotations;

namespace AndreAirLinesWebApplication.Model
{
    public class Aeronave
    {
        #region Properties
        [Key]
        public string Id { get; set; }
        public string Nome { get; set; }
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
