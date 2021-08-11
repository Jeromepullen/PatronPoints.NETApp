using PatronPointsRewards.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PatronPointsRewards.Services
{
    public class RewardsDAO : RewardsDataService
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PatronPointsRewards;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int Delete(RewardsModel rewards)
        {
            int newIdNumber = -1;

            string sqlStatement = "DELETE * FROM dbo.Rewards WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", rewards.Id);

                try
                {
                    connection.Open();

                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());


                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return newIdNumber;
        }

        public List<RewardsModel> GetAllRewards()
        {
            List<RewardsModel> foundRewards = new List<RewardsModel>();

            string sqlStatement = "SELECT * FROM dbo.Rewards";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundRewards.Add(new RewardsModel { Id = (int)reader[0], Name = (string)reader[1], Rewards = (int)reader[2], RewardsType = (string)reader[3] });
                    }

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return foundRewards;
        }

        public RewardsModel GetUserById(int id)
        {
            RewardsModel foundReward = null;

            string sqlStatement = "SELECT * FROM dbo.Rewards WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("Id", id);
                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundReward = new RewardsModel { Id = (int)reader[0], Name = (string)reader[1], Rewards = (int)reader[2], RewardsType = (string)reader[3] };
                    }

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return foundReward;
        }

        public int Insert(RewardsModel rewards)
        {
            int newIdNumber = 1;

            string sqlStatement = "INSERT INTO dbo.Rewards (Id, Name, Rewards, RewardsType)" +
                "VALUES (@Id, @Name, @Rewards, @RewardsType)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", rewards.Id);
                command.Parameters.AddWithValue("@Name", rewards.Name);
                command.Parameters.AddWithValue("@Rewards", rewards.Rewards);
                command.Parameters.AddWithValue("@RewardsType", rewards.RewardsType);
                try
                {
                    connection.Open();

                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());


                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return newIdNumber;
        }

        public List<RewardsModel> SearchRewards(string searchTerm)
        {
            List<RewardsModel> foundRewards = new List<RewardsModel>();

            string sqlStatement = "SELECT * FROM dbo.Rewards WHERE Name LIKE @Name";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", searchTerm);
                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundRewards.Add(new RewardsModel { Id = (int)reader[0], Name = (string)reader[1], Rewards = (int)reader[2], RewardsType = (string)reader[3] });
                    }

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return foundRewards;
        }

        public int Update(RewardsModel rewards)
        {
            int newIdNumber = -1;

            string sqlStatement = "SELECT * FROM dbo.Rewards SET Name = @Name, Rewards = @Rewards, RewardsType = @RewardsType WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", rewards.Name);
                command.Parameters.AddWithValue("@Rewards", rewards.Rewards);
                command.Parameters.AddWithValue("@RewardsType", rewards.RewardsType);
                try
                {
                    connection.Open();

                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
 

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return newIdNumber;
        }
    }
}
