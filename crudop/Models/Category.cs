using System.ComponentModel.DataAnnotations;

namespace crudop.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        [Required]  
        public string name { get; set; }    

        public int Displayorder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
