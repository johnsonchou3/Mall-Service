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

    [HttpGet("Id/{id}", Name = "GetMemberInfo")]
    public ActionResult<MemberInfo> Get(int id)
    {
        Logger.Log(LogLevel.Information, "my own log");
        return MemberInfoRepository.Get(id);
    }
    
}