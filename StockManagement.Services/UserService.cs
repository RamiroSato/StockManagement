using System;
using StockManagement.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using StockManagement.Interfaces;
using StockManagement.Models;
using StockManagement.Exceptions;

namespace StockManagement.Services;

public class UserService : IUserService
{
    public StockManagementContext _context;

    public UserService(StockManagementContext context)
    {
        _context = context;
    }

    public async Task<User> CreateAsync(User entity)
    {
        await _context.Users.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            throw new ResourceNotFoundException("User not found");
        }
        return user;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> UpdateAsync(User entity)
    {
        _context.Users.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            throw new ResourceNotFoundException("User to delete not found");
        }
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }
    
}
