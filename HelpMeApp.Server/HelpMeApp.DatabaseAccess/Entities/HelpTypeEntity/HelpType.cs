using System.ComponentModel.DataAnnotations;

namespace HelpMeApp.DatabaseAccess.Entities.HelpTypeEntity
{
    public class HelpType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}