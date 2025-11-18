using System.Reflection.Metadata;
using Microsoft.Extensions.Primitives;

namespace importa;

public class Parametres
{
    public const string POSTGRES = "postgres";
    public const string MYSQL = "mysql";
    public const string SQLSERVER = "sqlserver";
    public const string FitxerCSV = "Data/Estadística_de_l'assignació_de_places_en_el_procés_de_la_preinscripció_en_els_ensenyaments_post-obligatoris_20251118.csv";

    public static string DbBrandParam =>
        (Environment.GetEnvironmentVariable("DbBrandParam") ?? POSTGRES).Trim().ToLowerInvariant();

    public static string ConnectionStringParam
    {
        get
        {
            var custom = Environment.GetEnvironmentVariable("ConnectionStringParam");
            if (!string.IsNullOrWhiteSpace(custom)) return custom;

            // Construïm per defecte segons el gestor seleccionat
            return DbBrandParam switch
            {
                POSTGRES => "Host=postgres;Port=5432;Username=postgres;Password=123456;Database=assignacions",
                MYSQL => "Server=mysql;Port=3306;User=root;Password=123456;Database=assignacions",
                SQLSERVER => "Server=sqlserver,1433;User Id=sa;Password=Str0ngPass!;TrustServerCertificate=True;Database=assignacions",
                _ => "Host=postgres;Port=5432;Username=postgres;Password=123456;Database=assignacions"
            };
        }
    }
}