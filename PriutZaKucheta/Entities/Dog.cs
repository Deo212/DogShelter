using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DogShelter.Entities
{
    public class Dog
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(1, 30)]
        public int Age { get; set; }

        [Required]

        public string Breed { get; set; }
        public string Description { get; set; }

        public string Picture { get; set; }

        public bool IsAdopted { get; set; }

        [ForeignKey("RequestDog")]
        public int? RequestDogId { get; set; }
        public virtual RequestDog RequestDog { get; set; }

        public int PlaceId { get; set; }
        public virtual Place Place { get; set; }

        
    }
}
