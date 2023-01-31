using System.ComponentModel.DataAnnotations;

namespace HelpMeApp.DatabaseAccess.Entities.CategoryEntity
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}