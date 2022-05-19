namespace DocumentManagement.Models
{
    public class Process
    {
           public int Id { get; set; }

           public string Name { get; set; }

           public int CategoryId { get; set; }
            
           public CategoryModel? Category { get; set; }
    }
}
