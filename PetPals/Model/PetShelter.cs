using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Model
{
    internal class PetShelter
    {
        public List<Pet> AvailablePets { get; set; }
        public PetShelter()
        {
            AvailablePets = new List<Pet>();
        }
        public void AddPet(Pet pet)
        {
            if (pet != null && !AvailablePets.Contains(pet))
            {
                AvailablePets.Add(pet);
            }
        }
        public void RemovePet(Pet pet)
        {
            if (pet != null && AvailablePets.Contains(pet))
            {
                AvailablePets.Remove(pet);
            }
        }
        public void ListAvailablePets()
        {
            if (AvailablePets.Count == 0)
            {
                Console.WriteLine("No pets available for adoption.");
            }
            else
            {
                foreach (var pet in AvailablePets)
                {
                    Console.WriteLine(pet.ToString());
                }
            }
        }
    }
}
