using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using StockManagement.Models;

namespace StockManagement.Data.Contexts;

public class StockManagementContext : DbContext
{
    #region Private Variables

    #region Entidades Depenencia 0
    DbSet<UserRole>? userRoles;
    DbSet<Warehouse>? warehouses;
    DbSet<ProductType>? productTypes;
    DbSet<Client>? clients;
    #endregion

    #region Entidades Depenencia 1
    DbSet<Batch>? batches;
    DbSet<Product>? products;
    DbSet<PreOrder>? preOrders;
    DbSet<User>? users;
    #endregion

    #region Entidades Depenencia 2
    DbSet<BatchItem>? batchItems;
    DbSet<Wishlist>? wishlists;
    DbSet<PreOrderItem>? preOrderItems;
    DbSet<Order>? orders;
    DbSet<Transaction>? transactions;
    #endregion

    #endregion

    #region Properties

    public DbSet<UserRole> UserRoles
    {
        get
        {
            if (userRoles == null)
            {
                throw new DataException("UserRoles DbSet is not initialized");
            }
            return userRoles;
        }
        set => userRoles = value;
    }

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

        #region Entidades Depenencia 0
        modelBuilder.Entity<UserRole>(u =>
        {
            u.HasKey(u => u.RoleID);
            u.Property(u => u.RoleName).IsRequired();
            u.Property(u => u.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);
            u.Property(u => u.UpdatedAt);
            u.Property(u => u.Active).HasDefaultValue(true);
        });

        modelBuilder.Entity<Warehouse>(w =>
        {
            w.HasKey(w => w.WarehouseID);
            w.Property(w => w.WarehouseID).ValueGeneratedOnAdd();

            w.Property(w => w.WarehouseName).IsRequired();
            w.Property(w => w.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);
            w.Property(w => w.UpdatedAt);
            w.Property(w => w.Active).HasDefaultValue(true);
        });

        modelBuilder.Entity<ProductType>(p =>
        {
            p.HasKey(p => p.ProductTypeID);
            p.Property(p => p.ProductTypeID).ValueGeneratedOnAdd();

            p.Property(p => p.TypeName).IsRequired();
            p.Property(p => p.Description).IsRequired();
            p.Property(p => p.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);
            p.Property(p => p.UpdatedAt);
            p.Property(p => p.Active).HasDefaultValue(true);
        });

        modelBuilder.Entity<Client>(c =>
        {
            c.HasKey(c => c.ClientID);
            c.Property(c => c.ClientID).ValueGeneratedOnAdd();

            c.Property(c => c.FirstName).IsRequired();
            c.Property(c => c.LastName).IsRequired();
            c.Property(c => c.Email).IsRequired();
            c.Property(c => c.Phone).IsRequired();
            c.Property(c => c.Address).IsRequired();
            c.Property(c => c.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);
            c.Property(c => c.UpdatedAt);
            c.Property(c => c.Active).HasDefaultValue(true);
        });

        #endregion

