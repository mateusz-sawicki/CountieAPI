using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountieAPI.Models
{
    public class ProcedureDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public bool IsFavourite { get; set; }
        
        [Required]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
