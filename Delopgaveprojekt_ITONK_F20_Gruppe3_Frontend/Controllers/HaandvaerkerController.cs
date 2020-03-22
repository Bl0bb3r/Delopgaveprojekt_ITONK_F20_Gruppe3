using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Delopgaveprojekt_ITONK_F20_Gruppe3_Frontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Delopgaveprojekt_ITONK_F20_Gruppe3_Frontend.Controllers
{
    public class HaandvaerkerController : Controller
    {
        private readonly HttpClient _client;

        public HaandvaerkerController(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("backend");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("api/haandvaerkere");
            response.EnsureSuccessStatusCode();
            var responseStream = await response.Content.ReadAsStreamAsync();
            return View(await JsonSerializer.DeserializeAsync<IEnumerable<Haandvaerker>>(responseStream, new JsonSerializerOptions()));
        }

        //TODO Insert


    }
}
