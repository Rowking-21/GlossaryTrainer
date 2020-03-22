using System;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace GlossoryTrainer
{
    public class MainApp
    {
        private static int correctAnswers;
        private static int incorrectAnswers;

        public static void Run(string jsonFile)
        {
            var lexiconFileContent = System.IO.File.ReadAllText(jsonFile, Encoding.UTF8);

            var lexicon = JsonSerializer.Deserialize<Lexicon>(lexiconFileContent);

            var random = new Random();

            var randomCollection = lexicon.LexiconEntries.OrderBy((x) => Guid.NewGuid()).ToList();

            Console.WriteLine("Translate the following words:");
            Console.WriteLine();

            foreach (var lexiconEntry in randomCollection)
            {
                Console.WriteLine(String.Join(", ", lexiconEntry.Language1));
                var result = Console.ReadLine();

                if (lexiconEntry.Language2.Any(word => word.Equals(result)))
                {
                    correctAnswers += 1;
                    PrintConsole($"Correct!", ConsoleColor.Green);
                }
                else
                {
                    incorrectAnswers += 1;
                    var message = "Incorrect, right answer: " + String.Join(", ", lexiconEntry.Language2);
                    PrintConsole(message, ConsoleColor.Red);
                }

                Console.WriteLine($"Score: {correctAnswers}/{correctAnswers + incorrectAnswers}");
                Console.WriteLine();
            }
        }

        private static void PrintConsole(string message, ConsoleColor color)
        {
            var defaultColor = Console.ForegroundColor;
            try
            {
                Console.ForegroundColor = color;
                Console.WriteLine(message);
            }
            finally
            {
                Console.ForegroundColor = defaultColor;
            }
        }
    }
}