﻿using System.ComponentModel.DataAnnotations;

namespace AdrasJRS.Data.ViewModel;
public class CreateCategoryViewModel
{
    [Required(ErrorMessage = "Please enter category name")]
    [StringLength(100, ErrorMessage = "Category name cannot be more than 100 characters.")]
    public string Name { get; set; }
    [StringLength(256, ErrorMessage = "The description cannot be more than 256 characters.")]
    public string Description { get; set; }
}