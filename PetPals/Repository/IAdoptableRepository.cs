using System.Collections.Generic;
using PetPals.Model;

namespace PetPals.Repository
{
    internal interface IAdoptableRepository
    {
        List<Pets> GetAllAdoptablePets();
        Pets GetPetById(int petId);
        void AddPet(Pets pet);
        void UpdatePetAvailability(int petId, bool isAvailable);
        void RemovePet(int petId);
    }
}
