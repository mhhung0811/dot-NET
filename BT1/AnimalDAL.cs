using BT1.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT1
{
    internal class AnimalDAL
    {
        private string connectionString = "Put connectionString here!";

        public List<Animal> GetAnimals()
        {
            List<Animal> animals = new List<Animal>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM animal";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Animal animal;
                    switch (reader["type"].ToString())
                    {
                        case "COW":
                            animal = new Cow();
                            break;
                        case "SHEEP":
                            animal = new Sheep();
                            break;
                        case "GOAT":
                            animal = new Goat();
                            break;
                        default:
                            animal = new Animal();
                            break;
                    }
                    animal.id = reader["id"].ToString();
                    animal.type = reader["type"].ToString();
                    animal.sound = reader["sound"].ToString();
                    animal.milk = float.Parse(reader["milk"].ToString());
                    animals.Add(animal);
                }
            }
            return animals;
        }

        public void AddAnimal(Animal animal)
        {
            // Validate input data (optional but recommended)
            if (animal == null)
            {
                throw new ArgumentNullException(nameof(animal), "Animal cannot be null");
            }

            // Use a parameterized query to prevent SQL injection attacks
            string query = "INSERT INTO animal (id, type, sound, milk) VALUES (@id, @type, @sound, @milk)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id",animal.id);
                    cmd.Parameters.AddWithValue("@type", animal.type);
                    cmd.Parameters.AddWithValue("@sound", animal.sound);
                    cmd.Parameters.AddWithValue("@milk", animal.milk);

                    cmd.ExecuteNonQuery(); // Execute the INSERT statement
                }
            }
        }

        public void UpdateAnimal(Animal animal)
        {
            // Validate input data (optional but recommended)
            if (animal == null || string.IsNullOrEmpty(animal.id))
            {
                throw new ArgumentException("Animal object or its ID cannot be null or empty");
            }

            // Use a parameterized query to prevent SQL injection attacks
            string query = "UPDATE animal SET type = @type, sound = @sound, milk = @milk WHERE id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", animal.id);
                    cmd.Parameters.AddWithValue("@type", animal.type);
                    cmd.Parameters.AddWithValue("@sound", animal.sound);
                    cmd.Parameters.AddWithValue("@milk", animal.milk);

                    int rowsAffected = cmd.ExecuteNonQuery(); // Execute the UPDATE statement

                    if (rowsAffected == 0)
                    {
                        Console.WriteLine($"Warning: No animal with ID '{animal.id}' was found to update.");
                    }
                }
            }
        }
    }
}
