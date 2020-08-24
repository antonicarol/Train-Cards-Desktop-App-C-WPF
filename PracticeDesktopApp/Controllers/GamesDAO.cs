using MaterialDesignThemes.Wpf;
using PracticeDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PracticeDesktopApp.Controllers
{


    class GamesDAO
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        static String connectionString;

        public GamesDAO()
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
            if (cmd != null)
            {
                cmd.Dispose();
            }

            con.Close();
        }

        public List<Game> GetAllGames()
        {

            List<Game> allGames = new List<Game>();

            con.Open();

            cmd = new SqlCommand("SELECT * FROM [Users].[dbo].[Games];", con);

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                int id = (int)reader["Game_Id"];
                if (!IsGameOwned(id))
                {
                    string name = reader["Name"].ToString();
                    string price = reader["Price"].ToString();

                    allGames.Add(new Game(id, name));
                   
                }

            }
            EndDBConnection();
            return allGames;
        }

        private bool IsGameOwned(int id)
        {

            List<Game> userGames = UserInfo.Games;
            foreach (Game game in userGames)
            {

                if (game.Id == id)
                {
                    return true;
                }
            }
            return false;
          
        }

        public List<Game> GetUserGames()
        {
            List<Game> UserGames = new List<Game>();
            con.Open();

            cmd = new SqlCommand("SELECT g.Name, g.Game_Id FROM Users.dbo.Games AS g JOIN Users.dbo.UserGames AS ug ON(ug.Game_Id = g.Game_Id) AND (@UserId = ug.User_Id); ", con);
            cmd.Parameters.AddWithValue("@UserId", UserInfo.Id);

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string name = reader["Name"].ToString();
                int id = (int)reader["Game_Id"];

                UserGames.Add(new Game(id, name));
                UserInfo.Games.Add(new Game(id, name));
            }
            EndDBConnection();
            return UserGames;





        }

        internal void PurchaseGame(string name, int id)
        {
            con.Open();

            cmd = new SqlCommand("INSERT INTO Users.dbo.UserGames (Game_Id, User_Id) VALUES(@GameID, @UserID);", con);

            cmd.Parameters.AddWithValue("GameID", id);
            cmd.Parameters.AddWithValue("UserID", UserInfo.Id);

            int row = cmd.ExecuteNonQuery();

            if (row != 0)
            {
                MessageBox.Show("You purchased < " + name + " >  Succesfully");
                UserInfo.Games.Add(new Game(id, name));
            }
            EndDBConnection();
        }
    }
}
