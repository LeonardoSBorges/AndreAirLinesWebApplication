using System.ComponentModel.DataAnnotations;

namespace AndreAirLinesWebApplication.Model
{
    public class Classe
    {
        [Key]
        public int Id { get; set; }
        public double ValorPorcentagem { get; set; }
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