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
    /// Lógica de interacción para ModalLogin.xaml
    /// </summary>
    public partial class ModalLogin : Window
    {
        MainWindow window;
     
        UsersDAO userDAO;
        public ModalLogin(MainWindow win)
        {
            InitializeComponent();
            userDAO = new UsersDAO();
            window = win;
            window.isLoginOpen = true;
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            String message = "Invalid Credentials";
            Tuple<bool, string> response = new Tuple<bool, string> (false,message);
            try
            {
                response = userDAO.LoginUser(txtEmail.Text.ToString(), txtPassword.Password.ToString());

                if (response.Item1)
                {
                    CloseModal();
                    window.authorized = true;
                    window.CheckAuthorized();
                }
                else
                {
                    MessageBox.Show(response.Item2, "Info");
                }

            }
            catch (Exception ex)
            {
                message = ex.Message.ToString();
                message = ex.Message.ToString();
            }    
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            CloseModal();
            OpenRegisterModal();

        }

        private void OpenRegisterModal()
        {
            ModalRegister register = new ModalRegister(window);
            register.Owner = window;
            register.ShowDialog();
        }
        private void CloseModal()
        {
            window.isLoginOpen = false;
            Close();
        }
    }
}
