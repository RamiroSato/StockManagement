using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using StockManagement.Models;

namespace StockManagement.Data.Contexts;

public class StockManagementContext : DbContext
{
    #region Private Variables
    private DbSet<User>? users;    
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
        set
        {
            users = value;
        }
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
        #region User
        modelBuilder.Entity<User>( u =>
            {
                u.HasKey(u => u.ID);
                u.Property(u => u.Username).IsRequired();
                u.Property(u => u.PasswordHash).IsRequired();
                u.Property(u => u.Email).IsRequired();
                u.Property(u => u.Role).IsRequired();
                u.Property(u => u.CreatedAt).IsRequired();
                u.Property(u => u.UpdatedAt);
                u.Property(u => u.Active).IsRequired();
            }
        );
        #endregion
    }

    #endregion
}
