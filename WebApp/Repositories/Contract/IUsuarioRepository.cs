
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Repositories.Contract
{
    public interface IUsuarioRepository
    {

        bool ValidarLogin(string login, string senha);
        Usuario GetUsuario(int idUsuario);
        Usuario GetUsuarioLogin(string login);



    }
}
