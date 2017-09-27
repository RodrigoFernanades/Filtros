using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Filtros.Models;

namespace Filtros.Models
{
    public class K19Context : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
    }
}