using CSharpFunctionalExtensions;

namespace DirectoryService.Domain
{
    public class Department
    {
        public Department()
        {
            
        }
        private Department (Guid? id,
            string name,
            string identifier,
            Guid? parentId,
            Path path,
            short depth,
            string timeZone,
            DateTime createAt,
            DateTime updateAt)
        {
            Id = id ?? Guid.NewGuid();
            Name = name;
            Identifier = identifier;
            ParentId = parentId;
            Path = path;
            Depth = depth;
        }
        public Guid Id { get;  private set; }
        public string Name { get; private set; }
        public string Identifier { get; private set; }
        public Guid? ParentId { get; private set; }
        public Path Path { get; private set; }
        public short Depth { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreateAt { get; private set; }
        public DateTime UpdateAt { get; private set; }
        public List<Department> Departments { get; private set; }
        public List<Location> Locations { get; private set; }
        public List<Position> Positions { get; private set; }
    }

    public record Path
    {
        public string Value { get;}
        private Path(string value)
        {
            Value = value;
        }
        
        public static Result<Path, string> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.Failure<Path, string>("Пустая строка");
            }
            return new Path(value);
        }
    }
}