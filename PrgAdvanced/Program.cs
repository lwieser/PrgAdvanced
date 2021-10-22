using System;
using System.Collections.Generic;

namespace PrgAdvanced
{
    class Program
    {
        private static List<string> _operators = new List<string>()
        {
            "+","*","-","/"
        };

        public enum EntryType
        {
            Value,
            Operator
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans la calculatrice !");
            var key = "";
            var total = 0;
            var currentOperator = "";
            EntryType currentEntryType = EntryType.Operator;
            do
            {
                var message = $"Veuillez saisir {(currentEntryType == EntryType.Value ? "un opérateur" : "une valeur")}";
                Console.WriteLine(message);
                key = Console.ReadLine();
                if (currentEntryType == EntryType.Value)
                {
                    var trimed = key.Trim();
                    if (_operators.Contains(trimed))
                    {
                        currentOperator = trimed;
                        currentEntryType = EntryType.Operator;
                    }
                }
                else
                {
                    if (int.TryParse(key, out var intValue))
                    {
                        if (String.IsNullOrEmpty(currentOperator))
                        {
                            total = intValue;
                        }
                        else
                        {
                            switch (currentOperator)
                            {
                                case "+":
                                    total += intValue;
                                    break;
                                case "*":
                                    total *= intValue;
                                    break;
                                case "-":
                                    total -= intValue;
                                    break;
                                case "/":
                                    if (intValue == 0)
                                    {
                                        Console.WriteLine("Division par 0 impossible");
                                    }
                                    else
                                    {
                                        total /= intValue;
                                    }
                                    break;
                            }
                        }
                        currentEntryType = EntryType.Value;
                        Console.WriteLine($"Résultat actuel : {total}");
                    }
                }

            } while (!key.Equals("Bye", StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
