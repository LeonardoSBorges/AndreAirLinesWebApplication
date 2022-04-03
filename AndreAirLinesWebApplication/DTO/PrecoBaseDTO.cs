using System;

namespace AndreAirLinesWebApplication.DTO
{
    public class PrecoBaseDTO
    {
        public string OrigemId { get; set; }
        public string DestinoId { get; set; }
        public double Valor { get; set; }
        public int ClasseId { get; set; }
        public DateTime DataInclusao { get; set; }
    }
}
