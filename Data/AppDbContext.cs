using Microsoft.EntityFrameworkCore;
using WebAPII.Models;

namespace WebAPII.Data
{
    //Representação do banco em memória
    public class AppDbContext : DbContext
    {
        //DbSet = referencia das tabelas do banco.
        //Mapeando a classe ToDo.cs para uma tabela no banco
        public DbSet<ToDo> ToDos { get; set; }

        //Sobrescrendo o OnConfiguring para setar a "conection string"
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "DataSource=app.db; Cache=Shared");
        }

        /*
        //Escrevendo a mesma propriedade utilizando o arrow function
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(connectionString: "DataSource=app.db; Cache=Shared")
        */
    }
}