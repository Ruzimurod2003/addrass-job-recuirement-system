﻿using System.ComponentModel.DataAnnotations;

namespace AdrasJRS.Data.ViewModel;
public class CreateProvinceViewModel
{
    [Required(ErrorMessage = "Please enter province name")]
    [StringLength(50, ErrorMessage = "The province name cannot be more than 50 characters.")]
    public string Name { get; set; }
}