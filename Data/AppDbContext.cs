using Microsoft.EntityFrameworkCore;
using DimDimAPP.Models;

namespace DimDimAPP.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Clientes => Set<Cliente>();
}