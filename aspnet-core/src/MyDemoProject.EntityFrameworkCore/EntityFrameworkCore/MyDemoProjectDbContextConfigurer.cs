using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MyDemoProject.EntityFrameworkCore
{
    public static class MyDemoProjectDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MyDemoProjectDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MyDemoProjectDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
