namespace CICDPrac.Models;

/// <summary>
/// 產品
/// </summary>
public partial class Product
{
    /// <summary>
    /// 產品代號
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// 產品名稱
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 價錢
    /// </summary>
    public decimal? Price { get; set; }
}
