using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_Day1
{
	struct Postiion
	{
		public int X;
		public int Y;
	}

	class Program
	{
		private const string input = "L2, L3, L3, L4, R1, R2, L3, R3, R3, L1, L3, R2, R3, L3, R4, R3, R3, L1, L4, R4, L2, R5, R1, L5, R1, R3, L5, R2, L2, R2, R1, L1, L3, L3, R4, R5, R4, L1, L189, L2, R2, L5, R5, R45, L3, R4, R77, L1, R1, R194, R2, L5, L3, L2, L1, R5, L3, L3, L5, L5, L5, R2, L1, L2, L3, R2, R5, R4, L2, R3, R5, L2, L2, R3, L3, L2, L1, L3, R5, R4, R3, R2, L1, R2, L5, R4, L5, L4, R4, L2, R5, L3, L2, R4, L1, L2, R2, R3, L2, L5, R1, R1, R3, R4, R1, R2, R4, R5, L3, L5, L3, L3, R5, R4, R1, L3, R1, L3, R3, R3, R3, L1, R3, R4, L5, L3, L1, L5, L4, R4, R1, L4, R3, R3, R5, R4, R3, R3, L1, L2, R1, L4, L4, L3, L4, L3, L5, R2, R4, L2";

		static void Main(string[] args)
		{
			string[] splitInputs = input.Replace(" ", "").Split(',');
			int startX = 0;
			int startY = 0;
			int currentDirection = 0; // 0 - North, 1 - West, 2 - South, 3 - East
			bool firstLocationVisitedTwice = false;
			int positionTwiceX = 0;
			int positionTwiceY = 0;
			List<Postiion> positions = new List<Postiion>();

			foreach(string oneInput in splitInputs)
			{
				char direction = oneInput[0];
				int moveCount = int.Parse(oneInput.Remove(0, 1));

				switch(direction)
				{
					case 'L':
						currentDirection = (currentDirection - 1 < 0) ? 3 : currentDirection - 1;
						break;
					case 'R':
						currentDirection = (currentDirection + 1 > 3) ? 0 : currentDirection + 1;
						break;
				}

				switch (currentDirection)
				{
					case 0: // North
						startY += moveCount;
						break;
					case 1: // West
						startX += moveCount;
						break;
					case 2: // South
						startY -= moveCount;
						break;
					case 3: // East
						startX -= moveCount;
						break;
				}

				if(!firstLocationVisitedTwice)
				{
					foreach (Postiion pos in positions)
					{
						if (startX == pos.X && startY == pos.Y)
						{
							Console.WriteLine("X: " + pos.X + " Y: " + pos.Y);
							firstLocationVisitedTwice = true;
							positionTwiceX = startX;
							positionTwiceY = startY;
						}
					}

					positions.Add(new Postiion { X = startX, Y = startY });
				}
			}

			int distance = Math.Abs(startX + startY);
			Console.WriteLine("Distance: " + distance);

			int distanceToFirstLocationTwice = Math.Abs(positionTwiceX + positionTwiceY);
			Console.WriteLine("Distance to first location twice: " + distanceToFirstLocationTwice);
			Console.ReadKey();
		}
	}
}
