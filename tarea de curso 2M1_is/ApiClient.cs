using SharedModels.Dto.DeduccionesDto;
using SharedModels.Dto.EmpleadoDto;
using SharedModels.Dto.IngresosDto;
using SharedModels.Dto.NominaDto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace tarea_de_curso_2M1_is
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        public IRepository<EmpleadoReadDto> empleados { get; }
        public IRepository<DeduccionesReadDto> deducciones { get; }
        public IRepository<IngresosReadDto> ingresos { get; }
        public IRepository<NominaReadDto> nominas { get; }

        public IUserRepository LoginUsers { get; }
        public ApiClient()
        {
                string apiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
                _httpClient = new HttpClient { BaseAddress = new Uri(apiBaseUrl) };
                empleados = new Repository<EmpleadoReadDto>(_httpClient, "Empleado");
                deducciones = new Repository<DeduccionesReadDto>(_httpClient, "Deducciones");
                ingresos = new Repository<IngresosReadDto>(_httpClient, "Ingresos");
                nominas = new Repository<NominaReadDto>(_httpClient, "Nomina");
                LoginUsers = new UserRepository(_httpClient, "Auth/Login");
        }

        public void SetAuthToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
