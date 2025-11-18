using importa;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace importa_test;

public class IntegrationTest
{
    [Fact]
    public void OrquestradorIntegration()
    {

        // Arrange
        Environment.SetEnvironmentVariable("DbBrandParam", Parametres.INMEMORY);
        CSVReader reader = new();
        Cleaner cleaner = new();
        AssignacionsDbCtx context = new();
        
        // For in-memory SQLite, we need to keep the connection open
        context.Database.OpenConnection();
        context.Database.EnsureCreated();
        
        Normalitzador normalitzador = new(context);
        string rutaFitxer = Parametres.FitxerCSV;
        ILogger<Orquestrador> logger = Mock.Of<ILogger<Orquestrador>>();
        var orquestrador = new Orquestrador(reader, cleaner, context, normalitzador, rutaFitxer, logger);

        // Act
        orquestrador.Go();

        // Assert

    }
}
