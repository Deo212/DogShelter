using DogShelter.Abstractions;
using DogShelter.Entities;
using PriutZaKucheta.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogShelter.Services
{
    public class AdoptiveService : IAdoptiveService
    {
        private readonly ApplicationDbContext _context;

        public AdoptiveService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateAdoptive(string firstName, string lastName, string phone, DateTime birthDate, string userId)
        {
            if (_context.Adoptives.Any(p => p.UserId == userId))
            {
                throw new InvalidOperationException("Adoptive already exist.");
            }
            Adoptive adoptiveFromDb = new Adoptive()
            {
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                BirthDate = birthDate,
                UserId = userId
            };
            _context.Adoptives.Add(adoptiveFromDb);

            return _context.SaveChanges() != 0;
        }

        public Adoptive GetAdoptiveById(int adoptiveId)
        {
            throw new NotImplementedException();
        }

        public Adoptive GetAdoptiveByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public List<Adoptive> GetAdoptives()
        {

            List<Adoptive> adoptives = _context.Adoptives.ToList();

            return adoptives;
        }

        public string GetFullName(int adoptiveId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(int adoptiveId)
        {
            throw new NotImplementedException();
        }
    }
}
