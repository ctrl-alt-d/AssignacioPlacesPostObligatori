/*
"Curs","Any","Codi centre","Denominació completa","Codi naturalesa","Nom naturalesa","Codi titularitat","Nom titularitat","Codi Àrea Territorial","Nom Àrea Territorial","Codi comarca","Nom comarca","Codi municipi_5","Codi municipi_6","Nom municipi","Coordenades UTM X","Coordenades UTM Y","Longitud","Latitud","Convocatòria","Nom ensenyament","Règim","Torn","Nivell","Nombre grups","Nombre places","Places ofertades a la preinscripcio","Assignacions","Assginacions: 1a peticio","Assignacions: altres peticions","Places ofertades a la preinscripció (2a volta)","Assignacions (2a volta)","Assignacions 1a petició (2a volta)","Assignacions altres peticions(2a volta)","Georeferenciació"
"2025/2026","2025","08046840","Institut Castellet","1","Públic","01","Departament d'Educació i Formació Professional","1060","Catalunya Central","07","Bages","08262","082628","Sant Vicenç de Castellet","405443","4613948","1,864077","41,67168","Batxillerat - 2025-2026","Batxillerat d'arts","Diürn","Matí i tarda","2","1","35","7","1","1","0",,,,,"POINT (1.864077 41.67168)"
"2025/2026","2025","17005704","Institut Abat Oliba","1","Públic","01","Departament d'Educació i Formació Professional","0117","Girona","31","Ripollès","17147","171479","Ripoll","433483","4671250","2,194417","42,19057","PFI - 2025-2026 - Programes de Formació i Inserció","Auxiliar d'activitats d'oficina i de serveis administratius generals","Diürn","Matí i tarda","1","1","17","17","17","7","10",,,,,"POINT (2.194417 42.19057)"
"2025/2026","2025","08053224","Institut Les Termes","1","Públic","01","Departament d'Educació i Formació Professional","0408","Vallès Occidental","40","Vallès Occidental","08187","081878","Sabadell","426788","4598072","2,12241","41,53094","Batxillerat - 2025-2026","Batxillerat (resta de modalitats)","Diürn","Matí i tarda","1","3","105","57","38","25","13",,,,,"POINT (2.12241 41.53094)"
"2025/2026","2025","08047832","Institut Joan Coromines","1","Públic","01","Departament d'Educació i Formació Professional","0508","Maresme - Vallès Oriental","21","Maresme","08163","081635","Pineda de Mar","473514","4608440","2,682042","41,6272","Batxillerat - 2025-2026","Batxillerat (resta de modalitats)","Diürn","Matí i tarda","1","2","70","25","5","3","2",,,,,"POINT (2.682042 41.6272)"
*/


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace importa;

// El modelo y las columnas se mapearán en minúscula en la base de datos
[Table("assignacions")]
public class AssignacioRaw
{
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    
    [Column("curs")]
    public string? Curs { get; set; }
    
    [Column("any")]
    public string? Any { get; set; }
    
    [Column("codi_centre")]
    public string? CodiCentre { get; set; }
    
    [Column("denominacio_completa")]
    public string? DenominacioCompleta { get; set; }
    
    [Column("codi_naturalesa")]
    public string? CodiNaturalesa { get; set; }
    
    [Column("nom_naturalesa")]
    public string? NomNaturalesa { get; set; }
    
    [Column("codi_titularitat")]
    public string? CodiTitularitat { get; set; }
    
    [Column("nom_titularitat")]
    public string? NomTitularitat { get; set; }
    
    [Column("codi_area_territorial")]
    public string? CodiAreaTerritorial { get; set; }
    
    [Column("nom_area_territorial")]
    public string? NomAreaTerritorial { get; set; }
    
    [Column("codi_comarca")]
    public string? CodiComarca { get; set; }
    
    [Column("nom_comarca")]
    public string? NomComarca { get; set; }
    
    [Column("codi_municipi_5")]
    public string? CodiMunicipi5 { get; set; }
    
    [Column("codi_municipi_6")]
    public string? CodiMunicipi6 { get; set; }
    
    [Column("nom_municipi")]
    public string? NomMunicipi { get; set; }
    
    [Column("coordenades_utm_x")]
    public double? CoordenadesUtmX { get; set; }
    
    [Column("coordenades_utm_y")]
    public double? CoordenadesUtmY { get; set; }
    
    [Column("longitud")]
    public double? Longitud { get; set; }
    
    [Column("latitud")]
    public double? Latitud { get; set; }
    
    [Column("convocatoria")]
    public string? Convocatoria { get; set; }
    
    [Column("nom_ensenyament")]
    public string? NomEnsenyament { get; set; }
    
    [Column("regim")]
    public string? Regim { get; set; }
    
    [Column("torn")]
    public string? Torn { get; set; }
    
    [Column("nivell")]
    public int? Nivell { get; set; }
    
    [Column("nombre_grups")]
    public int? NombreGrups { get; set; }
    
    [Column("nombre_places")]
    public int? NombrePlaces { get; set; }
    
    [Column("places_ofertades_preinscripcio")]
    public int? PlacesOfertadesPreinscripcio { get; set; }
    
    [Column("assignacions")]
    public int? Assignacions { get; set; }
    
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
    
    [Column("georeferenciacio_longitud")]
    public double? GeoreferenciacionLongitud { get; set; }
    
    [Column("georeferenciacio_latitud")]
    public double? GeoreferenciacionLatitud { get; set; }
}
