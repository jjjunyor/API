using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Repositories
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected readonly ApplicationContext contexto;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(ApplicationContext contexto)
        {
            this.contexto = contexto;
            dbSet = contexto.Set<T>();
        }
       
    }
}
