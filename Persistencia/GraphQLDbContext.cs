using Microsoft.EntityFrameworkCore;

public class GraphQLDbContext : DbContext
    {
        public GraphQLDbContext(DbContextOptions<GraphQLDbContext> options) : base(options) {}

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
    }