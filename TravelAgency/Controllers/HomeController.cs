using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UC4_ATV2.Models;

namespace UC4_ATV2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Vitrine()
        {
            PacoteTuristicoDB pacoteTuristicoDB = new PacoteTuristicoDB();
            List<PacoteTuristico> ListaPacote  = pacoteTuristicoDB.Listar();
            return View(ListaPacote);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            UsuarioDB usuarioDB = new UsuarioDB();
            Usuario usuarioSessao = usuarioDB.TesteLogin(usuario);

            if(usuarioSessao != null) 
            {
                ViewBag.Mensagem="Você está logado!";
                HttpContext.Session.SetInt32("IdUsuario", usuarioSessao.Id);
                HttpContext.Session.SetString("NomeUsuario", usuarioSessao.Nome);

                 return View();
            } else {
                ViewBag.Mensagem = "Falha no login!";
                return View();
            }
        }
        public IActionResult Index()
        {
            PacoteTuristicoDB pacoteTuristicoDB = new PacoteTuristicoDB();
            List<PacoteTuristico> ListaPacote = pacoteTuristicoDB.Listar();
            return View(ListaPacote);
        }
            public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }

    }
}
