using System;
using System.Threading;

public class SlotMachine
{
    public int Balance { get; private set; } = 100;
    private string[] symbols = { "🍒", "🍋", "🍊", "🔔", "⭐", "7️⃣" };
    private Random rand = new Random();

    public void Play()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("🎰 Slot Machine!");
        Console.WriteLine("Each spin costs $1. Match 3 symbols to win!\n");

        while (Balance > 0)
        {
            Console.WriteLine($"Balance: ${Balance}");
            Console.Write("Press [Enter] to spin, or 'q' to quit: ");
            string input = Console.ReadLine()!.Trim().ToLower();
            if (input == "q") break;

            Balance--;

            string[] result = Spin();
            Console.WriteLine($"| {result[0]} | {result[1]} | {result[2]} |");

            int win = Evaluate(result);
            if (win > 0)
            {
                Balance += win;
                Console.WriteLine($"🎉 You won ${win}!\n");
            }
            else
            {
                Console.WriteLine("❌ No win.\n");
            }
        }

        Console.WriteLine($"Game over. Final balance: ${Balance}");
    }

    private string[] Spin()
    {
        string[] result = new string[3];
        for (int i = 0; i < 3; i++)
            result[i] = symbols[rand.Next(symbols.Length)];
        Thread.Sleep(300);
        return result;
    }

    private int Evaluate(string[] r)
    {
        if (r[0] == r[1] && r[1] == r[2])
        {
            switch (r[0])
            {
                case "7️⃣": return 100;
                case "⭐": return 50;
                case "🔔": return 20;
                case "🍊": return 10;
                case "🍋": return 5;
                case "🍒": return 3;
            }
        }
        if (r[0] == r[1] || r[1] == r[2] || r[0] == r[2])
            return 1;
        return 0;
    }
}