using System;

namespace Day_2
{
    class Program
    {
        private static readonly string[] GAME_INPUT =
        {
            "UUURRRRULRDLRDRRDURDDDLLDLLLULDUDDLDLULUURULRLDLRRLLLRRDRRLDDLLULUDUDDLRDRDUURDLURUURLRULLDDURULRRURDUURLULUUUURDDDDUUDLULRULLLRLLRRRURDLLRLLRRRUURULRDRUUDDDDDLLLRURRURRUURDUURDDRDLULRRLLLDRRRLURRLLURLDRRDDLDLRRLLRDRLLLLDLULDLRRDRRLDDURLULLUDLUDRRDRRLRLULURDRLRLUUUDLRLDLLLURDUDULULDDRUUURLLLDLLDDUDDRURURUDDLUULRDRRRRLDRDDURLUDURDULLDLUDLULDRLRLLRLLLLRURDURLLDRRDRLRUUUUULLLRUDURUDLLLUDLLLLRDLDRDUDRURLUDDUDDURLUUUUDDLLUDLULLLLLDUDLLRLRRDDDULULRLDRLLULDLUDLLURULRDDUURULRDLDLDLRL",
            "URUUURDULUDLUUUUDDRRRDRRRLDUDLRDRRDRDDLRUULDLLDUDULLLRLDRDRRLDLDLUUDRUULDUDULDUDURURDDURULDLURULRLULDUDDUULDLLLDDURDDRDDURUULUUDRLDDULDRRRRDURRUDLLLURDDDLRULLRDDRDDDDLUUDRDUULRRRRURULDDDLDDRDRRUDRRURUDRDDLDRRRLLURURUULUUDRDULLDRLRDRRDDURDUDLDRLUDRURDURURULDUUURDUULRRRRRUDLLULDDDRLULDDULUDRRRDDRUDRRDLDLRUULLLLRRDRRLUDRUULRDUDRDRRRDDRLLRUUDRLLLUDUDLULUUDULDRRRRDDRURULDULLURDLLLDUUDLLUDRLDURRRLDDDURUDUDURRULDD",
            "LRUDDULLLULRLUDUDUDRLLUUUULLUDLUUUUDULLUURDLLRDUDLRUDRUDDURURRURUDLLLRLDLUDRRRRRRDLUURLRDDDULRRUDRULRDRDDUULRDDLDULDRRRDDLURRURLLLRURDULLRUUUDDUDUURLRLDDUURLRDRRLURLDRLLUUURDRUUDUUUDRLURUUUDLDRRLRLLRRUURULLLRLLDLLLDULDDLDULDLDDRUDURDDURDUDURDLLLRRDDLULLLUDURLUDDLDLUUDRDRUDUUDLLDDLLLLDRDULRDLDULLRUDDUULDUDLDDDRUURLDRRLURRDDRUUDRUDLLDLULLULUDUDURDDRLRDLRLDRLDDRULLLRUDULDRLRLRULLRLLRRRLLRRRDDRULRUURRLLLRULDLUDRRDDLLLUDDUDDDLURLUDRDLURUUDLLDLULURRLLDURUDDDDRLULRDDLRLDDLRLLDDRRLRDUDUUULRRLRULUDURDUDRLRLRUDUDLLRRRRLRRUDUL",
            "RULLLLUUUDLLDLLRULLRURRULDDRDLUULDRLLRUDLLRRLRDURLLDUUUUURUUURDLUURRLDDDLRRRRLRULDUDDLURDRRUUDLRRRDLDDUDUDDRUDURURLDULLDLULDLLUDLULRDRLLURRLLDURLDLRDLULUDDULDLDDDDDUURRDRURLDLDULLURDLLDDLLUDLDLDRLRLDLRDRLDLRRUUDRURLUUUDLURUULDUDRDULLDURUDLUUURRRLLDUDUDDUUULLLRUULDLURUDDRLUDRDDLDLLUDUDRRRDDUUULUULLLRLLUURDUUDRUUULULLDLDRUUDURLLUULRLDLUURLLUUDRURDDRLURULDUDUUDRRUUURDULRLDUUDDRURURDRRULDDDRLUDLLUUDURRRLDLRLRDRURLURLLLRLDDLRRLDLDDURDUUDRDRRLDRLULDRLURUUUDDRLLLDDLDURLLLLDRDLDRRUDULURRLULRDRLLUULLRLRDRLLULUURRUDRUDDDLLDURURLURRRDLLDRDLUDRULULULRLDLRRRUUDLULDURLRDRLULRUUURRDDLRUURUDRURUDURURDD",
            "DURRDLLLDDLLDLLRLULULLRDLDRRDDRDLRULURRDUUDDRLLDDLDRRLRDUDRULDLRURDUUDRDDLLDRRDRUDUDULLDDDDLDRRRLRLRDRDLURRDDLDDDUUDRDRLLLDLUDDDLUULRDRLLLRLLUULUDDDRLDUUUURULRDDURRDRLUURLUDRLRLLLDDLRDDUULRRRRURDLDDDRLDLDRRLLDRDDUDDUURDLDUUDRDLDLDDULULUDDLRDDRLRLDDLUDLLDRLUDUDDRULLRLDLLRULRUURDDRDRDRURDRRLRDLLUDDRRDRRLDDULLLDLUDRRUDLDULDRURRDURLURRLDLRDLRUDLULUDDRULRLLDUURULURULURRLURRUULRULRRRLRDLULRLRLUDURDDRUUURDRLLRRRDDLDRRRULLDLRDRULDRRLRRDLUDDRDDDUUURRLULLDRRUULULLRRRRLDDRDDLUURLLUDLLDUDLULUULUDLLUUURRRUDDDRLLLRDRUUDUUURDRULURRLRDLLUURLRDURULDRRUDURRDDLDRLDRUUDRLLUDLRRU"
        };

