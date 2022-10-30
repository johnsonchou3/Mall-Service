using ProjectService.Repositories.Entities;

namespace ProjectService.Repositories;

public interface IProductInfoRepository
{
    ProductInfo Get(int id);
    void Insert(string name, double price);
    void Delete(int id);
    void ThrowsKeyNotFound();
}

public class ProductInfoRepository : IProductInfoRepository
{
    private readonly Dictionary<int, ProductInfo> ProductInfos;
    private int IdCounter;

    public ProductInfoRepository()
    {
        var members = new[]
        {
            new ProductInfo(1, "Mouse", 1.0,DateTimeOffset.Now.AddDays(-1).ToUnixTimeMilliseconds()),
            new ProductInfo(2, "Keyboard", 2.5, DateTimeOffset.Now.AddDays(-2).ToUnixTimeMilliseconds()),
            new ProductInfo(3, "Monitor", 3.2, DateTimeOffset.Now.AddDays(-3).ToUnixTimeMilliseconds()),
        };
        ProductInfos = members.ToDictionary(member => member.Id, member => member);
    }

    public ProductInfo Get(int id)
    {
        if (!ProductInfos.TryGetValue(id, out var productInfo))
        {
            throw new KeyNotFoundException($"ProductInfo could not be found with Id: {id}");
        }
        return productInfo;
    }

    public void Insert(string name, double price)
    {
        var productInfo = new ProductInfo(IdCounter, name, price, DateTimeOffset.Now.ToUnixTimeMilliseconds());
        if (!ProductInfos.TryAdd(IdCounter, productInfo))
        {
            throw new InvalidDataException("Id already Exists");
        }
        IdCounter++;
    }

    public void Delete(int id)
    {
        ProductInfos.Remove(id);
    }

    public void ThrowsKeyNotFound()
    {
        throw new KeyNotFoundException("Member Not Found");
    }
}