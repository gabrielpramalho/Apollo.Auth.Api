using Apollo.Auth.Api.Interface.Models;
using Microsoft.EntityFrameworkCore;

namespace Apollo.Auth.Api.Interface.Data;

public class DbCtx : DbContext
{
    public DbCtx(DbContextOptions<DbCtx> options) : base(options)
    {
    }

    public DbSet<UserModel> Users { get; set; }
}
