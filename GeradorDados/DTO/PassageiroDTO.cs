using System;
using System.ComponentModel.DataAnnotations;

namespace GeradorDados.DTO
{
    public class PassageiroDTO
    {
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
