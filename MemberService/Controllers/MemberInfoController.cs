using MemberService.Repositories;
using MemberService.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MemberService.Controllers;

[ApiController]
[Route("[controller]")]
public class MemberInfoController : ControllerBase
{
    private readonly ILogger<MemberInfoController> Logger;
    private readonly IMemberInfoRepository MemberInfoRepository;
    public MemberInfoController(ILogger<MemberInfoController> logger, IMemberInfoRepository memberInfoRepository)
    {
        MemberInfoRepository = memberInfoRepository;
        Logger = logger;
    }

    [HttpGet("Id/{id}", Name = "GetInfo")]
    public ActionResult<MemberInfo> Get(int id)
    {
        Logger.Log(LogLevel.Information, "my own log");
        return MemberInfoRepository.Get(id);
    }

    [HttpPost("Name/{name}", Name = "Insert")]
    public ActionResult<int> Insert(string name)
    {
        MemberInfoRepository.Insert(name);
        return NoContent();
    }

    [HttpDelete("Id/{id}", Name = "Delete")]
    public ActionResult Delete(int id)
    {
        MemberInfoRepository.Delete(id);
        return NoContent();
    }

    [HttpGet("CatchedException")]
    public ActionResult CatchedException()
    {
        try
        {
            MemberInfoRepository.ThrowsKeyNotFound();
            return NoContent();
        }
        catch (KeyNotFoundException e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("NotHandledException")]
    public ActionResult NotHandledException()
    {
        MemberInfoRepository.ThrowsKeyNotFound();
        return NoContent();
    }
}