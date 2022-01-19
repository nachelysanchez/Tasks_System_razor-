using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks_System_razor.Entidades;

namespace Tasks_System_razor.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Tareas> Tareas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!(optionsBuilder.IsConfigured))
            {
                optionsBuilder.UseSqlite($"Data Source = Data\\Tasks.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tareas>().HasData(new Tareas
            {
                TareaId = 1,
                Nombre = "Análisis",
                Descripcion = "La persona X debe de analizar el sistema que su superior le asignó."
            });
        }
    }
}
