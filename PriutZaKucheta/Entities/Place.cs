using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogShelter.Entities
{
    public class Place
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Area { get; set; }

        public int DogId { get; set; }

        public ICollection<Dog> Dogs { get; set; } = new List<Dog>();
    }
}
