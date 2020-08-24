using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PracticeDesktopApp.Logic._3inaRow
{

    class IA
    {
        private ThreeRowGame game;
        
        int lastRow;
        int lastCol;
        Board board;
        List<Tuple<int, int>> possibleMoves;

        public IA(ThreeRowGame g, Board b)
        {
            game = g;
            board = b;
            possibleMoves = new List<Tuple<int, int>>();
        }

        public void IA_Pick(int turn, int pRow, int pCol)
        {

            if (turn == 0)
            {
                Random rnd = new Random();
                int row = rnd.Next(0, 2);
                int col = rnd.Next(0, 2);

                lastRow = row;
                lastCol = col;

                game.AiSetBoard(row, col);
            }
            else
            {
                int[][] b = board.getBoard();
                //We need to check if the player is about to do a Row,
                // -Yes- he is going to win in 1 turn
                // -No- he is still stucked

                // 1. Analize the board
                AnalizeBoard(b);

                // 2. Take one option and draw it

                if (MakeMove())
                {

                }




            }
        }

        private bool MakeMove()
        {
            Random rnd = new Random();
            int choices = possibleMoves.Count;
            if (choices == 0)
            {
                int choice = rnd.Next(choices);
                int row = possibleMoves[choice].Item1;
                int col = possibleMoves[choice].Item2;
                possibleMoves = new List<Tuple<int, int>>();
                game.AiSetBoard(row, col);
                return true;
            }
            else if (choices == 1)
            {
                int row = possibleMoves[0].Item1;
                int col = possibleMoves[0].Item2;
                possibleMoves = new List<Tuple<int, int>>();
                game.AiSetBoard(row, col);
                return true;
            }
            else
            {
                int choice = rnd.Next(choices);
                int row = possibleMoves[choice].Item1;
                int col = possibleMoves[choice].Item2;
                possibleMoves = new List<Tuple<int, int>>();
                game.AiSetBoard(row, col);
                return true;

            }
            
        }
                


                        

        

        internal void AnalizeBoard(int[][] b)
        {
            //We're going to search all the possible Rows, col that the user will do,
            // store it and then chose one by random or by some parameters.
            for (int row = 0; row < 3; row++)
            {
                if (!board.CompletedRow(row))
                {
                    if (CheckPlayerRow(b, row))
                    {

                    }
                }

            }

            for (int col = 0; col < 3; col++)
            {
                if (!board.Completedcolumn(col))
                {
                    if (CheckPlayerColumn(b, col))
                    {

                    }
                }
            }


            if (!board.CompletedPositivDiag())
            {
                if (CheckPlayerPosDiago(b))
                {

                }
            }

            if (!board.CompletedNegativeDiag())
            {
                if (CheckPlayerNegDiago(b))
                {

                }
            }

        }


        #region Checking Player Progress
        private bool CheckPlayerColumn(int[][] board, int col)
        {
            int count = 0;
            int[] tempCol = new int[3];
            for (int row = 0; row < board[col].Length; row++)
            {
                tempCol[row] = board[row][col];

                if (board[row][col] == 1)
                {
                    count += 1;
                }
                if (count == 2)
                {
                    //2 Cells!

                    for (int i = 0; i < 3; i++)
                    {
                        if (tempCol[i] == 0)
                        {
                            possibleMoves.Add(new Tuple<int, int>(i, col));
                            return true;
                        }
                    }
                }
                if (count == 1)
                {
                    //Just 1 Cell
                }

                



            }
            return false;
        }

        private bool CheckPlayerRow(int[][] board, int row)
        {
            int count = 0;
            int[] tempRow = board[row];
            for (int col = 0; col < board[row].Length; col++)
            {
                if (board[row][col] == 1)
                {
                    count += 1;
                }

            }
            if (count == 2)
            {
                //2 Cells!
                tempRow = board[row];
                for (int i = 0; i < tempRow.Length; i++)
                {
                    if (tempRow[i] == 0)
                    {
                        possibleMoves.Add(new Tuple<int, int>(row, i));
                        return true;
                    }
                }
            }
            if (count == 1)
            {
                //Just 1 Cell
            }

            return false;

        }

        private bool CheckPlayerPosDiago(int[][] board)
        {
            int count = 0;
            int[] tempDiag = new int[3];
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (row == col)
                    {
                        tempDiag[col] = board[row][col];
                    }
                }
            }
            for (int i = 0; i < tempDiag.Length; i++)
            {
                if (tempDiag[i] == 1)
                {
                    count += 1;
                }
            }
            if (count == 2)
            {
            
            

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if(row == col)
                    {
                        if(board[row][col] == 0) {
                           possibleMoves.Add(new Tuple<int, int>(row, col));
                           return true;
                            }
                        }
                }
            }
            }
            return false;
        }

        private bool CheckPlayerNegDiago(int[][] board)
        {
            int count = 0;
            int[] tempDiag = new int[3];
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (row == 2 && col == 0 || row == 0 && col == 2)
                    {

                        if (row == 0)
                        {
                            if (board[row + 1][col - 1] == 1)
                            {
                                count += 1;
                                tempDiag[row] = board[row + 1][col - 1];
                            }

                            if (board[row][col] == 1)
                            {
                                count += 1;
                                
                            }
                            
                            if (count == 2)
                            {
                                for (int i = 0; i < tempDiag.Length; i++)
                                {
                                    if (tempDiag[i] == 0)
                                    {
                                        possibleMoves.Add(new Tuple<int, int>(row, col));
                                        return true;
                                    }
                                }
                            }
                    }
                }
            }

           
               
            }

            return false;
        }
        #endregion
    }
}

