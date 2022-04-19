using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogShelter.Entities
{
    public class RequestDog
    {
        public int Id { get; set; }

        public int DogId { get; set; }
        public virtual Dog Dog { get; set; }

        public int AdoptiveId { get; set; }
        public virtual Adoptive Adoptive { get; set; }

        public DateTime CreatedOn{ get; set; }

        public DateTime DateOfAdoption { get; set; }

        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

        
       
    }
}
