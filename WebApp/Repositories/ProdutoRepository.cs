


using global::WebApp.Models;
using global::WebApp.Repositories.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApp.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext contexto) : base(contexto)
        {
        }
        /// <summary>
        /// Buscar os Produtos
        /// </summary>
        /// <returns></returns>
        public IList<Produto> GetProdutos()
       {
            return dbSet.ToList();
        }
        public IList<Produto> GetProdutoByID(int cdProduto)
        {
            try
            {
                var produto = contexto.Set<Produto>()
                                .Where(p => p.Id == cdProduto)
                                .ToList();
                return  produto;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

           
        }
        public Produto AdicionarProduto(Produto Produto)
        {
            try
            {
                contexto.Add(Produto);
                contexto.SaveChanges();
                return Produto;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }

        }
        public Produto SalvarProduto(Produto Produto)
        {
            try
            {
                var produto = contexto.Set<Produto>()
                              .Where(p => p.Id == Produto.Id)
                              .SingleOrDefault();


                produto.descricao = Produto.descricao;
                produto.qtdDisponivel = Produto.qtdDisponivel;
                

                contexto.SaveChanges();
                return Produto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }

}



