using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Framework.Domain.Entity;

namespace Framework.InfraStructure.Data
{
    public class EFConnectionFactory:DbContext
    {

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Facturas> Facturas { get; set; }
        public DbSet<Detalles> Detalles { get; set; }
        public DbSet<Productos> Productos { get; set; }

        public EFConnectionFactory(DbContextOptions<EFConnectionFactory> options) : base(options) 
        { 
        
        }

       
    }
}
