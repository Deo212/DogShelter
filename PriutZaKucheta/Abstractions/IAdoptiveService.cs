using DogShelter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogShelter.Abstractions
{
    public interface IAdoptiveService
    {
        List<Adoptive> GetAdoptives();

        Adoptive GetAdoptiveById(int adoptiveId);

        public bool RemoveById(int adoptiveId);

        string GetFullName(int adoptiveId);

        bool CreateAdoptive(string firstName, string lastName, string phone, DateTime birthDate, string userId);

        public Adoptive GetAdoptiveByUserId(string userId);
    }
}