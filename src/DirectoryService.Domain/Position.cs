using DirectoryService.Domain.ValueObject;

namespace DirectoryService.Domain;

public sealed class Position
{
    private readonly List<DepartmentPosition> _departmentPositions = [];
    private Position()
    {
    }
    
    public Position(Guid? id, PositionName name, Description description)
    {
        Id = id ?? Guid.NewGuid();
        Name = name;
        Description = description;
        IsActive = true;
        CreateAt = DateTime.Now;
        UpdateAt = null;
    }
    
    public Guid Id { get; private set; }
    public PositionName Name { get; private set; }
    public Description Description { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreateAt { get; private set; }
    public DateTime? UpdateAt { get; private set; }
    public IReadOnlyList<DepartmentPosition> DepartmentPositions => _departmentPositions;
}