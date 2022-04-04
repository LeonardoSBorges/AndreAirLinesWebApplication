
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace AndreAirLinesWebApplication.Model
{
    public class Passageiro
    {
        #region Propriedades
        [Key]
        [JsonProperty("cpf")]
        public string Cpf { get; set; }
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("telefone")]
        public string Telefone { get; set; }
        [JsonProperty("dataNascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("endereco")]
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
