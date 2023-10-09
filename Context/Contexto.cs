using BurgerPlace.Models;
using Microsoft.EntityFrameworkCore;

namespace BurgerPlace.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):
base(options){
}
public DbSet<Item> Item {get;set;}
public DbSet<Categoria> Categoria {get;set;}
}
}