using GeradorDados.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDados.Service
{
    public class PassageirosService
    {
        public static async void CadastraPassageiros(PassageiroDTO passageirosDTO)
        {
            using(var httpClient = new HttpClient())
            {
                try
                {
                    httpClient.BaseAddress = new Uri("https://localhost:44312");
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("/application/json"));

                    var response = await httpClient.PostAsJsonAsync("api/Passageiros", passageirosDTO);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Exception: " + ex);
                }
            }
        }
    }
}
