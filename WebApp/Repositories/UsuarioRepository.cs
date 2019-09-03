using global::WebApp.Models;
using global::WebApp.Repositories.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApp.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationContext contexto) : base(contexto)
        {
        }
   

        public bool ValidarLogin(string login, string senha)
        {
            return dbSet.Where(x => x.login == login && x.senha == senha).Any();
        }
        public Usuario GetUsuario(int idUsuario)
        {
            return dbSet.Where(x => x.Id== idUsuario).FirstOrDefault();
        }
        public Usuario GetUsuarioLogin(string  login)
        {
            return dbSet.Where(x => x.login == login).FirstOrDefault();
        }

    }

}



