namespace importa;

public class Cleaner
{
    private static readonly string[] ValorsInvalids = ["Sense especificar", "Sense Especificar", "NA"];

    public void CleanDataset(List<AssignacioRaw> assignacions)
    {

        // Aplicar limpieza para campos string con valores inválidos
        CleanStringField(assignacions, a => a.DenominacioCompleta, (a, v) => a.DenominacioCompleta = v);

    }

    /// <summary>
    /// Aplica una regla de limpieza genérica para campos nullable
    /// </summary>
    private void ApplyCleaningRule<T>(
        List<AssignacioRaw> assignacions,
        Func<AssignacioRaw, T?> getter,
        Action<AssignacioRaw, T?> setter,
        Func<T?, bool> shouldClean) where T : struct
    {
        assignacions
            .Where(a => shouldClean(getter(a)))
            .ToList()
            .ForEach(a => setter(a, null));
    }

    /// <summary>
    /// Limpia campos string que contienen valores inválidos o están vacíos
    /// </summary>
    private void CleanStringField(
        List<AssignacioRaw> assignacions,
        Func<AssignacioRaw, string?> getter,
        Action<AssignacioRaw, string?> setter)
    {
        assignacions
            .Where(a => string.IsNullOrWhiteSpace(getter(a)) || ValorsInvalids.Contains(getter(a)))
            .ToList()
            .ForEach(a => setter(a, null));
    }
}


