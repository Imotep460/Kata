using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using System.Linq;

namespace TestKata.Unittests
{
    [TestClass]
    public class SudokuValidator
    {
        private static int[] nineNumbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public static bool SudokuValidator0(int[][] board)
        {
            for (int i = 0; i < 9; ++i)
            {
                var row = new List<int>();
                for (int j = 0; j < 9; ++j) row.Add(board[i][j]);
                if (!ValidateNine(row)) return false;

                var col = new List<int>();
                for (int j = 0; j < 9; ++j) col.Add(board[j][i]);
                if (!ValidateNine(col)) return false;

                var block = new List<int>();
                int br = (i / 3) * 3;
                int bc = (i % 3) * 3;
                for (int j = 0; j < 9; ++j) block.Add(board[br + j / 3][bc + j % 3]);
                if (!ValidateNine(block)) return false;
            }
            return true;
        }
        private static bool ValidateNine(IList<int> nine)
        {
            return nineNumbers.All(nine.Contains);
        }

        public static bool SudokuValidator1(int[][] board)
        {
            return Enumerable
                .Range(0, 9)
                .SelectMany(i => new[]
                {
                    board[i].Sum(),
                    board.Sum(b => b[i]),
                    board.Skip(3 * (i / 3)).Take(3).SelectMany(r => r.Skip(3 * (i % 3)).Take(3)).Sum()
                })
                .All(i => i == 45);
        }
    }
}