using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

//add new context, add new model here 
//run new migration, will read context, which reference model, define that model should be table in database, will be created inside migrations folder


namespace netCoreAPI.Services
{
    public class ToDo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public int Priority { get; set; }

        public DateTime CreatedOn { get; set; }
    }
    public class TodoContext : DbContext
    {

        //constructor to pass context of DB to base constructor
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }
        public DbSet<ToDo> ToDos { get; set; }


        //insert some seeded data directly 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //when model is created, these items will be added to SQLite DB
            modelBuilder.Entity<ToDo>().HasData(
                new { Id = 1, Description = "Clean house", IsComplete = false, Priority = 1, CreatedOn = DateTime.Now},
                new { Id = 2, Description = "Bake cake", IsComplete = false, Priority = 3, CreatedOn = DateTime.Now }
            );
        }
    }
}
