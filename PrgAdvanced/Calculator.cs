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
            key = key.Replace(" ", "");
            var currentOperator = "";
            var intPoped = 0;
            var success = false;
            do
            {
                EntryType expectedType = GetExpectedType();
                var i = 0;
                if (key.Equals("b", StringComparison.InvariantCultureIgnoreCase))
                {
                }
                else if (expectedType == EntryType.Operator)
                {
                    var trimed = key.Substring(0,1);
                    if (_validOperators.Contains(trimed))
                    {
                        _operators.Add(trimed);
                        intPoped = 1;
                        success = true;
                    }
                }
                else
                {
                    var iteration = 1;
                    var valid = false;
                    var lastSucces = "";
                    var testedKey = "";
                    do
                    {
                        testedKey = key.Substring(0,iteration);
                        valid = int.TryParse(testedKey, out var intValue);
                        if (valid)
                        {
                            lastSucces = testedKey;
                            iteration++;
                        }
                    } while (valid && testedKey.Length < key.Length);

                    if (iteration >= 2)
                    {
                        _values.Add(int.Parse(lastSucces));
                        success = true;
                        intPoped = lastSucces.Length;
                    }

                }

                key = key.Substring(intPoped);
            } while (intPoped > 0 && !String.IsNullOrEmpty(key));

            return success;
        }

        public void Pop()
        {
            if (_operators.Count == 0 && _values.Count == 0) return;

            if (_operators.Count >= _values.Count)
            {
                _operators.RemoveAt(_operators.Count - 1);
            }
            else
            {
                _values.RemoveAt(_values.Count - 1);
            }
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