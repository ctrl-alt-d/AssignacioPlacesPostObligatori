using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace importa;


// Normalized models

[Table("cursos")]
public class Curs
{
    [Column("any")]
    [Key]
    [MaxLength(10)]
    public string Any { get; set; } = null!;
    
    [Column("curs")]
    [MaxLength(20)]
    public string CursText { get; set; } = null!;
    
    public ICollection<Assignacio> Assignacions { get; set; } = null!;
}

[Table("naturaleses")]
public class Naturalesa
{
    [Column("codi")]
    [Key]
    [MaxLength(10)]
    public string Codi { get; set; } = null!;
    
    [Column("nom")]
    [MaxLength(50)]
    public string Nom { get; set; } = null!;
    
    public ICollection<Centre> Centres { get; set; } = null!;
}

[Table("titularitats")]
public class Titularitat
{
    [Column("codi")]
    [Key]
    [MaxLength(10)]
    public string Codi { get; set; } = null!;
    
    [Column("nom")]
    [MaxLength(100)]
    public string Nom { get; set; } = null!;
    
    public ICollection<Centre> Centres { get; set; } = null!;
}

[Table("arees_territorials")]
public class AreaTerritorial
{
    [Column("codi")]
    [Key]
    [MaxLength(10)]
    public string Codi { get; set; } = null!;
    
    [Column("nom")]
    [MaxLength(100)]
    public string Nom { get; set; } = null!;
    
    public ICollection<Comarca> Comarques { get; set; } = null!;
}

[Table("comarques")]
public class Comarca
{
    [Column("codi")]
    [Key]
    [MaxLength(10)]
    public string Codi { get; set; } = null!;
    
    [Column("nom")]
    [MaxLength(100)]
    public string Nom { get; set; } = null!;
    
    [Column("codi_area_territorial")]
    [MaxLength(10)]
    public string CodiAreaTerritorial { get; set; } = null!;
    
    [ForeignKey(nameof(CodiAreaTerritorial))]
    public AreaTerritorial AreaTerritorial { get; set; } = null!;
    
    public ICollection<Municipi> Municipis { get; set; } = null!;
}

[Table("municipis")]
public class Municipi
{
    [Column("codi_5")]
    [Key]
    [MaxLength(10)]
    public string Codi5 { get; set; } = null!;
    
    [Column("codi_6")]
    [MaxLength(10)]
    public string? Codi6 { get; set; }
    
    [Column("nom")]
    [MaxLength(100)]
    public string Nom { get; set; } = null!;
    
    [Column("codi_comarca")]
    [MaxLength(10)]
    public string CodiComarca { get; set; } = null!;
    
    [ForeignKey(nameof(CodiComarca))]
    public Comarca Comarca { get; set; } = null!;
    
    public ICollection<Centre> Centres { get; set; } = null!;
}

[Table("centres")]
public class Centre
{
    [Column("codi")]
    [Key]
    [MaxLength(20)]
    public string Codi { get; set; } = null!;
    
    [Column("denominacio_completa")]
    [MaxLength(200)]
    public string DenominacioCompleta { get; set; } = null!;
    
    [Column("codi_naturalesa")]
    [MaxLength(10)]
    public string CodiNaturalesa { get; set; } = null!;
    
    [Column("codi_titularitat")]
    [MaxLength(10)]
    public string CodiTitularitat { get; set; } = null!;
    
    [Column("codi_municipi_5")]
    [MaxLength(10)]
    public string CodiMunicipi5 { get; set; } = null!;
    
    [Column("coordenades_utm_x")]
    public double? CoordenadesUtmX { get; set; }
    
    [Column("coordenades_utm_y")]
    public double? CoordenadesUtmY { get; set; }
    
    [Column("longitud")]
    public double? Longitud { get; set; }
    
    [Column("latitud")]
    public double? Latitud { get; set; }
    
