using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace scorecard_cbt.DTOs
{
    public class AddImageDto
    {
        [Required]
        public IFormFile Image { get; set; }
    }
}
