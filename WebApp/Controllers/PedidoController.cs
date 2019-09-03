using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Models;
using WebApp.Repositories.Contract;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Pedido")]
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository PedidoRepository;
        private readonly IUsuarioRepository UsuarioRepository;
        private readonly IProdutoRepository ProdutoRepository;
        private readonly IItemPediddoRepository IItemPediddoRepository;
        public PedidoController
            (IPedidoRepository _pedidoRepository,
            IUsuarioRepository _usuarioRepository,
            IProdutoRepository _produtoRepository,
            IItemPediddoRepository _itemPediddoRepository)
        {
            this.PedidoRepository = _pedidoRepository;
            this.UsuarioRepository = _usuarioRepository;
            this.ProdutoRepository = _produtoRepository;
            this.IItemPediddoRepository = _itemPediddoRepository;

        }
        [HttpGet]
        [Route("usuario/{idUsuario}")]
        public IActionResult Get(int idUsuario)
        {
            try
            {
                var produtos = PedidoRepository.GetPedido(0, idUsuario);
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status200OK, produtos);
            }
            catch (Exception ex)
            {
                var msg = string.Format("Ecommerce - Buscar pedidos - Msg: {0} - StackTrace:{1}", ex.Message, ex.StackTrace);
                EventLog.WriteEntry("FieldServices", msg, EventLogEntryType.Error);
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, msg);
            }
        }
        [HttpGet]
        [Route("{codigoPedido}")]
        public IActionResult ConsultarPedido(int codigoPedido)
        {
            try
            {
                var produtos = PedidoRepository.GetPedido(codigoPedido);
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status200OK, produtos);
            }
            catch (Exception ex)
            {
                var msg = string.Format("Ecommerce - Buscar pedidos - Msg: {0} - StackTrace:{1}", ex.Message, ex.StackTrace);
                EventLog.WriteEntry("FieldServices", msg, EventLogEntryType.Error);
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, msg);
            }
        }
        [HttpPost]
        public IActionResult Adicionar([FromBody]Cadastro obj)
        {
            Pedido pedido = new Pedido();

            try
            {
                if(obj.idProduto == 0 || obj.idUsuario == 0|| obj.quantidade==0)
                    return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status451UnavailableForLegalReasons, new {  msg = "Favor, preencher todos os campos obrigatório!" });

                var usuario = UsuarioRepository.GetUsuario(obj.idUsuario);
                var produto = ProdutoRepository.GetProdutoByID(obj.idProduto).FirstOrDefault();
                var pedidoECM = PedidoRepository.GetPedidobyID(obj.idPedido);
                ItensPedido itensPedido = CarregarPedido(obj, pedido, usuario, produto, pedidoECM);
                var item = IItemPediddoRepository.Add(itensPedido);
                var json = new { Pedido = item.Pedido.Id, itemID = item.Id, msg = "Item gravado com sucesso!" };
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status200OK, json);
            }
            catch (Exception ex)
            {
                var msg = string.Format("Ecommerce - adicionar pedidos - Msg: {0} - StackTrace:{1}", ex.Message, ex.StackTrace);
                EventLog.WriteEntry("FieldServices", msg, EventLogEntryType.Error);
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, msg);
            }
        }

        private static ItensPedido CarregarPedido(Cadastro obj, Pedido pedido, Usuario usuario, Produto produto, Pedido pedidoECM)
        {
            pedido.Usuario = usuario;
            pedido.valorTotal = (produto.PrecoUnitario * obj.quantidade);
            ItensPedido itensPedido = new ItensPedido()
            {
                Pedido = new Pedido()
                {
                    Usuario = usuario
                },
                Quantidade = obj.quantidade,
                Produto = produto

            };
            if (pedidoECM != null) // alterar pedido
                itensPedido.Pedido = pedidoECM;
            return itensPedido;
        }
    }
}