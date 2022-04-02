using System;

namespace GeradorDados.DTO
{
    public class VooDTO
    {
        public string origem { get; set; }
        public string destino { get; set; }
        public string aeronave { get; set; }
        public DateTime HorarioEmbarque { get; set; }
        public DateTime HorarioDesenbarque { get; set; }
        public string cpf { get; set; }

    }
}
