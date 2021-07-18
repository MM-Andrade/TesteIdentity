using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TesteIdentity.API.Models;

namespace TesteIdentity.API.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuario, Roles, int>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Usuario>()
                .HasOne(e => e.Endereco)
                .WithOne(u => u.Usuario)
                .HasForeignKey<Usuario>("EnderecoId");
        }
    }
}
