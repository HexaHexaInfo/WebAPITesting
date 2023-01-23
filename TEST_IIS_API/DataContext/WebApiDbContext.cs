using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TEST_IIS_API.Models;

namespace TEST_IIS_API.DataContext;

public partial class WebApiDbContext : DbContext
{
    

    public WebApiDbContext(DbContextOptions<WebApiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bed> Beds { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Student> Students { get; set; }

   
}
