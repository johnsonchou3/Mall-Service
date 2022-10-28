namespace MemberService.Repositories.Entities;

public class MemberInfo
{
    public MemberInfo(int id, string name, long createTime)
    {
        Id = id;
        Name = name;
        CreateTime = createTime;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public long CreateTime { get; set; }
}