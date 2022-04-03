using AndreAirLinesWebApplication.DTO;
using AndreAirLinesWebApplication.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace RoboInsereDados.Service
{
    public class InsereAeronaveHttp
    {
        public static void PopulaAeronavePost()
        {
            try
            {
                var jsonAeronave = JsonConvert.DeserializeObject<List<Aeronave>>(@"C:\Users\LeonardoBorges\Desktop\Curso_5by5\AndreAirLinesWebApplication\RoboInsereDados\ArquivosJson\Aeronave.json");

                foreach (var aeronave in jsonAeronave)
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:44312/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(
                            new MediaTypeWithQualityHeaderValue("application/json"));
                        var response =  client.PostAsJsonAsync($"api/Aeronaves", aeronave);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
