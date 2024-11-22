using PetPals.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Service
{
    internal interface IPetService
    {
        void GetAllPets();
        void GetPetById(int petId);
        void AddPet(Pet pet);
        void UpdatePet(Pet pet);
        void DeletePet(int petId);
    }
}
