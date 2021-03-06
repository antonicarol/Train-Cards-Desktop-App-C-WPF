﻿using PracticeDesktopApp.Models;
using PracticeDesktopApp.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeDesktopApp.Controllers
{
    class UsersDAO
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        static String connectionString;

        

        public UsersDAO()
        {
            DBConnection();
            
        }

        private void DBConnection()
        {
            connectionString = @"Data Source=DESKTOP-5S6R1GD;Initial Catalog=Users;Integrated Security=True";
            con = new SqlConnection(connectionString);

        }
        private void EndDBConnection()
        {
            if(cmd != null)
            {
                cmd.Dispose();
            }
            
            con.Close();
        }

        #region AUthroization : Login and Register

        public Tuple<bool, string> RegisterUser(string email, string password, string repPassword)
        {
            bool response = false;
            string message = "Invalid Credentials";

            if (AuthValidation.CheckSecurePassword(password))
            {
                if (AuthValidation.CheckPasswordMatch(password, repPassword))
                {
                    if (CheckAccountWithEmail(email))
                    {
                        message = "Already a user created with that Email!";
                    }
                    else
                    {
                        con.Open();
                        cmd = new SqlCommand("INSERT INTO [Users].[dbo].[User] (Email,Password) VALUES(@Email, @Password);", con);

                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        int row = cmd.ExecuteNonQuery();

                        if (row != 0)
                        {
                            response = true;

                            UserInfo.Email = email;
                        }
                    }
                }
            }
            else
            {
                message = "Please enter a valid password!";
            }
            
            EndDBConnection();
            return new Tuple<bool, string>(response, message);
        }



        public bool GamePurchased(int user_Id, Game game)
        {
            con.Open();
            cmd = new SqlCommand("UPDATE[Users].[dbo].[User] SET Currency = @NewCurrency WHERE Id = @Id;",con);
            cmd.Parameters.AddWithValue("@Id", user_Id);
            cmd.Parameters.AddWithValue("@NewCurrency", UserInfo.Currency - game.Price);

            int row = cmd.ExecuteNonQuery();
            if(row != 0)
            {
                UserInfo.Currency -= game.Price;
                EndDBConnection();
                return true;
            }
            EndDBConnection();
            return false;

        }

        private bool CheckAccountWithEmail(string email)
        {
            con.Open();
            cmd = new SqlCommand("SELECT * FROM [Users].[dbo].[User] WHERE Email=@Email;", con);
            cmd.Parameters.AddWithValue("@Email", email);


            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                return true;
            }
            EndDBConnection();
            return false;

        }

        public Tuple<bool, string> LoginUser(string email, string password)
        {
            bool response = false;
            string message = "Invalid Credentials";
            con.Open();

            cmd = new SqlCommand("SELECT * from [Users].[dbo].[User] WHERE Email=@Email;", con);

            cmd.Parameters.AddWithValue("@Email", email);

            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                
                if (reader["Password"].ToString().Equals(password, StringComparison.InvariantCulture))
                {

                    UserInfo.Email = email;
                    UserInfo.FirstTime = (int)reader["FirstTime"];
                    UserInfo.Id = (int)reader["Id"];
                    UserInfo.Currency = float.Parse(reader["Currency"].ToString());

                    response = true;

                }
            }
            EndDBConnection();
            return new Tuple<bool, string>(response, message);
        }


        #endregion

        #region Update User Data

        public Tuple<bool, string> FirstProfileSetUp(string userName, string gender, string birthdate)
        {
            string message = "Something went wrong :(";
            bool response = false;

            con.Open();

            cmd = new SqlCommand("UPDATE [Users].[dbo].[User] SET BirthDate = @BirthDate, Gender = @Gender, Name=@Name WHERE Email=@Email", con);
            cmd.Parameters.AddWithValue("@Name", userName);
            cmd.Parameters.AddWithValue("@BirthDate", birthdate);
            cmd.Parameters.AddWithValue("@Email", UserInfo.Email);
            cmd.Parameters.AddWithValue("@Gender", gender);

            int row = cmd.ExecuteNonQuery();
            if (row != 0)
            {
                response = true;
                UserInfo.BirthDate = birthdate;
                UserInfo.Gender = gender;
                UserInfo.Name = userName;
            }
            EndDBConnection();

            return new Tuple<bool, string>(response, message);
        }

        public bool FirstTimeDone()
        {
            bool response;
            con.Open();
            cmd = new SqlCommand("UPDATE [Users].[dbo].[User] SET FirstTime=1 WHERE Email=@Email", con);
            cmd.Parameters.AddWithValue("@Email", UserInfo.Email);
            int row = cmd.ExecuteNonQuery();
            if (row != 0)
            {
                response = true;
                UserInfo.FirstTime = 1;
                UserInfo.Currency = 20;
            }
            else
            {
                response = false;
            }
            EndDBConnection();
            return response;

        }

        #endregion

    }
}
