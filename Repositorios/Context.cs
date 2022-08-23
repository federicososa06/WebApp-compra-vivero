using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Dominio.EntidadesNegocio;
using Dominio.ParametroConfiguracion;
using Dominio.EntidadNegocio;

namespace Repositorios
{
   public class Context : DbContext
    {
        //Usurios
        public DbSet<Usuario> Usuarios { get; set; }

        //Plantas
        public DbSet<Parametros> Parametros { get; set; }
        public DbSet<Planta> Plantas { get; set; }
        public DbSet<TipoPlanta> TiposPlanta { get; set; }
        public DbSet<TipoIluminacion> TipoIluminacion { get; set; }

        public DbSet<FichaCuidados> FichaCuidados { get; set; }

       

        //Compras
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Item> Items { get; set; }

        public DbSet<CompraImportada> ComprasImportadas { get; set; }
        public DbSet<CompraPlaza> ComprasPlaza { get; set; }


        public Context(DbContextOptions<Context> opciones) : base(opciones) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //PLANTA
            modelBuilder.Entity<Planta>().HasIndex(p => p.NombreCientifico).IsUnique();
            
            //NOMBRE VULGAR
            //Planta tiene N NombresVulgar, NombreVulgar tiene 1 Planta
            modelBuilder.Entity<Planta>().HasMany(p => p.ListaNombreVulgares).WithOne(lnv => lnv.Planta);

            //TIPO PLANTAS
            modelBuilder.Entity<TipoPlanta>().HasIndex(tp=>tp.Nombre).IsUnique();


            // ITEM
            //Planta tiene N Items, Items tiene 1 Planta
            modelBuilder.Entity<Planta>().HasMany(p => p.ListaItems).WithOne(li => li.Planta);

            //Compra tiene N Items, Items tiene 1 Compra
            modelBuilder.Entity<Compra>().HasMany(c => c.ListaItems).WithOne(li => li.Compra);

            //Primary Key compuesta
            modelBuilder.Entity<Item>().HasKey(i => new { i.CompraId, i.PlantaId });

            //Identity de Id(que ya no es PK)
            modelBuilder.Entity<Item>().Property(i => i.Id).ValueGeneratedOnAdd();

            

            base.OnModelCreating(modelBuilder);
        }
    }
}
