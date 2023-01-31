using System.ComponentModel.DataAnnotations;

namespace HelpMeApp.DatabaseAccess.Entities.SenderRoleEntity
{
    public class SenderRole
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}