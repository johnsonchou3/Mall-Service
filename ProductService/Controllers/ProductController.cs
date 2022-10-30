using Microsoft.AspNetCore.Mvc;
using ProjectService.Repositories;
using ProjectService.Repositories.Entities;

namespace ProjectService.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly  IProductInfoRepository ProductInfoRepository;

    public ProductController(IProductInfoRepository productInfoRepository)
    {
        ProductInfoRepository = productInfoRepository;
    }

    [HttpGet("Id/{id}", Name = "GetInfo")]
    public ActionResult<ProductInfo> Get(int id)
    {
        return ProductInfoRepository.Get(id);
    }

    [HttpPost("Name/{name}/Price/{price}", Name = "Insert")]
    public ActionResult<int> Insert(string name, double price)
    {
        ProductInfoRepository.Insert(name, price);
        return NoContent();
    }

    [HttpDelete("Id/{id}", Name = "Delete")]
    public ActionResult Delete(int id)
    {
        ProductInfoRepository.Delete(id);
        return NoContent();
    }

    [HttpGet("CatchedException")]
    public ActionResult CatchedException()
    {
        try
        {
            ProductInfoRepository.ThrowsKeyNotFound();
            return NoContent();
        }
        catch (KeyNotFoundException e)
        {
            return StatusCode(404, e.Message);
        }
    }

    [HttpGet("NotHandledException")]
    public ActionResult NotHandledException()
    {
        ProductInfoRepository.ThrowsKeyNotFound();
        return NoContent();
    }
}