using TODOLIST.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace TODOLIST.DBContext
{
    public class ToDoContext : DbContext 
    { 
        public DbSet<User>? Users { get; set; }
        public DbSet<ToDo>? ToDo { get; set; }
        public ToDoContext(DbContextOptions<ToDoContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Email = "ramirodicarlo2@gmail.com",
                    UserId = 1,
                    UserName = "rdic",
                    Address = "Membrives 8911",
                    State = true
                });

            modelBuilder.Entity<ToDo>().HasData(
               new ToDo
               {
                   ToDoId = 1,
                   Title = "Controlers",
                   Description= "Es la descripcion",
                   State = true
               },
               new ToDo
               {
                   ToDoId = 2,
                   Title = "Controlers2",
                   Description = "Es la descripcion",
                   State = true
               },
               new ToDo
               {
                   ToDoId = 3,
                   Title = "Controlers3",
                   Description = "Es la descripcion",
                   State = true
               });
            //relación uno (user) a muchos (todo)
            modelBuilder.Entity<USer>()
                .HasMany(u => u.ToDos);
        }
    }
}

