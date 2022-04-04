using AndreAirLinesWebApplication.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AndreAirLinesWebApplication.Service
{
    public static class RelatoriosService
    {
        public static readonly HttpClient BuscaApi = new HttpClient();
        public static async Task RelatorioComprasPassagem()
        {
            try
            {
                HttpResponseMessage response = await BuscaApi.GetAsync("https://localhost:44312/api/Passagems");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                File.WriteAllText(@"C:\Users\LeonardoBorges\Desktop\Curso_5by5\AndreAirLinesWebApplication\RoboBancoDados\FileJson\RelatorioCompras.json", responseBody);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static async Task RelatorioPrecoRecente()
        {
            try
            {
                HttpResponseMessage response = await BuscaApi.GetAsync("https://localhost:44312/api/PrecoBases");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                File.WriteAllText($@"C:\Users\LeonardoBorges\Desktop\Curso_5by5\AndreAirLinesWebApplication\RoboBancoDados\FileJson\PrecoRecente.json", responseBody);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
