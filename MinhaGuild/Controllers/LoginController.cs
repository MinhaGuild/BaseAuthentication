using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.Base.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Model.Base.DataFake;
using Model.Base.Models;

namespace MinhaGuild.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult> Authenticate([FromBody]User model)
        {
            //UserRepository é uma classe que simula a busca dos dados do usuário em um banco de dados. Substitua para deixar da forma que deseja e necessita para autenticar o usuário.
            var user = UserRepository.Get(model.Username, model.Password);
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user, AppSettings.Secret);
            user.Password = "";

            return Ok(new { user = user, token = token });
        }

        [HttpGet]
        [Authorize]
        [Route("autorizado")]
        public async Task<ActionResult> Autorized()
        {
            //Este endpoint deve ser acessivel somente quando um usuário está autenticado na aplicação.
            return Ok(new { message = "Você está autorizado." });
        }

        [HttpGet]
        [Route("autorizado2")]
        [Authorize(Roles = "employee,manager")]
        public async Task<ActionResult> Autorized2()
        {
            //Este endpoint deve ser acessivel somente quando um usuário está autenticado na aplicação e esteja associado a uma Role "employee" ou "manager".
            return Ok(new { message = "Você está autorizado pera role." });
        }

        [HttpGet]
        [Route("autorizado3")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult> Autorized3()
        {//Este endpoint deve ser acessivel somente quando um usuário está autenticado na aplicação e esteeja associado a Role "manager".
            return Ok(new { message = "Você está autorizado pera role Manager." });
        }
    }
}