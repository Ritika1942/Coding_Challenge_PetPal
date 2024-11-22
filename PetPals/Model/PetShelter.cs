using System;
using System.Collections.Generic;

namespace PetPals.Model
{
    internal class PetShelter
    {
        private List<Pets> availablePets;
        public PetShelter()
        {
            availablePets = new List<Pets>();
        }
        public void AddPet(Pets pet)
        {
            availablePets.Add(pet);
            Console.WriteLine($"{pet.Name} has been added to the shelter.");
        }
        public void RemovePet(Pets pet)
        {
            if (availablePets.Contains(pet))
            {
                availablePets.Remove(pet);
                Console.WriteLine($"{pet.Name} has been removed from the shelter.");
            }
            else
            {
                Console.WriteLine($"{pet.Name} was not found in the shelter.");
            }
        }
        public void ListAvailablePets()
        {
            if (availablePets.Count > 0)
            {
                Console.WriteLine("Available Pets for Adoption:");
                foreach (var pet in availablePets)
                {
                    Console.WriteLine(pet.ToString());
                }
            }
            else
            {
                Console.WriteLine("No pets are available for adoption at the moment.");
            }
        }
    }
}

