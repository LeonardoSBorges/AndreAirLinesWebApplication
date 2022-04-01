
using System;
using System.ComponentModel.DataAnnotations;

namespace AndreAirLinesWebApplication.Model
{
    public class Passageiro
    {
        #region Propriedades
        [Key]
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }
        #endregion

        #region Construtor
        public Passageiro()
        {

        }
        public Passageiro(string cpf, string nome, string telefone, DateTime dataNascimento, string email, Endereco endereco)
        {
            Cpf = cpf;
            Nome = nome;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            Email = email;
            Endereco = endereco;
        }
        #endregion
    }
}
