﻿using DeliveryOffice.Core.Configurations;
using DeliveryOffice.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryOffice.DataAccess;

public class DeliveryOfficeDbContext : DbContext
{
    /// <remarks>
    ///     dotnet tool install --global dotnet-ef
    ///     dotnet ef migrations add Init --project DeliveryOffice.DataAccess\DeliveryOffice.DataAccess.csproj
    ///     dotnet ef database update --project DeliveryOffice.DataAccess\DeliveryOffice.DataAccess.csproj
    /// </remarks>
    public DeliveryOfficeDbContext(DbContextOptions<DeliveryOfficeDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConfigurationAnchor).Assembly);
    }

    public DbSet<Bill> Bills { get; init; }
    public DbSet<Buyer> Buyers { get; init; }
    public DbSet<Product> Products { get; init; }
    public DbSet<Supplier> Suppliers { get; init; }
}
