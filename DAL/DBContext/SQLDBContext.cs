using BOL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.DBContext
{
    public class SQLDBContext:IdentityDbContext<ApplicationUser>
    {
        public SQLDBContext(DbContextOptions<SQLDBContext> options): base(options)
        {
            
        }
    }
}
