namespace JbCoders.OpenWarehouse.MasterData.Domain;

public class OpenWarehouseMasterDataDbProperties
{
    /// <summary>
    /// Default value: "MasterData".
    /// </summary>
    public static string DbTablePrefix { get; set; } = "MasterData";

    /// <summary>
    /// Default value: "null".
    /// </summary>
    public static string DbSchema { get; set; } = null;

    /// <summary>
    /// "MasterData".
    /// </summary>
    public const string ConnectionStringName = "MasterData";
}