using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kpz_ex.Models
{
    public class Book
    {

       [Key]
       public int Book_Id { get; set; }
       [MaxLength(100)]
       public string? Book_Name { get; set; }
       [MaxLength(50)]
       public string? Book_Author { get; set; }
       [Required]
       public int? Book_Quantity { get; set; }

    }
}
