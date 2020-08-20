﻿using PracticeDesktopApp.Controllers;
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
    /// Lógica de interacción para ModalRegister.xaml
    /// </summary>
    public partial class ModalRegister : Window
    {
        MainWindow window;
       
        UsersDAO userDAO;
        
        public ModalRegister(MainWindow win)
        {
            InitializeComponent();
            window = win;
            window.isRegisterOpen = true;
            userDAO = new UsersDAO();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            String message = "Invalid Credentials";
            Tuple<bool, string> response;
            
            try
            {
                
         

                string email = txtEmail.Text.ToString();
                string password = txtPassword.Password.ToString();
                string repPassword = txtRepeatPassword.Password.ToString();

                response = userDAO.RegisterUser(email, password, repPassword);
                
                if (response.Item1)
                {
                    CloseModal();
                    OpenLogInModal();
                }
                else
                    MessageBox.Show(response.Item2, "Info");
               

            }
            catch (Exception ex)
            {
                message = ex.Message.ToString();
                message = ex.Message.ToString();
                MessageBox.Show(message, "Info");
            }
         
           
        }

        private void OpenLogInModal()
        {
           
            ModalLogin login = new ModalLogin(window);
            login.Owner = window;
            login.ShowDialog();

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            CloseModal();
            OpenLogInModal();
           
        }
        private void CloseModal()
        {
            window.isRegisterOpen = false;
            Close();
        }
    }
}
