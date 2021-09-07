using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Help
    {
        private int[,] ConditionMap { get; set; }
        private string[] Steps { get; set; }

        public Help(int[,] ConditionMap, string[] Steps)
        {
            this.ConditionMap = ConditionMap;
            this.Steps = Steps;
        }

        public void ShowHelp()
        {
            int ShiftCount = 0;
            string ConditionRow = "";
            string UserColumn = $"\nPC \\ User ";

            for (int i = 0; i < Steps.Length; i++)
            {
                UserColumn += $"|  {Steps[i]}  ";
            }
            Console.Write(UserColumn + "|\n");

            for (int i=0; i< Steps.Length; i++)
            {
                DrawLine(UserColumn.Length);
                ShiftCount = 10 - Steps[i].Length;
                Console.Write($"{Steps[i]}");

                for (int z = 0; z < ShiftCount; z++)
                {
                    Console.Write($" ");
                }

                for (int j = 0; j < Steps.Length; j++)
                {
                    if (ConditionMap[i, j] == 2)
                    {
                        ConditionRow = $"|  DRAW";
                    }
                    else if (ConditionMap[i, j] == 1)
                    {
                        ConditionRow = $"|  WIN";
                    }
                    else
                    {
                        ConditionRow = $"|  LOSE";
                    }
                    Console.Write(ConditionRow);
                    for (int z = 0; z < Steps[j].Length - (ConditionRow.Length-5); z++)
                    {
                        Console.Write($" ");
                    }
                }
                Console.Write($"|");
                Console.WriteLine("");
            }
            DrawLine(UserColumn.Length);
        }

        private void DrawLine(int UserColumns)
        {
            for (int z = 0; z < UserColumns; z++)
            {
                Console.Write($"-");    
            }
            Console.WriteLine("");
        }
    }
}
