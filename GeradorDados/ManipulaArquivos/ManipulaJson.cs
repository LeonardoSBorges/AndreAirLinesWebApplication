using GeradorDados.DTO;
using GeradorDados.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GeradorDados.ManipulaArquivos
{
    public class ManipulaJson : IManipulaJson
    {
        public void PassageirosDeserialize(string pathFile)
        {
            try
            {
                string filePassageiros = File.ReadAllText(pathFile);
                var passageiros = JsonSerializer.Deserialize<List<PassageiroDTO>>(filePassageiros);
                foreach (var passageiro in passageiros)
                {
                    PassageirosService.CadastraPassageiros(passageiro);
                }
                Console.WriteLine("Passageiros foram inseridos");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //public static void AeroportoDeserialize(string pathFile)
        //{
        //    var jsonString = JsonSerializer.Serialize(pathFile);
        //    return jsonString;
        //}
        //public static void AeronaveDeserialize(string pathFile)
        //{
        //    var jsonString = JsonSerializer.Serialize(pathFile);
        //    return jsonString;
        //}

    }
}
