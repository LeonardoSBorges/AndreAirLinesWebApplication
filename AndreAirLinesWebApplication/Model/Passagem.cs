using System;
using System.ComponentModel.DataAnnotations;

namespace AndreAirLinesWebApplication.Model
{
    public class Passagem
    {
        [Key]
        public Guid Id { get; set; } 
        public Voo Voo { get; set; }
        public Passageiro Passageiro { get; set; }
        public double Valor { get; set; }
        public Classe Classe { get; set; }
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
