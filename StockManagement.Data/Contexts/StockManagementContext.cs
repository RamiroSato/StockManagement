using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using StockManagement.Models;

namespace StockManagement.Data.Contexts;

public class StockManagementContext : DbContext
{
    #region Private Variables
    DbSet<User>? users;
    DbSet<ProductType>? productTypes;
    DbSet<Product>? products;
    DbSet<Warehouse>? warehouses;
    #endregion

    #region Properties

    public DbSet<User> Users
    {
        get
        {
            if (users == null)
            {
                throw new DataException("Users DbSet is not initialized");
            }
            return users;
        }
        set => users = value;
    }

    public DbSet<ProductType> ProductTypes
    {
        get
        {
            if (productTypes == null)
            {
                throw new DataException("ProductTypes DbSet is not initialized");
            }
            return productTypes;
        }
        set => productTypes = value;
    }

    public DbSet<Product> Products
    {
        get
        {
            if (products == null)
            {
                throw new DataException("Products DbSet is not initialized");
            }
            return products;
        }
        set => products = value;
    }

    public DbSet<Warehouse> Warehouses
    {
        get
        {
            if (warehouses == null)
            {
                throw new DataException("Warehouses DbSet is not initialized");
            }
            return warehouses;
        }
        set => warehouses = value;
    }

    #endregion

    #region Constructors
    public StockManagementContext(DbContextOptions<StockManagementContext> options) : base(options)
    {
    }
    #endregion

    #region Methods

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        #region UserRole
        modelBuilder.Entity<UserRole>(u =>
        {
            u.HasKey(u => u.RoleID);
            u.Property(u => u.RoleName).IsRequired();
            u.Property(u => u.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
            u.Property(u => u.UpdatedAt);
            u.Property(u => u.Active).HasDefaultValue(true);
        });
        #endregion

        #region User
        modelBuilder.Entity<User>( u =>
            {
                u.HasKey(u => u.ID);
                u.Property(u => u.Username).IsRequired().HasMaxLength(50);
                u.HasIndex(u => u.Username).IsUnique();
                u.Property(u => u.PasswordHash).IsRequired();
                u.Property(u => u.Email).IsRequired();
                u.HasIndex(u => u.Email).IsUnique();
                u.Property(u => u.RoleID).IsRequired();
                u.Property(u => u.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);
                u.Property(u => u.UpdatedAt);
                u.Property(u => u.Active).HasDefaultValue(true);
                u.HasOne(u => u.Role).WithMany().HasForeignKey(u => u.RoleID);
            }
        );
        #endregion
    }

    #endregion
}
