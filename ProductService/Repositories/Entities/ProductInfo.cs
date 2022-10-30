namespace ProjectService.Repositories.Entities;

public class ProductInfo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public long CreateTime { get; set; }

    public ProductInfo(int id, string name, double price, long createTime)
    {
        Id = id;
        Name = name;
        Price = price;
        CreateTime = createTime;
    }
}