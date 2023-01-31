using System.ComponentModel.DataAnnotations;

namespace HelpMeApp.DatabaseAccess.Entities.TermsEntity
{
    public class Terms
    {
        public int Id { get; set; }
        [Required]
        public int Days { get; set; }
    }
}