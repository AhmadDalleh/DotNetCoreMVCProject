using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreMVCProject.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required,MaxLength(250)]
        [DisplayName("Product name")]
        public string? Name { get; set; }

        [DisplayName("Product Price")]
        public decimal? Price { get; set; }

        [DisplayName("Create date")]
        public DateTime CreatedDate { get; set; }

    }
}
