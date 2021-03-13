  
using System.Collections.Generic;
using UC4_ATV2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UC4_ATV2.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult ListaUser()
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");

            UsuarioDB usuarioDB = new UsuarioDB();
            List<Usuario> Lista = usuarioDB.ListarUser();
            return View(Lista);
        }

        public IActionResult CadastroUser()
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");

            return View();
        }

        [HttpPost]
        public IActionResult CadastroUser(Usuario usuario)
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");            
            UsuarioDB usuarioDB = new UsuarioDB();
            usuarioDB.InserirUser(usuario);
            ViewBag.Mensagem = "Cadastro realizado com sucesso!";
            return View();            
        }


        public IActionResult EditarUser(int Id)
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");
            UsuarioDB usuarioDB = new UsuarioDB();
            Usuario usuario = usuarioDB.BuscarPorIdUser(Id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult EditarUser(Usuario usuario)
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");            
            UsuarioDB usuarioDB = new UsuarioDB();
            usuarioDB.AtualizarUser(usuario);
            ViewBag.Mensagem = "Usuario atualizado com sucesso!";
            return RedirectToAction("ListaUser");
        }

        public IActionResult RemoverUser(int Id)
        {
            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");
            UsuarioDB usuarioDB = new UsuarioDB();
            usuarioDB.RemoverUser(Id);
            return RedirectToAction("ListaUser");           
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            UsuarioDB usuarioDB= new UsuarioDB();
            Usuario usuarioSessao = usuarioDB.TesteLogin(usuario);

            if(usuarioSessao != null) 
            {
                ViewBag.Mensagem="Você está logado!";
                HttpContext.Session.SetInt32("IdUsuario", usuarioSessao.Id);
                HttpContext.Session.SetString("NomeUsuario", usuarioSessao.Nome);

                return View();
            } 
            else {
                ViewBag.Mensagem = "Falha no login!";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
    }
}