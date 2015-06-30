namespace MineSweeper
{
	using System;
	using System.Collections.Generic;
	using Minesweeper;
	
	public class MineSweeper
	{
		private static void Main()
		{
			string command;
			char[,] board = CreateBoard();
			char[,] mines = PlaceMines();
			int counter = 0;
			bool isMine = false;
			List<Points> highScores = new List<Points>(6);
			int row = 0;
			int column = 0;
			bool inGame = true;
			const int MaxScore = 35;
			bool maxResultAchieved = false;

			do
			{
				if (inGame)
				{
					Console.WriteLine("Lets play MineSweeper. Try to find the free from mines fields." +
					    "The 'top' command shows the current standings, 'restart' starts a new game, 'exit'" +
					    "quits the game.");
					PrintBoard(board);
					inGame = false;
				}

				Console.Write("Enter row and column: ");
				command = Console.ReadLine()?.Trim();

				if (command != null && command.Length >= 3)
				{
					if (int.TryParse(command[0].ToString(), out row) &&
					    int.TryParse(command[2].ToString(), out column) &&
						row <= board.GetLength(0) && column <= board.GetLength(1))
					{
						command = "turn";
					}
				}

				switch (command)
				{
					case "top":
						PrintHighscores(highScores);
						break;

					case "restart":
						board = CreateBoard();
						mines = PlaceMines();
						PrintBoard(board);
						break;

					case "exit":
						Console.WriteLine("Bye, bye!");
						break;

					case "turn":
						if (mines[row, column] != '*')
						{
							if (mines[row, column] == '-')
							{
								PlayerTurn(board, mines, row, column);
								counter++;
							}

							if (MaxScore == counter)
							{
								maxResultAchieved = true;
							}
							else
							{
								PrintBoard(board);
							}
						}
						else
						{
							isMine = true;
						}

						break;
					default:
						Console.WriteLine("\nError! Invalid command!\n");
						break;
				}

				if (isMine)
				{
					PrintBoard(mines);
					Console.Write("\nBOOM! You died heroically with {0} points. Enter your nickname: ", counter);
					string nickname = Console.ReadLine();
					Points result = new Points(nickname, counter);

					if (highScores.Count < 5)
					{
						highScores.Add(result);
					}
					else
					{
						for (int i = 0; i < highScores.Count; i++)
						{
							if (highScores[i].UserPoints < result.UserPoints)
							{
								highScores.Insert(i, result);
								highScores.RemoveAt(highScores.Count - 1);
								break;
							}
						}
					}

					highScores.Sort((result1, result2) => string.Compare(
						result2.UserName, 
						result1.UserName, 
						StringComparison.Ordinal));
					highScores.Sort((result1, result2) => result2.UserPoints.CompareTo(result1.UserPoints));
					PrintHighscores(highScores);

					board = CreateBoard();
					mines = PlaceMines();
					counter = 0;
					isMine = false;
					inGame = true;
				}

				if (maxResultAchieved)
				{
					Console.WriteLine("\nCongratulations! You opened 35 cells!");
					PrintBoard(mines);
					Console.WriteLine("Enter your name: ");
					string name = Console.ReadLine();
					Points result = new Points(name, counter);
					highScores.Add(result);
					PrintHighscores(highScores);
					board = CreateBoard();
					mines = PlaceMines();
					counter = 0;
					maxResultAchieved = false;
					inGame = true;
				}
			}
			while (command != "exit");
			Console.WriteLine("Made in Bulgaria");
			Console.Read();
		}

		private static void PrintHighscores(List<Points> points)
		{
			Console.WriteLine("\nPoints: ");
			if (points.Count > 0)
			{
				for (int i = 0; i < points.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} cells", i + 1, points[i].UserName, points[i].UserPoints);
				}

				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("No highscore!\n");
			}
		}

		private static void PlayerTurn(char[,] field, char[,] mines, int row, int column)
		{
			char minesCount = Count(mines, row, column);
			mines[row, column] = minesCount;
			field[row, column] = minesCount;
		}

		private static void PrintBoard(char[,] board)
		{
			int rows = board.GetLength(0);
			int cols = board.GetLength(1);
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");

			for (int i = 0; i < rows; i++)
			{
				Console.Write("{0} | ", i);
				for (int j = 0; j < cols; j++)
				{
					Console.Write("{0} ", board[i, j]);
				}

				Console.Write("|");
				Console.WriteLine();
			}

			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] CreateBoard()
		{
			int boardRows = 5;
			int boardColumns = 10;
			char[,] board = new char[boardRows, boardColumns];

			for (int i = 0; i < boardRows; i++)
			{
				for (int j = 0; j < boardColumns; j++)
				{
					board[i, j] = '?';
				}
			}

			return board;
		}

		private static char[,] PlaceMines()
		{
			int rows = 5;
			int cols = 10;
			char[,] board = new char[rows, cols];

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					board[i, j] = '-';
				}
			}

			List<int> randomIntegers = new List<int>();

			while (randomIntegers.Count < 15)
			{
				Random random = new Random();
				int newRandom = random.Next(50);
				if (!randomIntegers.Contains(newRandom))
				{
					randomIntegers.Add(newRandom);
				}
			}

			foreach (int random in randomIntegers)
			{
				int col = random / cols;
				int row = random % cols;
				if (row == 0 && random != 0)
				{
					col--;
					row = cols;
				}
				else
				{
					row++;
				}

				board[col, row - 1] = '*';
			}

			return board;
		}

		private static char Count(char[,] board, int row, int col)
		{
			int count = 0;
			int rows = board.GetLength(0);
			int cols = board.GetLength(1);

			if (row - 1 >= 0)
			{
				if (board[row - 1, col] == '*')
				{
					count++;
				}
			}

			if (row + 1 < rows)
			{
				if (board[row + 1, col] == '*')
				{
					count++;
				}
			}

			if (col - 1 >= 0)
			{
				if (board[row, col - 1] == '*')
				{
					count++;
				}
			}

			if (col + 1 < cols)
			{
				if (board[row, col + 1] == '*')
				{
					count++;
				}
			}

			if ((row - 1 >= 0) && (col - 1 >= 0))
			{
				if (board[row - 1, col - 1] == '*')
				{
					count++;
				}
			}

			if ((row - 1 >= 0) && (col + 1 < cols))
			{
				if (board[row - 1, col + 1] == '*')
				{
					count++;
				}
			}

			if ((row + 1 < rows) && (col - 1 >= 0))
			{
				if (board[row + 1, col - 1] == '*')
				{
					count++;
				}
			}

			if ((row + 1 < rows) && (col + 1 < cols))
			{
				if (board[row + 1, col + 1] == '*')
				{
					count++;
				}
			}

			return char.Parse(count.ToString());
		}
	}
}
