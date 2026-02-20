namespace DirectoryService.Domain;

public class Location
{
    public Location()
    {
        
    }
    public Location(Guid id, string name, string adress, string timeZone, string description, DateTime createAt, DateTime updateAt)
    {
       Id = id;
       Name = name;
       Adress = adress;
       TimeZone = timeZone;
        IsActive = true;
        CreateAt = DateTime.Now;
        UpdateAt = DateTime.Now;
    }
    public string test { get; set; }
    private Guid Id { get; set; }
    private string Name { get; set; }
    private string Adress { get; set; }
    private string TimeZone { get; set; }
    private bool IsActive { get; set; }
    private DateTime CreateAt { get; set; }
    private DateTime UpdateAt { get; set; }
    
}