using System;
using System.Collections.Generic;
using System.Linq;

namespace CalcModels
{
    /// <summary>
    /// Standardized names of operations in the calculator
    /// </summary>
    public enum TypeOperation
    {
        None, Addition, Subtraction, Multiplication, Division, Equally, ClearAll
    }

    /// <summary>
    /// Static class which stored operation symbols and their actions
    /// </summary>
    public static class CalcSymbol
    {
        /// <summary>
        /// Structure for stored of operation symbol and their action
        /// </summary>
        public struct Oper
        {
            public string Symbol { get; set; }
            public Func<double, double, double> Calc { get; set; }
        }

        /// <summary>
        /// Standardized names of operations in the calculator and their operation symbol and action
        /// </summary>
        public static Dictionary<TypeOperation, Oper> Operation
        {
            get => new Dictionary<TypeOperation, Oper>
            {
                { TypeOperation.None, new Oper{ Symbol = "", Calc = null} },
                { TypeOperation.Addition, new Oper{ Symbol = "+", Calc = (a, b) => a + b} },
                { TypeOperation.Subtraction, new Oper{ Symbol = "-", Calc = (a, b) => a - b} },
                { TypeOperation.Multiplication, new Oper{ Symbol = "*", Calc = (a, b) => a * b} },
                { TypeOperation.Division, new Oper{ Symbol = "/",
                    Calc = (a, b) => {
                        if (b == 0) throw new DivideByZeroException(); 
                        else return a / b;
                    } }
                },
                { TypeOperation.Equally, new Oper{ Symbol = "=", Calc = null } },
                { TypeOperation.ClearAll, new Oper{ Symbol = "CE", Calc = null} }
            };
        }

        /// <summary>
        /// Transformation of operation symbol into one of the elements of TypeOperation
        /// </summary>
        /// <param name="arg">Symbol of the operation</param>
        /// <returns>Standardized names of operations in the calculator (TypeOperation) in the form of string</returns>
        public static string TransformationArg(string arg)
        {
            IEnumerable<TypeOperation> k = Operation.Where(n => n.Value.Symbol == arg).Select(n => n.Key);

            var z = k.GetEnumerator();
            z.MoveNext();

            return z.Current.ToString();
        }
    }
}
