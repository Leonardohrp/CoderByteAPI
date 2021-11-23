using CoderByteAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoderByteAPI.Helpers
{
    public static class ViaCEPIntegration
    {
        private static readonly HttpClient httpClient = new HttpClient();
        public async static Task<ViaCEPResponse> GetCompleteAddress(string zipCode)
        {
            Address address = new Address();
            try
            {
                string url = $@"http://viacep.com.br/ws/{zipCode}/json/";
                var response = await httpClient.GetAsync(url);

                if(!response.IsSuccessStatusCode)
                    throw new Exception($"Falha ao pegar o endereço do CEP {zipCode}");
                
                var finalData = await response.Content.ReadAsStringAsync();

                if(finalData.Contains("erro"))
                    throw new Exception($"Falha ao pegar o endereço do CEP {zipCode}");

                var dataResponse = JsonConvert.DeserializeObject<ViaCEPResponse>(finalData);

                return dataResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
