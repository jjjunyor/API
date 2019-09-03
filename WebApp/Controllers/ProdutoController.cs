using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Repositories.Contract;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {

        private readonly IProdutoRepository produtoRepository;
        public ProdutoController(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;

        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var produtos = produtoRepository.GetProdutos();
                var json = JsonConvert.SerializeObject(produtos);
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
       [Route("{cdProduto}")]
        public IActionResult GetProduto(int cdProduto)
        {
            try
            {
                var produtos = produtoRepository.GetProdutoByID(cdProduto);
                var json = JsonConvert.SerializeObject(produtos);
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status200OK, json);
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