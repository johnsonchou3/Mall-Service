using System.Dynamic;
using MemberService.Repositories.Entities;

namespace MemberService.Repositories;

public interface IMemberInfoRepository
{
    MemberInfo Get(int id);
    void Insert(string name);
    void Delete(int id);
}

public class MemberInfoRepository : IMemberInfoRepository
{
    private readonly Dictionary<int, MemberInfo> MemberInfos;
    private int IdCounter;

    public MemberInfoRepository()
    {
        var members = new[]
        {
            new MemberInfo(1, "John", DateTimeOffset.Now.AddDays(-1).ToUnixTimeMilliseconds()),
            new MemberInfo(2, "Mary", DateTimeOffset.Now.AddDays(-2).ToUnixTimeMilliseconds()),
            new MemberInfo(3, "Ted", DateTimeOffset.Now.AddDays(-3).ToUnixTimeMilliseconds()),
        };
        MemberInfos = members.ToDictionary(member => member.Id, member => member);
    }

    public MemberInfo Get(int id)
    {
        if (!MemberInfos.TryGetValue(id, out var memberInfo))
        {
            throw new KeyNotFoundException($"MemberInfo could not be found with Id: {id}");
        }
        return memberInfo;
    }

    public void Insert(string name)
    {
        var memberInfo = new MemberInfo(IdCounter, name, DateTimeOffset.Now.ToUnixTimeMilliseconds());
        if (!MemberInfos.TryAdd(IdCounter, memberInfo))
        {
            throw new InvalidDataException("Id already Exists");
        }
        IdCounter++;
    }

    public void Delete(int id)
    {
        MemberInfos.Remove(id);
    }
}