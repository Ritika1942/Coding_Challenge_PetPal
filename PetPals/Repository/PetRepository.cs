using PetPals.Model;
using PetPals.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Repository
{
    internal class PetRepository : IPetRepository 
    {
        private readonly string _connectionString;
        private SqlCommand _cmd;

        public PetRepository()
        {
            _connectionString = DBConnection.GetConnectionString();
            _cmd = new SqlCommand();
        }

        public List<Pet> GetAllPets()
        {
            List<Pet> pets = new List<Pet>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    _cmd.CommandText = "SELECT * FROM Pets";
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
                    Console.WriteLine("Error retrieving pets: " + ex.Message);
                }
            }

            return pets;
        }

        public Pet GetPetById(int petId)
        {
            Pet pet = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    _cmd.CommandText = "SELECT * FROM Pets WHERE PetID = @PetID";
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
                    Console.WriteLine("Error retrieving pet by ID: " + ex.Message);
                }
            }

            return pet;
        }

        public void AddPet(Pet pet)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    // SQL Query with placeholders for parameters
                    string query = @"INSERT INTO Pets (Name, Age, Breed, Type, AvailableForAdoption) 
                             VALUES (@Name, @Age, @Breed, @Type, @AvailableForAdoption)";

                    // Create the SQL command
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Clear existing parameters just in case
                        cmd.Parameters.Clear();

                        // Check if pet.Type is null or empty (to avoid passing null or empty value)
                        if (string.IsNullOrEmpty(pet.Type))
                        {
                            throw new ArgumentException("Type cannot be null or empty");
                        }

                        // Add parameters
                        cmd.Parameters.AddWithValue("@Name", pet.Name);
                        cmd.Parameters.AddWithValue("@Age", pet.Age);
                        cmd.Parameters.AddWithValue("@Breed", pet.Breed);
                        cmd.Parameters.AddWithValue("@Type", pet.Type); // Ensure this is supplied
                        cmd.Parameters.AddWithValue("@AvailableForAdoption", pet.AvailableForAdoption);

                        // Open the connection
                        conn.Open();

                        // Execute the SQL query
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if the operation was successful
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Pet added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Error: No rows affected.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding pet: " + ex.Message);
                }
            }
        }




        public void UpdatePetAdoptionStatus(int petId, bool isAvailable)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    _cmd.CommandText = @"UPDATE Pets 
                                         SET AvailableForAdoption = @AvailableForAdoption 
                                         WHERE PetID = @PetID";
                    _cmd.Connection = conn;
                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@AvailableForAdoption", isAvailable);
                    _cmd.Parameters.AddWithValue("@PetID", petId);

                    conn.Open();
                    _cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating adoption status: " + ex.Message);
                }
            }
        }

        public bool UpdatePet(Pet pet)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    _cmd.CommandText = @"UPDATE Pets 
                                         SET Name = @Name, Age = @Age, Breed = @Breed, Type = @Type, AvailableForAdoption = @AvailableForAdoption 
                                         WHERE PetID = @PetID";
                    _cmd.Connection = conn;
                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@PetID", pet.PetID);
                    _cmd.Parameters.AddWithValue("@Name", pet.Name);
                    _cmd.Parameters.AddWithValue("@Age", pet.Age);
                    _cmd.Parameters.AddWithValue("@Breed", pet.Breed);
                    _cmd.Parameters.AddWithValue("@Type", pet.Type);
                    _cmd.Parameters.AddWithValue("@AvailableForAdoption", pet.AvailableForAdoption);

                    conn.Open();
                    int rowsAffected = _cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Return true if the update was successful
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating pet: " + ex.Message);
                    return false;
                }
            }
        }

        public bool DeletePet(int petId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    _cmd.CommandText = @"DELETE FROM Pets WHERE PetID = @PetID";
                    _cmd.Connection = conn;
                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@PetID", petId);

                    conn.Open();
                    int rowsAffected = _cmd.ExecuteNonQuery();
                    return rowsAffected > 0; 
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting pet: " + ex.Message);
                    return false;
                }
            }
        }

        private Pet ExtractPet(SqlDataReader reader)
        {
            return new Pet
            {
                PetID = (int)reader["PetID"],
                Name = (string)reader["Name"],
                Age = (int)reader["Age"],
                Breed = (string)reader["Breed"],
                Type = (string)reader["Type"],
                AvailableForAdoption = (bool)reader["AvailableForAdoption"]
            };
        }
    }
}
