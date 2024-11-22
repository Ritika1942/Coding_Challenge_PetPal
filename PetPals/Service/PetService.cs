using PetPals.Model;
using PetPals.Repository;  
using System;
using System.Collections.Generic;

namespace PetPals.Service
{
    internal class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public void GetAllPets()
        {
            List<Pet> pets = _petRepository.GetAllPets();
            if (pets.Count == 0)
            {
                Console.WriteLine("No pets found.");
            }
            else
            {
                Console.WriteLine("Pets:");
                foreach (var pet in pets)
                {
                    Console.WriteLine($"Pet ID: {pet.PetID}, Name: {pet.Name}, Breed: {pet.Breed}, Age: {pet.Age}");
                }
            }
        }
        public void GetPetById(int petId)
        {
            Pet pet = _petRepository.GetPetById(petId); 
            if (pet == null)
            {
                Console.WriteLine($"Pet not found with ID: {petId}");
            }
            else
            {
                Console.WriteLine($"Pet Found: ID: {pet.PetID}, Name: {pet.Name}, Breed: {pet.Breed}, Age: {pet.Age}");
            }
        }


        public void AddPet(Pet pet)
        {
            _petRepository.AddPet(pet);
            Console.WriteLine("Pet added successfully.");
        }

        public void UpdatePet(Pet pet)
        {
            bool updated = _petRepository.UpdatePet(pet);
            if (updated)
            {
                Console.WriteLine("Pet updated successfully.");
            }
            else
            {
                Console.WriteLine("Update failed. Pet not found.");
            }
        }

        public void DeletePet(int petId)
        {
            bool deleted = _petRepository.DeletePet(petId);
            if (deleted)
            {
                Console.WriteLine("Pet deleted successfully.");
            }
            else
            {
                Console.WriteLine("Delete failed. Pet not found.");
            }
        }
    }
}
