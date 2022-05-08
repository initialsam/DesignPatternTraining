using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1;

public class CommerceContext : DbContext
{
    private readonly string connectionString;

    public CommerceContext(string connectionString)
    {
        if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException("Value should not be empty.", nameof(connectionString));

        this.connectionString = connectionString;
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<AuditEntry> AuditEntries { get; set; }
    public DbSet<ProductInventory> ProductInventories { get; set; }
    public DbSet<Order> Orders { get; set; }

    public bool IsNew<TEntity>(TEntity entity) where TEntity : class
    {
        return !this.Set<TEntity>().Local.Any(e => e == entity);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Change this to 'UseSqlServer' to use SQL Server instead.
        optionsBuilder.UseSqlite(this.connectionString);
    }
}


public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal UnitPrice { get; set; }
    public bool IsFeatured { get; set; }
    public bool HasTierPrices { get; set; }
}

public class AuditEntry
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime TimeOfExecution { get; set; }
    public string Operation { get; set; }
    public string Data { get; set; }
}

public class ProductInventory
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
}