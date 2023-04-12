namespace JbCoders.OpenWarehouse.PutawayProcess.Domain;

public static class OpenWarehousePutAwayProcessDbProperties
{
    /// <summary>
    /// Default value: "PutAwayProcess".
    /// </summary>
    public static string DbTablePrefix { get; set; } = "PutAwayProcess";

    /// <summary>
    /// Default value: "null".
    /// </summary>
    public static string DbSchema { get; set; } = null;

    /// <summary>
    /// "MasterData".
    /// </summary>
    public const string ConnectionStringName = "PutAwayProcess";
}