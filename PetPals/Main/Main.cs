using PetPals.Model;
using PetPals.Repository;
using PetPals.Service;
using System;

namespace PetPals
{
    class Program
    {
        static void Main(string[] args)
        {
            IPetRepository petRepository = new PetRepository(); 
            IPetService petService = new PetService(petRepository);
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Pet Management System");
                Console.WriteLine("1. Add Pet");
                Console.WriteLine("2. View All Pets");
                Console.WriteLine("3. View Pet by ID");
                Console.WriteLine("4. Update Pet");
                Console.WriteLine("5. Delete Pet");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddPet(petService);
                        break;
                    case "2":
                        petService.GetAllPets();
                        break;
                    case "3":
                        ViewPetById(petService);
                        break;
                    case "4":
                        UpdatePet(petService);
                        break;
                    case "5":
                        DeletePet(petService);
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private static void AddPet(IPetService petService)
        {
            Console.WriteLine("\nEnter Pet details to add:");

            // Taking input for Pet details
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Breed: ");
            string breed = Console.ReadLine();

            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Type: ");
            string type = Console.ReadLine();

            // Validate the 'Type' field
            while (string.IsNullOrEmpty(type))
            {
                Console.Write("Pet type cannot be empty. Please enter a valid type (e.g., Dog, Cat): ");
                type = Console.ReadLine();
            }

            // Validate AvailableForAdoption to accept only 'yes' or 'no'
            string availableForAdoptionInput;
            bool availableForAdoption = false;  // Default value

            while (true)
            {
                Console.Write("Available for adoption (yes/no): ");
                availableForAdoptionInput = Console.ReadLine().Trim().ToLower();

                if (availableForAdoptionInput == "yes")
                {
                    availableForAdoption = true;
                    break;
                }
                else if (availableForAdoptionInput == "no")
                {
                    availableForAdoption = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                }
            }

            // Create the new Pet object
            Pet newPet = new Pet
            {
                Name = name,
                Breed = breed,
                Age = age,
                Type = type,  // Ensure the type is set correctly
                AvailableForAdoption = availableForAdoption  // Set adoption status
            };

            // Call AddPet on the PetService to add the pet
            petService.AddPet(newPet);

            Console.WriteLine("Pet added successfully!");
        }

        private static void ViewPetById(IPetService petService)
        {
            Console.Write("\nEnter Pet ID to view: ");
            int petId = int.Parse(Console.ReadLine());

            
            petService.GetPetById(petId);  
        }

        private static void UpdatePet(IPetService petService)
        {
            Console.Write("\nEnter Pet ID to update: ");
            int petId = int.Parse(Console.ReadLine());
            petService.GetPetById(petId);  

            Console.WriteLine("\nEnter new details:");

            Pet petToUpdate = new Pet
            {
                PetID = petId 
            };

            Console.Write("Name: ");
            petToUpdate.Name = Console.ReadLine();

            Console.Write("Breed: ");
            petToUpdate.Breed = Console.ReadLine();

            Console.Write("Age: ");
            petToUpdate.Age = int.Parse(Console.ReadLine());

            petService.UpdatePet(petToUpdate);
        }

        private static void DeletePet(IPetService petService)
        {
            Console.Write("\nEnter Pet ID to delete: ");
            int petId = int.Parse(Console.ReadLine());

            petService.DeletePet(petId);
        }
    }
}
