using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codewars
{
    /// <summary>
    /// Description:
    /// If we were to set up a Tic-Tac-Toe game, we would want to know whether the board's current state is solved,
    /// wouldn't we? Our goal is to create a function that will check that for us!    /// 
    /// Assume that the board comes in the form of a 3x3 array, where the value is 0 if a spot is empty, 1 if it is an "X", or 2 if it is an "O", like so:
    /// 
    /// [[0, 0, 1],
    /// [0, 1, 2],
    /// [2, 1, 0]]
    /// 
    /// We want our function to return:
    /// -1 if the board is not yet finished AND no one has won yet(there are empty spots),
    /// 1 if "X" won,
    /// 2 if "O" won,
    /// 0 if it's a cat's game(i.e.a draw).
    /// You may assume that the board passed in is valid in the context of a game of Tic-Tac-Toe.
    /// 
    /// Link to the kata:
    /// https://www.codewars.com/kata/525caa5c1bf619d28c000335
    /// </summary>
    [TestClass]
    public class TicTacToeCheck
    {
        /// <summary>
        /// Solution from Codewars
        /// </summary>
        /// <param name="board">The tic tac toe board being checked.</param>
        /// <returns>
        /// Return -1 if the board is not finished yet,
        /// Returns 0 if it's a draw,
        /// Returns 1 if "O" won the game,
        /// Returns 2 if "X" won the game.
        /// </returns>
        public int TicTacToeCheck0(int[,] board)
        {
            var c012 = new int[] { 0, 1, 2 };
            var s = string.Join(",", c012.Select(x => string.Join("", c012.Select(y => board[x, y])))) + ","
                    + string.Join(",", c012.Select(x => string.Join("", c012.Select(y => board[y, x])))) + ","
                    + string.Join("", c012.Select(x => board[x, x])) + ","
                    + string.Join("", c012.Select(x => board[2 - x, x]));
            return s.Contains("111") ? 1 : s.Contains("222") ? 2 : !s.Contains("0") ? 0 : -1;
        }

        /// <summary>
        /// Solution from Codewars
        /// </summary>
        /// <param name="board">The tic tac toe board being checked.</param>
        /// <returns>
        /// Return -1 if the board is not finished yet,
        /// Returns 0 if it's a draw,
        /// Returns 1 if "O" won the game,
        /// Returns 2 if "X" won the game.
        /// </returns>
        public int TicTacToeCheck1(int[,] board)
        {
            int d1 = 1;
            int d2 = 1;
            bool empty = false;
            for (int i = 0; i < 3; i++)
            {
                d1 *= board[i, i];
                d2 *= board[2 - i, i];
                int row = 1;
                int col = 1;
                for (int j = 0; j < 3; j++)
                {
                    row *= board[i, j];
                    col *= board[j, i];
                }
                if (row == 1 || col == 1)
                {
                    return 1;
                }
                if (row == 8 || col == 8)
                {
                    return 2;
                }
                if (row == 0 || col == 0)
                {
                    empty = true;
                }
            }
            if (d1 == 1 || d2 == 1)
            {
                return 1;
            }
            if (d1 == 8 || d2 == 8)
            {
                return 2;
            }
            if (empty)
            {
                return -1;
            }
            return 0;
        }

        [TestMethod]
        public void TestMethod0()
        {
            Assert.AreEqual(1, TicTacToeCheck0(new int[,] { { 1, 1, 1 }, { 0, 2, 2 }, { 0, 0, 0 } }));
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(1, TicTacToeCheck1(new int[,] { { 1, 1, 1 }, { 0, 2, 2 }, { 0, 0, 0 } }));
        }
    }
}