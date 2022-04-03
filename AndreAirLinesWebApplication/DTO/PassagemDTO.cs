﻿using AndreAirLinesWebApplication.Model;
using System;

namespace AndreAirLinesWebApplication.DTO
{
    public class PassagemDTO
    {
        public int IdVoo { get; set; }
        public string PassageiroCpf { get; set; }
        public double Valor { get; set; }
        public int IdClasse { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
