using PracticeDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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
            cmd.Dispose();
            con.Close();
        }

        #region AUthroization : Login and Register

        public Tuple<bool,string> RegisterUser(string email, string password, string repPassword)
        {
            bool response = false;
            string message = "Invalid Credentials";
            con.Open();

            if(password == repPassword)
            {
                cmd = new SqlCommand("INSERT INTO [Users].[dbo].[User] (Email,Password) VALUES(@Email, @Password);", con);

                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                int row = cmd.ExecuteNonQuery();
                if( row != 0)
                {
                    response = true;

                    UserInfo.Email = email;
                }
            }
            EndDBConnection();
            return new Tuple<bool, string> (response, message);
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

                    response = true;

                }
            }
            EndDBConnection();
            return new Tuple<bool, string>(response, message);
        }


        #endregion

        #region Update User Data

        public Tuple<bool,string> FirstProfileSetUp(string userName, string gender, string birthdate)
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
            if(row != 0)
            {
                response = true;
                UserInfo.FirstTime = 1;
            }
            else{
                response = false;
            }
            EndDBConnection();
            return response;
            
        }

        #endregion

    }
}
