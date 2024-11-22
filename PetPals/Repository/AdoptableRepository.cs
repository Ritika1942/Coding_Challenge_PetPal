using PetPals.Model;
using PetPals.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PetPals.Repository
{
    internal class AdoptableRepository : IAdoptableRepository
    {
        private readonly string connectionString;
        private SqlCommand _cmd;

        public AdoptableRepository()
        {
            connectionString = DBConnection.GetConnectionString();
            _cmd = new SqlCommand();
        }

        public List<Pets> GetAllAdoptablePets()
        {
            List<Pets> pets = new List<Pets>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = "SELECT * FROM Pets WHERE AvailableForAdoption = 1";
                    _cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = _cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        pets.Add(ExtractPet(reader));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving adoptable pets: {ex.Message}");
                }
            }

            return pets;
        }

        public Pets GetPetById(int petId)
        {
            Pets pet = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = "SELECT * FROM Pets WHERE PetID = @PetID";
                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@PetID", petId);
                    _cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = _cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        pet = ExtractPet(reader);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving pet by ID: {ex.Message}");
                }
            }

            return pet;
        }

        public void AddPet(Pets pet)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = @"INSERT INTO Pets (Name, Age, Breed, Type, AvailableForAdoption)
                                         VALUES (@Name, @Age, @Breed, @Type, @AvailableForAdoption)";
                    _cmd.Connection = conn;

                    // Add parameters
                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@Name", pet.Name);
                    _cmd.Parameters.AddWithValue("@Age", pet.Age);
                    _cmd.Parameters.AddWithValue("@Breed", pet.Breed);
                    _cmd.Parameters.AddWithValue("@Type", pet.Type);
                    _cmd.Parameters.AddWithValue("@AvailableForAdoption", pet.AvailableForAdoption);

                    conn.Open();
                    _cmd.ExecuteNonQuery();
                    Console.WriteLine($"{pet.Name} has been added to the shelter.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding pet: {ex.Message}");
                }
            }
        }

        public void UpdatePetAvailability(int petId, bool isAvailable)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = "UPDATE Pets SET AvailableForAdoption = @Available WHERE PetID = @PetID";
                    _cmd.Connection = conn;

                    // Add parameters
                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@Available", isAvailable);
                    _cmd.Parameters.AddWithValue("@PetID", petId);

                    conn.Open();
                    _cmd.ExecuteNonQuery();
                    Console.WriteLine($"Pet availability updated for Pet ID {petId}.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating pet availability: {ex.Message}");
                }
            }
        }

        public void RemovePet(int petId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = "DELETE FROM Pets WHERE PetID = @PetID";
                    _cmd.Connection = conn;

                    // Add parameter
                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@PetID", petId);

                    conn.Open();
                    _cmd.ExecuteNonQuery();
                    Console.WriteLine($"Pet with ID {petId} has been removed.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error removing pet: {ex.Message}");
                }
            }
        }

        private Pets ExtractPet(SqlDataReader reader)
        {
            return new Pets(
                (int)reader["PetID"],
                (string)reader["Name"],
                (int)reader["Age"],
                (string)reader["Breed"],
                (string)reader["Type"],
                (bool)reader["AvailableForAdoption"]
            );
        }
    }
}
