using DogShelter.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DogShelter.Models.Employee;
using DogShelter.Models.Adoptive;

namespace PriutZaKucheta.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Adoptive> Adoptives { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<RequestDog> RequestDogs { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
       
    }
}
