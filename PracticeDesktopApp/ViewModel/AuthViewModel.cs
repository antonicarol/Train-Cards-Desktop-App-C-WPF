using PracticeDesktopApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PracticeDesktopApp.ViewModel
{
    class AuthViewModel
    {
        private Window window;
        private UsersDAO usersDAO;

        public AuthViewModel(Window w)
        {
            window = w;
            usersDAO = new UsersDAO();
        }

        internal bool LogIn(string email, string password)
        {
            string message = "Invalid Credentials";
            Tuple<bool, string> response;
            try
            {
                response = usersDAO.LoginUser(email, password);

                if (response.Item1)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(response.Item2, "Info");
                    return false;
                }

            }
            catch (Exception ex)
            {
                message = ex.Message.ToString();
                message = ex.Message.ToString();
                return false;
            }
        }

        internal bool Register(string email, string password, string repPassword)
        {
            string message = "Invalid Credentials";
            Tuple<bool, string> response;

            try
            {
                response = usersDAO.RegisterUser(email, password, repPassword);

                if (response.Item1)
                {
                    return true;
                }
                else
                    MessageBox.Show(response.Item2, "Info");
                    return false;


            }
            catch (Exception ex)
            {
                message = ex.Message.ToString();
                message = ex.Message.ToString();
                MessageBox.Show(message, "Info");
                return false;
            }

        }
    }
  }

