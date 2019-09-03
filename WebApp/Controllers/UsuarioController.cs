using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repositories.Contract;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/usuario")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository usuarioRepository;
        public UsuarioController(IUsuarioRepository _usuarioRepository)
        {
            this.usuarioRepository = _usuarioRepository;

        }
        [HttpPost]
        [Route("validarlogin")]
        public IActionResult ValidarLogin([FromBody] Usuario obj)
        {
            try
            {
                var acesso = usuarioRepository.ValidarLogin(obj.login, obj.senha);
                var json = new { acesso = acesso };

                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status200OK, json);
            }
            catch (Exception ex)
            {
                var msg = string.Format("Ecommerce - Buscar Produtos - Msg: {0} - StackTrace:{1}", ex.Message, ex.StackTrace);
                EventLog.WriteEntry("FieldServices", msg, EventLogEntryType.Error);
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, msg);
            }
        }
        [HttpGet]
        [Route("{login}")]
        public IActionResult getUserLogin(string login)
        {
            try
            {
                var usuario = usuarioRepository.GetUsuarioLogin(login);
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status200OK, usuario);
            }
            catch (Exception ex)
            {
                var msg = string.Format("Ecommerce - Buscar Produtos - Msg: {0} - StackTrace:{1}", ex.Message, ex.StackTrace);
                EventLog.WriteEntry("FieldServices", msg, EventLogEntryType.Error);
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, msg);
            }
        }

     

    }

}