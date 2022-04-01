using System;

namespace AndreAirLinesWebApplication.DTO
{
    public class VooDTO
    {
        public string origem { get; set; }
        public string destino { get; set; }
        public string id { get; set; }
        public DateTime HorarioEmbarque { get; set; }
        public DateTime HorarioDesenbarque { get; set; }
        public string cep { get; set; }
    }
}
