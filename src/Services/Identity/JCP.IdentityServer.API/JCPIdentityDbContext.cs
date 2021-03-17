using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JCP.IdentityServer.API
{
    public class JCPIdentityDbContext : IdentityDbContext
    {
        public JCPIdentityDbContext(DbContextOptions<JCPIdentityDbContext> options) : base(options) { }
    }
}