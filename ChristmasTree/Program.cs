using System;

namespace ChristmasTree
{
    class Program
    {
        public static void Main(string[] args)
        {
            string horizontalLine = new string('═', 60);
            string version = "v. 1.0.1";
            Console.WriteLine("{0}{1}", Environment.NewLine, horizontalLine);
            Console.WriteLine("══════════════  ChristmasTree.exe - {0}  ══════════════", version);
            Console.WriteLine("{1}{0}", Environment.NewLine, horizontalLine);

            ChristmasTree.InputTreeSize();
        }

    }

    class ChristmasTree
    {
        /// <summary>
        /// Introducing the size of the Christmas tree
        /// </summary>
        public static void InputTreeSize()
        {
            Console.Write("Enter the number of tree branches: ");
            string enteredNumber = Console.ReadLine();

            if (!Int32.TryParse(enteredNumber, out int numberOfBranches) || numberOfBranches <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("{0}The wrong amount of branches was given :({0}", Environment.NewLine);
                Console.ResetColor();
                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey();
                return;
            }

            DrawTree(numberOfBranches);
        }

        /// <summary>
        /// Drawing Christmass tree
        /// </summary>
        private static void DrawTree(int branches)
        {
            /// <summary>
            /// Space between left edge and center of Christmas tree
            /// </summary>
            int starSpaceCount = branches * 2 - 1;
            if (branches == 1)
            {
                starSpaceCount = 2;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            string starSpace = new String(' ', starSpaceCount);
            System.Threading.Thread.Sleep(200);
            Console.WriteLine("{0}{1}☼{0}{1}▲", Environment.NewLine, starSpace);
            Console.ResetColor();

            /// <summary>
            /// Drawing branches of Christmass tree
            /// </summary>
            for (int i = 0; i < branches; i++)
            {
                string slash = "/";
                string backslash = "\\";

                for (int j = 0; j <= i + 1; j++)
                {
                    /// <summary>
                    /// Space between left edge and left border of Christmas tree
                    /// </summary>
                    int leavesSpaceCount = branches * 2 - 2 - j;
                    if (branches == 1)
                    {
                        leavesSpaceCount = 1 - j;
                    }

                    /// <summary>
                    /// Space between borders of Christmas tree
                    /// </summary>
                    int leavesSpaceBetweenCount = j * 2 + 1;

                    if (i > 1)
                    {
                        leavesSpaceCount = leavesSpaceCount - (i - 1);
                        leavesSpaceBetweenCount = leavesSpaceBetweenCount + (i - 2) * 2 + 2;
                    }

                    /// <summary>
                    /// Drawing the connection between the branches
                    /// </summary>
                    string leavesSpace = new String(' ', leavesSpaceCount);
                    string leavesSpaceBetween = new String('_', leavesSpaceBetweenCount);
                    if (j < i + 1)
                    {
                        leavesSpaceBetween = new String(' ', leavesSpaceBetweenCount);
                    }
                    else if (i < branches - 1)
                    {
                        if (i == 0)
                        {
                            leavesSpaceBetween = "_ _";
                        }
                        else
                        {
                            leavesSpaceBetween = new String('_', i) + new String(' ', i * 2 + 1) + new String('_', i);
                        }
                    }

                    /// <summary>
                    /// Drawing Christmas baubles in random places
                    /// </summary>
                    var leavesSpaceBetweenChar = leavesSpaceBetween.ToCharArray();
                    Random random = new Random();
                    for (int k = 0; k < leavesSpaceBetweenChar.Length; k++)
                    {
                        int randomInt = random.Next(leavesSpaceBetweenChar.Length);
                        bool randomBauble = random.Next(100) <= 3 ? true : false;
                        /// <summary>
                        /// The lower the Christmas tree we are, the less chance that k == randomInt,
                        /// but the bigger that randomBauble == true,
                        /// the proportions are more or less equal
                        /// </summary>  
                        if (randomBauble == true || k == randomInt)
                        {
                            if (leavesSpaceBetweenChar[randomInt] != '_')
                            {
                                leavesSpaceBetweenChar[randomInt] = 'o';
                            }
                        }
                    }

                    System.Threading.Thread.Sleep(50);

                    /// <summary>
                    /// Drawing random colors on the baubles
                    /// </summary>
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(leavesSpace);
                    Console.Write(slash);
                    foreach (char bauble in leavesSpaceBetweenChar)
                    {
                        if (bauble == 'o')
                        {
                            Console.ForegroundColor = (ConsoleColor)random.Next(9, 15);
                            Console.Write(bauble);
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                        }
                        else
                        {
                            Console.Write(bauble);
                        }
                    }
                    Console.Write(backslash);
                    Console.WriteLine();
                    Console.ResetColor();
                }

            }

            /// <summary>
            /// Drawing log of Christmass tree
            /// </summary>
            int logSpaceCount = branches + 1;
            if (branches < 4)
            {
                logSpaceCount = branches + 1;
            }
            else if (branches < 6)
            {
                logSpaceCount = branches + 2;
            }
            else
            {
                logSpaceCount = branches * 2 - 3;
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            string logSpace = new String(' ', logSpaceCount);
            System.Threading.Thread.Sleep(100);
            switch (branches)
            {
                case 1:
                    Console.WriteLine("{1}║", Environment.NewLine, logSpace);
                    break;
                case 2:
                    Console.WriteLine("{1}║{0}{1}║", Environment.NewLine, logSpace);
                    break;
                case 3:
                    Console.WriteLine("{1}║ ║{0}{1}╚═╝", Environment.NewLine, logSpace);
                    break;
                case 4:
                    Console.WriteLine("{1}║ ║{0}{1}║ ║{0}{1}╚═╝", Environment.NewLine, logSpace);
                    break;
                case 5:
                    Console.WriteLine("{1}║   ║{0}{1}║   ║{0}{1}╚═══╝", Environment.NewLine, logSpace);
                    break;
                default:
                    Console.WriteLine("{1}║   ║{0}{1}║   ║{0}{1}║   ║{0}{1}╚═══╝", Environment.NewLine, logSpace);
                    break;
            }
            Console.ResetColor();

            System.Threading.Thread.Sleep(200);
            Console.WriteLine("{0}════════════════════════════════════════════════════════════════{0}", Environment.NewLine);


            /// <summary>
            /// Return to introducing the size of the Christmas tree
            /// </summary>
            InputTreeSize();

        }
    }

}
