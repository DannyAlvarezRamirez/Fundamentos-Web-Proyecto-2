using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto_2.Models;

namespace Proyecto_2.Data
{
    public class Proyecto_2Context : DbContext
    {
        public Proyecto_2Context (DbContextOptions<Proyecto_2Context> options)
            : base(options)
        {
        }

        public DbSet<Proyecto_2.Models.Cliente> Cliente { get; set; }

        public DbSet<Proyecto_2.Models.ProyectoCliente> ProyectoCliente { get; set; }
    }
}
