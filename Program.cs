using System;
using System.Data;

namespace GPTAgentCreations
{
    class Program
    {
        static void EvaluateAndPrint(string expr)
        {
            try
            {
                var dt = new DataTable();
                object result = dt.Compute(expr, "");
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string expr = string.Join(" ", args);
                EvaluateAndPrint(expr);
                return;
            }

            Console.WriteLine("Simple Calculator. Type 'quit' to exit.");
            while (true)
            {
                Console.Write("> ");
                string? input = Console.ReadLine();
                if (input == null)
                    continue;
                var trimmed = input.Trim();
                if (trimmed.Equals("quit", StringComparison.OrdinalIgnoreCase) ||
                    trimmed.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;
                if (string.IsNullOrWhiteSpace(trimmed))
                    continue;
                EvaluateAndPrint(trimmed);
            }
        }
    }
}

