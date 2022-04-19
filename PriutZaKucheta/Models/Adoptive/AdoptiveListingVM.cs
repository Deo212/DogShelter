﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogShelter.Models.Adoptive
{
    public class AdoptiveListingVM
    {
        [Key]
        public int Id { get; set; }

        [Required]

        public string FirstName { get; set; }

        [Required]

        public string LastName { get; set; }

        [Required]
        [MaxLength(10)]
        public string Phone { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }
}
