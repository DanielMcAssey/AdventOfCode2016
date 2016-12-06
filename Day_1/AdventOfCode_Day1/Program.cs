using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_Day1
{
    class Position
    {
        public int X;
        public int Y;
    }

    class Player
    {
        public List<Position> history = new List<Position>();
        public Position position = new Position();

        public void Move(int direction, int count)
        {
            for (int i = 0; i < count; i++)
            {
                switch (direction)
                {
                    case 0: // North
                        position.Y += 1;
                        break;
                    case 1: // West
                        position.X -= 1;
                        break;
                    case 2: // South
                        position.Y -= 1;
                        break;
                    case 3: // East
                        position.X += 1;
                        break;
                }
                history.Add(new Position { X = position.X, Y = position.Y });
            }
        }
    }

    class Program
    {
        private const string GAME_INPUT = "L2, L3, L3, L4, R1, R2, L3, R3, R3, L1, L3, R2, R3, L3, R4, R3, R3, L1, L4, R4, L2, R5, R1, L5, R1, R3, L5, R2, L2, R2, R1, L1, L3, L3, R4, R5, R4, L1, L189, L2, R2, L5, R5, R45, L3, R4, R77, L1, R1, R194, R2, L5, L3, L2, L1, R5, L3, L3, L5, L5, L5, R2, L1, L2, L3, R2, R5, R4, L2, R3, R5, L2, L2, R3, L3, L2, L1, L3, R5, R4, R3, R2, L1, R2, L5, R4, L5, L4, R4, L2, R5, L3, L2, R4, L1, L2, R2, R3, L2, L5, R1, R1, R3, R4, R1, R2, R4, R5, L3, L5, L3, L3, R5, R4, R1, L3, R1, L3, R3, R3, R3, L1, R3, R4, L5, L3, L1, L5, L4, R4, R1, L4, R3, R3, R5, R4, R3, R3, L1, L2, R1, L4, L4, L3, L4, L3, L5, R2, R4, L2";

        static void Main(string[] args)
        {
            string[] splitInputs = GAME_INPUT.Replace(" ", "").Split(',');
            int compassDirection = 0; // 0 - North, 1 - West, 2 - South, 3 - East

            bool isFirstLocationHitTwiceFound= false;
            Position posHitTwice = new Position();
            Player player = new Player();

            foreach (string oneInput in splitInputs)
            {
                char direction = oneInput[0];
                int moveCount = int.Parse(oneInput.Remove(0, 1));

                switch (direction)
                {
                    case 'L':
                        compassDirection = (compassDirection - 1 < 0) ? 3 : compassDirection - 1;
                        break;
                    case 'R':
                        compassDirection = (compassDirection + 1 > 3) ? 0 : compassDirection + 1;
                        break;
                }

                player.Move(compassDirection, moveCount);
            }

            for(int i = 0; i < player.history.Count; i++)
            {
                for(int j = 0; j < player.history.Count; j++)
                {
                    if (i != j && player.history[i].X == player.history[j].X && player.history[i].Y == player.history[j].Y)
                    {
                        isFirstLocationHitTwiceFound = true;
                        posHitTwice = player.history[i];
                        break;
                    }

                    if (isFirstLocationHitTwiceFound)
                    {
                        break;
                    }
                }
            }

            int distance = Math.Abs(player.position.X) + Math.Abs(player.position.Y);
            Console.WriteLine("Distance: " + distance);

            int distanceToFirstLocationHitTwice = Math.Abs(posHitTwice.X) + Math.Abs(posHitTwice.Y);
            Console.WriteLine("Distance to first location hit twice: " + distanceToFirstLocationHitTwice);
            Console.ReadKey();
        }
    }
}
