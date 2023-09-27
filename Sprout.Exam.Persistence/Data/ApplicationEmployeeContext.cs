namespace Sprout.Exam.Persistence.Data
{
    public class ApplicationEmployeeContext : DbContext
    {
        public ApplicationEmployeeContext(DbContextOptions<ApplicationEmployeeContext> options) :base (options) { }
        public DbSet<Employee> Employee { get ; set ; }
    }
}
