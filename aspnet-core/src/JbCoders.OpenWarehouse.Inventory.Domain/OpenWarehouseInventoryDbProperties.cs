namespace JbCoders.OpenWarehouse.Inventory.Domain;

public static class OpenWarehouseInventoryDbProperties
{
    /// <summary>
    /// Default value: "MasterData".
    /// </summary>
    public static string DbTablePrefix { get; set; } = "Inventory";

    /// <summary>
    /// Default value: "null".
    /// </summary>
    public static string DbSchema { get; set; } = null;

    /// <summary>
    /// "MasterData".
    /// </summary>
    public const string ConnectionStringName = "Inventory";
}