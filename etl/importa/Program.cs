using Microsoft.Extensions.Logging;

namespace importa;

class Program
{
    static void Main(string[] args)
    {
        // Configurar el logger
        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddConsole()
                .SetMinimumLevel(LogLevel.Information);
        });

        var logger = loggerFactory.CreateLogger<Program>();

        logger.LogInformation("=== Inici del procés d'importació ===");

        try
        {
            // Orquestrar el procés d'importació
            using var reader = new CSVReader();
            using var context = new AssignacionsDbCtx();
            var normalitzador = new Normalitzador(context);
            var cleaner = new Cleaner();

            var orquestrador = new Orquestrador(reader, cleaner, context, normalitzador, Parametres.FitxerCSV, loggerFactory.CreateLogger<Orquestrador>());

            // Iniciar el procés
            orquestrador.Go();

            logger.LogInformation("=== Procés d'importació finalitzat amb èxit ===");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error durant el procés d'importació");
            throw;
        }
    }
}
