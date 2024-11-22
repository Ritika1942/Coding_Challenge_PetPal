using System;
using System.Collections.Generic;

namespace PetPals.Service
{
    public class AdoptableService : IAdoptableService
    {
        private readonly List<AdoptableService> _adoptableList;

        public AdoptableService(Repository.IAdoptableRepository adoptableRepository)
        {
            _adoptableList = new List<AdoptableService>();
        }

        public void AddAdoptable(AdoptableService adoptable)
        {
            try
            {
                _adoptableList.Add(adoptable);
                Console.WriteLine($"Adoptable added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding adoptable: {ex.Message}");
            }
        }

        public AdoptableService GetAdoptableById(int participantId)
        {
            try
            {
                return _adoptableList.Find(a => a.GetHashCode() == participantId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching adoptable by ID: {ex.Message}");
                return null;
            }
        }

        public List<AdoptableService> GetAllAdoptables()
        {
            try
            {
                return _adoptableList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching all adoptables: {ex.Message}");
                return new List<AdoptableService>();
            }
        }

        public void UpdateAdoptable(AdoptableService adoptable)
        {
            try
            {
                var existingAdoptable = _adoptableList.Find(a => a.GetHashCode() == adoptable.GetHashCode());
                if (existingAdoptable == null)
                {
                    throw new Exception("Adoptable not found.");
                }

                Console.WriteLine("Adoptable updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating adoptable: {ex.Message}");
            }
        }

        public void DeleteAdoptable(int participantId)
        {
            try
            {
                var adoptable = _adoptableList.Find(a => a.GetHashCode() == participantId);
                if (adoptable == null)
                {
                    throw new Exception("Adoptable not found.");
                }

                _adoptableList.Remove(adoptable);
                Console.WriteLine("Adoptable deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting adoptable: {ex.Message}");
            }
        }

        public void Adopt(int adoptableId, int adopterId)
        {
            try
            {
                var adoptable = _adoptableList.Find(a => a.GetHashCode() == adoptableId);
                if (adoptable == null)
                {
                    throw new Exception("Adoptable not found.");
                }

                Console.WriteLine($"Adoptable with ID {adoptableId} adopted by adopter {adopterId}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during adoption: {ex.Message}");
            }
        }
    }
}
