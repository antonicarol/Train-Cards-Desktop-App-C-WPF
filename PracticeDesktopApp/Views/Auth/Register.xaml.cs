using PracticeDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PracticeDesktopApp.Views.Auth
{
    /// <summary>
    /// Lógica de interacción para Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        SqlConnection con;
        SqlCommand cmd;
  
        static String connectionString = @"Data Source=DESKTOP-5S6R1GD;Initial Catalog=Users;Integrated Security=True";
        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            String message = "Invalid Credentials";

            // We open SQL CONNECTION
            try
            {
                con = new SqlConnection(connectionString);
                con.Open();
                //We Launch the command, we want to get the user with an specific email
                cmd = new SqlCommand("INSERT INTO [Users].[dbo].[User] (Name,Email,Password) VALUES(@Name, @Email, @Password);", con);
                //HEre we define the value of teh @variables
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.ToString());
                cmd.Parameters.AddWithValue("@Name", txtUserId.Text.ToString());
                cmd.Parameters.AddWithValue("@Password", txtPassword.Password.ToString());
                //We execute the command
                int row = cmd.ExecuteNonQuery();
                if (row != 0)
                {
                    message = "1";
                    //We make sure that the password is the same, to do the auth


                    UserInfo.Email = txtEmail.Text.ToString();
                    UserInfo.Name = txtUserId.Text.ToString();

                }
                //We close everything
                cmd.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                message = ex.Message.ToString();
                message = ex.Message.ToString();
            }
            if (message == "1")
            {
                Login login = new Login();
                login.Show(); 
                Close();
            }
            else
                MessageBox.Show(message, "Info");
        }


     

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }
    }
}

