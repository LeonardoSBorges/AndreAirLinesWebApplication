﻿using System;

namespace AndreAirLinesWebApplication.DTO
{
    public class VooDTO
    {
        public string origem { get; set; }
        public string destino { get; set; }
        public string aeronave { get; set; }
        public DateTime HorarioEmbarque { get; set; }
        public DateTime HorarioDesembarque { get; set; }

    }
}
