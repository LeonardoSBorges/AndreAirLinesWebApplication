using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace GeradorDados.DTO
{
    public class PassageiroDTO
    {
        public PassageiroDTO(string cpf, string nome, string telefone, DateTime dataNascimento, string email, string cEP, int numero)
        {
            Cpf = cpf;
            Nome = nome;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            Email = email;
            CEP = cEP;
            Numero = numero;
        }
        #region Propriedades
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public int Numero { get; set; }
        #endregion
        



    }
}
