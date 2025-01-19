using System;
using System.Data;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using StockManagement.Data.Seeds;
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

    #region Constructors
    public StockManagementContext(DbContextOptions<StockManagementContext> options) : base(options)
    {
    }

    #endregion

    #region Properties

    public DbSet<UserRole>? UserRoles { get => userRoles; set => userRoles = value; }
    public DbSet<Warehouse>? Warehouses { get => warehouses; set => warehouses = value; }
    public DbSet<ProductType>? ProductTypes { get => productTypes; set => productTypes = value; }
    public DbSet<Client>? Clients { get => clients; set => clients = value; }
    public DbSet<Batch>? Batches { get => batches; set => batches = value; }
    public DbSet<Product>? Products { get => products; set => products = value; }
    public DbSet<PreOrder>? PreOrders { get => preOrders; set => preOrders = value; }
    public DbSet<User>? Users { get => users; set => users = value; }
    public DbSet<BatchItem>? BatchItems { get => batchItems; set => batchItems = value; }
    public DbSet<Wishlist>? Wishlists { get => wishlists; set => wishlists = value; }
    public DbSet<PreOrderItem>? PreOrderItems { get => preOrderItems; set => preOrderItems = value; }
    public DbSet<Order>? Orders { get => orders; set => orders = value; }
    public DbSet<Transaction>? Transactions { get => transactions; set => transactions = value; }
    #endregion

    #region Methods

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        #region Entidades Depenencia 0
        modelBuilder.Entity<UserRole>(u =>
        {
            u.HasKey(u => u.UserRoleID);
            u.Property(u => u.RoleName).IsRequired();
            u.Property(u => u.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
            u.Property(u => u.UpdatedAt);
            u.Property(u => u.Active).HasDefaultValue(true);
        });

        modelBuilder.Entity<Warehouse>(w =>
        {
            w.HasKey(w => w.WarehouseID);
            w.Property(w => w.WarehouseID).ValueGeneratedOnAdd();

            w.Property(w => w.WarehouseName).IsRequired();
            w.Property(w => w.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
            w.Property(w => w.UpdatedAt);
            w.Property(w => w.Active).HasDefaultValue(true);
        });

        modelBuilder.Entity<ProductType>(p =>
        {
            p.HasKey(p => p.ProductTypeID);
            p.Property(p => p.ProductTypeID).ValueGeneratedOnAdd();

            p.Property(p => p.TypeName).IsRequired();
            p.Property(p => p.Description).IsRequired();
            p.Property(p => p.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
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
            c.Property(c => c.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
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

            u.Property(u => u.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");

            u.Property(u => u.UpdatedAt);

            u.Property(u => u.Active).HasDefaultValue(true);

            u.HasOne(u => u.UserRole)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.UserRoleID);
        });

        modelBuilder.Entity<Batch>(b =>
        {
            b.HasKey(b => b.BatchID);
            b.Property(b => b.BatchID).ValueGeneratedOnAdd();

            b.Property(b => b.BatchNumber).IsRequired();
            b.HasIndex(b => b.BatchNumber).IsUnique();

            b.Property(b => b.ProductionDate).IsRequired();

            b.Property(b => b.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");

            b.Property(b => b.Active).HasDefaultValue(true);

            b.HasOne(b => b.Warehouse)
                .WithMany(w => w.Batches)
                .HasForeignKey(b => b.WarehouseId);
        });

        modelBuilder.Entity<Product>(p =>
        {
            p.HasKey(p => p.ProductID);
            p.Property(p => p.ProductID).ValueGeneratedOnAdd();

            p.Property(p => p.ProductName).IsRequired();
            p.Property(p => p.Description).IsRequired();
            p.Property(p => p.Price).IsRequired().HasConversion<decimal>();
            p.Property(p => p.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
            p.Property(p => p.UpdatedAt);
            p.Property(p => p.Active).HasDefaultValue(true);

            p.HasOne(p => p.ProductType)
                .WithMany(pt => pt.Products)
                .HasForeignKey(p => p.ProductTypeId);
        });

        modelBuilder.Entity<PreOrder>(po =>
        {
            po.HasKey(p => p.PreOrderID);
            po.Property(p => p.PreOrderID).ValueGeneratedOnAdd();

            po.Property(p => p.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");

            po.Property(p => p.Active).HasDefaultValue(true);

            po.HasOne(p => p.Client)
                .WithMany(c => c.PreOrders)
                .HasForeignKey(p => p.ClientID);

            po.HasOne(po => po.Transaction)
                .WithOne(t => t.PreOrder)
                .HasForeignKey<Transaction>(t => t.PreOrderID);
            
            po.HasOne(po => po.Order)
                .WithOne(o => o.PreOrder)
                .HasForeignKey<Order>(o => o.PreOrderID);

        });

        #endregion

        #region Entidades Depenencia 2

        modelBuilder.Entity<BatchItem>(bi =>
        {
            bi.HasKey(bi => bi.BatchItemID);
            bi.Property(bi => bi.BatchItemID).ValueGeneratedOnAdd();

            bi.Property(bi => bi.Quantity).IsRequired();

            bi.Property(bi => bi.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");

            bi.Property(bi => bi.Active).HasDefaultValue(true);

            bi.HasOne(bi => bi.Batch)
                .WithMany(b => b.BatchItems)
                .HasForeignKey(bi => bi.BatchId);

            bi.HasOne(bi => bi.Product)
                .WithMany(p => p.BatchItems)
                .HasForeignKey(bi => bi.ProductID);
        });

        modelBuilder.Entity<Wishlist>(w =>
        {
            w.HasKey(w => w.WishlistID);
            w.Property(w => w.WishlistID).ValueGeneratedOnAdd();

            w.Property(w => w.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");

            w.Property(w => w.Active).HasDefaultValue(true);

            w.HasOne(w => w.Client)
                .WithMany(c => c.Wishlists)
                .HasForeignKey(w => w.ClientID);

            w.HasMany(w => w.Products)
                .WithMany(p => p.Wishlists)
                .UsingEntity(j => j.ToTable("WishlistProducts"));

        });

        modelBuilder.Entity<PreOrderItem>(poi =>
        {
            poi.HasKey(poi => poi.PreOrderItemID);
            poi.Property(poi => poi.PreOrderItemID).ValueGeneratedOnAdd();

            poi.Property(poi => poi.Quantity).IsRequired();

            poi.Property(poi => poi.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");

            poi.Property(poi => poi.Active).HasDefaultValue(true);

            poi.HasOne(poi => poi.PreOrder)
                .WithMany(po => po.PreOrderItems)
                .HasForeignKey(poi => poi.PreOrderID);

            poi.HasOne(poi => poi.BatchItem)
                .WithMany(bi => bi.PreOrderItems)
                .HasForeignKey(poi => poi.BatchItemID);
        });

        modelBuilder.Entity<Order>(o =>
        {
            o.HasKey(o => o.OrderID);
            o.Property(o => o.OrderID).ValueGeneratedOnAdd();

            o.Property(o => o.OrderNumber).IsRequired().UseIdentityColumn();
            o.HasIndex(o => o.OrderNumber).IsUnique();

            o.Property(o => o.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");

            o.Property(o => o.Active).HasDefaultValue(true);

        });

        modelBuilder.Entity<Transaction>(t =>
        {
            t.HasKey(t => t.TransactionID);
            t.Property(t => t.TransactionID).ValueGeneratedOnAdd();

            t.Property(t => t.TransactionDate).IsRequired();
            t.Property(t => t.Amount).IsRequired().HasConversion<decimal>();

            t.Property(t => t.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");

            t.Property(t => t.Active).HasDefaultValue(true);

        });


        #endregion

        #region Seeds
        modelBuilder.ApplyConfiguration(new UserRoleSeed());

        #endregion
    }

    #endregion
}
