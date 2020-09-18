using AtenasConsultoria.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AtenasConsultoria.Data
{
    public class Context : IdentityDbContext<User>
    {
        public Context(DbContextOptions options):base (options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Log>().HasKey(opt => opt.Cod_nota);

            builder.Entity<User>().HasMany(opt => opt.Log).WithOne(opt=>opt.user);           
        }
    }
}
