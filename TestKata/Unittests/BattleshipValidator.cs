using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestKata.Unittests
{
    /// <summary>
    /// Write a method that takes a field for well-known board game "Battleship" as an argument and returns true if it has a valid disposition of ships, false otherwise.
    /// Argument is guaranteed to be 10*10 two-dimension array.
    /// Elements in the array are numbers, 0 if the cell is free and 1 if occupied by ship.
    /// Battleship (also Battleships or Sea Battle) is a guessing game for two players.Each player has a 10x10 grid containing several "ships",
    /// and objective is to destroy enemy's forces by targetting individual cells on his field.
    /// The ship occupies one or more cells in the grid. Size and number of ships may differ from version to version. In this kata we will use Soviet/Russian version of the game.
    /// Before the game begins, players set up the board and place the ships accordingly to the following rules:
    /// There must be single battleship (size of 4 cells), 2 cruisers(size 3), 3 destroyers(size 2) and 4 submarines(size 1). Any additional ships are not allowed, as well as missing ships.
    /// Each ship must be a straight line, except for submarines, which are just single cell.
    /// The ship cannot overlap or be in contact with any other ship, neither by edge nor by corner.
    /// This is all you need to solve this kata.If you're interested in more information about the game, visit this link: "https://en.wikipedia.org/wiki/Battleship_(game)"
    /// 
    /// Codewars link: https://www.codewars.com/kata/52bb6539a4cf1b12d90005b7/csharp
    /// </summary>
    [TestClass]
    public class BattleshipValidator
    {
        /// <summary>
        /// My own solution
        /// </summary>
        /// <param name="board">The game board to validate.</param>
        /// <returns>True og false.</returns>
        public static bool ValidateBattlefield0(int[,] board)
        {
            int[] shipCount = new int[5];
            int MarkShip(int x, int y)
            {
                Queue<(int, int)> queue = new Queue<(int, int)>();
                queue.Enqueue((x, y));
                int size = 0;
                bool horizontal = true;
                bool vertical = true;

                while (queue.Count > 0)
                {
                    var (cx, cy) = queue.Dequeue();
                    if (board[cx, cy] == 1)
                    {
                        board[cx, cy] = -1;
                        size++;

                        int[][] directions = new int[][] {
                        new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 }
                    };

                        foreach (var dir in directions)
                        {
                            int nx = cx + dir[0];
                            int ny = cy + dir[1];
                            if (nx >= 0 && nx < 10 && ny >= 0 && ny < 10 && board[nx, ny] == 1)
                            {
                                queue.Enqueue((nx, ny));
                            }
                        }

                        int[][] corners = new int[][] {
                        new int[] { -1, -1 }, new int[] { -1, 1 }, new int[] { 1, -1 }, new int[] { 1, 1 }
                    };

                        foreach (var corner in corners)
                        {
                            int nx = cx + corner[0];
                            int ny = cy + corner[1];
                            if (nx >= 0 && nx < 10 && ny >= 0 && ny < 10 && board[nx, ny] == 1)
                            {
                                return -1;
                            }
                        }

                        if (size > 1)
                        {
                            if (cx != x)
                            {
                                horizontal = false;
                            }
                            if (cy != y)
                            {
                                vertical = false;
                            }
                        }
                    }
                }

                if (!horizontal && !vertical)
                {
                    return -1;
                }

                return size;
            }


            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (board[i, j] == 1)
                    {
                        int size = MarkShip(i, j);
                        if (size == -1)
                        {
                            return false;
                        }
                        if (size >= 1 && size <= 4)
                        {
                            shipCount[size]++;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            return shipCount[1] == 4 && shipCount[2] == 3 && shipCount[3] == 2 && shipCount[4] == 1;
        }
        
        public bool ValidateBattlefield1(int[,] field)
        {
            var ships = new List<int>();
            for (var x = 0; x < 10; x++)
                for (var y = 0; y < 10; y++)
                    if (field[x, y] == 1)
                    {
                        var length = 1;
                        while (x + length < 10 && field[x + length, y] == 1)
                            field[x + length++, y] = 0;
                        while (y + length < 10 && field[x, y + length] == 1)
                            field[x, y + length++] = 0;
                        ships.Add(length);
                    }
            ships.Sort();
            return string.Join("", ships) == "1111222334";
        }

        [TestMethod]
        public void TestCase0()
        {
            int[,] field = new int[10, 10]
            {
                {1, 0, 0, 0, 0, 1, 1, 0, 0, 0},
                {1, 0, 1, 0, 0, 0, 0, 0, 1, 0},
                {1, 0, 1, 0, 1, 1, 1, 0, 1, 0},
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                {0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                {0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            };
            Assert.IsTrue(ValidateBattlefield0(field));
        }

        [TestMethod]
        public void TestCase1()
        {
            int[,] field = new int[10, 10]
            {
                {1, 0, 0, 0, 0, 1, 1, 0, 0, 0},
                {1, 0, 1, 0, 0, 0, 0, 0, 1, 0},
                {1, 0, 1, 0, 1, 1, 1, 0, 1, 0},
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                {0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                {0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            };
            Assert.IsTrue(ValidateBattlefield1(field));
        }
    }
}
