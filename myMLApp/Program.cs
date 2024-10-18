using MyMLApp;
#nullable disable

internal class Program
{
    private static void Main(string[] args)
    {
        // Skapa en instans av klassen och kör programmet
        MyMLAppGame app = new();
        app.Run();
    }
}

class MyMLAppGame
{
    bool running = true;

    public void Run()
    {
        while (running)
        {
            Console.Clear();
            Console.WriteLine("P O S I T I V E  or  N E G A T I V E  by Philip Telberg©");
            Console.WriteLine("\nChoose a option: ");
            Console.WriteLine("\n1: Write feedback");
            Console.WriteLine("2: Quit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Please enter your feedback:");
                    string feedBack = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(feedBack))
                    {
                        Console.WriteLine("Error: Feedback cannot be empty.");
                    }
                    else
                    {
                        // Variabel för att lagra input för modellen
                        string Col0 = feedBack;

                        // Skapa inputdata för ML-modellen
                        var sampleData = new SentimentModel.ModelInput() { Col0 = Col0 };

                        // Gör en prediktion med ML-modellen
                        var result = SentimentModel.Predict(sampleData);
                        var sentiment = result.PredictedLabel == 1 ? "positive" : "negative";

                        Console.WriteLine($"\nReview: {sampleData.Col0}\nThis review is {sentiment}");
                    }

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;

                case "2":
                    running = false;
                    Console.WriteLine("Programmet avslutas.");
                    break;

                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }
    }
}
