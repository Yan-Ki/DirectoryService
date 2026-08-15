using System.Runtime.CompilerServices;
using DirectoryService.Domain.ValueObject;
using Path = DirectoryService.Domain.ValueObject.Path;

namespace DirectoryService.Domain
{
    public sealed class Department
    {
        private Department()
        {
        }
        
        public Department (
            Guid? id,
            Name name,
            Identifier identifier,
            Guid? parentId,
            Path path,
            short depth)
        {
            Id = id ?? Guid.NewGuid();
            Name = name;
            Identifier = identifier;
            ParentId = parentId ?? Guid.Empty;
            Path = path;
            Depth = depth;
            IsActive = true;
            CreateAt = DateTime.UtcNow;
            UpdateAt = null;
        }

        public Guid Id { get;  private set; }
        
        public Name Name { get; private set; }
        
        public Identifier Identifier { get; private set; }
        
        public Guid? ParentId { get; private set; }
        
        public Path Path { get; private set; }
        
        public short Depth { get; private set; }
        
        public bool IsActive { get; private set; }
        
        public DateTime CreateAt { get; private set; }
        
        public DateTime? UpdateAt { get; private set; }
        
        public List<DepartmentPosition> DepartmentPositions { get; private set; } = [];
        
        public List<DepartmentLocation> DepartmentLocations { get; private set; } = [];
    }
}