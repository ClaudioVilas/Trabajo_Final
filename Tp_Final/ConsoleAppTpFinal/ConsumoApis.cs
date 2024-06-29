using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTpFinal
{
    public class ConsumoApis
    {
        private readonly HttpClient _client;
        private readonly string _basePath;

        public ConsumoApis(string basePath)
        {
            _client = new HttpClient();
            _basePath = basePath;
        }


        public async Task<List<UsuarioEntitie>> FiltrarAsync()
        {
            List<UsuarioEntitie>? list = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_basePath);
                if (response.IsSuccessStatusCode)
                {
                    list = await response.Content.ReadFromJsonAsync<List<UsuarioEntitie>>();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error con la API: " + ex.Message);
            }
            return list;
        }

        public async Task<bool> UpdateUsuario(UsuarioEntitie usuario)
        {
            HttpResponseMessage response = await _client.PutAsJsonAsync(_basePath, usuario);
            response.EnsureSuccessStatusCode();

            return response.IsSuccessStatusCode;

        }


        public async Task<bool> CreateUsuario(UsuarioEntitie usuario)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync(_basePath, usuario);

            response.EnsureSuccessStatusCode();

            return response.IsSuccessStatusCode;

        }
        public async Task<bool> DeleteUsuario(int id)
        {
            try
            {

                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    Content = JsonContent.Create(id),
                    RequestUri = new Uri(_basePath, UriKind.Absolute)
                };

                HttpResponseMessage response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
        
