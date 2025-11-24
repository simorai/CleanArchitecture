using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name max length is 100 characters")]
        [MinLength(3, ErrorMessage = "Name min length is 3 characters")]
        public string Name { get; set; }
    }
}
