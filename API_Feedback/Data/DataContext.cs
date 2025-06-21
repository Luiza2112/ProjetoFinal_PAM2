using System;
//using API_Feedback.Controllers;
using API_Feedback.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;


namespace API_Feedback.Data
{
    public class DataContext : DbContext // Organiza todas as entidades do Banco
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Feedback> TB_FEEDBACKS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //Durante a criação do modelo de Banco, faça algo. Só pode ter uma classe OnModelCreating
        {
            modelBuilder.Entity<Feedback>().ToTable("TB_FEEDBACKS");

            modelBuilder.Entity<Feedback>().HasData
            (
                new Feedback() { Id = 1, Remetente = "Kelly", Destinatario = "Daniela", Descricao = "O ventilador da sala 7 foi concertado com sucesso. Favor dar baixa no chamado pelo sistema.", Data = new DateTime(2025, 4, 10, 8, 5, 20) }, //ano, mês, dia, hora, minuto, segundo
                new Feedback() { Id = 2, Remetente = "Marion", Destinatario = "Lucas", Descricao = "A visita do técnico precisou ser adiada, peço que aguarde mais alguns dias até a resolução do problema no pc do lab 4.", Data = new DateTime(2025, 4, 15, 12, 50, 31) },
                new Feedback() { Id = 3, Remetente = "Marion", Destinatario = "Lucas", Descricao = "A tela do pc do lab 4 foi trocada com sucesso, agradeço a paciencia. Favor dar baixa no chamado pelo sistema.", Data = new DateTime(2025, 4, 18, 7, 15, 44) },
                new Feedback() { Id = 4, Remetente = "Luis", Destinatario = "Aline", Descricao = "Os mouses defeituosos do lab 2 foram substituídos com sucesso. Favor dar baixa no chamado pelo sistema.", Data = new DateTime(2025, 4, 28, 17, 2, 28) },
                new Feedback() { Id = 5, Remetente = "Flávio", Destinatario = "Roberto", Descricao = "Já encomendamos o vidro para a janela quebrada da sala 17 e o problema será resolvido o quanto antes.", Data = new DateTime(2025, 5, 11, 13, 34, 12) },
                new Feedback() { Id = 6, Remetente = "Flávio", Destinatario = "Roberto", Descricao = "A janela da sala 17 foi concertada com sucesso. Favor dar baixa no chamado pelo sistema.", Data = new DateTime(2025, 5, 13, 9, 37, 53) },
                new Feedback() { Id = 7, Remetente = "Amanda", Destinatario = "Carlos", Descricao = "O vazamento nos bebedouros do pátio foi resolvido imediatamente, agradecemos o aviso. Favor dar baixa no chamado pelo sistema.", Data = new DateTime(2025, 5, 21, 14, 16, 49) }
            );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Elimina o erro do dotnet database update
        {
            optionsBuilder.ConfigureWarnings(warnings =>
              warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
    }
}