namespace DirectoryService.Domain;

public class Location
{
    private Guid Id { get; set; }
    private string Name { get; set; }
    private string Adress { get; set; }
    private string TimeZone { get; set; }
    private bool IsActive { get; set; }
    private DateTime CreateAt { get; set; }
    private DateTime UpdateAt { get; set; }
    
}