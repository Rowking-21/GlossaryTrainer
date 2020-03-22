using System;

namespace GlossoryTrainer
{
    public class Program
    {
        private static readonly string jsonFile = @"TestData/LexiconTest.json";

        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                MainApp.Run(jsonFile);
            }
            else
            {
                foreach (var arg in args)
                {
                    if (arg.EndsWith(".json"))
                    {
                        MainApp.Run(arg);
                    }
                }
            }
        }
    }
}
