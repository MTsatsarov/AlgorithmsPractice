using static System.Formats.Asn1.AsnWriter;

namespace Minimax
{
	public class Program
	{
		static void Main(string[] args)
		{
			var minimax = new Minimax();

			char[,] board = { { '-', 'o', 'x'},
							  { '-', '-', '-'},
							  { 'x', '-', '-'} };

			//INPUT
			//  '-', 'o', 'x'
			//  '-', 'o', '-'
			//  'x', '-', '-'

			//OUTPUT
			// '-' 'o' 'x'
			// '-' 'o' '-'
			// 'x' '-' 'x'

			var bestScore = int.MinValue;
			var moveRow = -1;
			var moveCol = -1;

			for (int row = 0; row < board.GetLength(0); row++)
			{
				for (int col = 0; col < board.GetLength(1); col++)
				{
					if (board[row, col] == '-')
					{
						var score = minimax.GetMiniMax(board, 'x');

						board[row, col] = '-';

						Console.WriteLine("Score: " + score);
						Console.WriteLine("BestScore: " + bestScore);

						if (score > bestScore)
						{
							moveRow = row;
							moveCol = col;
						}
					}
				}

			}
			board[moveRow, moveCol] = 'x';

			for (int row = 0; row < board.GetLength(0); row++)
			{
				for (int col = 0; col < board.GetLength(1); col++)
				{
					Console.Write($"'{board[row, col]}' ");
				}
				Console.WriteLine();
			}
		}
	}
}