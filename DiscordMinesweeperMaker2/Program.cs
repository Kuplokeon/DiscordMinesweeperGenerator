using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordMinesweeperMaker2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[][] board = new int[12][]
            {
                new int[8],
                new int[8],
                new int[8],
                new int[8],
                new int[8],
                new int[8],
                new int[8],
                new int[8],
                new int[8],
                new int[8],
                new int[8],
                new int[8],
            };


            board = LoadBombs(board);
            board = GenerateNumbers(board);
            for (int i = 0; i < board.GetLength(0); i++)
            {
                PrintRow(board[i]);
            }
            Console.ReadLine();
        }

        static int[][] LoadBombs(int[][] board)
        {
            Random random = new Random();
            for (int y = 0; y < board.Length; y++)
            {
                for (int x = 0; x < board[y].Length; x++)
                {
                    if (random.Next(0, 7) == 0)
                    {
                        board[y][x] = -1;
                    }
                }
            }
            return board;
        }

        static int[][] GenerateNumbers(int[][] board)
        {
            for (int y = 0; y < board.Length; y++)
            {
                for (int x = 0; x < board[y].Length; x++)
                {
                    if (board[y][x] != -1)
                    {
                        board[y][x] = GetNearbyBombs(board, x, y);
                    }
                }
            }
            return board;
        }

        static int GetNearbyBombs(int[][] board, int x, int y)
        {
            int numBombs = 0;

            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int yPosToCheck = y + yOffset;
                    int xPosToCheck = x + xOffset;

                    if (yPosToCheck >= 0 && yPosToCheck < board.Length)
                    {
                        if (xPosToCheck >= 0 && xPosToCheck < board[yPosToCheck].Length)
                        {
                            if (board[yPosToCheck][xPosToCheck] == -1)
                            {
                                numBombs++;
                            }
                        }
                    }
                }
            }

            return numBombs;
        }


        static Dictionary<int, string> intToString = new Dictionary<int, string>()
        {
            { -1, "bomb" },
            { 0, "zero" },
            { 1, "one" },
            { 2, "two" },
            { 3, "three" },
            { 4, "four" },
            { 5, "five" },
            { 6, "six" },
            { 7, "seven" },
            { 8, "8ball" }
        };

        static string GetEmojiString(int input)
        {
            return "[||:" + intToString[input] + ":||] ";
        }

        static void PrintRow(int[] lane)
        {
            foreach (int i in lane)
            {
                Console.Write(GetEmojiString(i));
            }
            Console.WriteLine();
        }
    }
}
