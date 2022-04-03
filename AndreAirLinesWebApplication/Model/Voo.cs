using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AndreAirLinesWebApplication.Model
{
    public class Voo
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        public Aeroporto Destino { get; set; }
        public Aeroporto Origem { get; set; }
        public Aeronave Aeronave { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0: yyyy/MM/dd", ApplyFormatInEditMode = true)]
        public DateTime HorarioEmbarque { get; set; }
        public DateTime HorarioDesenbarque { get; set; }
        #endregion

        #region Constructor
        public Voo()
        {

        }

        public Voo(Aeroporto destino, Aeroporto origem, Aeronave aeronave, DateTime horarioEmbarque, DateTime horarioDesembarque)
        {
            Destino = destino;
            Origem = origem;
            Aeronave = aeronave;
            HorarioDesenbarque = horarioDesembarque;
            HorarioEmbarque = horarioEmbarque;
        }
        #endregion
    }
}
