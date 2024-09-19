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
        private string connectionString = "Data Source=HP_ADMIN_H;Initial Catalog=FARMMANAGEMENT;Integrated Security=True";

        public List<Animal> GetAnimals()
        {
            List<Animal> animals = new List<Animal>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ANIMALS";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Animal animal;
                    switch (reader["type"].ToString())
                    {
                        case "Cow":
                            animal = new Cow();
                            break;
                        case "Sheep":
                            animal = new Sheep();
                            break;
                        case "Goat":
                            animal = new Goat();
                            break;
                        default:
                            animal = new Animal();
                            break;
                    }
                    animal.id = reader["id"].ToString();
                    animal.type = reader["ANIMALTYPE"].ToString();
                    animal.sound = reader["SOUND"].ToString();
                    animals.Add(animal);
                    Debug.WriteLine(animal.type);
                }
            }
            return animals;
        }
    }
}
