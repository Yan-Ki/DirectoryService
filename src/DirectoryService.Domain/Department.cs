namespace DirectoryService.Domain
{
    public class Department
    {
        private Guid Id {get; set; }
        private string Name {get; set;}
        private string Identifier {get; set;}
        private Guid? ParentId {get; set;}
        private string Path {get; set;}
        private short Depth {get; set;}
        private bool IsActive {get; set;}
        private DateTime CreateAt {get; set;}
        private DateTime UpdateAt {get; set;}
    }
}