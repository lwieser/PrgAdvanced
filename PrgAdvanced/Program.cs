using System;
using System.Collections.Generic;

namespace PrgAdvanced
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans la calculatrice !");
            var key = "";
            var calculator = new Calculator();
            EntryType currentEntryType = EntryType.Operator;
            do
            {
                var message = $"Veuillez saisir {(calculator.GetExpectedType() == EntryType.Operator ? "un opérateur" : "une valeur")}";
                Console.WriteLine(message);
                key = Console.ReadLine();
                if (calculator.TryAdd(key))
                {
                    DisplayCalculator(calculator);
                }
                else if (key.Trim().Equals("b", StringComparison.CurrentCultureIgnoreCase))
                {
                        calculator.Pop();
                        DisplayCalculator(calculator);
                }
                else
                {
                    Console.WriteLine("Valeur invalide");
                }
                // if (key.Equals("b", StringComparison.InvariantCultureIgnoreCase))
                // {
                //     currentEntryType = EntryType.Operator;
                // }
                // else if (currentEntryType == EntryType.Value)
                // {
                //     var trimed = key.Trim();
                //     if (_operators.Contains(trimed))
                //     {
                //         currentOperator = trimed;
                //         currentEntryType = EntryType.Operator;
                //     }
                // }
                // else
                // {
                //     if (int.TryParse(key, out var intValue))
                //     {
                //         if (String.IsNullOrEmpty(currentOperator))
                //         {
                //             total = intValue;
                //         }
                //         else
                //         {
                //             switch (currentOperator)
                //             {
                //                 case "+":
                //                     total += intValue;
                //                     break;
                //                 case "*":
                //                     total *= intValue;
                //                     break;
                //                 case "-":
                //                     total -= intValue;
                //                     break;
                //                 case "/":
                //                     if (intValue == 0)
                //                     {
                //                         Console.WriteLine("Division par 0 impossible");
                //                     }
                //                     else
                //                     {
                //                         total /= intValue;
                //                     }
                //                     break;
                //             }
                //         }
                //         currentEntryType = EntryType.Value;
                //         Console.WriteLine($"Résultat actuel : {total}");
                //     }
                // }

            } while (!key.Equals("Bye", StringComparison.InvariantCultureIgnoreCase));
        }

        private static void DisplayCalculator(Calculator calculator)
        {
            Console.WriteLine(calculator.GetFormula());
            Console.WriteLine(calculator.GetValue());
        }
    }
}
