using System;
using System.ComponentModel.DataAnnotations;

namespace AndreAirLinesWebApplication.Model
{
    public class PrecoBase
    {
        [Key]
        public int Id { get; set; }
        public Aeroporto Origem { get; set; }
        public Aeroporto Destino { get; set; }
        public double Valor { get; set; }
        public Classe Classe { get; set; }
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
