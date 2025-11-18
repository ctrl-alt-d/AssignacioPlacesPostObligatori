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

[Table("assignacions")]
public class AssignacioRaw
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    
    public string? Curs { get; set; }
    
    public string? Any { get; set; }
    
    public string? CodiCentre { get; set; }
    
    public string? DenominacióCompleta { get; set; }
    
    public string? CodiNaturalesa { get; set; }
    
    public string? NomNaturalesa { get; set; }
    
    public string? CodiTitularitat { get; set; }
    
    public string? NomTitularitat { get; set; }
    
    public string? CodiÀreaTerritorial { get; set; }
    
    public string? NomÀreaTerritorial { get; set; }
    
    public string? CodiComarca { get; set; }
    
    public string? NomComarca { get; set; }
    
    public string? CodiMunicipi5 { get; set; }
    
    public string? CodiMunicipi6 { get; set; }
    
    public string? NomMunicipi { get; set; }
    
    public double? CoordenadesUtmX { get; set; }
    
    public double? CoordenadesUtmY { get; set; }
    
    public double? Longitud { get; set; }
    
    public double? Latitud { get; set; }
    
    public string? Convocatòria { get; set; }
    
    public string? NomEnsenyament { get; set; }
    
    public string? Règim { get; set; }
    
    public string? Torn { get; set; }
    
    public int? Nivell { get; set; }
    
    public int? NombreGrups { get; set; }
    
    public int? NombrePlaces { get; set; }
    
    public int? PlacesOfertadesPreinscripcio { get; set; }
    
    public int? Assignacions { get; set; }
    
    public int? Assignacions1aPeticio { get; set; }
    
    public int? AssignacionsAltresPeticions { get; set; }
    
    public int? PlacesOfertadesPreinscripcio2aVolta { get; set; }
    
    public int? Assignacions2aVolta { get; set; }
    
    public int? Assignacions1aPeticio2aVolta { get; set; }
    
    public int? AssignacionsAltresPeticions2aVolta { get; set; }
    
    public double? GeoreferenciacionLongitud { get; set; }
    
    public double? GeoreferenciacionLatitud { get; set; }
}
