using importa;
using Microsoft.Extensions.Logging;
using Moq;

namespace importa_test;

public class IntegrationTest
{
    [Fact]
    public void OrquestradorIntegration()
    {

        // Arrange
        CSVReader reader = new();
        Cleaner cleaner = new();
        IAssignacionsDbCtx context = Mock.Of<IAssignacionsDbCtx>();
        Normalitzador normalitzador = new(context);
        string rutaFitxer = Parametres.FitxerCSV;
        ILogger<Orquestrador> logger = Mock.Of<ILogger<Orquestrador>>();
        var orquestrador = new Orquestrador(reader, cleaner, context, normalitzador, rutaFitxer, logger);

        // Act
        orquestrador.Go();

        // Assert

    }
}
