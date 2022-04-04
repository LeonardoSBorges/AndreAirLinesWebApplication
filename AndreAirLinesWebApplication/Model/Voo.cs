using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AndreAirLinesWebApplication.Model
{
    public class Voo
    {
        #region Properties
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("destino")]
        public Aeroporto Destino { get; set; }
        [JsonProperty("origem")]
        public Aeroporto Origem { get; set; }
        [JsonProperty("aeronave")]
        public Aeronave Aeronave { get; set; }
        [JsonProperty("horarioEmbarque")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0: yyyy/MM/dd", ApplyFormatInEditMode = true)]
        public DateTime HorarioEmbarque { get; set; }

        [JsonProperty("horarioDesembarque")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0: yyyy/MM/dd", ApplyFormatInEditMode = true)]
        public DateTime HorarioDesembarque { get; set; }
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
            HorarioDesembarque = horarioDesembarque;
            HorarioEmbarque = horarioEmbarque;
        }
        #endregion
    }
}
