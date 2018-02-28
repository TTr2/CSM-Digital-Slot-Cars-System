﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Web;

namespace SlotCarsGo_Server.App_Start
{
    public class TestConnection
    {
        // Specify the provider name, server and database.
        private static string providerName = "System.Data.SqlClient";
        private static string serverName = "db725800987.db.1and1.com";
        private static string databaseName = "db725800987";
//        private static string serverName = @"(localdb)\MSSQLLocalDB";
//        private static string databaseName = "slotcarsgo_dev";
        private static string contextClass = "SlotCarsGo_Server.Models.ApplicationDbContext";

        public static string ConnectToDB()
        {
            string message = "Running...";

            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();

            // Set the properties for the data source.
            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;
            sqlBuilder.IntegratedSecurity = true;

            // Build the SqlConnection connection string.
            string connectionString = sqlBuilder.ToString();

            string userId = "dbo725800987";
            string password = "Sl0tC4rsG0!";

            using (SecureString s_password = new SecureString())
            {
                foreach (char c in password)
                {
                    s_password.AppendChar(c);
                }

                SqlCredential sqlCredential = new SqlCredential(userId, s_password);

                using (SqlConnection conn = new SqlConnection(connectionString, sqlCredential))
                {
                    try
                    {
                        conn.Open();
                        message = "Connection opened.";
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        message = $"FAILED: { e.Message}\n{e.StackTrace}\n{e.Source}";
                    }

                }
            }

            return message;
        }
    }
}