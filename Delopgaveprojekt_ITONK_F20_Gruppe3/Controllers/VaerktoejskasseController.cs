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
    public class VaerktoejskasseController : ControllerBase
    {
        private IVaerktoejskasseRepository _vaerktoejskasseRepository;
        private readonly ILogger<VaerktoejskasseController> _logger;

        public VaerktoejskasseController(ILogger<VaerktoejskasseController> logger, IVaerktoejskasseRepository vaerktoejskasseRepository)
        {
            _logger = logger;
            _vaerktoejskasseRepository = vaerktoejskasseRepository;
        }

        [HttpGet]
        public List<Models.Vaerktoejskasse> Get()
        {
            return _vaerktoejskasseRepository.GetVaerktoejskasse();
        }

        [HttpGet("{id}")]
        public Models.Vaerktoejskasse Get(int id)
        {
            return _vaerktoejskasseRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody]Models.Vaerktoejskasse vaerktoejskasse)
        {
            _vaerktoejskasseRepository.AddVaerktøjskasse(vaerktoejskasse);
        }

        [HttpPut("{id}")]
        public void Put(int id)
        {
            _vaerktoejskasseRepository.UpdateVaerktoejskasse(id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _vaerktoejskasseRepository.DeleteVaerktoejskasse(id);
        }
    }
}
