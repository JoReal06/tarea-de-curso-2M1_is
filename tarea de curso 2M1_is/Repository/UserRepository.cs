using Newtonsoft.Json;
using SharedModels.Dto;
using SharedModels.Dto.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace tarea_de_curso_2M1_is
{
    public class UserRepository : IUserRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        public UserRepository(HttpClient httpClient,
            string endpoint)
        {
            _httpClient = httpClient;
            _endpoint = endpoint;
        }

        public async Task<string> AuthenticateUserAsync(string username, string password)
        {
            try
            {
                var loginDto = new LoginUsuarioDto
                {
                    nombreDeUsuario = username,
                    contraseña = password
                };
                var json = JsonConvert.SerializeObject(loginDto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(_endpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<dynamic>(responseData).token;
                }
                else
                {
                    throw new Exception("Invalid credentials");
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

    }
}
