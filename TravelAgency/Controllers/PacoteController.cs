using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using UC4_ATV2.Models;

namespace UC4_ATV2.Controllers
{
    public class PacoteController : Controller
    {
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
                ViewBag.Mensagem = "Você está logado!";
                HttpContext.Session.SetInt32("IdUsuario", usuarioSessao.Id);
                HttpContext.Session.SetString("NomeUsuario", usuarioSessao.Nome);

                return View();
            }
            else
            {
                ViewBag.Mensagem = "Falha no login!";
                return View();
            }
        }
        
        public IActionResult CadastroPacote()
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");

            return View();
        }
        [HttpPost]
        public IActionResult CadastroPacote(PacoteTuristico pacoteTuristico)
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");
            PacoteTuristicoDB pacoteTuristicoDB = new PacoteTuristicoDB();
            pacoteTuristicoDB.Inserir(pacoteTuristico);
            ViewBag.Mensagem = "Cadastro de pacote finalizado!";
            
            return View();
        }
        public IActionResult ListaPacote()
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");

            PacoteTuristicoDB pacoteTuristicoDB = new PacoteTuristicoDB();
            List<PacoteTuristico> ListaPacote = pacoteTuristicoDB.Listar();
            return View(ListaPacote);
        }
        public IActionResult EditarPacote(int Id)
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");
            PacoteTuristicoDB pacoteTuristicoDB = new PacoteTuristicoDB();
            PacoteTuristico pacoteTuristico = pacoteTuristicoDB.BuscarPorId(Id);
            return View(pacoteTuristico); 
        }
        [HttpPost]
        public IActionResult EditarPacote(PacoteTuristico pacoteTuristico)
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");            
            PacoteTuristicoDB pacoteTuristicoDB = new PacoteTuristicoDB();
            pacoteTuristicoDB.Atualizar(pacoteTuristico);
            ViewBag.Mensagem = "Pacote de viagem atualizado com sucesso!";
            return RedirectToAction("ListaPacote");
        }
        public IActionResult Remover(int Id)
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login");
            }
            else{
                PacoteTuristicoDB pacoteTuristicoDB = new PacoteTuristicoDB();
                pacoteTuristicoDB.Remover(Id);
                return RedirectToAction("ListaPacote"); 
            }          
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }

}   }