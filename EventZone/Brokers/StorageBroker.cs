using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace EventZone.Brokers;

internal partial class StorageBroker : DbContext, IStorageBroker
{
    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString =
            @"Server=(localdb)\mssqllocaldb;Database=Coworking;Trusted_Connection=true;";

        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly());
    }

    private async ValueTask<T> InsertAsync<T>(T entity)
    {
        this.Entry(entity).State = EntityState.Added;

        await this.SaveChangesAsync();

        return entity;
    }

    private IQueryable<T> SelectAll<T>() where T : class =>
        this.Set<T>();

    private async ValueTask<T> SelectByIdAsync<T>(int entityId)where T : class =>
        await this.Set<T>().FindAsync(entityId);

    private async ValueTask<T> UpdateAsync<T>(T entity)
    {
        this.Entry(entity).State = EntityState.Modified;

        await this.SaveChangesAsync();

        return entity;
    }

    private async ValueTask<T> DeleteAsync<T>(T entity)
    {
        this.Entry(entity).State = EntityState.Deleted;

        await this.SaveChangesAsync();

        return entity;
    }

    private async ValueTask<T> SelectByIdAsync<T>(
        Expression<Func<T, bool>> expression,
        List<string> includes) where T : class
    {
        IQueryable<T> entities = this.SelectAll<T>();

        foreach(var include in includes)
        {
            entities = entities.Include(include);
        }

        return await entities.FirstOrDefaultAsync(expression);
    }
}