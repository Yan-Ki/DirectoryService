namespace DirectoryService.Domain;

public class Position
{
    private Guid Id { get; set; }
    private string Name { get; set; }
    private string Description { get; set; }
    private bool IsActive { get; set; }
    private DateTime CreateAt { get; set; }
    private DateTime UpdateAt { get; set; }
}