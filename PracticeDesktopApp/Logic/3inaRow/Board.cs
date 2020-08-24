using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDesktopApp.Logic._3inaRow
{
    class Board
    {
        public int[][] board;

        public Board()
        {
            board = InitBoard();

        }

        private int[][] InitBoard()
        {
            return new int[][] {new int[]   {0,0,0},
                                new int[]   {0,0,0},
                                new int[]   {0,0,0}};
        }
        public int[][] getBoard()
        {
            return board;
        }

        public void SetBoard(int[][] b)
        {
            board = b;
        }

        #region Check If player has won
        public bool CheckRowComplete(int row, int column)
        {
            int count = 0;
            for (int i = 0; i < board[row].Length; i++)
            {
                if (board[row][i] == 1)
                {
                    count += 1;
                }
                if (count == 3)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckColumnComplete(int row, int column)
        {
            int count = 0;
            for (int i = 0; i < board[column].Length; i++)
            {
                if (board[i][column] == 1)
                {
                    count += 1;
                }
                if (count == 3)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckPositiveDiagComplete(int row, int column)
        {
            int count = 0;
            for (int i = 0; i < board[row].Length; i++)
            {
                for (int j = 0; j < board[column].Length; j++)
                {
                    //positive diag, 0,0 1,1 2,2 ...
                    if (i == j)
                    {
                        if (board[i][j] == 1)
                        {
                            count += 1;
                        }
                        if (count == 3)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool CheckNegativeDiagComplete(int row, int column)
        {
            int count = 0;
            for (int i = 0; i < board[row].Length; i++)
            {
                for (int j = 0; j < board[column].Length; j++)
                {
                    if (i == 2 && j == 0 || i == 0 && j == 2)
                    {
                        if (i == 0)
                        {
                            if (board[i + 1][j - 1] == 1)
                            {
                                count += 1;
                            }
                        }

                        if (board[i][j] == 1)
                        {
                            count += 1;
                        }
                        if (count == 3)
                        {
                            return true;
                        }
                    }

                }

            }
            return false;
        }

        #endregion


        #region Check Completed Row, Col, Diag

        internal bool CompletedRow(int row)
        {
            for (int col = 0; col < board[row].Length; col++)
            {
                if (board[row][col] == 0)
                {
                    return false;
                }

            }
            return true;
        }

        internal bool Completedcolumn(int col)
        {
            for (int row = 0; row < board[col].Length; row++)
            {
                if (board[row][col] == 0)
                {
                    return false;
                }

            }
            return true;
        }

        internal bool CompletedPositivDiag()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (row == col)
                    {
                        if (board[row][col] == 0)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        internal bool CompletedNegativeDiag()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (row == 2 && col == 0 || row == 0 && col == 2)
                    {
                        if (row == 0)
                        {
                            if (board[row + 1][col - 1] == 0)
                            {
                                return false;
                            }

                            if (board[row][col] == 0)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        #endregion
    }

}

