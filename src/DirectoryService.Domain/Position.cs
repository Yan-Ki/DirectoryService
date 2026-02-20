namespace DirectoryService.Domain;

public class Position
{
    public Position(Guid id, string name, DateTime createAt, DateTime updateAt)
    {
        Id = id;
        Name = name;
        CreateAt = createAt;
        UpdateAt = updateAt;
        IsActive = true;
        UpdateAt = DateTime.Now;
        CreateAt = DateTime.Now;
        UpdateAt = DateTime.Now;
    }
    private Guid Id { get; set; }
    private string Name { get; set; }
    private string Description { get; set; }
    private bool IsActive { get; set; }
    private DateTime CreateAt { get; set; }
    private DateTime UpdateAt { get; set; }
     
}