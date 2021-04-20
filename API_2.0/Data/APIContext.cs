using API_2._0.Models;
using Microsoft.EntityFrameworkCore;

namespace API_2._0.Data
{
    public class APIContext : DbContext
    {

        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        {
        }

        public DbSet<ContaModel> Conta { get; set; }

    }
}
