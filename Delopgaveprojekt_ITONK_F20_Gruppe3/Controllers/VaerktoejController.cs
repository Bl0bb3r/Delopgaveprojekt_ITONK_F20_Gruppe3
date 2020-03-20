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
    public class VaerktoejController : ControllerBase
    {
            private IVaerktoejRepository _vaerktoejRepository;
            private readonly ILogger<VaerktoejController> _logger;

            public VaerktoejController(ILogger<VaerktoejController> logger, IVaerktoejRepository vaerktoejRepository)
            {
                _logger = logger;
                _vaerktoejRepository = vaerktoejRepository;
            }

            [HttpGet]
            public List<Models.Vaerktoej> Get()
            {
                return _vaerktoejRepository.GetVaerktoej();
            }

            [HttpGet("{id}")]
            public Models.Vaerktoej Get(int id)
            {
                return _vaerktoejRepository.GetById(id);
            }

            [HttpPost]
            public void Post([FromBody]Models.Vaerktoej vaerktoej)
            {
                _vaerktoejRepository.AddVaerktoej(vaerktoej);
            }

            [HttpPut("{id}")]
            public void Put(int id)
            {
                _vaerktoejRepository.UpdateVaerktoej(id);
            }

            [HttpDelete("{id}")]
            public void Delete(int id)
            {
                _vaerktoejRepository.DeleteVaertoej(id);
            }
    }
}
