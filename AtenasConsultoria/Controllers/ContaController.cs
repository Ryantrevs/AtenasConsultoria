using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AtenasConsultoria.Controllers
{
    public class ContaController : Controller
    {
        public IActionResult Registrar()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Registrar(RegistrarViewModel model)
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public Task<IActionResult> Login(LoginViewModel model)
        {
            return View();
        }
    }
}
