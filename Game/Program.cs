using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ArgsTest = { "Rock", "Scissor", "Paper" };
            var Rules = new Rules(ArgsTest);
            var Help = new Help(Rules.ResultTable, ArgsTest);
            var KeyGen = new KeyGenerator();
            var StepGen = new StepGenerator();
            var Hmac = new HMAC();
            
            string UserMove;
            int UserChoise;

            if (ArgsTest.Length >= 3)
            {
                while (true)
                {
                    Hmac.GiveHmac(KeyGen.GiveKey(), StepGen.GivePcStep(ArgsTest.Length));
                  
                    Console.WriteLine("Available moves:");
                    for(int i=0; i<ArgsTest.Length; i++)
                    {
                        Console.WriteLine($" {i+1} - {ArgsTest[i]}");
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
                        if (UserChoise > 0 && UserChoise < ArgsTest.Length+1)
                        {
                            Console.WriteLine($"Your move: {ArgsTest[UserChoise-1]}");
                            Console.WriteLine($"Computer move: {ArgsTest[StepGen.StepResult]}");
                            Console.WriteLine($"{Rules.GiveWinner(UserChoise - 1, StepGen.StepResult)}");
                            Console.WriteLine($"HMAC key: {BitConverter.ToString(KeyGen.Key, 0).Replace("-", string.Empty)}");
                        }
                        else if (UserChoise == 0)
                        {
                            Environment.Exit(0);
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
                Console.WriteLine("!! Wrong count of moves, pls typing in args equal 3 words or more !!");
                Console.WriteLine("----------------------------");
            }


            Console.Read();
        }
        static void  ShowError()
        {
            Console.WriteLine("Values are not correct, pls type correct values");
        }
    }
}
