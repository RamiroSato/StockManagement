using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Data.Seeds
{
    public class UserRoleSeed : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData(
                new UserRole
                {
                    UserRoleID = 1,
                    RoleName = "Admin",
                },
                new UserRole
                {
                    UserRoleID = 2,
                    RoleName = "Werehouse Manager"
                },
                new UserRole
                {
                    UserRoleID = 3,
                    RoleName = "Batch Manager"
                },
                new UserRole
                {
                    UserRoleID = 4,
                    RoleName = "Clients Manager"
                },
                new UserRole
                {
                    UserRoleID = 5,
                    RoleName = "Sales Manager"
                }
                );
        }
    }
}
