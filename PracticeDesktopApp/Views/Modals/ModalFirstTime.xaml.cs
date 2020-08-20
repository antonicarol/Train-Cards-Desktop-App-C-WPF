using PracticeDesktopApp.Controllers;
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

namespace PracticeDesktopApp.Views.Modals
{
    /// <summary>
    /// Lógica de interacción para ModalFirstTime.xaml
    /// </summary>
    public partial class ModalFirstTime : Window
    {
        private MainWindow window;
        SqlConnection con;
        SqlCommand cmd;
        UsersDAO usersDAO;
        static String connectionString = @"Data Source=DESKTOP-5S6R1GD;Initial Catalog=Users;Integrated Security=True";
        public ModalFirstTime(MainWindow win)
        {
            InitializeComponent();
            window = win;
            usersDAO = new UsersDAO();
            window.isModalOpen = true;
        }
 

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            String message = "Invalid Credentials";
            Tuple<bool, string> response;

            try
            {
                string username = txtUsername.Text.ToString();
                string gender = "Male";
                string birthdate = BirthDate.SelectedDate.ToString();
                //We open SQL CONNECTION
                response = usersDAO.FirstProfileSetUp(username, gender, birthdate);
                
                if(response.Item1)
                {
                    
                    if (usersDAO.FirstTimeDone()) {
                        window.UpdateUI();
                    }
                    CloseModal();
                }
                else
                {
                    MessageBox.Show(message, "Info");
                }

            }
            catch (Exception ex)
            {
                message = ex.Message.ToString();
                message = ex.Message.ToString();
            }
            
               
        }

       

        private void CloseModal()
        {
            window.isModalOpen = false;
            Close();
        }
    }
}
