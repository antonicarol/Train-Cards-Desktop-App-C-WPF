using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PracticeDesktopApp.Logic._3inaRow
{
    class ThreeRowGame
    {
        public Board boardLogic;
        public int turn;
        public Player player;
        public IA ai;
        public string winMessage;
        public bool win;
        public int[][] board;

        public ThreeRowGame()
        {
            boardLogic = new Board();
            ai = new IA(this, boardLogic);
            turn = 0;
            board = boardLogic.getBoard();
        }

        public int[][] GetBoard()
        {
            return board;
        }

        public void Player_Pick(int row, int column)
        {
            board[row][column] = 1;
            boardLogic.SetBoard(board);
            if (ChekIfWon(row, column))
            {
                winMessage = "You have won";
                win = true;
            };

        }

        private bool ChekIfWon(int row, int column)
        {
            
            if (boardLogic.CheckRowComplete(row,column) ||
                boardLogic.CheckColumnComplete(row,column) ||
                boardLogic.CheckPositiveDiagComplete(row,column) ||
                boardLogic.CheckNegativeDiagComplete(row,column))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void IA_Pick(int row, int col)
        {
            ai.IA_Pick(turn, row, col);
        }

        internal void AiSetBoard(int row, int col)
        {
            if (board[row][col] == 0) {
                board[row][col] = 2;
                boardLogic.SetBoard(board);
                
            }
            turn++;
        }
    }
}
