using Delopgaveprojekt_ITONK_F20_Gruppe3.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delopgaveprojekt_ITONK_F20_Gruppe3.Controllers
{
    [Route("api/[controller]")]
    public class HaandvaerkerController : ControllerBase
    {
        private IHaandvaerkerRepository _haandvaerkerRepository;
        private readonly ILogger<HaandvaerkerController> _logger;

        public HaandvaerkerController(ILogger<HaandvaerkerController> logger, IHaandvaerkerRepository haandvaerkerRepository)
        {
            _logger = logger;
            _haandvaerkerRepository = haandvaerkerRepository;
        }

        [HttpGet]
        public List<Models.Haandvaerker> Get()
        {
            return _haandvaerkerRepository.GetHaandvaerkers();
        }

        [HttpGet("{id}")]
        public Models.Haandvaerker Get(int id)
        {
            return _haandvaerkerRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody]Models.Haandvaerker haandvaerker)
        {
            _haandvaerkerRepository.AddHaandvaerker(haandvaerker);
        }

        [HttpPut("{id}")]
        public void Put(int id)
        {
            _haandvaerkerRepository.UpdateHaandvaerker(id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _haandvaerkerRepository.DeleteHaandvaerker(id);
        }

    }
}
