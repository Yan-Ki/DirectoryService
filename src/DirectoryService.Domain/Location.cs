using DirectoryService.Domain.ValueObject;

namespace DirectoryService.Domain;

public sealed class Location
{
    private Location()
    {
    }
    
    public Location(Guid? id, LocationName name, string adress, string timeZone)
    {
       Id = id ?? Guid.NewGuid();
       Name = name;
       Adress = adress;
       TimeZone = timeZone;
       IsActive = true;
       CreateAt = DateTime.Now;
       UpdateAt = null;
    }
    
    public Guid Id { get; private set; }
    public LocationName Name { get; private set; }
    public string Adress { get; private set; }
    public string TimeZone { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreateAt { get; private set; }
    public DateTime? UpdateAt { get; private set; }
    public List<DepartmentLocation> DepartmentLocations { get; private set; } = [];
}