        #region Entidades Depenencia 1
        modelBuilder.Entity<User>(u =>
        {
            u.HasKey(u => u.UserID);
            u.Property(u => u.UserID).ValueGeneratedOnAdd();

            u.Property(u => u.Username).IsRequired().HasMaxLength(50);
            u.HasIndex(u => u.Username).IsUnique();

            u.Property(u => u.PasswordHash).IsRequired();

            u.Property(u => u.Email).IsRequired();
            u.HasIndex(u => u.Email).IsUnique();

            //u.Property(u => u.RoleID).IsRequired();

            u.Property(u => u.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);

            u.Property(u => u.UpdatedAt);

            u.Property(u => u.Active).HasDefaultValue(true);

            u.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.Role);
        });

        modelBuilder.Entity<Batch>(b =>
        {
            b.HasKey(b => b.BatchID);
            b.Property(b => b.BatchID).ValueGeneratedOnAdd();

            b.Property(b => b.BatchNumber).IsRequired();
            b.HasIndex(b => b.BatchNumber).IsUnique();

            b.Property(b => b.ProductionDate).IsRequired();

            b.Property(b => b.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);

            b.Property(b => b.Active).HasDefaultValue(true);

            b.HasOne(b => b.Warehouse)
                .WithMany(w => w.Batches)
                .HasForeignKey(b => b.Warehouse);
        });

        modelBuilder.Entity<Product>(p =>
        {
            p.HasKey(p => p.ProductID);
            p.Property(p => p.ProductID).ValueGeneratedOnAdd();

            p.Property(p => p.ProductName).IsRequired();
            p.Property(p => p.Description).IsRequired();
            p.Property(p => p.Price).IsRequired();
            p.Property(p => p.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);
            p.Property(p => p.UpdatedAt);
            p.Property(p => p.Active).HasDefaultValue(true);

            p.HasOne(p => p.ProductType)
                .WithMany(pt => pt.Products)
                .HasForeignKey(p => p.ProductType);
        });

        modelBuilder.Entity<PreOrder>(p =>
        {
            p.HasKey(p => p.PreOrderID);
            p.Property(p => p.PreOrderID).ValueGeneratedOnAdd();

            p.Property(p => p.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);

            p.Property(p => p.Active).HasDefaultValue(true);

            p.HasOne(p => p.Client)
                .WithMany(c => c.PreOrders)
                .HasForeignKey(p => p.Client);
        });

        #endregion

        #region Entidades Depenencia 2

        modelBuilder.Entity<BatchItem>(bi =>
        {
            bi.HasKey(bi => bi.BatchItemID);
            bi.Property(bi => bi.BatchItemID).ValueGeneratedOnAdd();

            bi.Property(bi => bi.Quantity).IsRequired();

            bi.Property(bi => bi.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);

            bi.Property(bi => bi.Active).HasDefaultValue(true);

            bi.HasOne(bi => bi.Batch)
                .WithMany(b => b.BatchItems)
                .HasForeignKey(bi => bi.Batch);

            bi.HasOne(bi => bi.Product)
                .WithMany(p => p.BatchItems)
                .HasForeignKey(bi => bi.Product);
        });

        modelBuilder.Entity<Wishlist>(w =>
        {
            w.HasKey(w => w.WishlistID);
            w.Property(w => w.WishlistID).ValueGeneratedOnAdd();

            w.Property(w => w.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);

            w.Property(w => w.Active).HasDefaultValue(true);

            w.HasOne(w => w.Client)
                .WithMany(c => c.Wishlists)
                .HasForeignKey(w => w.Client);

            w.HasMany(w => w.Products)
                .WithMany(p => p.Wishlists)
                .UsingEntity(j => j.ToTable("WishlistProducts"));
            
        });

        modelBuilder.Entity<PreOrderItem>(poi =>
        {
            poi.HasKey(poi => poi.PreOrderItemID);
            poi.Property(poi => poi.PreOrderItemID).ValueGeneratedOnAdd();

            poi.Property(poi => poi.Quantity).IsRequired();

            poi.Property(poi => poi.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);

            poi.Property(poi => poi.Active).HasDefaultValue(true);

            poi.HasOne(poi => poi.PreOrder)
                .WithMany(po => po.PreOrderItems)
                .HasForeignKey(poi => poi.PreOrder);

            poi.HasOne(poi => poi.BatchItem)
                .WithMany(bi => bi.PreOrderItems)
                .HasForeignKey(poi => poi.BatchItem);
        });

        modelBuilder.Entity<Order>(o =>
        {
            o.HasKey(o => o.OrderID);
            o.Property(o => o.OrderID).ValueGeneratedOnAdd();

            o.Property(o => o.OrderNumber).IsRequired().ValueGeneratedOnAdd();
            o.HasIndex(o => o.OrderNumber).IsUnique();

            o.Property(o => o.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);

            o.Property(o => o.Active).HasDefaultValue(true);

            o.HasOne(o => o.PreOrder)
                .WithOne(po => po.Order)
                .HasForeignKey<Order>(o => o.PreOrder);
        });

        modelBuilder.Entity<Transaction>(t =>
        {
            t.HasKey(t => t.TransactionID);
            t.Property(t => t.TransactionID).ValueGeneratedOnAdd();

            t.Property(t => t.TransactionDate).IsRequired();

            t.Property(t => t.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);

            t.Property(t => t.Active).HasDefaultValue(true);

            t.HasOne(t => t.PreOrder)
            .WithOne(po => po.Transaction)
            .HasForeignKey<Transaction>(t => t.PreOrder);

        });
        
        
        #endregion
    }

    #endregion
}
