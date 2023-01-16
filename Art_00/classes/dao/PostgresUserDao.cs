using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Art_00.classes.model;
using Npgsql; // Need to install package with "dotnet add package npgsql"
using Nito.AsyncEx.Synchronous;

namespace Art_00.classes.dao
{
    /**
     * The User DAO class interacts with a local postgreSQL database to perform CRUD operations on user-related tasks           
     */
    public class PostgresUserDao
    {
        const string CONN_STRING = "Host=localhost:5432;" +
                                   "Username=Thomas;" +
                                   "Password=psqlt2=init;" +
                                   "Database=ArtemisDB";
        Dictionary<int, string> positionMap = new Dictionary<int, string>();


        public PostgresUserDao() 
        {
            PostgresPositionDao positionDao = new PostgresPositionDao();
            var getPositionMapTask = positionDao.GetPositionMap();
            positionMap = getPositionMapTask.WaitAndUnwrapException();
        }

        /**
         * Retrieves all users from the database as a list of User objects. For each row reader, passes the 
         * reader into the readUser(NpgsqlDataReader reader) method return a User object.
         * @param  none
         * @return List - A list of User objects, reflects all the users in the database
         */
        public async System.Threading.Tasks.Task<List<User>> GetAllUsers()
        {
            List<User> allUsers = new List<User>();

            try
            {
                // Open connection
                await using var conn = new NpgsqlConnection(CONN_STRING);
                await conn.OpenAsync();
                try
                {
                    // Retrieve all rows
                    await using (var cmd = new NpgsqlCommand("SELECT * FROM users", conn))
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            User user = ReadUser(reader);
                            allUsers.Add(user);
                        }
                    }
                }
                catch (Exception executionException)
                {
                    Console.WriteLine("Execution Exception: " + executionException.Message);
                }
            }
            catch (Exception connectionException)
            {
                Console.WriteLine("Connection Exception: " + connectionException.Message);
            }

            return allUsers;
        }


        /**
         * Sends a post request to the database and creates a new user there. Sends another get request to the database and gets
         * the newly created user. Returns that new user with the user id as a User object.
         * @param  User - The user to be created. This User object does not have its userId.
         * @return User - The newly created user, has its userId.
         */
        public async System.Threading.Tasks.Task<User> PostUser(User userToBeAdded)
        {
            try
            {
                // Open connection
                await using var conn = new NpgsqlConnection(CONN_STRING);
                await conn.OpenAsync();
                try
                {
                    // Retrieve all rows
                    await using var cmd = new NpgsqlCommand("INSERT INTO users (position_id, username, password_hash, salt) " +
                                                            "VALUES (@p1, @p2, @p3, @p4) RETURNING *", conn)
                    {
                        Parameters =
                        {
                            new NpgsqlParameter("p1", 5),
                            new NpgsqlParameter("p2", "memearchitect"),
                            new NpgsqlParameter("p3", "Iamadankboy"),
                            new NpgsqlParameter("p4", "helloWaltuh")
                        }
                    };
                    Object res = await cmd.ExecuteNonQueryAsync();
                }
                catch (Exception executionException)
                {
                    Console.WriteLine("Execution Exception: " + executionException.Message);
                }
            }
            catch (Exception connectionException)
            {
                Console.WriteLine("Connection Exception: " + connectionException.Message);
            }

            User user = new User();


            return user;
        }



        /**
         * Uses the NpgsqlDataReader object's row reading to create a User object
         * @param  none
         * @return User - A User object that contains information about the user's id, position, and username
         */
        public User ReadUser(NpgsqlDataReader reader)
        {
            int userId = reader.GetInt32(0);
            string position = "";
            try
            {
                position = positionMap[userId];
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception: " + exception.Message);
            }
            string username = reader.GetString(2);

            User user = new User(userId, position, username);
            return user;
        }
    }
}
