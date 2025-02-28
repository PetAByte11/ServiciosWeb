<<<<<<< HEAD
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;
=======
namespace API.Data;
using API.DataEntities;
using Microsoft.EntityFrameworkCore;
>>>>>>> datingapp/main

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<AppUser> Users { get; set; }
}
