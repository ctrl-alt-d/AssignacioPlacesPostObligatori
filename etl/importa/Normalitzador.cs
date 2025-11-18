namespace importa;

public class Normalitzador
{
    private AssignacionsDbCtx context;
    public Normalitzador(AssignacionsDbCtx context)
    {
        this.context = context;
    }

    public void Normalitza(List<AssignacioRaw> raw_data)
    {
        // Extract and store unique values for lookup tables
        var cursos = raw_data
            .Where(r => !string.IsNullOrEmpty(r.Any) && !string.IsNullOrEmpty(r.Curs))
            .GroupBy(r => r.Any)
            .Select(g => new Curs { Any = g.Key!, CursText = g.First().Curs! })
            .ToList();
        
        var naturaleses = raw_data
            .Where(r => !string.IsNullOrEmpty(r.CodiNaturalesa) && !string.IsNullOrEmpty(r.NomNaturalesa))
            .GroupBy(r => r.CodiNaturalesa)
            .Select(g => new Naturalesa { Codi = g.Key!, Nom = g.First().NomNaturalesa! })
            .ToList();
        
        var titularitats = raw_data
            .Where(r => !string.IsNullOrEmpty(r.CodiTitularitat) && !string.IsNullOrEmpty(r.NomTitularitat))
            .GroupBy(r => r.CodiTitularitat)
            .Select(g => new Titularitat { Codi = g.Key!, Nom = g.First().NomTitularitat! })
            .ToList();
        
        var areesTerritorials = raw_data
            .Where(r => !string.IsNullOrEmpty(r.CodiÀreaTerritorial) && !string.IsNullOrEmpty(r.NomÀreaTerritorial))
            .GroupBy(r => r.CodiÀreaTerritorial)
            .Select(g => new AreaTerritorial { Codi = g.Key!, Nom = g.First().NomÀreaTerritorial! })
            .ToList();
        
        var comarques = raw_data
            .Where(r => !string.IsNullOrEmpty(r.CodiComarca) && !string.IsNullOrEmpty(r.NomComarca) && !string.IsNullOrEmpty(r.CodiÀreaTerritorial))
            .GroupBy(r => r.CodiComarca)
            .Select(g => new Comarca 
            { 
                Codi = g.Key!, 
                Nom = g.First().NomComarca!, 
                CodiAreaTerritorial = g.First().CodiÀreaTerritorial! 
            })
            .ToList();
        
        var municipis = raw_data
            .Where(r => !string.IsNullOrEmpty(r.CodiMunicipi5) && !string.IsNullOrEmpty(r.NomMunicipi) && !string.IsNullOrEmpty(r.CodiComarca))
            .GroupBy(r => r.CodiMunicipi5)
            .Select(g => new Municipi 
            { 
                Codi5 = g.Key!, 
                Codi6 = g.First().CodiMunicipi6, 
                Nom = g.First().NomMunicipi!, 
                CodiComarca = g.First().CodiComarca! 
            })
            .ToList();
        
        var centres = raw_data
            .Where(r => !string.IsNullOrEmpty(r.CodiCentre) && !string.IsNullOrEmpty(r.DenominacióCompleta) 
                && !string.IsNullOrEmpty(r.CodiNaturalesa) && !string.IsNullOrEmpty(r.CodiTitularitat) 
                && !string.IsNullOrEmpty(r.CodiMunicipi5))
            .GroupBy(r => r.CodiCentre)
            .Select(g => new Centre 
            { 
                Codi = g.Key!, 
                DenominacioCompleta = g.First().DenominacióCompleta!, 
                CodiNaturalesa = g.First().CodiNaturalesa!, 
                CodiTitularitat = g.First().CodiTitularitat!, 
                CodiMunicipi5 = g.First().CodiMunicipi5!,
                CoordenadesUtmX = g.First().CoordenadesUtmX,
                CoordenadesUtmY = g.First().CoordenadesUtmY,
                Longitud = g.First().Longitud,
                Latitud = g.First().Latitud
            })
            .ToList();
        
        var convocatories = raw_data
            .Where(r => !string.IsNullOrEmpty(r.Convocatòria))
            .Select(r => r.Convocatòria!)
            .Distinct()
            .Select(nom => new Convocatoria { Nom = nom })
            .ToList();
        
        var ensenyaments = raw_data
            .Where(r => !string.IsNullOrEmpty(r.NomEnsenyament))
            .Select(r => r.NomEnsenyament!)
            .Distinct()
            .Select(nom => new Ensenyament { Nom = nom })
            .ToList();
        
        var regims = raw_data
            .Where(r => !string.IsNullOrEmpty(r.Règim))
            .Select(r => r.Règim!)
            .Distinct()
            .Select(nom => new Regim { Nom = nom })
            .ToList();
        
        var torns = raw_data
            .Where(r => !string.IsNullOrEmpty(r.Torn))
            .Select(r => r.Torn!)
            .Distinct()
            .Select(nom => new Torn { Nom = nom })
            .ToList();

        // Insert lookup tables in order (respecting foreign key dependencies)
        context.AddRange(cursos);
        context.AddRange(naturaleses);
        context.AddRange(titularitats);
        context.AddRange(areesTerritorials);
        context.SaveChanges();
        
        context.AddRange(comarques);
        context.SaveChanges();
        
        context.AddRange(municipis);
        context.SaveChanges();
        
        context.AddRange(centres);
        context.AddRange(convocatories);
        context.AddRange(ensenyaments);
        context.AddRange(regims);
        context.AddRange(torns);
        context.SaveChanges();

        // Create lookup dictionaries for foreign key resolution
        var xx = context.Convocatories.ToList();

        var convocatoriaDict = context.Set<Convocatoria>().ToDictionary(c => c.Nom, c => c.Id);
        var ensenyamentDict = context.Set<Ensenyament>().ToDictionary(e => e.Nom, e => e.Id);
        var regimDict = context.Set<Regim>().ToDictionary(r => r.Nom, r => r.Id);
        var tornDict = context.Set<Torn>().ToDictionary(t => t.Nom, t => t.Id);

        // Create assignacions (fact table)
        var assignacions = raw_data
            .Where(r => !string.IsNullOrEmpty(r.CodiCentre) && !string.IsNullOrEmpty(r.Any)
                && !string.IsNullOrEmpty(r.Convocatòria) && !string.IsNullOrEmpty(r.NomEnsenyament)
                && !string.IsNullOrEmpty(r.Règim) && !string.IsNullOrEmpty(r.Torn))
            .Select(r => new Assignacio
            {
                CodiCentre = r.CodiCentre!,
                Any = r.Any!,
                ConvocatoriaId = convocatoriaDict[r.Convocatòria!],
                EnsenyamentId = ensenyamentDict[r.NomEnsenyament!],
                RegimId = regimDict[r.Règim!],
                TornId = tornDict[r.Torn!],
                Nivell = r.Nivell,
                NombreGrups = r.NombreGrups,
                NombrePlaces = r.NombrePlaces,
                PlacesOfertadesPreinscripcio = r.PlacesOfertadesPreinscripcio,
                AssignacionsTotal = r.Assignacions,
                Assignacions1aPeticio = r.Assignacions1aPeticio,
                AssignacionsAltresPeticions = r.AssignacionsAltresPeticions,
                PlacesOfertadesPreinscripcio2aVolta = r.PlacesOfertadesPreinscripcio2aVolta,
                Assignacions2aVolta = r.Assignacions2aVolta,
                Assignacions1aPeticio2aVolta = r.Assignacions1aPeticio2aVolta,
                AssignacionsAltresPeticions2aVolta = r.AssignacionsAltresPeticions2aVolta
            })
            .ToList();

        context.AddRange(assignacions);
        context.SaveChanges();

    }

}


