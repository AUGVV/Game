using System;
using System.Linq;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var Rules = new Rules(args);
            var Help = new Help(Rules.ResultTable, args);
            var KeyGen = new KeyGenerator();
            var StepGen = new StepGenerator();
            var Hmac = new HMAC();
            
            string UserMove;
            int UserChoise;

            if (args.Length >= 3 && args.Length%2!=0)
            {
                if (args.Distinct().Count() != args.Count())
                {
                    Console.WriteLine("Duplicate values! Check the names of the moves");
                    Close();
                }
                while (true)
                {
                    Console.WriteLine(Hmac.GiveHmac(KeyGen.GiveKey(), args[StepGen.GivePcStep(args.Length)]));              
                    Console.WriteLine("Available moves:");
                    for(int i=0; i< args.Length; i++)
                    {
                        Console.WriteLine($" {i+1} - {args[i]}");
                    }
                    Console.WriteLine(" 0 - exit");
                    Console.WriteLine(" ? - Help");
                    Console.Write("Enter your move: ");
                    UserMove = Console.ReadLine().ToString();
                    UserChoise=-1;
                    if(UserMove == "?")
                    {
                        Help.ShowHelp();
                    }              
                    else if(int.TryParse(UserMove, out UserChoise)==true)
                    {
                        if (UserChoise > 0 && UserChoise < args.Length+1)
                        {
                            Console.WriteLine($"Your move: {args[UserChoise-1]}");
                            Console.WriteLine($"Computer move: {args[StepGen.StepResult]}");
                            Console.WriteLine($"{Rules.GiveWinner(UserChoise - 1, StepGen.StepResult)}");
                            Console.WriteLine($"HMAC key: {KeyGen.Key}");
                        }
                        else if (UserChoise == 0)
                        {
                            Close();
                        }
                        else
                        {
                            ShowError();
                        }
                    }
                    else
                    {
                        ShowError();
                    }
                    Console.WriteLine("[Press any button]");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("!! Wrong count of moves, pls typing in args equal 3 words or more, but an odd number of words !!");
                Console.WriteLine("----------------------------");
                Close();
            }
            Console.Read();
        }

        static void Close()
        {
            Console.Read();
            Environment.Exit(0);
        }
        static void  ShowError()
        {
            Console.WriteLine("Values are not correct, pls type correct values");
        }
    }
}
