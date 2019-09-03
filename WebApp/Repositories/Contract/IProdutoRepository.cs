using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Repositories.Contract
{
    public interface IProdutoRepository
    {
      
        IList<Produto> GetProdutos();
        IList<Produto> GetProdutoByID(int cdProduto);
        Produto AdicionarProduto(Produto Produto);
        Produto SalvarProduto(Produto Produto);


    }
}