    [ForeignKey(nameof(CodiNaturalesa))]
    public Naturalesa Naturalesa { get; set; } = null!;
    
    [ForeignKey(nameof(CodiTitularitat))]
    public Titularitat Titularitat { get; set; } = null!;
    
    [ForeignKey(nameof(CodiMunicipi5))]
    public Municipi Municipi { get; set; } = null!;
    
    public ICollection<Assignacio> Assignacions { get; set; } = null!;
}

[Table("convocatories")]
public class Convocatoria
{
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    
    [Column("nom")]
    [MaxLength(200)]
    public string Nom { get; set; } = null!;
    
    public ICollection<Assignacio> Assignacions { get; set; } = null!;
}

[Table("ensenyaments")]
public class Ensenyament
{
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    
    [Column("nom")]
    [MaxLength(200)]
    public string Nom { get; set; } = null!;
    
    public ICollection<Assignacio> Assignacions { get; set; } = null!;
}

[Table("regims")]
public class Regim
{
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    
    [Column("nom")]
    [MaxLength(50)]
    public string Nom { get; set; } = null!;
    
    public ICollection<Assignacio> Assignacions { get; set; } = null!;
}

[Table("torns")]
public class Torn
{
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    
    [Column("nom")]
    [MaxLength(50)]
    public string Nom { get; set; } = null!;
    
    public ICollection<Assignacio> Assignacions { get; set; } = null!;
}

[Table("assignacions_normalitzades")]
public class Assignacio
{
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    
    [Column("codi_centre")]
    [MaxLength(20)]
    public string CodiCentre { get; set; } = null!;
    
    [Column("any")]
    [MaxLength(10)]
    public string Any { get; set; } = null!;
    
    [Column("convocatoria_id")]
    public int ConvocatoriaId { get; set; }
    
    [Column("ensenyament_id")]
    public int EnsenyamentId { get; set; }
    
    [Column("regim_id")]
    public int RegimId { get; set; }
    
    [Column("torn_id")]
    public int TornId { get; set; }
    
    [Column("nivell")]
    public int? Nivell { get; set; }
    
    [Column("nombre_grups")]
    public int? NombreGrups { get; set; }
    
    [Column("nombre_places")]
    public int? NombrePlaces { get; set; }
    
    [Column("places_ofertades_preinscripcio")]
    public int? PlacesOfertadesPreinscripcio { get; set; }
    
    [Column("assignacions_total")]
    public int? AssignacionsTotal { get; set; }
    
    [Column("assignacions_1a_peticio")]
    public int? Assignacions1aPeticio { get; set; }
    
    [Column("assignacions_altres_peticions")]
    public int? AssignacionsAltresPeticions { get; set; }
    
    [Column("places_ofertades_preinscripcio_2a_volta")]
    public int? PlacesOfertadesPreinscripcio2aVolta { get; set; }
    
    [Column("assignacions_2a_volta")]
    public int? Assignacions2aVolta { get; set; }
    
    [Column("assignacions_1a_peticio_2a_volta")]
    public int? Assignacions1aPeticio2aVolta { get; set; }
    
    [Column("assignacions_altres_peticions_2a_volta")]
    public int? AssignacionsAltresPeticions2aVolta { get; set; }
    
    [ForeignKey(nameof(CodiCentre))]
    public Centre Centre { get; set; } = null!;
    
    [ForeignKey(nameof(Any))]
    public Curs Curs { get; set; } = null!;
    
    [ForeignKey(nameof(ConvocatoriaId))]
    public Convocatoria Convocatoria { get; set; } = null!;
    
    [ForeignKey(nameof(EnsenyamentId))]
    public Ensenyament Ensenyament { get; set; } = null!;
    
    [ForeignKey(nameof(RegimId))]
    public Regim Regim { get; set; } = null!;
    
    [ForeignKey(nameof(TornId))]
    public Torn Torn { get; set; } = null!;
}


