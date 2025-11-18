using Microsoft.EntityFrameworkCore;

namespace importa;

public class AssignacionsDbCtx : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        switch (Parametres.DbBrandParam)
        {
            case Parametres.POSTGRES:
                optionsBuilder.UseNpgsql(Parametres.ConnectionStringParam);
                break;
            case Parametres.MYSQL:
                optionsBuilder.UseMySql(Parametres.ConnectionStringParam, ServerVersion.AutoDetect(Parametres.ConnectionStringParam));
                break;
            case Parametres.SQLSERVER:
                optionsBuilder.UseSqlServer(Parametres.ConnectionStringParam);
                break;
            default:
                var msg = $"El tipus de base de dades '{Parametres.DbBrandParam}' no és compatible, vols afegir-lo? https://github.com/ctrl-alt-d/AssignacionsAmbAssignacions";
                throw new NotSupportedException(msg);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        

    }

    public DbSet<Curs> Cursos { get; set; } = null!;
    public DbSet<Naturalesa> Naturaleses { get; set; } = null!;
    public DbSet<Titularitat> Titularitats { get; set; } = null!;
    public DbSet<AreaTerritorial> AreesTerritorials { get; set; } = null!;
    public DbSet<Comarca> Comarques { get; set; } = null!;
    public DbSet<Municipi> Municipis { get; set; } = null!;
    public DbSet<Centre> Centres { get; set; } = null!;
    public DbSet<Convocatoria> Convocatories { get; set; } = null!;
    public DbSet<Ensenyament> Ensenyaments { get; set; } = null!;
    public DbSet<Regim> Regims { get; set; } = null!;
    public DbSet<Torn> Torns { get; set; } = null!;
    public DbSet<Assignacio> Assignacions { get; set; } = null!;
    
}