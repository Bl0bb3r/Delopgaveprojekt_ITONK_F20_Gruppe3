using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Delopgaveprojekt_ITONK_F20_Gruppe3_Frontend.AppDbFrontendContext;
using Delopgaveprojekt_ITONK_F20_Gruppe3_Frontend.Models;

namespace Delopgaveprojekt_ITONK_F20_Gruppe3_Frontend.Controllers
{
    public class VaerktoejsKasseController : Controller
    {
        private readonly AppDbFrontendContext.AppDbFrontendContext _context;

        public VaerktoejsKasseController(AppDbFrontendContext.AppDbFrontendContext context)
        {
            _context = context;
        }


        //TODO Insert

    }
}
