using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreMVCProject.Models
{
    public class TheClassStudent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(55)]
        public string? Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string? Phone {  get; set; }

        [ForeignKey("theClass")]
        public int TheClassId { get; set; }

        public TheClass TheClass { get; set; }
    }
}