﻿using System.ComponentModel.DataAnnotations;

namespace SPSS.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; } = string.Empty;

        public string? Description { get; set; }
        public bool isDelete { get; set; } = false;
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
