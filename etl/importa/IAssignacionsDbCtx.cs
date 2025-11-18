using Microsoft.EntityFrameworkCore;

namespace importa;

public interface IAssignacionsDbCtx
{
    DbSet<Convocatoria> Convocatories { get; }
    DbSet<Ensenyament> Ensenyaments { get; }
    DbSet<Regim> Regims { get; }
    DbSet<Torn> Torns { get; }
    
    void AddRange(params object[] entities);
    int SaveChanges();
    DbSet<TEntity> Set<TEntity>() where TEntity : class;

    void RecreateDatabase();
}
