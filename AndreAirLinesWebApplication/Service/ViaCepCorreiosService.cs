using AndreAirLinesWebApplication.DTO;
using AndreAirLinesWebApplication.Model;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AndreAirLinesWebApplication.Service
{
    public static class ViaCepCorreiosService
    {
        public static async Task<Endereco> HTTPCorreios(string cep)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("https://viacep.com.br/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync($"ws/{cep}/json/");

            ViaCepDTO viaCep = await response.Content.ReadFromJsonAsync<ViaCepDTO>();

            return new Endereco(viaCep.bairro, viaCep.localidade, viaCep.cep, viaCep.logradouro, viaCep.uf); ;
        }

    }
}
