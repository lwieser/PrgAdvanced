using System;
using System.Collections.Generic;
using System.Linq;

namespace PrgAdvanced
{
    public class Calculator
    {

        private static List<string> _validOperators = new List<string>()
        {
            "+","*","-","/"
        };

        private List<string> _operators = new List<string>();
        private List<int> _values = new List<int>();
        private int _total;
        public Calculator()
        {

        }

        public bool TryAdd(string key)
        {
            var currentOperator = "";
            EntryType expectedType = GetExpectedType();

            if (key.Equals("b", StringComparison.InvariantCultureIgnoreCase))
            {
            }
            else if (expectedType == EntryType.Operator)
            {
                var trimed = key.Trim();
                if (_validOperators.Contains(trimed))
                {
                    _operators.Add(trimed);
                }

                return true;
            }
            else
            {
                if (int.TryParse(key, out var intValue))
                {
                    _values.Add(intValue);
                }
                return true;
            }
            return false;
        }

        public string GetFormula()
        {
            var str = "";
            for (int i = 0; i < _operators.Count; i++)
            {
                str += "(";
            }
            for (var i = 0; i < _values.Count; i++)
            {
                str += $"{_values.ElementAt(i)}";
                if (i > 0)
                {
                    str += ")";
                }
                else
                {
                    str += " ";
                }

                if (_operators.Count > i)
                {
                    var op = _operators.ElementAt(i);
                    str += $"{op} ";
                }
            }

            return str;
        }

        public EntryType GetExpectedType()
        {
            return _operators.Count == _values.Count ? EntryType.Value : EntryType.Operator;
        }
        public int GetValue()
        {
            var total = 0;
            var currentOperator = "";
            for (var i = 0; i < _operators.Count + _values.Count; i++)
            {
                if (i == 0)
                {
                    total = _values.ElementAt(i);
                }
                else
                {
                    if (i % 2 == 0)
                    {
                        var intValue = _values.ElementAt(i / 2);
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
                    else
                    {
                        currentOperator = _operators.ElementAt(i / 2);
                    }
                }
            }

            return total;
        }
    }
}