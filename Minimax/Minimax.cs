using System.Numerics;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace Minimax
{
	public class Minimax
	{
		public int GetMiniMax(char[,] board, char forWho)
		{
			var score = CheckWhoWIns(board, forWho);
			if (score != 0)
			{
				return score;
			}

			if (forWho == 'o')
			{
				var bestScore = int.MinValue;
				for (var i = 0; i < 3; i++)
				{
					for (var j = 0; j < 3; j++)
					{
						if (board[i, j] == '-')
						{
							board[i, j] = forWho;
							var currentScore = GetMiniMax(board, 'x');
							board[i, j] = '-';

							bestScore = Math.Max(bestScore, currentScore);
						}
					}
				}
				return bestScore;
			}
			else
			{
				var bestScore = int.MaxValue;
				for (var i = 0; i < 3; i++)
				{
					for (var j = 0; j < 3; j++)
					{
						if (board[i, j] == '-')
						{
							board[i, j] = forWho;
							var currentScore = GetMiniMax(board, 'o');
							board[i, j] = '-';

							bestScore = Math.Min(bestScore, currentScore);
						}
					}
				}
				return bestScore;
			}
		}

		private int CheckWhoWIns(char[,] board, char forWho)
		{
			if ((board[0, 0] == forWho && board[0, 1] == forWho && board[0, 2] == forWho)
		|| (board[1, 0] == forWho && board[1, 1] == forWho && board[1, 2] == forWho)
		|| (board[2, 0] == forWho && board[2, 1] == forWho && board[2, 2] == forWho)
		|| (board[0, 0] == forWho && board[1, 0] == forWho && board[2, 0] == forWho)
		|| (board[0, 1] == forWho && board[1, 1] == forWho && board[2, 1] == forWho)
		|| (board[0, 2] == forWho && board[1, 2] == forWho && board[2, 2] == forWho)
		|| (board[0, 0] == forWho && board[1, 1] == forWho && board[2, 2] == forWho)
		|| (board[0, 2] == forWho && board[1, 1] == forWho && board[2, 0] == forWho))
			{
				var score = 1;
				for (var i = 0; i < 3; i++)
				{
					for (var j = 0; j < 3; j++)
					{
						if (board[i, j] == '-')
						{
							score++;
						}
					}
				}
				return score;
			}
			else
				return 0;
		}
	}
}
