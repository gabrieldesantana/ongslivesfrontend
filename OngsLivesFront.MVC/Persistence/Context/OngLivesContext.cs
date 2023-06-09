﻿using Microsoft.EntityFrameworkCore;
using OngsLivesFront.MVC.Models;
namespace ONGLIVES.API.Persistence.Context
{
    public class OngLivesContext : DbContext
    {
        public OngLivesContext(DbContextOptions<OngLivesContext> options) : base(options)
        {
        }

        public DbSet<Voluntario> TB_Voluntarios { get; set; }
        public DbSet<Ong> TB_Ongs { get; set; }
        public DbSet<Vaga> TB_Vagas { get; set; }
        public DbSet<Experiencia> TB_Experiencias { get; set; }
        public DbSet<OngFinanceiro> TB_OngFinanceiros { get; set; }
        public DbSet<Usuario> TB_Usuarios { get; set; }
        public DbSet<Imagem> TB_Imagens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=GSGOMES-DESKTOP\\SQLEXPRESS;DataBase=DB_OngsLives;Integrated Security=SSPI;TrustServerCertificate=True");
            optionsBuilder.UseSqlServer("Server=sv-ongslives.database.windows.net;DataBase=BD_OngsLives;User Id=ongslivesdba;Password=Ongs0707");
        }



    }
}