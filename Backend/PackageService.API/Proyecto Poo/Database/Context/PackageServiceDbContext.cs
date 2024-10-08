﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Proyecto_Poo.Database.Entity;
using Proyecto_Poo.Service;
using Proyecto_Poo.Service.Interface;

namespace Proyecto_Poo.Database.Contex
{
    public class PackageServiceDbContext : DbContext
    {
        private readonly IAuthService _authService;

        public PackageServiceDbContext(DbContextOptions<PackageServiceDbContext> options, IAuthService authService) : base(options)
        {
            _authService = authService;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is OrderEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = entry.Entity as OrderEntity;
                if (entity != null && entry.State == EntityState.Added)
                {
                    entity.OrderDate = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<PackageEntity> Packages { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<StopPointEntity> StopPoints { get; set; }
        public DbSet<PaymentEntity> Total {  get; set; }
        public DbSet<RouteEntity> Routes { get; set; } // Corrige el nombre a 'Routes'
        public DbSet<ShipmentEntity> Pay { get; set; }
    }
}

