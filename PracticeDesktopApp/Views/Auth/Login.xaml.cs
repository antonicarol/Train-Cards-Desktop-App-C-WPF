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
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        static String connectionString = @"Data Source=DESKTOP-5S6R1GD;Initial Catalog=Users;Integrated Security=True";
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click_1(object sender, RoutedEventArgs e)
        {
            String message = "Invalid Credentials";
            try
            {
                //We open SQL CONNECTION
                con = new SqlConnection(connectionString);
                con.Open();
                //We Launch the command, we want to get the user with an specific email
                cmd = new SqlCommand("SELECT * from [Users].[dbo].[User] WHERE Email=@Email;", con);
                //HEre we define the value of teh @variables
                cmd.Parameters.AddWithValue("@Email", txtUserId.Text.ToString());
                //We execute the command
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    //We make sure that the password is the same, to do the auth
                    if (reader["Password"].ToString().Equals(txtPassword.Password.ToString(), StringComparison.InvariantCulture))
                    {
                        message = "1";
                        UserInfo.Email = txtUserId.Text.ToString();
                        UserInfo.Name = reader["Name"].ToString();
                    }
                }
                //We close everything
                reader.Close();
                reader.Dispose();
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
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
                MessageBox.Show(message, "Info");
        }

       

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();

            register.Show();
            Close();
        }
    }
}
        
    

