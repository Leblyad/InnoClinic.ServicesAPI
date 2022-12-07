﻿using System.ComponentModel.DataAnnotations;

namespace ServicesAPI.Core.Entities.Models
{
    public class ServiceCategory
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Category Name is required field.")]
        [MaxLength(30, ErrorMessage = "Maximum lenght for the Category Name is 30 characters.")]
        public string CategoryName { get; set; }

        public int TimeSlotSize { get; set; }
    }
}