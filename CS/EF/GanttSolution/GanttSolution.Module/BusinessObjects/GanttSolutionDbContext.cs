using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GanttSolution.Module.BusinessObjects;

// This code allows our Model Editor to get relevant EF Core metadata at design time.
// For details, please refer to https://supportcenter.devexpress.com/ticket/details/t933891.
public class GanttSolutionContextInitializer : DbContextTypesInfoInitializerBase {
    protected override DbContext CreateDbContext() {
        var optionsBuilder = new DbContextOptionsBuilder<GanttSolutionEFCoreDbContext>()
            .UseSqlServer(";")
            .UseChangeTrackingProxies()
            .UseObjectSpaceLinkProxies();
        return new GanttSolutionEFCoreDbContext(optionsBuilder.Options);
    }
}
//This factory creates DbContext for design-time services. For example, it is required for database migration.
public class GanttSolutionDesignTimeDbContextFactory : IDesignTimeDbContextFactory<GanttSolutionEFCoreDbContext> {
    public GanttSolutionEFCoreDbContext CreateDbContext(string[] args) {
        throw new InvalidOperationException("Make sure that the database connection string and connection provider are correct. After that, uncomment the code below and remove this exception.");
        //var optionsBuilder = new DbContextOptionsBuilder<GanttSolutionEFCoreDbContext>();
        //optionsBuilder.UseSqlServer("Integrated Security=SSPI;Data Source=(localdb)\\mssqllocaldb;Initial Catalog=GanttSolution");
        //optionsBuilder.UseChangeTrackingProxies();
        //optionsBuilder.UseObjectSpaceLinkProxies();
        //return new GanttSolutionEFCoreDbContext(optionsBuilder.Options);
    }
}
[TypesInfoInitializer(typeof(GanttSolutionContextInitializer))]
public class GanttSolutionEFCoreDbContext : DbContext {
    public GanttSolutionEFCoreDbContext(DbContextOptions<GanttSolutionEFCoreDbContext> options) : base(options) {
    }
    public DbSet<MyTask> MyTasks { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues);
        modelBuilder.UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);

        // Parent is an independent self-referencing FK — no inverse collection
        modelBuilder.Entity<MyTask>()
            .HasOne(t => t.Parent)
            .WithMany()
            .IsRequired(false);

        // PredecessorTasks is a separate many-to-many — join table, no inverse navigation
        modelBuilder.Entity<MyTask>()
            .HasMany(t => t.PredecessorTasks)
            .WithMany(t => t.SuccessorTasks)
            .UsingEntity(j => j.ToTable("MyTaskPredecessors"));
    }
}
