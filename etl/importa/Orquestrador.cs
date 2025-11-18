using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace importa;


public class Orquestrador
{
    protected CSVReader reader;
    protected IAssignacionsDbCtx context;
    protected Cleaner cleaner;
    protected Normalitzador normalitzador;
    protected string rutaFitxer;
    protected ILogger<Orquestrador> logger;

    public Orquestrador(CSVReader reader, Cleaner cleaner, IAssignacionsDbCtx context, Normalitzador normalitzador, string rutaFitxer, ILogger<Orquestrador> logger)
    {
        this.reader = reader;
        this.cleaner = cleaner;
        this.context = context;
        this.normalitzador = normalitzador;
        this.rutaFitxer = rutaFitxer;
        this.logger = logger;
    }

    public void Go()
    {
        var stopwatch = Stopwatch.StartNew();

        logger.LogInformation("No hi ha dades. Iniciant procés d'importació...");

        // Llegir el fitxer CSV
        logger.LogInformation("Llegint fitxer CSV: {RutaFitxer}", rutaFitxer);
        var raw_data = reader.ReadCSV(rutaFitxer);
        logger.LogInformation("S'han llegit {NumAssignacions} assignacions del fitxer CSV", raw_data.Count());

        // Netejar les dades
        logger.LogInformation("Netejant les dades...");
        cleaner.CleanDataset(raw_data);
        logger.LogInformation("Les dades s'han netejat correctament.");

        // Crear la base de dades i la taula
        logger.LogInformation("Recreant la base de dades i la taula ...");
        context.RecreateDatabase();

        logger.LogInformation("Inserint les dades a la base de dades...");
        // Inserir les dades a la base de dades
        normalitzador.Normalitza(raw_data);
        
        stopwatch.Stop();
        logger.LogInformation("S'han inserit les dades correctament a la base de dades en {TempsTrigat:F2} segons", stopwatch.Elapsed.TotalSeconds);
    }
}