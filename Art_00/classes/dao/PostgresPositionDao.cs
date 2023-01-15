using System;
using System.Collections.Generic;
using System.Text;
using Art_00.classes.model;
using Npgsql; // Need to install package with "dotnet add package npgsql"

namespace Art_00.classes.dao
{
    /**
     * The Position DAO class interacts with a local postgreSQL database to perform CRUD operations on position-related tasks           
     */
    class PostgresPositionDao
    {
        const string CONN_STRING = "Host=localhost:5432;" +
                                   "Username=Thomas;" +
                                   "Password=psqlt2=init;" + 
                                   "Database=ArtemisDB";
        /**
         * Retrieves all positions from the database as an (int, string) paired Dictionary 
         * @param  none
         * @return Dictionary - An (int, string) paired Dictionary where the key is the position id, and the value is the
         * position name
         */
        public async System.Threading.Tasks.Task<Dictionary<int, string>> GetPositionMap()
        {
            var positionMap = new Dictionary<int, string>();

            try
            {
                // Open connection
                await using var conn = new NpgsqlConnection(CONN_STRING);
                await conn.OpenAsync();
                try
                {
                    // Retrieve all rows
                    await using (var cmd = new NpgsqlCommand("SELECT * FROM positions", conn))
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            positionMap.Add(reader.GetInt32(0), reader.GetString(1));
                        }
                    }
                }
                catch (Exception executionException)
                {
                    Console.WriteLine("Connection Exception: " + executionException.Message);
                }
            }
            catch (Exception connectionException)
            {
                Console.WriteLine("Connection Exception: " + connectionException.Message);
            }

            return positionMap;
        }
    }
}
