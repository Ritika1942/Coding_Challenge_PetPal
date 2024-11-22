using PetPals.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Repository
{
    internal interface IPetRepository
    {
        List<Pet> GetAllPets();
        Pet GetPetById(int petId);
        void AddPet(Pet pet);
        void UpdatePetAdoptionStatus(int petId, bool isAvailable);
        bool DeletePet(int petId);
        bool UpdatePet(Pet pet);
    }
}
