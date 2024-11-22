using PetPals.Model;
using PetPals.Repository;
using PetPals.Service;
using System;
using System.Collections.Generic;

namespace PetPals
{
    class Program
    {
        static void Main(string[] args)
        {
            IAdoptableRepository adoptableRepository = new AdoptableRepository();
            IAdoptableService adoptableService = new AdoptableService(adoptableRepository);

            bool continueRunning = true;

            while (continueRunning)
            {
                Console.WriteLine("PetPals - Manage Adoptable Pets");
                Console.WriteLine("1. Add New Adoptable Pet");
                Console.WriteLine("2. Update Adoptable Pet");
                Console.WriteLine("3. Remove Adoptable Pet");
                Console.WriteLine("4. View Adoptable Pet By ID");
                Console.WriteLine("5. View All Adoptable Pets");
                Console.WriteLine("6. Adopt a Pet");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        
                        Console.WriteLine("Enter Pet Details:");
                        Adoptable newPet = new Adoptable();

                        Console.Write("Name: ");
                        newPet.Name = Console.ReadLine();

                        Console.Write("Breed: ");
                        newPet.Breed = Console.ReadLine();

                        Console.Write("Age (in years): ");
                        newPet.Age = int.Parse(Console.ReadLine());

                        newPet.IsAdopted = false;

                        adoptableService.AddAdoptable(newPet);
                        Console.WriteLine("Adoptable pet added successfully.");
                        break;

                    case "2":
                        Console.Write("Enter Pet ID to update: ");
                        int updatePetID = int.Parse(Console.ReadLine());

                        Adoptable existingPet = adoptableService.GetAdoptableById(updatePetID);
                        if (existingPet != null)
                        {
                            Console.Write("New Name (leave blank to keep current): ");
                            string newName = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(newName)) existingPet.Name = newName;

                            Console.Write("New Breed (leave blank to keep current): ");
                            string newBreed = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(newBreed)) existingPet.Breed = newBreed;

                            Console.Write("New Age (leave blank to keep current): ");
                            string newAge = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(newAge)) existingPet.Age = int.Parse(newAge);

                            adoptableService.UpdateAdoptable(existingPet);
                            Console.WriteLine("Adoptable pet updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Pet not found.");
                        }
                        break;

                    case "3":
                       
                        Console.Write("Enter Pet ID to remove: ");
                        int removePetID = int.Parse(Console.ReadLine());

                        adoptableService.DeleteAdoptable(removePetID);
                        Console.WriteLine("Adoptable pet removed successfully.");
                        break;

                    case "4":
                        
                        Console.Write("Enter Pet ID: ");
                        int viewPetID = int.Parse(Console.ReadLine());

                        Adoptable pet = adoptableService.GetAdoptableById(viewPetID);
                        if (pet != null)
                        {
                            Console.WriteLine($"Name: {pet.Name}");
                            Console.WriteLine($"Breed: {pet.Breed}");
                            Console.WriteLine($"Age: {pet.Age}");
                            Console.WriteLine($"Adopted: {pet.IsAdopted}");
                        }
                        else
                        {
                            Console.WriteLine("Pet not found.");
                        }
                        break;

                    case "5":
                        
                        List<Adoptable> pets = adoptableService.GetAllAdoptables();
                        if (pets.Count > 0)
                        {
                            Console.WriteLine("Adoptable Pets:");
                            foreach (var p in pets)
                            {
                                Console.WriteLine($"ID: {p.AdoptableID}, Name: {p.Name}, Breed: {p.Breed}, Age: {p.Age}, Adopted: {p.IsAdopted}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No adoptable pets found.");
                        }
                        break;

                    case "6":
                      
                        Console.Write("Enter Pet ID to adopt: ");
                        int adoptableId = int.Parse(Console.ReadLine());

                        Console.Write("Enter Adopter ID: ");
                        int adopterId = int.Parse(Console.ReadLine());

                        adoptableService.Adopt(adoptableId, adopterId);
                        Console.WriteLine("Adoption process completed successfully.");
                        break;

                    case "7":
                        continueRunning = false;
                        Console.WriteLine("Exiting the system. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
