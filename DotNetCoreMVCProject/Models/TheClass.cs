using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreMVCProject.Models
{
    public class TheClass
    {
        [Key]
        public int Id { get; set; }

        [Required,MaxLength(55)]
        [DisplayName("Class Name")]
        public string? ClassName {  get; set; }

        [MaxLength(55)]
        [DisplayName("Teacher Name")]
        public string? Teacher { get; set; }

        public virtual List<TheClassStudent>? Students { get; set; } = new List<TheClassStudent>();

    }
}