        static void Main(string[] args)
        {
            char startingChar = '5';

            Console.WriteLine("(Normal Input) Code is: " + NormalInputSolver.Solve(GAME_INPUT, startingChar));
            Console.WriteLine("(Weird Input) Code is: " + WeirdInputSolver.Solve(GAME_INPUT, startingChar));
            Console.ReadKey();
        }
    }

    public class WeirdInputSolver
    {
        private static readonly char[,] keypad = {
            { '#', '#', '1', '#', '#' },
            { '#', '2', '3', '4', '#' },
            { '5', '6', '7', '8', '9' },
            { '#', 'A', 'B', 'C', '#' },
            { '#', '#', 'D', '#', '#' },
        };

        private static int currentPositionX = 0;
        private static int currentPositionY = 0;

        public static string Solve(string[] input, char start)
        {
            char currentChar = start;
            string code = "";

            SetCurrentPosition(start);

            foreach (string inputToFind in input)
            {
                foreach (char charInInput in inputToFind)
                {
                    currentChar = Step(charInInput);
                }

                code += currentChar;
            }

            return code;
        }

        private static char Step(char moveDirection)
        {
            int newX = currentPositionX;
            int newY = currentPositionY;

            switch (moveDirection)
            {
                case 'U':
                    if ((newY - 1) >= 0 && keypad[newY - 1, newX] != '#')
                    {
                        currentPositionY -= 1;
                    }
                    break;
                case 'D':
                    if ((newY + 1) < keypad.GetLength(0) && keypad[newY + 1, newX] != '#')
                    {
                        currentPositionY += 1;
                    }
                    break;
                case 'L':
                    if ((newX - 1) >= 0 && keypad[newY, newX - 1] != '#')
                    {
                        currentPositionX -= 1;
                    }
                    break;
                case 'R':
                    if ((newX + 1) < keypad.GetLength(1) && keypad[newY, newX + 1] != '#')
                    {
                        currentPositionX += 1;
                    }
                    break;
            }

            return keypad[currentPositionY, currentPositionX];
        }

        private static void SetCurrentPosition(char charToFind)
        {
            bool isFound = false;

            for(int y = 0; y < keypad.GetLength(0); y++)
            {
                for(int x = 0; x < keypad.GetLength(1); x++)
                {
                    if(keypad[y,x] == charToFind)
                    {
                        currentPositionX = x;
                        currentPositionY = y;
                        isFound = true;
                        break;
                    }
                }

                if(isFound)
                {
                    break;
                }
            }
        }
    }

    public class NormalInputSolver
    {
        public static string Solve(string[] input, char start)
        {
            int currentNumber = int.Parse(start.ToString());
            string code = "";

            foreach (string inputToFind in input)
            {
                foreach (char charInInput in inputToFind)
                {
                    currentNumber = Step(currentNumber, charInInput);
                }

                code += currentNumber.ToString();
            }

            return code;
        }

        private static int Step(int currentNumber, char moveDirection)
        {
            int foundNumber = currentNumber;
            int currentRow = 0;
            int currentColumn = 0;

            // Expensive - Meh, this is not the best way to do it ;)
            currentRow = (int)Math.Ceiling((double)foundNumber / 3);
            currentColumn = (foundNumber % 3);
            if (currentColumn == 0)
            {
                currentColumn = 3; // Just so its consistent with row.
            }

            switch (moveDirection)
            {
                case 'U':
                    if (currentRow != 1)
                    {
                        foundNumber -= 3;
                    }
                    break;
                case 'D':
                    if (currentRow != 3)
                    {
                        foundNumber += 3;
                    }
                    break;
                case 'L':
                    if (currentColumn != 1)
                    {
                        foundNumber -= 1;
                    }
                    break;
                case 'R':
                    if (currentColumn != 3)
                    {
                        foundNumber += 1;
                    }
                    break;
            }

            return foundNumber;
        }
    }
}
