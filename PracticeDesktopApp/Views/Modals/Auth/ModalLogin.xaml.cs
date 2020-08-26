using PracticeDesktopApp.Controllers;
using PracticeDesktopApp.Models;
using PracticeDesktopApp.ViewModel;
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
        AuthViewModel authViewModel;

        public ModalLogin(MainWindow win)
        {
            InitializeComponent();
            authViewModel = new AuthViewModel(window);
            
            window = win;
            window.isLoginOpen = true;
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            if (authViewModel.LogIn(txtEmail.Text.ToString(), txtPassword.Password.ToString()))
            {
                CloseModal();
                window.authorized = true;
                window.CheckAuthorized();
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
