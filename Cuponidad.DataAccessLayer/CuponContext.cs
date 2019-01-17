using Cuponidad.DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cuponidad.DataAccessLayer
{
    public class CuponContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-4BRLBUI\SQL2014;Initial Catalog=CuponDB;Integrated Security=True");
            //optionsBuilder.UseSqlServer(@"Server=localhost; Database=CuponDB; uid=sa; pwd=fincon@123");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .Property(b => b.Quantity)
                .HasDefaultValue(0);

            modelBuilder.Entity<Category>().HasIndex(p =>  p.CategoryLevelID).IsUnique(false).HasName("Index_CategoryLevelID");
            modelBuilder.Entity<Category>().HasIndex(p =>  p.FamilyID).IsUnique(false).HasName("Index_FamilyID");

            modelBuilder.Entity<Department>().HasData
                (
                new Department { DepartmentID = 1, Name = "Department 1" },
                new Department { DepartmentID = 2, Name = "Department 2" },
                new Department { DepartmentID = 3, Name = "Department 3" }
                );
            modelBuilder.Entity<DropDownListBydays>().HasData
               (
               new DropDownListBydays { DaysOpenID = 1, Name = "FROM LUN. TO DOM (INCIDED HOLIDAY)" },
               new DropDownListBydays { DaysOpenID = 2, Name = " DE LUN. TO DOM (NOT INC. HOLIDAY)" },
               new DropDownListBydays { DaysOpenID = 3, Name = "Only Monday (INC HOLIDAYS)" },
               new DropDownListBydays { DaysOpenID = 4, Name = "Only Monday (NO INC. HOLIDAYS)" }
               );

            modelBuilder.Entity<CategoryLevel>().HasData
                (
                new CategoryLevel { CategoryLevelID = 1, LevelNumber = 1 },
                new CategoryLevel { CategoryLevelID = 2, LevelNumber = 2 },
                new CategoryLevel { CategoryLevelID = 3, LevelNumber = 3 }
                );


            modelBuilder.Entity<Family>().HasData
               (
               new Family { FamilyID = 1, Name = "Productos", ImagePath = "images/a2.png" },
               new Family { FamilyID = 2, Name = "Viajes", ImagePath = "images/f2.png" },
               new Family { FamilyID = 3, Name = "Salud", ImagePath = "images/d2.png" },
               new Family { FamilyID = 4, Name = "Servicios", ImagePath = "images/e2.png" },
               new Family { FamilyID = 5, Name = "Cyber Days ", ImagePath = "images/menucyberday2018v3.png" },
               new Family { FamilyID = 6, Name = "Entretenimiento", ImagePath = "images/entre2c.png" },
               new Family { FamilyID = 7, Name = "Sin Reserva", ImagePath = "images/sinreservaicov2.png" },
               new Family { FamilyID = 8, Name = "Belleza", ImagePath = "images/b2.png" },
               new Family { FamilyID = 9, Name = "Restaurantes", ImagePath = "images/buffet2c.png" },
               new Family { FamilyID = 10, Name = "Cines", ImagePath = "images/g2.png" }
               );
            modelBuilder.Entity<Company>().HasData
               (
               new Company { CompanyID = 1, Phone = "11515455", Direction = "Company 1" },
               new Company { CompanyID = 2, Phone = "65685448", Direction = "Company 2" },
               new Company { CompanyID = 3, Phone = "45487877", Direction = "Company 3" }
               );
           

            modelBuilder.Entity<Category>().HasData
              (
              new Category { CategoryID = 1, CategoryLevelID = 2, FamilyID = 1, Name = "Accesorios Para Auto" },
              new Category { CategoryID = 2, CategoryLevelID = 2, FamilyID = 1, Name = "Camping" },
              new Category { CategoryID = 3, CategoryLevelID = 2, FamilyID = 2, Name = "Año Nuevo" },
              new Category { CategoryID = 4, CategoryLevelID = 2, FamilyID = 2, Name = "Hoteles" },

              new Category { CategoryID = 5, CategoryLevelID = 3, FamilyID = 9, Name = "Buffets" },
              new Category { CategoryID = 6, CategoryLevelID = 3, FamilyID = 6, Name = "Actividades Familiares" },
              new Category { CategoryID = 7, CategoryLevelID = 3, FamilyID = 6, Name = "Teatro" },
              new Category { CategoryID = 8, CategoryLevelID = 3, FamilyID = 8, Name = "Maquillaje y Extensiones" },
              new Category { CategoryID = 9, CategoryLevelID = 3, FamilyID = 4, Name = "Fotografia" }
              );
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CategoryLevel> CategoryLevels { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DropDownListBydays> DropDownListBydays { get; set; }
        public DbSet<RightBanner> RightBanners { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
